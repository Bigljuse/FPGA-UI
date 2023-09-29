using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class UART : IFPGATableColumn
    {
        public int Id { get; set; } = 0;

        public int Baud { get; set; } = 9600;

        public bool Start_Bit { get; set; } = true;

        public bool Stop_Bit { get; set; } = true;

        public bool Hand_Shake { get; set; } = false;

        public int Package_Size { get; set; } = 8;

        public Type GetTypeOfColumn()
        {
            return this.GetType();
        }
    }
}
