namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Bluetooth
    {
        public int Id { get; set; }

        public bool Connectioned_To_Device { get; set; }
        
        public string Mac_Address { get; set; }

        public int Device_Id { get; set; }
    }
}
