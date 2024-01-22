using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO.Pipes;

namespace IntroductionToADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            //string insert_string = @"INSERT INTO Authors (first_name, last_name) VALUES ('Steven', 'Hawking')";
            string insert_string = @"INSERT INTO Books (author, title, price, pages) VALUES ('4', 'The Steven Hawkings Universe', 160, 850)";
            SqlCommand cmd = new SqlCommand(insert_string, connection);
            //cmd.ExecuteNonQuery();
            
            string select_string = @"SELECT Authors.first_name + ' ' + Authors.last_name, Books.title, Books.price, Books.pages FROM Authors, Books WHERE Books.author = Authors.id";
            cmd.CommandText = select_string;

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]} {rdr[1]} {rdr[2]} {rdr[3]}");
            }            

            connection.Close();
        }
    }
}
