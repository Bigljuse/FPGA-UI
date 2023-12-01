using MySqlLibrary.MySql.Models;
using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Bluetooth : IFPGATable
    {
        public UInt32 Id { get; set; }

        public bool Connectioned_To_Device { get; set; } = false;

        public string Mac_Address { get; set; } = "Empty";

        public int Device_Id { get; set; } = 0;
    }
}
