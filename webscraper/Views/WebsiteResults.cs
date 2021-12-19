using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webscraper.Models;

namespace webscraper.Views
{
    class WebsiteResults
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("~~Webscraper Grevendonk Tim~~");
            Console.WriteLine("page: WebsiteResults.Show");
            Console.WriteLine("------------------------------");
            Console.WriteLine(" ");
        }

        public static void ShowEndOfResults()
        {
            Console.WriteLine(" ");
            Console.WriteLine("press enter to return");
            Console.WriteLine(" ");
        }

        public static void ShowYoutubeVideos(IEnumerable<YoutubeVideo> youtubeVideos)
        {
            Console.Clear();
            Console.WriteLine("~~Webscraper Grevendonk Tim~~");
            Console.WriteLine("page: WebsiteResults.ShowYoutubeVideos");
            Console.WriteLine("------------------------------");
            Console.WriteLine(" ");
            foreach (YoutubeVideo video in youtubeVideos)
            {
                Console.WriteLine(video.Title);
                Console.WriteLine(video.Channel);
                Console.WriteLine(video.Views);
                Console.WriteLine(video.Link);
                Console.WriteLine(" ");
            }
        }
    }
}
