using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

[assembly:log4net.Config.XmlConfigurator(Watch =true)]
namespace ConsoleUI
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("Program.cs");
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            log.Error("my error message");
            for (int i = 0; i < 1000; i++)
            {
                log.Error("my error message from for each");
            }
            var connString = "data source=localhost\\SQLEXPRESS; initial catalog=ApplicationLog_Log4net;integrated security=true";
            SqlConnection sc = new SqlConnection(connString);
            sc.Open();
            Console.WriteLine("connection opened");
            string query = "INSERT INTO logs (logdate,logthread,loglevel,logSource,logMessage,logException) VALUES ('2022-01-01', '12', '101', 'sd', 'code from c#', 'no exception')";
            SqlCommand cmd = new SqlCommand(query, sc);
            cmd.ExecuteNonQuery();
            Console.ReadLine();


        }
    }
}
