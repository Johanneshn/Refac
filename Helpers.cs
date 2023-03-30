using System.Data;

namespace WebApplication3;

public static class Helpers
{
    public static DataTable Devices(int cursorPosition)
    {
        var first = cursorPosition + 1;
        var second = cursorPosition + 2;
        DataTable deviceTable = new DataTable();
        deviceTable.Columns.Add(new DataColumn()
        {
            ColumnName = "id",
            DataType = typeof(int)
        });
        deviceTable.Columns.Add(new DataColumn()
        {
            ColumnName = "name",
            DataType = typeof(string)
        });

        deviceTable.Rows.Add(new object[] { first, "Device1" });
        deviceTable.Rows.Add(new object[] { second, "Device2" });

        return deviceTable;
    }

    public static DataTable Positions(int cursor)
    {
        var first = cursor + 1;

        DataTable positionTable = new DataTable();
        positionTable.Columns.Add(new DataColumn()
        {
            ColumnName = "id",
            DataType = typeof(int)
        });
        positionTable.Columns.Add(new DataColumn()
        {
            ColumnName = "position",
            DataType = typeof(string)
        });

        positionTable.Rows.Add(new object[] { first, "position" });

        return positionTable;
    }
}