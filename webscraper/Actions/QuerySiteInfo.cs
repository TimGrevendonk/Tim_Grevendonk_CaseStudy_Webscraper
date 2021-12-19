using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webscraper.DAL;
using webscraper.Models;

namespace webscraper.Actions
{
    class QuerySiteInfo
    {
        public static void YoutubeVideos()
        {
                // Find all the videos (loaded in the page).
            IList<IWebElement> videos = Globals.driver.FindElements(By.CssSelector("ytd-video-renderer div[id='dismissible']"));
                // For the first 5 videos print the Title to the console.
            for (int index = 0; index < 5; index++)
            {
                    // Get the video Title.
                Console.WriteLine("- - video " + (index + 1) + " info - -");
                IWebElement videoTitle = (IWebElement)videos[index].FindElement(By.Id("video-title"));
                Console.WriteLine("Title= " + videoTitle.Text);
                    // Get the channel name.
                IWebElement channelName = (IWebElement)videos[index].FindElement(By.CssSelector("div[id='channel-info'] ytd-channel-name a"));
                Console.WriteLine("Channel= " + channelName.Text);
                    // Get the video views.
                IWebElement videoViews = (IWebElement)videos[index].FindElement(By.CssSelector("div[id='metadata'] div[id='metadata-line'] span"));
                Console.WriteLine("Views= " + videoViews.Text);
                    // Get the video link
                Console.WriteLine(videoTitle.GetAttribute("href"));
                    // One blank line for console readability.
                Console.WriteLine("");
                    // Construct the object with all parameters.
                YoutubeVideo videoObject = new YoutubeVideo(videoTitle.Text, channelName.Text, videoViews.Text, videoTitle.GetAttribute("href"));
                    // Enter the video object into the database.
                YoutubeSql.InsertYoutubeVideo(videoObject);
                    // Add the video object to the sortedSet list (in global variables).
                Globals.youtubeVideos.Add(videoObject);
            }
        }

        public static void IndeedJobs()
        {
                // Get the jobs shown on the page.
            IList<IWebElement> allJobs = Globals.driver.FindElements(By.XPath("//a[contains(@class, 'result')]"));
                // From those jobs, get info per job.
            foreach(IWebElement job in allJobs)
            {
                    // Get the job title.
                IWebElement jobTitle = job.FindElement(By.CssSelector("h2[class*='jobTitle'] span[title]"));
                Console.WriteLine("Title= " + jobTitle.Text);
                    // The name of the company.
                IWebElement companyName = job.FindElement(By.CssSelector("span[class='companyName']"));
                Console.WriteLine("Company= " + companyName.Text);
                    // The location of the job/company.
                IWebElement jobLocation = job.FindElement(By.CssSelector("div[class='companyLocation']"));
                Console.WriteLine("Location= " + jobLocation.Text);
                    // The link of the job advertisment.
                Console.WriteLine(job.GetAttribute("href"));
                    // One blank line for console readability.
                Console.WriteLine("");
            }
        }

        public static void BellOfLostSoulsPosts()
        {
                // div class="column-posts" =posts table.
            IList<IWebElement> allPosts = Globals.driver.FindElements(By.TagName("article"));
            foreach (IWebElement post in allPosts)
            {
                    // Find the title tag of the post, and the text under it.
                IWebElement postTitle = post.FindElement(By.TagName("h2"));
                Console.WriteLine("Title= " + postTitle.Text);
                    // Find the tag with the autor, then the name (without reading time).
                IWebElement postAuthor = post.FindElement(By.CssSelector("span[class='sub-title'] a"));
                Console.WriteLine("Author= " + postAuthor.Text);
                    // Find the Url tag, then the a tag under it for the href.
                IWebElement postUrl = post.FindElement(By.CssSelector("div[class='entry-media']")).FindElement(By.TagName("a"));
                Console.WriteLine(postUrl.GetAttribute("href"));
                    // Print 1 empty line for console readability
                Console.WriteLine();
            }
                // Click away (christmas) ad video.
            System.Threading.Thread.Sleep(8000);
            AcceptPopupButtons.TryAll();
        }
    }
}
