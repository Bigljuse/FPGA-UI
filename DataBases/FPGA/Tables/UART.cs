using MySqlLibrary.MySql.Models;
using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class UART : IFPGATable
    {
        public UInt32 Id { get; set; }

        public int Baud { get; set; } = 9600;

        public int Start_Bit { get; set; } = 1;

        public int Stop_Bit { get; set; } = 1;

        public int Hand_Shake { get; set; } = 0;

        public int Package_Size { get; set; } = 8;
    }
}
