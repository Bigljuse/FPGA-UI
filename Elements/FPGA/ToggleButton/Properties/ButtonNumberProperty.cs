using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FPGA_UI.Elements.FPGA
{
    public partial class ToggleButton
    {
        public static readonly DependencyProperty ButtonNumberProperty = DependencyProperty.Register(
            nameof(ButtonNumber),
            typeof(int),
            typeof(ToggleButton),
            new UIPropertyMetadata(0));

        public int ButtonNumber
        {
            get => (int)GetValue(ButtonNumberProperty);
            set => SetValue(ButtonNumberProperty, value);
        }
    }
}
