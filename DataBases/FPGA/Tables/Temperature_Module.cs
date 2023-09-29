using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    public class Temperature_Module : IFPGATableColumn
    {
        public int Id { get; set; } = 0;

        public string Request_Time { get; set; } = "Empty";

        public string Response_Time { get; set; } = "Empty";

        public string Temperature { get; set; } = "Empty";

        public string Critical_Temperature { get; set; } = "Empty";

        public int Device_Id { get; set; } = 0;

        public int UART_Id { get; set; } = 0;

        public Type GetTypeOfColumn()
        {
            return this.GetType();
        }
    }
}
