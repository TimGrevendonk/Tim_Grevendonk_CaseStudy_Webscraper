using Dapper;
using webscraper.Models;
using Microsoft.Data.Sqlite;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webscraper.DAL
{
        // Extends SqliteRepository.
    internal class YoutubeSql : SqliteRepository
    {
            // Constructor that will check if the database exists, if not will create it.
        public YoutubeSql()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }

        public static void InsertYoutubeVideo(YoutubeVideo video)
        {
                // The sql string used inside the database.
            string sqlString = "INSERT INTO YoutubeVideo (Title, Channel, Views, Link) VALUES (@Title, @Channel, @Views, @Link);";
                // Use the connection for the inserts.
            using (SqliteConnection connection = DbConnectionFactory())
            {
                    // Open the connection.
                connection.Open();
                    // Execute the insert statment (Default returns int of rows effected).
                connection.Execute(sqlString, video);
            }
        }

        public IEnumerable<YoutubeVideo> GetYoutubeVideos()
        {
                // Query all Youtube videos.
            String youtubeSql = "SELECT * FROM YoutubeVideo;";
                // use the connection to the database.
            using (SqliteConnection connection = DbConnectionFactory())
            {  
                    // the query of all youtube videos returned in objects.
                return connection.Query<YoutubeVideo>(youtubeSql);
            }
        }
        
            // Delete all Youtube records in the database.
        public static void DeleteYoutubeVideo()
        {
                // Sql query to empty a table in the database.
            String youtubeSql = "DELETE FROM YoutubeVideo;";
                // Use the database connection. 
            using (SqliteConnection connection = DbConnectionFactory())
            {
                    // Delete the actual table content (but not the table).
                connection.Query<YoutubeVideo>(youtubeSql);
            }
        }
    }
}
