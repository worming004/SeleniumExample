using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace ReachSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = // Put url here with port and /wd/hub path
            var driver = new RemoteWebDriver(new Uri(url), (new OpenQA.Selenium.Chrome.ChromeOptions()).ToCapabilities(), TimeSpan.FromSeconds(600));

            try
            {
                PingGoogle(driver);
            }
            finally
            {
                driver.Close();
            }
        }

        static void PingGoogle(IWebDriver driver)
        {
            driver.Navigate()
                .GoToUrl("https://secure.ogone.com/ncol/test/backoffice");

            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = Path.Combine("./Screenshot", DateTime.Now.ToLongDateString() + Guid.NewGuid() + ".jpg");
            if (!Directory.Exists("./Screenshot"))
            {
                Directory.CreateDirectory("./Screenshot");
            }
            ss.SaveAsFile(fileName);
        }
    }
}
