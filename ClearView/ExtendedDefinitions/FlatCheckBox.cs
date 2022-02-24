using System.Windows;
using System.Windows.Controls;

namespace BosonStation.ExtendedDefinitions
{
    public    class FlatCheckBox:CheckBox
    {
        public FlatCheckBox()
        {
            Style = this.FindResource("FlatCheckbox") as Style;
        }
    }
}
