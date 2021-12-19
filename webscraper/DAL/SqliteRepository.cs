using Microsoft.Data.Sqlite;
using Dapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace webscraper.DAL
{
    class SqliteRepository
    {
            // Empty constructor.
        public SqliteRepository()
        {
        }
        
            // Creates an object to work with.
        public static SqliteConnection DbConnectionFactory()
        {
            // By calling the database it wil also create it.
            return new SqliteConnection("DataSource=WebscraperDB.sqlite");
        }
        
            // Proctected = this class and inherited classes can only use the method.
        protected static bool DatabaseExists()
        {
                // Just check if the database is already present in the files.
            return File.Exists(@"WebscraperDB.sqlite");
        }


        protected static void CreateDatabase()
        {
            // Use the created database connection.
            using (SqliteConnection connection = DbConnectionFactory())
            {   
                    // Open the connection to the database.
                connection.Open();
                    // fill a table.
                connection.Execute(
                    @"CREATE TABLE YoutubeVideo
                    (
                    id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title          VARCHAR5(100),
                    Channel        VARCHAR(100),
                    Views          VARCHAR(24),
                    Link           VARCHAR(255)
                    )"
                    );
                // Connection will be ended here (due to "using").
            }
        }

    }
}
