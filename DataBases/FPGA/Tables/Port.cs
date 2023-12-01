using MySqlLibrary.MySql.Models;
using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Port : IFPGATable
    {
        public UInt32 Id { get; set; }

        public string Mark { get; set; } = "Empty";

        public object Device_Type { get; set; } = "Empty";

        public object Power_State { get; set; } = false;
    }
}
