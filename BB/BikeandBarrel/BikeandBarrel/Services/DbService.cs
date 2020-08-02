using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BikeandBarrel.Services
{
    public class DbService
    {
        private static string myConnectionString = "server=13.67.72.187;uid=bnbadmin;pwd=bnbpassword;database=bnbdb";
        private MySqlConnection conn = new MySqlConnection(myConnectionString);

        public DataTable SelectData(string sql)
        {
            DataTable DT = new DataTable("Table");
            try
            {
                conn.Open();
                //MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter returnVal = new MySqlDataAdapter(sql, conn);
                returnVal.Fill(DT);
                conn.Close();
                return DT;
            }
            catch (MySqlException ex)
            {
                //log error
                return DT;
            }
        }

        public bool Executequery(string sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                }
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetLastInsertId()
        {
            DataTable DT = new DataTable("Table");
            try
            {
                conn.Open();
                //MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter returnVal = new MySqlDataAdapter("SELECT LAST_INSERT_ID() AS INSERTID;", conn);
                returnVal.Fill(DT);
                conn.Close();
                return Convert.ToInt32(DT.Rows[0]["INSERTID"]);
            }
            catch (MySqlException ex)
            {
                //log error
                return 0;
            }
        }
    }
}