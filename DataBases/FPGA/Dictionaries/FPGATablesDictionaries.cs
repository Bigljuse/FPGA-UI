using FPGA_UI.DataBases.FPGA.Enums;
using FPGA_UI.DataBases.FPGA.Tables;
using MySqlLibrary.MySql.Models;
using System;
using System.Collections.Generic;

namespace FPGA_UI.DataBases.FPGA
{
    internal static class FPGATablesDictionaries
    {
        private static readonly Dictionary<FPGATables, Type> s_tablesTypesDictionary = new()
        {
            { FPGATables.Bluetooth, typeof(Bluetooth) },
            { FPGATables.Button, typeof(Button) },
            { FPGATables.Device, typeof(Device) },
            { FPGATables.Port, typeof(Port) },
            { FPGATables.Temperature_Module, typeof(Temperature_Module) },
            { FPGATables.Toggle, typeof(Toggle) },
            { FPGATables.UART, typeof(UART) }
        };

        private static readonly Dictionary<FPGATables, MySqlColumnModel[]> s_tableColumns = new()
        {
            {
                FPGATables.Bluetooth,
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ Name = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ Name = "Connectioned_To_Device", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ Name = "Mac_Address", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ Name = "Device_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                FPGATables.Button,
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ Name = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ Name = "State", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ Name = "Mark", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ Name = "Device_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                FPGATables.Device,
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ Name = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ Name = "Address", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ Name = "Memory_Address", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ Name = "Memory_Size", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ Name = "Port_Type_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                FPGATables.Port,
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ Name = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ Name = "Mark", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ Name = "Device_Type", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ Name = "Power_State", DataType = MySqlDataTypeEnum.BIT}
                }
            },

            {
                FPGATables.Temperature_Module,
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ Name = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ Name = "Request_Time", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ Name = "Response_Time", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ Name = "Temperature", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ Name = "Critical Temperature", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ Name = "Device_Id", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ Name = "UART_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                FPGATables.Toggle,
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ Name = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ Name = "Toggled", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ Name = "Mark", DataType = MySqlDataTypeEnum.LONGTEXT},
                    new MySqlColumnModel(){ Name = "Device_Id", DataType = MySqlDataTypeEnum.INT}
                }
            },

            {
                FPGATables.UART,
                new MySqlColumnModel[]
                {
                    new MySqlColumnModel(){ Name = "Id", DataType = MySqlDataTypeEnum.INT, Primary_Key = true, Auto_Increment = true, Unsigned = true},
                    new MySqlColumnModel(){ Name = "Baud", DataType = MySqlDataTypeEnum.INT},
                    new MySqlColumnModel(){ Name = "Start_Bit", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ Name = "Stop_Bit", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ Name = "Hand_Shake", DataType = MySqlDataTypeEnum.BIT},
                    new MySqlColumnModel(){ Name = "Package_Size", DataType = MySqlDataTypeEnum.INT}
                }
            }
        };

        internal static Type GetTableType(FPGATables tableName)
        {
            return s_tablesTypesDictionary[tableName];
        }

        internal static MySqlColumnModel[] GetTableColumns(FPGATables tableName)
        {
            return s_tableColumns[tableName];
        }
    }
}
