using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FPGA_UI.Elements
{
    public partial class UserProfile : UserControl
    {
        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
            nameof(UserName),
            typeof(string),
            typeof(UserProfile),
            new UIPropertyMetadata("None"));

        public string UserName
        {
            get => (string)GetValue(UserNameProperty);
            set => SetValue(UserNameProperty, value);
        }
    }
}
