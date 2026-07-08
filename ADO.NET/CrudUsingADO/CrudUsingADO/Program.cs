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

            using (SqlCommand insertCmd = new SqlCommand("insert into Student values(1, 'John Doe', 20)", con)) {
                insertCmd.ExecuteNonQuery();

                Console.WriteLine("Data Inserted Successfully!");
            }

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

            using (SqlCommand cmd = new SqlCommand("insert into Student values(1, 'John Doe', 20)", con))
            {
                cmd.ExecuteNonQuery();

                Console.WriteLine("Data Inserted Successfully!");
            }

            using (SqlCommand cmd = new SqlCommand("insert into Student values(1, 'John Doe', 20)", con))
            {
                cmd.ExecuteNonQuery();

                Console.WriteLine("Data Inserted Successfully!");
            }
        }
    }
}
