using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGA_UI.FPGA_communication
{
    internal class SerialPortController
    {
        internal string[] Hello_Method()
        {
            string[] portNames = SerialPort.GetPortNames();
            return portNames;
        }
    }
}
