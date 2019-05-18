using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MonoliticoWebApp.DB
{
    public class SqlLocalDbHelper
    {
        public const string ConnectionStringTemplate = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog={0};AttachDBFileName='{1}';Integrated Security=True;";

        private string database;
        private string folder;
        public SqlLocalDbHelper(string database, string folder)
        {
            this.database = database;
            this.folder = folder;
        }
        public string GetConnectionString()
        {
            string outputFolder = GetOutoutFolder();
            string dbFileName = GetFullDataFileName(this.database);
            string logFileName = GetFullLogFileName(this.database);

            // Create Data Directory If It Doesn't Already Exist.
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            if (!File.Exists(dbFileName))
            {
                CreateDatabase(this.database, dbFileName);
            }

            // Open newly created, or old database.
            string connectionString = String.Format(ConnectionStringTemplate, this.database, dbFileName);
            return connectionString;


        }


        public bool CreateDatabase(string dbName, string dbFileName)
        {
            try
            {
                string connectionString = String.Format(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=master;Integrated Security=True");
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();


                    DetachDatabase(dbName);

                    cmd.CommandText = String.Format("CREATE DATABASE {0} ON (NAME = N'{0}', FILENAME = '{1}')", dbName, dbFileName);
                    cmd.ExecuteNonQuery();
                }

                if (File.Exists(dbFileName)) return true;
                else return false;
            }
            catch
            {
                throw;
            }
        }

        public bool DetachDatabase(string dbName)
        {
            try
            {
                string connectionString = String.Format(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=master;Integrated Security=True");
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = String.Format("exec sp_detach_db '{0}'", dbName);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        private string GetOutoutFolder()
        {
            string outputFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), this.folder);
            return outputFolder;
        }

        private string GetFullDataFileName(string dbName)
        {
            string dbFileName = Path.Combine(GetOutoutFolder(), dbName + ".mdf");
            return dbFileName;
        }

        private string GetFullLogFileName(string dbName)
        {
            string logFileName = Path.Combine(GetOutoutFolder(), String.Format("{0}_log.ldf", dbName));
            return logFileName;
        }
    }
}