//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Reflection;

//namespace UnsubscribeR
//{

//    public static class ListToDataTableConverter
//    {
//        public static DataTable ConvertToDataTable<T>(List<T> list)
//        {
//            DataTable DataTable = new DataTable();

//            // Use reflection to get the properties of the generic type
//            PropertyInfo[] Properties = typeof(T).GetProperties();

//            // Create the columns in the DataTable for each property
//            foreach (PropertyInfo Property in Properties)
//            {
//                DataTable.Columns.Add(Property.Name, Nullable.GetUnderlyingType(Property.PropertyType) ?? Property.PropertyType);
//            }

//            // Populate the DataTable with data from the list
//            foreach (T item in list)
//            {
//                DataRow row = DataTable.NewRow();

//                foreach (PropertyInfo Property in Properties)
//                {
//                    // row[property.Name] = property.GetValue(item) ?? DBNull.Value;

//                    row[Property.Name] = Property.GetValue(item) ?? DBNull.Value;

//                }

//                DataTable.Rows.Add(row);
//            }

//            return DataTable;
//        }
//    }

//}
