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
    internal class YoutubeSql : SqliteRepository
    {
        public YoutubeSql()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }

        public static void InsertYoutubeVideo(YoutubeVideo video)
        {
            string sqlString = "INSERT INTO YoutubeVideo (Title, Channel, Views, Link) VALUES (@Title, @Channel, @Views, @Link);";

            using (SqliteConnection connection = DbConnectionFactory())
            {
                connection.Open();
                    // Default returns rows effected.
                connection.Execute(sqlString, video);
            }
        }

        public IEnumerable<YoutubeVideo> GetYoutubeVideos()
        {
            String youtubeSql = "SELECT * FROM YoutubeVideo;";

            using (SqliteConnection connection = DbConnectionFactory())
            {
                return connection.Query<YoutubeVideo>(youtubeSql);
            }
        }
        
            // Delete all Youtube records in the database.
        public static void DeleteYoutubeVideo()
        {
            String youtubeSql = "DELETE FROM YoutubeVideo;";
            using (SqliteConnection connection = DbConnectionFactory())
            {
                connection.Query<YoutubeVideo>(youtubeSql);
            }
        }
    }
}
