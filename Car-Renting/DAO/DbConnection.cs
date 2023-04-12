using System;
using System.Collections.Generic;
using System.Data;

namespace Car_Renting
{
    class DbConnection
    {
        public static DbConnection Instance { get; set; }

        internal int executeInsertQuery(string sqlStr, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        internal int ExecuteNonQuery(string sqlStr)
        {
            throw new NotImplementedException();
        }

        internal int executeUpdateQuery(string sqlStr, Dictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }

        internal DataTable getData(string sqlStr)
        {
            throw new NotImplementedException();
        }
    }
}