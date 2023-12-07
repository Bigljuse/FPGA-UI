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
            typeof(int),
            typeof(Button),
            new UIPropertyMetadata(0, new PropertyChangedCallback(StatePropertyChanged)));

        public int State
        {
            get => (int)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        protected static void StatePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            Button toggleButton = (Button)dependencyObject;
            int state = (int)args.NewValue;

            if (state == 1)
                toggleButton.Ellipse_State.Fill = Brushes.LightGray;
            else
                toggleButton.Ellipse_State.Fill = Brushes.Black;
        }
    }
}
