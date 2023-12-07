using MySqlLibrary.MySql.Models;
using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Button : IFPGATable
    {
        public UInt32 Id { get; set; }

        public int State { get; set; } = 0;

        public string Mark { get; set; } = "Empty";

        public int Device_Id { get; set; } = 0;
    }
}
