using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using webscraper.Views;
using webscraper.Actions;
using webscraper.DAL;
using webscraper.Models;

using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace webscraper
{
    class Globals
    {
            // A driver for global use (so its not used in function parameters).
        public static ChromeDriver driver;
            // A global sortet set (so it can be used in other classes).
        public static SortedSet<YoutubeVideo> youtubeVideos;

    }
    public class Webscraper
    {
        public static void Main(string[] args)
        {
                // Check if a database has been created, else make one to use further on.
            YoutubeSql youtubeSql = new YoutubeSql();
                // Make a sortedSet with the contents from the database.
            Globals.youtubeVideos = new SortedSet<YoutubeVideo>(youtubeSql.GetYoutubeVideos());
            do
            {
                    // Show the home page under "views"
                HomePage.Show();
                    // Set the selection made to uppercase and take only the first letter.
                String selection = Console.ReadLine().Substring(0, 1).ToUpper();

                    // Y = youtube query.
                if (selection == "Y")
                {
                        // make a driver and browse to Youtube.
                    //ChromeDriver driver = StartDriver.Website("https://www.youtube.com/");
                    StartDriver.Website("https://www.youtube.com/");
                        // Click Youtube "accept Terms" button.
                    AcceptPopupButtons.TryAll();
                        // Show the prompt to enter a search value.
                    InputSearchValue.ShowGeneric();
                    string searchTerm = Console.ReadLine();
                        // Do a youtube search, and filter on most recent.
                    ActiveWebsiteSearch.SearchForYoutubeVideos(searchTerm);
                        // get the info of the top 5 youtube video results.
                    WebsiteResults.Show();
                    QuerySiteInfo.YoutubeVideos();
                    // Any input will return to the big loop.
                    Console.ReadLine();
                }

                    // J = indeed Jobs.
                if (selection == "J")
                {
                        // Make driver and browse to indeed.com
                    StartDriver.Website("https://be.indeed.com");
                        // Show the prompt to enter a job value.
                    InputSearchValue.ShowAskJob();
                    string searchJob = Console.ReadLine();
                        // Show the prompt to enter a city value.
                    InputSearchValue.ShowAskCity();
                    string searchCity = Console.ReadLine();
                    // Do a search, filtering on jobs and city.
                    AcceptPopupButtons.TryAll();
                    ActiveWebsiteSearch.SearchForIndeedJobs(searchCity, searchJob);
                        // get the info of the jobs returned.
                    WebsiteResults.Show();
                    QuerySiteInfo.IndeedJobs();
                    WebsiteResults.ShowEndOfResults();
                    // Any input will return to the big loop.
                    Console.ReadLine();
                }

                    // W = Warhammer
                if (selection == "W")
                {
                        // Make driver and browse to belloflostsouls.net
                    StartDriver.Website("https://www.belloflostsouls.net");
                    System.Threading.Thread.Sleep(1500);
                        // Cancel website notifications and accept terms.
                    AcceptPopupButtons.TryAll();
                        // Get the info per post.
                    WebsiteResults.Show();
                    QuerySiteInfo.BellOfLostSoulsPosts();
                    WebsiteResults.ShowEndOfResults();
                        // Any input will return to the big loop.
                    Console.ReadLine();
                }

                    // I = info of saved/database items.
                if(selection == "I")
                {
                        // Shiw promt to ask for wich info
                    InputSearchValue.ShowSavedInfo();
                        // Ask the wanted info category.
                    String showInfo = Console.ReadLine().Substring(0, 1).ToUpper();
                    if (showInfo == "Y")
                    {
                            // Show the results stored in the SQL YoutubeVideo table.
                        WebsiteResults.ShowYoutubeVideos(Globals.youtubeVideos);
                        WebsiteResults.ShowEndOfResults();
                        // Any input will return to the big loop.
                        Console.ReadLine();
                    }
                }

                    // D =delete saved info.
                if (selection == "D")
                {
                    InputSearchValue.ShowDeleteInfo();
                    
                    string deleteInfo = Console.ReadLine().Substring(0, 1).ToUpper();
                    if(deleteInfo == "Y")
                    {
                            // Delete items from the database.
                        YoutubeSql.DeleteYoutubeVideo();
                            // Empty the sortedSet list.
                        Globals.youtubeVideos.Clear();
                    }
                }

                    // M = My own webpage.
                if (selection == "M")
                {
                        // Show the prompt to enter a URL
                    EnterWebsiteName.Show();
                    string website = Console.ReadLine();
                        // make a driver and browse to the given website.
                    StartDriver.Website("https://www." + website);
                }
            } while (true);
        }
    }
}
