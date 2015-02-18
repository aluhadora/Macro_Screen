using System.Drawing;

namespace Replacement_for_Macros.Controls
{
  public interface IControlBase
  {
    bool EditMode { get; set; }

    bool _moving { get; set; }
    Point _previousLocation { get; set; }
  }
}