using System;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;

namespace Replacement_for_Macros.Controls.BNetStatus
{
  public class BnetStatusProcess
  {
    private static Action<Image> _setImage;
    private WebClient _web;
    
    private BnetStatusProcess(Action<Image> setImage)
    {
      _setImage = setImage;
    }

    public static void Go(Action<Image> setImage)
    {
      var instance = new BnetStatusProcess(setImage);
      new Action(instance.Go).BeginInvoke(null, null);
    }

    public void Go()
    {
      _web = new WebClient();

      _setImage(BNetUp() ? Properties.Resources.Circle_Green : Properties.Resources.Circle_Red);
    }

    private bool BNetUp()
    {
      try
      {
        string source = _web.DownloadString(@"http://www.teamliquid.net/forum/viewmessage.php?topic_id=138846");
        string title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;

        return !title.Contains("US: Down");
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
