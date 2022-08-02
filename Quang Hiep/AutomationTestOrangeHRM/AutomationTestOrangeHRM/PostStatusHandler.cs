using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestOrangeHRM
{
    internal class PostStatusHandler:BaseHandler
    {
        public PostStatusHandler()
        {
            Login();
        }

        [Test]
        public void PostStatus(string status)
        {
            IWebElement btnMenuBuzz = driver.FindElement(By.XPath(".//a[@id='menu_buzz_viewBuzz']/b"));
            btnMenuBuzz.Click();

            IWebElement txtPostContent = driver.FindElement(By.Id("createPost_content"));
            txtPostContent.Click();
            txtPostContent.SendKeys(status);

            IWebElement btnSubmit = driver.FindElement(By.Id("postSubmitBtn"));
            btnSubmit.Click();
        }
    }
}
