using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Port : IFPGATableColumn
    {
        public int Id { get; set; } = 0;

        public string Mark { get; set; } = "Empty";

        public string Device_Type { get; set; } = "Empty";

        public bool Power_State { get; set; } = false;

        public Type GetTypeOfColumn()
        {
            return this.GetType();
        }
    }
}
