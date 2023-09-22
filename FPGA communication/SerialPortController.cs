using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FPGA_UI.FPGA_communication
{
    internal class SerialPortController
    {
        internal string[] Hello_Method()
        {
            ///////////////
            // https://learn.microsoft.com/ru-ru/windows/win32/cimwin32prov/computer-system-hardware-classes?redirectedfrom=MSDN
            ///////////////
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            ManagementObjectCollection usbQueryCollection = managementObjectSearcher.Get();

            List<string> usbStrings = new List<string>();

            foreach(var obj in usbQueryCollection)
            {
                usbStrings.Add(obj.ToString());
            }

            return new string[2];
        }
    }
}
