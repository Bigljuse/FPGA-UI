using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Toggle : IFPGATableColumn
    {
        public int Id { get; set; } = 0;

        public string Mark { get; set; } = "Empty";

        public bool Toggled { get; set; } = false;

        public int Device_Id { get; set; } = 0;

        public Type GetTypeOfColumn()
        {
            return this.GetType();
        }
    }
}
