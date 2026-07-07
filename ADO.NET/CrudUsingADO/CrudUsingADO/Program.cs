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

            SqlCommand cmd = new SqlCommand("insert into Student values(1, 'John Doe', 20)", con);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Data Inserted Successfully!");
        }
    }
}
