using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.CRUD
{
    internal class FetchDataFromServer
    {
        public static void RetrieveDatafromtheServer()
        {
            string ConnectionAString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Assignment;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;";

            using(SqlConnection connection = new SqlConnection(ConnectionAString)) 
            {
                SqlCommand command = new SqlCommand("GetDetails", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader Read = command.ExecuteReader();

                while(Read.Read())
                {
                    int id = (int)Read["Id"];
                    string Name = (string)Read["Name"];
                    long PhoneNumber = (long)Read["PhoneNumber"];
                    string Address = (string)Read["Address"];
                    
                    Console.WriteLine($" Id= {id} Name= {Name} PhoneNumber= {PhoneNumber} Address= {Address}");
                }
                Read.Close();
                connection.Close();
            }
        
        }
    }
}
