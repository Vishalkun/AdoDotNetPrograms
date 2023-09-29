using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ADOnetDemo
{
    internal class CustomerOperations
    {

        public static void createdatabase()
        {
            SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=master;integrated security=true");
            string query = "create database Customer";
            SqlCommand cmd = new SqlCommand(query, con);
            //open connection
            con.Open();
            //Execut query
            cmd.ExecuteNonQuery();
            //Message
            Console.WriteLine("Database created successfully");
            Console.WriteLine("-----------------------------");
            //Close connection
            con.Close();
        }
        public static SqlConnection con = new SqlConnection("data source=(localdb)\\MSSQLLocalDB;initial catalog=master;integrated security=true");
        public static void CreateTable()
        {
            string query = "create table CustomerData(Id int primary key identity(1,1),Name varchar(200),City varchar(200),Phone bigint)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table created successfully");
            Console.WriteLine("---------------------------");
            con.Close();
        }
        public static void InsertData()
        {
            string query = "insert into  CustomerData values('vishal','mumbai',1223234)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted successfully");
            Console.WriteLine("---------------------------");
            con.Close();
        }
        public static void Delete()
        {
            string query = "Delete from Customer where id=1";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Inserted successfully");
            Console.WriteLine("---------------------------");
            con.Close();
        }
        public static void Display()
        {
            using (con)
            {
                CustomerModel m = new CustomerModel();
                string query = "select * from Customer";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("-----------Data--------");
                    while (sqlDataReader.Read())
                    {
                        m.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        m.Name = Convert.ToString(sqlDataReader["Name"]);
                        m.phone = Convert.ToInt32(sqlDataReader["City"]);
                        m.city = Convert.ToString(sqlDataReader["Phone"]);

                        Console.WriteLine();
                    }

                }


                Console.WriteLine("Data Inserted successfully");
                Console.WriteLine("---------------------------");
                con.Close();
            }

        }
        public static void InsertUsingStoredProcedure(CustomerModel CustomerModel)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("Sp_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", CustomerModel.Name);
                cmd.Parameters.AddWithValue("@city", CustomerModel.city);
                cmd.Parameters.AddWithValue("@Phone", CustomerModel.phone);
                con.Open();
                var result = cmd.ExecuteNonQuery();
                Console.WriteLine("Data Inserted Successfully");
                con.Close();

            }

        }
        public static void DisplayUsingInsert(CustomerModel model)
        {
            using (con)
            {

                SqlCommand cmd = new SqlCommand("Display", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("-----------Data--------");
                    while (sqlDataReader.Read())
                    {
                        model.Id = Convert.ToInt32(sqlDataReader["Id"]);
                        model.Name = Convert.ToString(sqlDataReader["Name"]);
                        model.phone = Convert.ToInt32(sqlDataReader["City"]);
                        model.city = Convert.ToString(sqlDataReader["Phone"]);

                        Console.WriteLine("Id:{0}\n Name:{1}\n city:{2}\n");
                    }

                }



                Console.WriteLine("Data Inserted successfully");
                Console.WriteLine("---------------------------");
                con.Close();
            }
        }
        public static void get_emp_in_date_range()
        {
            using (con)
            {
                CustomerModel employee = new CustomerModel();

                string query = @"select * from CustomerData where START_DATE between CAST('2019-01-01' as date) and getdate()";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("-----data-----");
                    while (reader.Read())
                    {
                        employee.Id = Convert.ToInt32(reader["EMP_ID"]);
                        employee.Name = Convert.ToString(reader["EMP_NAME"]);
                        employee.phone = Convert.ToInt64(reader["PHONE_NUM"]);
                        employee.city = Convert.ToString(reader["CITY"]);
                        employee.salary = Convert.ToInt32(reader["SALARY"]);
                        employee.start_date = Convert.ToDateTime(reader["START_DATE"]);

                        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n", employee.Id, employee.Name, employee.phone, employee.city, employee.salary, employee.start_date);
                    }
                }
            }
        }
    }
}