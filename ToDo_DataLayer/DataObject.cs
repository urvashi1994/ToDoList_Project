using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ToDoList_DataLayer
{
    public class DataObject
    {
        private string _connectionString;

        public DataObject()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MVC"].ConnectionString;

           // SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MVC"].ConnectionString);

        }

        public string connectionString => _connectionString;
    }
}