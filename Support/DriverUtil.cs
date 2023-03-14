using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBaseFramework
{
    public class DriverUtil
    {
        IWebDriver driver;

        public void setDriver(IWebDriver driver)
        {
            this.driver= driver;
        }
        public IWebDriver launchBrowser()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
            return driver;
        }
        public void navigateToUrl(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

    }
}
