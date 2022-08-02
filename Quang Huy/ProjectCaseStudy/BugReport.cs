using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ProjectCaseStudy.Data;
using Xunit;

namespace ProjectCaseStudy
{
    public abstract class BugReport<T> : IClassFixture<T> where T : ConfigurationFixture
    {
        private const string WebURL = "https://cs.hcmus.edu.vn/mantisbt/login_page.php";
        private const string _username = "2022.CLC.Team02.19127425";
        private const string _password = "Quanghuy2807";
        private readonly T Fixture;
        public BugReport(T fixture)
        {
            Fixture = fixture;
            Setup_Login(_username, _password);
        }

        private void Setup_Login(string username, string password) {
            Fixture.Driver.Navigate().GoToUrl(WebURL);
            Fixture.Driver.FindElement(By.Name("username")).SendKeys(username);
            Fixture.Driver.FindElement(By.Name("password")).Click();
            Fixture.Driver.FindElement(By.Name("password")).SendKeys(password);
            Fixture.Driver.FindElement(By.Name("password")).SendKeys(Keys.Enter);
            Fixture.Driver.FindElement(By.Name("project_id")).Click();
            {
                var dropdown = Fixture.Driver.FindElement(By.Name("project_id"));
                dropdown.FindElement(By.XPath("//option[. = '19CLC.Team02']")).Click();
            }
        }

        private static List<object[]> ReadFile(string filePath)
        {
            List<object[]> result = new();
            
            if (!System.IO.File.Exists(filePath)) return result;

            var data = System.IO.File.ReadAllLines(filePath);

            for (int i = 1; i < data.Length; i++)
            {
                var dataclass = BugReportData.Parse(data[i], ",");
                if (dataclass == null) continue;
                result[i] = new object[] { dataclass };
            }

            return result;
        }

        private const string filePath = "Data\\bug_port.csv";
        public static IEnumerable<object[]> GetData()
        {
            return ReadFile(filePath);
        }

        public void AddBugReport(BugReportData data)
        {
            Fixture.Driver.FindElement(By.LinkText("Report Issue")).Click();
            Fixture.Driver.FindElement(By.Name("category_id")).Click();
            {
                var dropdown = Fixture.Driver.FindElement(By.Name("category_id"));
                dropdown.FindElement(By.XPath("//option[. = '[All Projects] General']")).Click();
            }
            Fixture.Driver.FindElement(By.Name("reproducibility")).Click();
            {
                var dropdown = Fixture.Driver.FindElement(By.Name("reproducibility"));
                dropdown.FindElement(By.XPath($"//option[. = '{data.Reproducibility}']")).Click();
            }
            Fixture.Driver.FindElement(By.Name("severity")).Click();
            {
                var dropdown = Fixture.Driver.FindElement(By.Name("severity"));
                dropdown.FindElement(By.XPath($"//option[. = '{data.Severity}']")).Click();
            }
            Fixture.Driver.FindElement(By.Name("priority")).Click();
            {
                var dropdown = Fixture.Driver.FindElement(By.Name("priority"));
                dropdown.FindElement(By.XPath($"//option[. = '{data.Priority}']")).Click();
            }
            
            Fixture.Driver.FindElement(By.Name("handler_id")).Click();
            {
                var dropdown = Fixture.Driver.FindElement(By.Name("handler_id"));
                dropdown.FindElement(By.XPath("//option[. = '2022.CLC.Team02.19127425']")).Click();
            }
            Fixture.Driver.FindElement(By.Name("summary")).Click();
            Fixture.Driver.FindElement(By.Name("summary")).SendKeys($"{data.Summary}");
            Fixture.Driver.FindElement(By.Name("description")).Click();
            Fixture.Driver.FindElement(By.Name("description")).SendKeys($"{data.Description}");
            Fixture.Driver.FindElement(By.Name("steps_to_reproduce")).Click();
            Fixture.Driver.FindElement(By.Name("steps_to_reproduce")).SendKeys($"{data.Steps}");
            Fixture.Driver.FindElement(By.Name("additional_info")).Click();
            Fixture.Driver.FindElement(By.Name("additional_info")).SendKeys($"{data.Addition}");
            Fixture.Driver.FindElement(By.CssSelector(".button")).Click();
        }
    }

    public class BugReport : BugReport<ConfigurationChromeFixture>
    {
        public BugReport(ConfigurationChromeFixture fixture) : base(fixture)
        {
        }
    }
}
