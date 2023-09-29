using FPGA_UI.DataBases.FPGA.Tables;
using MySqlLibrary.MySql.Models;
using System.Collections.Generic;

namespace FPGA_UI.DataBases.FPGA
{
    internal static class FPGATablesColumnsDictionary
    {
        internal static Dictionary<string, MySqlColumnModel[]> MySqlColumns = new()
        {
            {
                nameof(Bluetooth).ToLower(),
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ ColumnName = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ ColumnName = "Connectioned_To_Device", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ ColumnName = "Mac_Address", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ ColumnName = "Device_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                nameof(Button).ToLower(),
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ ColumnName = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ ColumnName = "State", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ ColumnName = "Mark", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ ColumnName = "Device_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                nameof(Device).ToLower(),
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ ColumnName = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ ColumnName = "Address", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ ColumnName = "Memory_Address", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ ColumnName = "Memory_Size", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ ColumnName = "Port_Type_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                nameof(Port).ToLower(),
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ ColumnName = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ ColumnName = "Mark", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ ColumnName = "Device_Type", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ ColumnName = "Power_State", DataType = MySqlDataTypeEnum.BIT}
                }
            },

            {
                nameof(Temperature_Module).ToLower(),
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ ColumnName = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ ColumnName = "Request_Time", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ ColumnName = "Response_Time", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ ColumnName = "Temperature", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ ColumnName = "Critical Temperature", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ ColumnName = "Device_Id", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ ColumnName = "UART_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                nameof(Toggle).ToLower(),
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ ColumnName = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ ColumnName = "Toggled", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ ColumnName = "Mark", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ ColumnName = "Device_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                nameof(UART).ToLower(),
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ ColumnName = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ ColumnName = "Baud", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ ColumnName = "Start_Bit", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ ColumnName = "Stop_Bit", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ ColumnName = "Hand_Shake", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ ColumnName = "Package_Size", DataType = MySqlDataTypeEnum.INT}
                }
            }
        };
    }
}
