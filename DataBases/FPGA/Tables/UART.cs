using MySqlLibrary.MySql.Models;
using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class UART : IFPGATable
    {
        public UInt32 Id { get; set; }

        public int Baud { get; set; } = 9600;

        public bool Start_Bit { get; set; } = true;

        public bool Stop_Bit { get; set; } = true;

        public bool Hand_Shake { get; set; } = false;

        public int Package_Size { get; set; } = 8;
    }
}
