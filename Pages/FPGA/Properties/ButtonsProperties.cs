using FPGA_UI.DataBases.FPGA.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FPGA_UI.Pages
{
    public partial class Elements_Page
    {
        public static readonly DependencyProperty ButtonsProperty = DependencyProperty.Register(
            nameof(Buttons),
            typeof(List<Button>),
            typeof(Elements_Page),
            new UIPropertyMetadata(new List<Button>()));

        public List<Button> Buttons
        {
            get => (List<Button>)GetValue(ButtonsProperty);
            set => SetValue(ButtonsProperty, value);
        }
    }
}
