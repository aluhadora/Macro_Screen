using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Replacement_for_Macros.Utilities;

namespace Replacement_for_Macros.Controls.Authenticator
{
  public partial class AuthenticatorWidget : UserControl, IControlBase
  {
    private Authenticator _authenticator;

    public AuthenticatorWidget()
    {
      InitializeComponent();
      
      MovementUtility.SetupControl(this);
    }

    public string ConfigFile { get; set; }

		/// <summary>
		/// Load an old or 3rd party authenticator file
		/// </summary>
		/// <param name="configFile">filename to load</param>
		/// <returns>new Authenticator object</returns>
		public static Authenticator LoadAuthenticator(string configFile)
		{
      var doc = new XmlDocument();
      doc.Load(configFile);
		  if (doc.DocumentElement == null) return null;
		  
      XmlNodeList nodes = doc.DocumentElement.SelectNodes("authenticator");

		  if (nodes == null) return null;
		  
      foreach (XmlNode authenticatorNode in nodes)
		  {
		    var auth = new Authenticator();
		    auth.Load(authenticatorNode, null);
		    return auth;
		  }

		  return null;
		}


    private void AuthenticatorWidget_Load(object sender, EventArgs e)
    {
      return;
      if (DesignMode) return;
      if (ConfigFile == null) return;
      if (ConfigFile == string.Empty) return;
      _authenticator = LoadAuthenticator(ConfigFile);


      var timer = new Timer { Interval = 100 };
      timer.Tick += Tick;
      
      timer.Start();
    }

    private void Tick(object sender, EventArgs e)
    {
      textBox.Text = _authenticator.CurrentCode;

      var tillUpdate = (int)((_authenticator.ServerTime % 30000L) / 1000L);
      progressBar.Value = tillUpdate;
    }

    private void AuthenticatorClick(object sender, EventArgs e)
    {
      Clipboard.SetText(_authenticator.CurrentCode);
    }

    bool IControlBase.EditMode { get; set; }
    bool IControlBase._moving { get; set; }
    Point IControlBase._previousLocation { get; set; }
  }
}
