using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Renting
{
    public static class CommonDB
    {
        public static DataTable ConvertListToDataTable<T>(List<T> list) 
        {
            DataTable result = new DataTable();
            //set Name column
            foreach (var prop in typeof(T).GetProperties())
            {
                //ignore virtual prop , ưhich is association 
                if (prop.GetGetMethod().IsVirtual)
                    continue;
                result.Columns.Add(prop.Name);
            }
            //set row value
            foreach (var item in list)
            {
                DataRow row = result.NewRow();
                foreach (var prop in typeof(T).GetProperties())
                {
                    //ignore virtual prop , ưhich is association 
                    if (prop.GetGetMethod().IsVirtual)
                        continue;

                    row[prop.Name] = prop.GetValue(item, null);
                }
                result.Rows.Add(row);
            }

            return result;
        }

    }
}
