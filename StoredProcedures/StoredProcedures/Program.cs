using System;
using System.Data.SqlClient;
using System.Data;

namespace StoredProcedures
{
    class Program
    {
        static void Main()
        {
             string connectionString = "Data Source=LAPTOP-43E0PBDE\\SQLEXPRESS;Initial Catalog=ConnectionDataBase;Integrated Security=SSPI";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string procedure = "spPassengerAdd";
            SqlCommand sqlCommand = new SqlCommand(procedure, sqlConnection);
            sqlCommand.CommandType =CommandType.StoredProcedure;
            SqlParameter sqlParameter;

            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the age:");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter user mail id: ");
            string mailId = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            sqlCommand.Parameters.AddWithValue("@Name", name);
            sqlCommand.Parameters.AddWithValue("@Age", age);
            sqlCommand.Parameters.AddWithValue("@Email", mailId);
            sqlCommand.Parameters.AddWithValue("@Password", password);
            


            // Add the parameter representing the return value.

            sqlParameter = sqlCommand.Parameters.Add("@PassengerID", SqlDbType.Int);

            sqlParameter.Direction = ParameterDirection.ReturnValue;

            // Execute the command.

            sqlConnection.Open();

            
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();



            sqlParameter = sqlCommand.Parameters["@PassengerID"];

            Console.WriteLine("New customer has ID of " + sqlParameter.Value);

        }
    }
}
