using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Bluetooth : IFPGATableColumn
    {
        public int Id { get; set; } = 0;

        public bool Connectioned_To_Device { get; set; } = false;

        public string Mac_Address { get; set; } = "Empty";

        public int Device_Id { get; set; } = 0;

        public Type GetTypeOfColumn()
        {
            return this.GetType();
        }
    }
}
