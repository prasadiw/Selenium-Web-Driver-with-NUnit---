using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests
{
    //This class will consist of the entire set of page objects we have.  
    //this is the only class that can communicate with each page.
    public static class Pages
    {

        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Tests.getDriver, page);
            return page;
        }
        public static ContactUs contactUs
        {
            get { return getPages<ContactUs>(); }
        }
    }

}
