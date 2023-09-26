namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class UART
    {
        public int Id { get; set; }

        public int Baud { get; set; }

        public bool Start_Bit { get; set; }

        public bool Stop_Bit { get; set; }

        public bool Hand_Shake { get; set; }

        public int Package_Size { get; set; }
    }
}
