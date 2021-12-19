using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using webscraper.Views;
using webscraper.Actions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webscraper.Actions
{
    class AcceptPopupButtons
    {
        public static void TryAll()
        {
            
            try
            {
                    // Youtube accept terms.
                Globals.driver.FindElement(By.XPath("//*[@id='content']/div[2]/div[5]/div[2]/ytd-button-renderer[2]")).Click();
            }
            catch {/*Do nothing, just ignore the possible error*/}
            try
            {
                // Indeed confirm cookies.
                Globals.driver.FindElement(By.CssSelector("#cookie-preferences div[class='save-preference-btn-container'] button")).Click();
            }
            catch {/*Do nothing, just ignore the possible error*/}
            try
            {
                // bell of lost souls accpet coockies.
                Globals.driver.FindElement(By.XPath("//*[@id='qc-cmp2-ui']/div[2]/div/button[2]")).Click();
            }
            catch {/*Do nothing, just ignore the possible error*/}
            try
            {
                    // bell of lost souls cancel notifications.
                Globals.driver.FindElement(By.Id("onesignal-slidedown-cancel-button")).Click();
            }
            catch {/*Do nothing, just ignore the possible error*/}
                // wait for popups to fade away.
            System.Threading.Thread.Sleep(1500);
        }

        public static void DismissVideoAdd()
        {
            try
            {
                    // bell of lost soul dismiss (christmas) video add.
                Globals.driver.FindElement(By.CssSelector("div[class='vdrm-section vdrm-node']")).Click();
            }
            catch { Console.WriteLine("no add found");/*Do nothing, just ignore the possible error*/}
        }
    }
}
