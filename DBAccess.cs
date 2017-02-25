using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApplication2
{

    class DBAccess
    {
         SqlConnection conn;


         public DBAccess()
         {

             conn = ConnectionManger.GetConnection();


         }

         public bool add_student(int sid, string sname)
         {
             bool s = false;


             if (conn.State == ConnectionState.Closed)
             {
                 conn.Open();
             }

             SqlCommand cmd = conn.CreateCommand();

             cmd.Connection = conn;
             cmd.CommandType = CommandType.Text;

             cmd.CommandText = "INSERT INTO new_student(id, name) VALUES('" + sid + "', '" + sname + "')";
             cmd.ExecuteNonQuery();

             s = true;


             conn.Close();


             return s;
         }


         public bool update_student(int sid, string sname)
         {
             bool s = false;
             try
             {

                 if (conn.State == ConnectionState.Closed)
                 {
                     conn.Open();
                 }

                 SqlCommand cmd = conn.CreateCommand();

                 cmd.Connection = conn;
                 cmd.CommandType = CommandType.Text;

                 cmd.CommandText = "UPDATE new_student set id='" + sid + "', name= '" + sname + "' WHERE id='" + sid + "' ";
                 cmd.ExecuteNonQuery();

                 s = true;

                 conn.Close();
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }

             return s;
         }


         public bool delete_student(int sid, string sname)
         {
             bool s = false;
             try
             {

                 if (conn.State == ConnectionState.Closed)
                 {
                     conn.Open();
                 }

                 SqlCommand cmd = conn.CreateCommand();

                 cmd.Connection = conn;
                 cmd.CommandType = CommandType.Text;

                 cmd.CommandText = "Delete from new_student WHERE id='" + sid + "' ";
                 cmd.ExecuteNonQuery();

                 s = true;

                 conn.Close();
             }
             catch (Exception e)
             {
                 Console.WriteLine(e.Message);
             }

             return s;
         }


         public DataSet getAllJobs()
         {
             if (conn.State.ToString() == "Closed")
             {
                 conn.Open();
             }

             SqlCommand newCmd = conn.CreateCommand();
             newCmd.Connection = conn;
             newCmd.CommandType = CommandType.Text;
             newCmd.CommandText = "select * from new_student";

             SqlDataAdapter da = new SqlDataAdapter(newCmd);
             DataSet ds = new DataSet();
             da.Fill(ds, "new_student");

             conn.Close();

             return ds;
         }


    }
}
