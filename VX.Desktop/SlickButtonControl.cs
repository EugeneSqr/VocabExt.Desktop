//-------------------------------------------------------------------------------------
// Author:   Murray Foxcroft - April 2009
// Comments: A simple class that Inherits from ToggleButton and adds a few properties.
//           These properties are used to pass values to a control template and add 
//           some flexibility to allow for re-use of the control templates. See 
//           SlickButtonRD.xaml. 
//-------------------------------------------------------------------------------------

using System.Windows.Controls.Primitives;

namespace VX.Desktop
{
    public class SlickToggleButton : ToggleButton
    {
        // Property to hold a Corner Radius (button's dont have this property)
        public string CornerRadius { get; set; }

        // Property to hold the colour for the background highlighting (on mouse over)
        public string HighlightBackground { get; set; }

        // Property to hold the background colour applied when the button is in the pressed state
        public string PressedBackground { get; set; }
    }
}
