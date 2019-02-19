using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace MySqlBase
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                string connection = "server=localhost;user=root;database=user;";
                MySqlConnection resourseMysql = new MySqlConnection(connection);
                resourseMysql.Open();

                //string sqlCommand = "SHOW TABLES FROM user;";
                string sqlCommand = "DESCRIBE customers";
                MySqlCommand selectDescribe = new MySqlCommand(sqlCommand, resourseMysql);
                //Console.WriteLine(selectDescribe);
                MySqlDataReader reader = selectDescribe.ExecuteReader();

                //Console.WriteLine(reader.FieldCount);


                while (reader.Read())
                {

                    int i = 0;
                    string result = "";
                    for (; i < reader.FieldCount; i++)
                    {
                        
                        result += $"{reader[i].ToString()} ";
                    };
                    //Console.WriteLine($"{reader[0].ToString()} ");
                    Console.WriteLine(result);
                    
                }
                reader.Close(); 

                resourseMysql.Close();
                Console.ReadKey();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
