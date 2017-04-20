
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;

namespace EntryPoint
{
    [TestFixture]
    class EntryPoint
    {

        //public Page Page { get; private set; }
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            wait=new WebDriverWait(driver,TimeSpan.FromMilliseconds(5000));

        }

        [TearDown]

        public void Teardown()
        {
            Console.WriteLine("sTARTING NEXT METHOD");
        }


        public void ElementsDisplayOnHomePage()
        {
            // driver= new ChromeDriver();
            // driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://yahoo.com");
            StringAssert.Contains("Yahoo", driver.Title);


            Assert.True(driver.FindElement(By.Id("uh-search-box")).Displayed);

        }
       


    }

}