using MySqlLibrary.MySql.Models;
using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Device : IFPGATable
    {
        public UInt32 Id { get; set; }

        public int Address { get; set; } = 0;

        public int Memory_Address { get; set; } = 0;

        public int Memory_Size { get; set; } = 0;

        public int Port_Type_Id { get; set; } = 0;
    }
}
