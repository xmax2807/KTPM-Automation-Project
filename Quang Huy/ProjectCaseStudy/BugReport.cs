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
    public class BugReport : IClassFixture<BugReportFixture<Chrome>>
    {
        
        private readonly BugReportFixture<Chrome> Fixture;
        public BugReport(BugReportFixture<Chrome> fixture)
        {
            Fixture = fixture;
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
}
