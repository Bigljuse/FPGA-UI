using System.Reflection;

namespace FPGA_UI.DataBases.FPGA.Tables
{
    internal static class FPGAColumnExtentions
    {
        public static object[] ToCommandArguments(this IFPGATableColumn fPGATableColumn)
        {
            PropertyInfo[] propertiesInfos = fPGATableColumn.GetTypeOfColumn().GetProperties();
            object[] arguments = new object[propertiesInfos.Length];
            PropertyInfo propertyInfo;

            for (int counter = 0; counter < propertiesInfos.Length; counter++)
            {
                propertyInfo = propertiesInfos[counter];
                arguments[counter] = propertyInfo.GetValue(fPGATableColumn);
            }

            return arguments;
        }
    }
}
