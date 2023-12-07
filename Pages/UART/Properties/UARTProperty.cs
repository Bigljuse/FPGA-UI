using FPGA_UI.DataBases.FPGA.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FPGA_UI.Pages
{
    public partial class Page_UART
    {
        public static readonly DependencyProperty UARTProperty = DependencyProperty.Register(
            nameof(UART),
            typeof(UART),
            typeof(Page_UART),
            new UIPropertyMetadata(new UART()));

        public UART UART
        {
            get => (UART)GetValue(UARTProperty);
            set => SetValue(UARTProperty, value);
        }
    }
}
