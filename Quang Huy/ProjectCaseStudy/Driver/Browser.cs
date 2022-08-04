using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCaseStudy
{
    public abstract class Browser
    {

        protected IWebDriver? _driver;
        public abstract IWebDriver Driver { get; }

        protected abstract string _driverPath { get; }
    }

    public class Chrome : Browser
    {
        public override IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver(_driverPath);
                }
                return _driver;
            }
        }

        protected override string _driverPath => "Driver";

    }

    public class Firefox : Browser
    {
        public override IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new FirefoxDriver(_driverPath);
                }
                return _driver;
            }
        }

        protected override string _driverPath => "Driver";

    }
}
