using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ProjectCaseStudy
{
    
    public abstract class FixtureBase : IDisposable
    {
        public IWebDriver? Driver {
            get => Browser?.Driver;
        }

        private Browser? _browser;
        public Browser? Browser
        {
            get => _browser; 
            set
            {
                if (_browser != null) return;
                
                _browser = value;
                SettingUp();
            }
        }

        public IDictionary<string, object> vars { get; private set; }
        public IJavaScriptExecutor? js { get; private set; }

        protected virtual void SettingUp() {
        }
        public FixtureBase()
        {
            js = Driver as IJavaScriptExecutor;
            vars = new Dictionary<string, object>();
        }

        public void Dispose()
        {
            Driver?.Quit();
 
            // Delete temp files after completing the test and closing the Browser
            // source: https://stackoverflow.com/questions/43289035/chromedriver-not-deleting-scoped-dir-in-temp-folder-after-test-is-complete
            
            try
            {
                string tempfolder = Path.GetTempPath();
                string[] tempfiles = Directory.GetDirectories(tempfolder, "scoped_dir*", SearchOption.AllDirectories);
                foreach (string tempfile in tempfiles)
                {
                    DirectoryInfo directory = new(tempfolder);
                    foreach (DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);

                }
            }
            catch
            {
                // could not delete folders
            }
        }
    }

    public class TestSuite1Fixture : FixtureBase
    {
        private const string _username = "xmax2807";
        private const string _password = "Quanghuy@2807";

        
        protected override void SettingUp()
        {
            if (Driver == null) { return; }
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

    public class BugReportFixture : FixtureBase
    {
        private const string WebURL = "https://cs.hcmus.edu.vn/mantisbt/login_page.php";
        private const string _username = "2022.CLC.Team02.19127425";
        private const string _password = "Quanghuy2807";
        protected override void SettingUp()
        {
            if (Driver == null) { return; }

            Driver.Navigate().GoToUrl(WebURL);
            Driver.FindElement(By.Name("username")).SendKeys(_username);
            Driver.FindElement(By.Name("password")).Click();
            Driver.FindElement(By.Name("password")).SendKeys(_password);
            Driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
            Driver.FindElement(By.Name("project_id")).Click();
            {
                var dropdown = Driver.FindElement(By.Name("project_id"));
                dropdown.FindElement(By.XPath("//option[. = '19CLC.Team02']")).Click();
            }
        }
    }
}
