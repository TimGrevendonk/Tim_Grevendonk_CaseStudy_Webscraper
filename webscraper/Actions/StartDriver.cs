using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webscraper.Actions
{
    class StartDriver
    {
        public static void Website(String site)
        {
                // Add the option to disable system logging and add the driver path.
            // -----logging still active, find alternative way-----
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"../../.." + "/Drivers/");
            service.SuppressInitialDiagnosticInformation = true;
                // Use the chromedriver.exe in the Drivers folder, and the options.
            ChromeDriver Driver = new ChromeDriver(service);
            Driver.Manage().Window.Maximize();
                // set the timeout value to 10 seconds (will wait until items are loaded for a max of 10 seconds).
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                // Go to the website.
            Driver.Navigate().GoToUrl(site);
                // return the driver object.
            Globals.driver = Driver;
        }
    }
}
