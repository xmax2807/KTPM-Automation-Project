using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ProjectCaseStudy
{
    public enum Browser
    {
        CHROME, FIREFOX
    }
    public abstract class ConfigurationFixture : IDisposable
    {
        protected abstract Browser Browser { get; }
        protected IWebDriver? _driver;
        public IWebDriver Driver {
            get
            {
                if (_driver == null)
                {
                    switch (Browser)
                    {
                        case Browser.CHROME: 
                            _driver = new ChromeDriver(_driverPath, new ChromeOptions { Proxy = null }); 
                            break;
                        case Browser.FIREFOX:
                            _driver = new FirefoxDriver(_driverPath, new FirefoxOptions { Proxy = null });
                            break;
                    }
                    _driver?.Manage().Window.Maximize();
                }
                return _driver;
            }
            set { _driver = value; }
        }
        protected abstract string _driverPath { get; }
        public IDictionary<string, object> vars { get; private set; }
        public IJavaScriptExecutor js { get; private set; }

        protected virtual void SettingUp() { }
        public ConfigurationFixture()
        {
            js = (IJavaScriptExecutor)Driver;
            vars = new Dictionary<string, object>();
            SettingUp();
        }

        public void Dispose()
        {
            Driver?.Quit();
 
            // Delete temp files after completing the test and closing the Browser
            // source: https://stackoverflow.com/questions/43289035/chromedriver-not-deleting-scoped-dir-in-temp-folder-after-test-is-complete
            string tempfolder = Path.GetTempPath();
            string[] tempfiles = Directory.GetDirectories(tempfolder, "scoped_dir*", SearchOption.AllDirectories);
            foreach (string tempfile in tempfiles)
            {
                try
                {
                    DirectoryInfo directory = new(tempfolder);
                    foreach (DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
                }
                catch
                {
                    // could not delete folders
                }
            }
        }
    }

    public class ConfigurationChromeFixture : ConfigurationFixture
    {
        protected override string _driverPath => "Driver";

        protected override Browser Browser => Browser.CHROME;
    }

    public class ConfigurationFirefoxFixture : ConfigurationFixture
    {
       
        protected override string _driverPath => "Driver";

        protected override Browser Browser => Browser.FIREFOX;
    }

    public class ChromeConfigurationTestSuite1 : ConfigurationChromeFixture
    {
        private const string _username = "xmax2807";
        private const string _password = "Quanghuy@2807";
        protected override void SettingUp()
        {
            //Open web and set up
            Driver.Navigate().GoToUrl("http://localhost/orangehrm/symfony/web/index.php/auth/login");

            //Login
            Driver.FindElement(By.Id("txtUsername")).Click();
            Driver.FindElement(By.Id("txtUsername")).SendKeys(_username);
            Driver.FindElement(By.Id("txtPassword")).Click();
            Driver.FindElement(By.Id("txtPassword")).SendKeys(_password);
            Driver.FindElement(By.Id("txtPassword")).SendKeys(Keys.Enter);

        }
    }
}
