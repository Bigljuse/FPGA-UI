using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;

namespace FPGA_UI.Elements.FPGA
{
    public partial class ToggleButton
    {
        public static readonly DependencyProperty ToggleStateProperty = DependencyProperty.Register(
            nameof(ToggleState),
            typeof(bool),
            typeof(ToggleButton),
            new UIPropertyMetadata(false, new PropertyChangedCallback(ToggleStatePropertyChanged)));

        public bool ToggleState
        {
            get => (bool)GetValue(ToggleStateProperty);
            set => SetValue(ToggleStateProperty, value);
        }

        protected static void ToggleStatePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            ToggleButton toggleButton = (ToggleButton)dependencyObject;
            bool toggleState = (bool)args.NewValue;

            if (toggleState == true)
                toggleButton.Rectangle_BlackToggle.Margin = new Thickness(0,40,0,0);
            else
                toggleButton.Rectangle_BlackToggle.Margin = new Thickness(0,10,0,0);
        }
    }
}
