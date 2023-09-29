using System;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    internal interface IFPGATableColumn
    {
        public int Id { get; set; }

        public Type GetTypeOfColumn();
    }
}
