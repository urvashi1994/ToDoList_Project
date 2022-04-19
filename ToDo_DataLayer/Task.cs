using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ToDoList_DataLayer
{
    public class Task :DataObject
    {
       

        public class TaskDetails
        {
            public int id;
            public string Task_name;

        }
        public Task() : base()
        {
             
        }

        public List<TaskDetails>GetAllTask()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetAllTaskById", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter output = new SqlParameter();
            output.ParameterName = "@Taskid";
            output.SqlDbType = System.Data.SqlDbType.Int;

            output.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(output); 

            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                List<TaskDetails> tasks = new List<TaskDetails>();//Here List<TaskDetails> is returntype.

                while(rdr.Read())
                {
                    TaskDetails task = new TaskDetails();
                    task.id = Convert.ToInt32(rdr["id"]);
                    task.Task_name = Convert.ToString(rdr["Task_name"]);


                    tasks.Add(task);
                }
                return tasks;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertTask(TaskDetails obj)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SP_insert_task", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Task_name", obj.Task_name);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}