using FPGA_UI.DataBases.FPGA.Tables;
using FPGA_UI.Elements.FPGA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FPGA_UI.Pages
{
    public partial class Elements_Page
    {
        public static readonly DependencyProperty TogglesProperty = DependencyProperty.Register(
            nameof(Toggles),
            typeof(List<Toggle>),
            typeof(Elements_Page),
            new UIPropertyMetadata(new List<Toggle>()));

        public List<Toggle> Toggles
        {
            get => (List<Toggle>)GetValue(TogglesProperty);
            set => SetValue(TogglesProperty, value);
        }
    }
}
