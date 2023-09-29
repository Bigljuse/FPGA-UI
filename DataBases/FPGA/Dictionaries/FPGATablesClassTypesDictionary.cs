using FPGA_UI.DataBases.FPGA.Tables;
using System;
using System.Collections.Generic;

namespace FPGA_UI.DataBases.FPGA
{
    internal static class FPGATablesClassTypesDictionary
    {
        public static Dictionary<FPGATablesEnum, Type> TablesTypesDictionary = new Dictionary<FPGATablesEnum, Type>()
        {
            { FPGATablesEnum.Bluetooth, typeof(Bluetooth) },
            { FPGATablesEnum.Button, typeof(Button) },
            { FPGATablesEnum.Device, typeof(Device) },
            { FPGATablesEnum.Port, typeof(Port) },
            { FPGATablesEnum.Temperature_Module, typeof(Temperature_Module) },
            { FPGATablesEnum.Toggle, typeof(Toggle) },
            { FPGATablesEnum.UART, typeof(UART) }
        };
    }
}
