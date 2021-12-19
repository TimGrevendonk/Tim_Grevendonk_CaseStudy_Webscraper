using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webscraper.Actions
{
    class ActiveWebsiteSearch
    {
        public static void SearchForYoutubeVideos(String searchTerm)
        {
                // Find the Youtube input field.
            IWebElement searchBarInput = Globals.driver.FindElement(By.Name("search_query"));
                // Enter value in the field and submit it.
            searchBarInput.SendKeys(searchTerm);
            searchBarInput.Submit();
                // Wait for the page to load.
            System.Threading.Thread.Sleep(1000);
                // Find the filters button and click it
            IWebElement filterButton = Globals.driver.FindElement(By.XPath("//*[@id='container']/ytd-toggle-button-renderer/a"));
            filterButton.Click();
            System.Threading.Thread.Sleep(700);
                // Find the "sort by: upload date" button and click it.
            IWebElement uploadDateButton = Globals.driver.FindElement(By.XPath("//*[@id='collapse-content']/ytd-search-filter-group-renderer[5]/ytd-search-filter-renderer[2]/a"));
            uploadDateButton.Click();
            System.Threading.Thread.Sleep(1000);
        }

        public static void SearchForIndeedJobs(String searchCity, String searchJob = "IT")
        {
                // find city input field.
            IWebElement searchBarCityName = Globals.driver.FindElement(By.Id("text-input-where"));
            searchBarCityName.SendKeys(searchCity);
            //
            IWebElement searchBarJobName = Globals.driver.FindElement(By.Id("text-input-what"));
            searchBarJobName.SendKeys(searchJob);
            searchBarJobName.Submit();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
