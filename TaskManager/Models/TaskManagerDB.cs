using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace TaskManager.Models
{
    static public class TaskManagerDB
    {

        public static SqlConnection GetConnection()
        {
            string output = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;

            return new SqlConnection(output);
        }

        public static ObservableCollection<Task> GetTasks()
        {
            ObservableCollection<Task> output = new ObservableCollection<Task>();

            SqlConnection cnn = null;
            SqlDataReader rdr = null;

            try
            {
                // Open Connection

                cnn = GetConnection();
                cnn.Open();

                // Execute Procedure

                SqlCommand cmd = new SqlCommand("SelectAllTasks", cnn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                rdr = cmd.ExecuteReader();

                // Read

                while (rdr.Read())
                {
                    if (DBNull.Value.Equals(rdr["Deadline"]))
                    {
                        output.Add(new Task((int)rdr["Id"], (string)rdr["TaskDesc"], (string)rdr["Priority"], (string)rdr["Status"], DateTime.MinValue));
                    }
                    else
                    {
                        output.Add(new Task((int)rdr["Id"], (string)rdr["TaskDesc"], (string)rdr["Priority"], (string)rdr["Status"], (DateTime)rdr["Deadline"]));
                    }
                }
            }
            finally
            {
                if (cnn != null) cnn.Close();
                if (rdr != null) rdr.Close();
            }
            return output;
        }

        public static void AddTask(string desc, string status, string priority, DateTime? deadline)
        {
            SqlConnection cnn = null;

            try
            {
                cnn = GetConnection();

                cnn.Open();

                SqlCommand cmd = new SqlCommand("AddTask", cnn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Desc", desc));
                cmd.Parameters.Add(new SqlParameter("@Status", status));
                cmd.Parameters.Add(new SqlParameter("@Priority", priority));

                // SqlParameter does not accept plain Null, have to use DBNull

                var tmp = (deadline == null) ? new SqlParameter("@Deadline", DBNull.Value) : new SqlParameter("Deadline", deadline);

                cmd.Parameters.Add(tmp);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cnn != null) cnn.Close();
            }
        }

        public static void RemoveTask(int id)
        {
            SqlConnection cnn = null;

            try
            {
                cnn = GetConnection();

                cnn.Open();

                SqlCommand cmd = new SqlCommand("RemoveTask", cnn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", id));

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cnn != null) cnn.Close();
            }
        }

        public static void ModifyTask(int id, string desc, string status, string priority, DateTime? deadline)
        {
            SqlConnection cnn = null;

            try
            {
                cnn = GetConnection();

                cnn.Open();

                SqlCommand cmd = new SqlCommand("UpdateTask", cnn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@Desc", desc));
                cmd.Parameters.Add(new SqlParameter("@Status", status));
                cmd.Parameters.Add(new SqlParameter("@Priority", priority));

                // SqlParameter does not accept plain Null, have to use DBNull

                var tmp = (deadline == null) ? new SqlParameter("@Deadline", DBNull.Value) : new SqlParameter("Deadline", deadline);

                cmd.Parameters.Add(tmp);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (cnn != null) cnn.Close();
            }
        }
    }
}
