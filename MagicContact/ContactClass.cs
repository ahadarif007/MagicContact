using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MagicContact
{
   public  class ContactClass
    {
        //Entity class 

        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        static string myconStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;


        //selecting data from database 

        public static DataTable select()
        {
                SqlConnection conn = new SqlConnection(myconStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from [tbl_contact]";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            return dt;
                //dataGridView1.DataSource = dt;
                //con.Close();
        }
        
        //Inserting data into datatable
        public static bool Insert(ContactClass c)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;
            //Step 1: connect database
            SqlConnection conn = new SqlConnection(myconStr);
            try
            {
                //Step 2: Create a sql query to insert data
                string sql="Insert into tbl_contact(FirstName,LastName,ContactNumber,Address,Gender) VALUES (@FirstName,@LastName,@ContactNumber,@Address,@Gender)";
                //creating SQL command using sql and conn 
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNumber", c.ContactNumber);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                //connection open here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if query run successfully then the value of rows will be grater then 0 , else it will be zero
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;

                }
            }
            catch (Exception ex)
            {

                
            }
            finally
            {
                conn.Close();

            }
            return isSuccess;
        }

        //update data into datatable
        public static bool Update(ContactClass c)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;
            //Step 1: connect database
            SqlConnection conn = new SqlConnection(myconStr);
            try
            {
                //Step 2: Create a sql query to insert data
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName,LastName=@LastName,ContactNumber=@ContactNumber,Address=@Address,Gender=@Gender where ContactID=@ContactID)";
                //creating SQL command using sql and conn 
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
               
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNumber", c.ContactNumber);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                //connection open here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if query run successfully then the value of rows will be grater then 0 , else it will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;

                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();

            }
            return isSuccess;
        }
        
        
        
        //delete data into datatable
        public static bool Delete(ContactClass c)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;
            //Step 1: connect database
            SqlConnection conn = new SqlConnection(myconStr);
            try
            {
                //Step 2: Create a sql query to insert data
                string sql = "Delete from tbl_contact where ContactID = @ContactID)";
                //creating SQL command using sql and conn 
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data

                SqlParameter p = new SqlParameter("@ContactID", SqlDbType.Int);
                p.Value = c.ContactID;
                cmd.Parameters.Add(p);
               
                //connection open here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if query run successfully then the value of rows will be grater then 0 , else it will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;

                }
            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();

            }
            return isSuccess;
        }



    }
}
