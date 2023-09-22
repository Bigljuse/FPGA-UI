﻿using FPGA_UI.FPGA_communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FPGA_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Change_Colour_Click(object sender, RoutedEventArgs e)
        {
            SerialPortController serialPortController = new SerialPortController();
            string[] portsNames = new string[2] { "Haaha", "VLados"};

            string text = String.Empty;

            for (int i = 0; i < portsNames.Count(); i++)
            {
                string portName = portsNames[i];
                text += portName;
            }

            text = string.Empty;

            foreach (string portName in portsNames)
            {
                text += portName;
            }

            MessageBox.Show(text);
        }
    }
}
