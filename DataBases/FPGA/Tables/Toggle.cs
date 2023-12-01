using MySqlLibrary.MySql.Models;
using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Toggle : IFPGATable
    {
        public UInt32 Id { get; set; }

        public string Mark { get; set; } = "Empty";

        public bool Toggled { get; set; } = false;

        public int Device_Id { get; set; } = 0;
    }
}
