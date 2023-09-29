using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Button : IFPGATableColumn
    {
        public int Id { get; set; } = 0;

        public bool State { get; set; } = false;

        public string Mark { get; set; } = "Empty";

        public int Device_Id { get; set; } = 0;

        public Type GetTypeOfColumn()
        {
            return this.GetType();
        }
    }
}
