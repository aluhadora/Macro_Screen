using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Replacement_for_Macros.Controls;
using Replacement_for_Macros.Controls.Authenticator;
using Replacement_for_Macros.Controls.BNetStatus;
using Replacement_for_Macros.Utilities;

namespace Replacement_for_Macros
{
  public class DefinitionProcessor
  {
    private XmlWriter _xw;

    public void LoadDefinition(Action<Control> addControl, ToolTip tooltip)
    {
      var defintion = File.ReadAllText("Config.xml");

      XmlReader xr = new XmlTextReader(new StringReader(defintion));

      AddControlsFromXML(addControl, tooltip, xr);
    }

    private void AddControlsFromXML(Action<Control> addControl, ToolTip tooltip, XmlReader xr)
    {
      while (xr.Read())
      {
        if (!xr.IsStartElement()) continue;
        if (xr.Name != "Control") continue;

        var control = GetControl(xr.GetAttribute("Type"));
        control.Left = xr.GetAttribute("X").ToInt();
        control.Top = xr.GetAttribute("Y").ToInt();
        control.Width = xr.GetAttribute("Width").ToInt();
        control.Height = xr.GetAttribute("Height").ToInt();

        var subReader = xr.ReadSubtree();
        while (subReader.Read())
        {
          if (!subReader.IsStartElement()) continue;
          if (subReader.Name == "Process")
            PopulateProcessButton(control, subReader, tooltip);
          if (subReader.Name == "Image")
            SetImageForButton(control, subReader.GetAttribute("Image"));
          if (subReader.Name == "Authenticator")
            PopulateAuthenticator(control, subReader);
        }

        addControl(control);
      }
    }

    private void PopulateAuthenticator(Control control, XmlReader reader)
    {
      var widget = control as AuthenticatorWidget;
      if (widget == null) return;

      widget.ConfigFile = reader.GetAttribute("ConfigFile");
    }

    private void SetImageForButton(Control control, string imageString)
    {
      var button = control as ProcessButton;
      if (button == null) return;

      button.UseVisualStyleBackColor = true;
      if (imageString == string.Empty) return;
      button.BackgroundImage = FromImageString(imageString);
      button.BackgroundImageLayout = ImageLayout.Stretch;
     }

    private void PopulateProcessButton(Control control, XmlReader reader, ToolTip tooltip)
    {
      var button = control as ProcessButton;
      if (button == null) return;

      button.ProcessToStart = reader.GetAttribute("Path");
      button.ProcessArguments = reader.GetAttribute("Arguments");
      tooltip.SetToolTip(button, reader.GetAttribute("Tooltip"));
      button.SetTooltip = x => tooltip.SetToolTip(control, x);
      button.GetTooltip = () => tooltip.GetToolTip(control);
    }

    private Control GetControl(string typeName)
    {
      if (typeName == "ProcessButton") return new ProcessButton();
      if (typeName == "BNetStatus") return new BNetStatus();
      if (typeName == "AuthenticatorWidget") return new AuthenticatorWidget();
      if (typeName == "Magnifier") return new Magnifier();
      return null;
    }

    public void WriteDefinition(Control.ControlCollection controls, Func<Control, string> getToolTip)
    {
      var definition = GetDefinition(controls, getToolTip);

      File.WriteAllText("Config.xml", definition);
    }

    public string GetDefinition(Control.ControlCollection controls, Func<Control, string> getToolTip)
    {
      var definition = new StringBuilder();
      var settings = new XmlWriterSettings { Indent = true, NewLineOnAttributes = false };

      _xw = XmlWriter.Create(new StringWriter(definition), settings);

      _xw.WriteStartDocument();
      _xw.WriteStartElement("Controls");

      foreach (Control control in controls)
      {
        if (control.Name == "exitButton") continue;
        if (control.Name == "editButton") continue;
        WriteControl(getToolTip, control);
      }

      _xw.WriteEndElement();
      _xw.WriteEndDocument();

      _xw.Close();

      return definition.ToString();
    }

    private void WriteControl(Func<Control, string> getToolTip, Control control)
    {
      _xw.WriteStartElement("Control");

      WriteAttribute("Type", control.GetType().Name);
      WriteAttribute("X", control.Left);
      WriteAttribute("Y", control.Top);
      WriteAttribute("Width", control.Width);
      WriteAttribute("Height", control.Height);

      WriteProcessButton(getToolTip, control);
      WriteAuthenticatorWidget(control);

      _xw.WriteEndElement();
    }

    private void WriteAuthenticatorWidget(Control control)
    {
      var widget = control as AuthenticatorWidget;
      if (widget == null) return;

      _xw.WriteStartElement("Authenticator");

      WriteAttribute("ConfigFile", widget.ConfigFile ?? string.Empty);

      _xw.WriteEndElement();
    }

    private void WriteProcessButton(Func<Control, string> getToolTip, Control control)
    {
      var button = control as ProcessButton;
      if (button == null) return;

      _xw.WriteStartElement("Process");

      WriteAttribute("Path", button.ProcessToStart ?? string.Empty);
      if (!string.IsNullOrEmpty(button.ProcessArguments)) WriteAttribute("Arguments", button.ProcessArguments);

      WriteAttribute("Tooltip", getToolTip(button));

      _xw.WriteEndElement();

      _xw.WriteStartElement("Image");

      WriteAttribute("Image", GetImageString(button.BackgroundImage));

      _xw.WriteEndElement();
    }

    private string GetImageString(Image image)
    {
      if (image == null) return string.Empty;

      var bufferImage = new Bitmap(image);
      var ms = new MemoryStream();
      bufferImage.Save(ms, image.RawFormat);
      bufferImage.Dispose();
      return Convert.ToBase64String(ms.ToArray());
    }

    private Image FromImageString(string value)
    {
      if (string.IsNullOrEmpty(value)) return null;
      byte[] data = Convert.FromBase64String(value);
      using (var stream = new MemoryStream(data, 0, data.Length))
      {
        return Image.FromStream(stream);
      }
    }

    private void WriteAttribute(string attribute, object value)
    {
      _xw.WriteStartAttribute(attribute);
      _xw.WriteValue(value);
      _xw.WriteEndAttribute();
    }
  }
}
