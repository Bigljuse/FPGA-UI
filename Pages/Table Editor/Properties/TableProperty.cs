using FPGA_UI.DataBases.FPGA.Enums;
using FPGA_UI.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FPGA_UI.Pages
{
    public partial class Page_Table_Editor
    {
        public static readonly DependencyProperty TableProperty = DependencyProperty.Register(
            nameof(Table),
            typeof(FPGATables),
            typeof(Page_Table_Editor),
            new UIPropertyMetadata(FPGATables.Port));

        public FPGATables Table
        {
            get => (FPGATables)GetValue(TableProperty);
            set => SetValue(TableProperty, value);
        }
    }
}
