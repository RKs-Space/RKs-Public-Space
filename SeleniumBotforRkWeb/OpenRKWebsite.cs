using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.Threading;

namespace SeleniumBotforRkWeb
{
    class OpenRKWebsite
    {
        static void Main(string[] args)
        {
            string szWebSite  = ConfigurationManager.AppSettings["rkWeb"];
            string szfilePath = ConfigurationManager.AppSettings["Screenshot"];
            int closeAppTime = Convert.ToInt32(ConfigurationManager.AppSettings["closeAppTime"]);
            //Always redirecting to My Website
            szWebSite = "https://www.rkdevelops.com";

            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.PageLoadStrategy = PageLoadStrategy.Eager;
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(chromeDriverService, options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(szWebSite);
            driver.Manage().Window.FullScreen();

            //Wait & Take Screenshot of my HomePage and Save to Local
            Thread.Sleep(4500);
            IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div[2]"));
            Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            System.Drawing.Bitmap screenshot = new System.Drawing.Bitmap(new System.IO.MemoryStream(byteArray));
            screenshot.Save(String.Format(szfilePath +"rkdevelops.png", System.Drawing.Imaging.ImageFormat.Png));

            Thread.Sleep(closeAppTime);
            
            driver.Quit();
        }
    }
}
