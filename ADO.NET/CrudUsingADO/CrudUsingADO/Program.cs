using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class AdoPractice
{
    public static void Main()
    {
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB; Database=ado; Trusted_Connection=True;"; 

            con.Open();
            Console.WriteLine("Connection Successful!");

            // -------- Insert --------

            using (SqlCommand insertCmd = new SqlCommand("insert into Student values(2, 'Walter', 25)", con)) {
                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Data Inserted Successfully!");
            }

            // -------- Read --------

            using (SqlCommand readCmd = new SqlCommand("select * from Student", con))
            {
                using (SqlDataReader reader = readCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID : {reader["Id"]}, Name : {reader["Name"]}, Age : {reader["Age"]}");
                    }
                }
            }

            // -------- Update --------

            using (SqlCommand updateCmd = new SqlCommand("update Student set Name = 'Khan' where Id = 1", con))
            {
                updateCmd.ExecuteNonQuery();
                Console.WriteLine("Data Updated Successfully!");
            }

            // -------- Delete --------

            using (SqlCommand deleteCmd = new SqlCommand("delete from Student where Id = 2", con))
            {
                deleteCmd.ExecuteNonQuery();
                Console.WriteLine("Data Deleted Successfully!");
            }
        }
    }
}
