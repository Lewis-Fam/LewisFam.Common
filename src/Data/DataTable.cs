using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Newtonsoft.Json;

namespace LewisFam.Common.Data
{
    public class DataTable : System.Data.DataTable
    {
        public static System.Data.DataTable ConvertToDataTable(IEnumerable<dynamic> data)
        {
            //List<dynamic> dlist = new List<dynamic>();
            var json = JsonConvert.SerializeObject(data);
            var dt = (System.Data.DataTable)JsonConvert.DeserializeObject(json, (typeof(System.Data.DataTable)));
            return dt;
        }

        //public static System.Data.DataTable ConvertToDataTableJson<T>(IEnumerable<T> dlist)
        //{
        //    //List<dynamic> dlist = new List<dynamic>();
        //    var json = JsonConvert.SerializeObject(dlist);
        //    System.Data.DataTable dt = (System.Data.DataTable)JsonConvert.DeserializeObject(json, (typeof(System.Data.DataTable)));
        //    return dt;
        //}

        public static System.Data.DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        {
            var properties =
                TypeDescriptor.GetProperties(typeof(T));
            var table = new System.Data.DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
    }
}
