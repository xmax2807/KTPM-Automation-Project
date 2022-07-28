using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ProjectCaseStudy
{
    public abstract class ConfigurationFixture : IDisposable
    {
        protected IWebDriver? _driver;
        public abstract IWebDriver Driver { get; set; }
        protected abstract string _driverPath { get; }
        public IDictionary<string, object> vars { get; private set; }
        public IJavaScriptExecutor js { get; private set; }

        //account for login (you can change these)
        private readonly string _username = "xmax2807";
        private readonly string _password = "Quanghuy@2807";
        public ConfigurationFixture()
        {
            js = (IJavaScriptExecutor)Driver;
            vars = new Dictionary<string, object>();

            SetUp_Login(_username, _password);
        }

        public void Dispose()
        {
            Driver.Quit();
        }

        private void SetUp_Login(string username, string password)
        {
            //Open web and set up
            Driver.Navigate().GoToUrl("http://localhost/orangehrm/symfony/web/index.php/auth/login");

            //Login
            Driver.FindElement(By.Id("txtUsername")).Click();
            Driver.FindElement(By.Id("txtUsername")).SendKeys(username);
            Driver.FindElement(By.Id("txtPassword")).Click();
            Driver.FindElement(By.Id("txtPassword")).SendKeys(password);
            Driver.FindElement(By.Id("txtPassword")).SendKeys(Keys.Enter);
        }
    }

    public class ConfigurationChromeFixture : ConfigurationFixture
    {
        public override IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver(_driverPath, new ChromeOptions { Proxy = null });
                    _driver.Manage().Window.Maximize();
                }
                return _driver;
            }
            set { _driver = value; }
        }

        protected override string _driverPath => "Driver";
    }

    public class ConfigurationFirefoxFixture : ConfigurationFixture
    {
        public override IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new FirefoxDriver(_driverPath, new FirefoxOptions { Proxy = null });
                    _driver.Manage().Window.Maximize();
                }
                return _driver;
            }
            set { _driver = value; }
        }

        protected override string _driverPath => "Driver";
    }
}
