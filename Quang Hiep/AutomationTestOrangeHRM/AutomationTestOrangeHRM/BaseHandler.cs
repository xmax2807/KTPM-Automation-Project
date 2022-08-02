using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTestOrangeHRM
{
    public class BaseHandler
    {
        string loginUrl = "http://localhost/orangehrm-4.5/orangehrm-4.5/symfony/web/index.php/auth/login";
        public IWebDriver driver;

        [Test]
        public void Login()
        {
            driver = new ChromeDriver("D:\\chrome");
            driver.Url = loginUrl; 
            driver.Manage().Window.Maximize();
            IWebElement usernameTextBox = driver.FindElement(By.Id("txtUsername"));
            usernameTextBox.Click();
            usernameTextBox.SendKeys("vuhiep");

            IWebElement passwordTextBox = driver.FindElement(By.Id("txtPassword"));
            passwordTextBox.Click();
            passwordTextBox.SendKeys("n3WP@ssWaaa111");

            IWebElement loginBtn = driver.FindElement(By.Id("btnLogin"));
            loginBtn.Click();
        }
    }
}
