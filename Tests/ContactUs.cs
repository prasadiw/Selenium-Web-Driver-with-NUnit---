using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    public class ContactUs
    {
        [FindsBy(How = How.Name, Using = "your-name")]
        private IWebElement yourName;

        [FindsBy(How = How.Name, Using = "your-email")]
        private IWebElement yourEmail;
        [FindsBy(How = How.Name, Using = "your-subject")]
        private IWebElement yourSubject;

        [FindsBy(How = How.Name, Using = "your-message")]
        private IWebElement yourMessage;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submit;

        [FindsBy(How = How.ClassName, Using = "wpcf7-response-output")]
        private IWebElement SuccMessage;

        [FindsBy(How = How.Id, Using = "menu-item-1296")]
        private IWebElement contactUs;

        public bool isAt()
        {
            return Tests.Title.Contains("Contact Us");
        }

        public void GoTo()
        {
            contactUs.Click();
        }

        public void SendYourName(string name)
        {
            yourName.Clear();
            yourName.SendKeys(name);
        }

        public void SendYourEmail(string email)
        {
            yourEmail.Clear();
            yourEmail.SendKeys(email);
        }

        public void SendYourSubject(string Subject)
        {
            yourSubject.Clear();
            yourSubject.SendKeys(Subject);
        }

        public void SendYourMessage(string massage)
        {
            yourMessage.Clear();
            yourMessage.SendKeys(massage);
        }

        public void clickSubmit()
        {
            Tests.getWaitDriver.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='submit']")));
            submit.Click();
        }

        public void ValidateMessage()
        {
            try
            {
                var text = SuccMessage.Text;
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
    }
}