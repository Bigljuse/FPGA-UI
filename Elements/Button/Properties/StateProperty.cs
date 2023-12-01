using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FPGA_UI.Elements.FPGA
{
    public partial class Button
    {
        public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
            nameof(State),
            typeof(bool),
            typeof(Button),
            new UIPropertyMetadata(false, new PropertyChangedCallback(StatePropertyChanged)));

        public bool State
        {
            get => (bool)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        protected static void StatePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Button toggleButton = (Button)dependencyObject;
            bool state = (bool)args.NewValue;

            if (state == true)
                toggleButton.Ellipse_State.Fill = Brushes.LightGray;
            else
                toggleButton.Ellipse_State.Fill = Brushes.Black;
        }
    }
}
