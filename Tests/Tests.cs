using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Remote;
using System.Configuration;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        //Public Page Page{get; private set;}
        //public Page Page { get; private set; }
        private static IWebDriver driver;
        private static WebDriverWait wait;

        private static string baseURL = ConfigurationManager.AppSettings["url"];
        private static string browser = ConfigurationManager.AppSettings["browser"];
        private static string dataFilePath = ConfigurationManager.AppSettings["dataPath"];

        [SetUp]
        public void Setup()
        {
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
            driver.Navigate().GoToUrl(baseURL);
        }

        [TearDown]

        public void Teardown()
        {
            Console.WriteLine("STARTING NEXT METHOD");
            driver.Close();
        }

        [Test]
        public void ElementsDisplayOnHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
            wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("body")));
            StringAssert.Contains("Yahoo", driver.Title);
            Assert.True(driver.Url.Equals("https://www.yahoo.com/"));
            Assert.AreEqual("https://www.yahoo.com/", driver.Url);


            Assert.True(driver.FindElement(By.Id("uh-search-box")).Displayed);

        }

        [Test]
        public void Searching()
        {
            driver.Navigate().GoToUrl("http://yahoo.com");
            IWebElement element = driver.FindElement(By.Id("uh-search-box"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("uh-search-box")));
            element.SendKeys("selenium");
            element.SendKeys(Keys.Enter);

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("results")));
            StringAssert.Contains("Yahoo Search", driver.Title);


        }

//****************page object model****************

        [Test]
        public void NavigateToContactPage()
        {
            Pages.contactUs.GoTo();
            Assert.True(Pages.contactUs.isAt());
        }

        [Test]
        public void SendContactMessage()
        {
            Pages.contactUs.GoTo();
            Pages.contactUs.SendYourName("abc");
            Pages.contactUs.SendYourEmail("abc@email.com");
            Pages.contactUs.SendYourSubject("subject");
            Pages.contactUs.SendYourMessage("message");
            Pages.contactUs.clickSubmit();
            Pages.contactUs.ValidateMessage();
        }

        [Test]
        public void SendContactMessageFromCSV()
        {
            Pages.contactUs.GoTo();
            List<string> data = new List<string>();
            data = Servers.general.loadCsvFile(dataFilePath);

            for (int i = 0; i < data.Count; i++)
            {
                var values = data[i].Split(',');
                
                Pages.contactUs.SendYourName(values[0]);
                Pages.contactUs.SendYourEmail(values[1]);
                Pages.contactUs.SendYourSubject(values[2]);
                Pages.contactUs.SendYourMessage(values[3]);
                Pages.contactUs.clickSubmit();
                Pages.contactUs.ValidateMessage();
            }
        }

        public static string Title
        {
            get { return driver.Title; }
        }

        public static IWebDriver getDriver
        {
            get { return driver; }
        }

        public static WebDriverWait getWaitDriver
        {
            get { return wait; }
        }


    }
}
