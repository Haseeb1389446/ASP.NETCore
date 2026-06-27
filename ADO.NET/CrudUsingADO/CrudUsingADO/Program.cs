using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class AdoPractice
{
    public static void Main()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "Server=(localdb)\\MSSQLLocalDB; Database=ado; Trusted_Connection=True;"; 

        con.Open();
        Console.WriteLine("Connection Successful!");
        con.Close();
    }
}
