using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Core;
using Core.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace PagesProject
{
    [SetUpFixture]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        public AppiumDriver<AppiumWebElement> GetMobileDriver(string type)
        {
            return DriverHelper.FactoryMobileDriver(type);
        }

        public IWebDriver GetWebDriver(string browser)
        {
            return DriverHelper.FactoryWebDriver(browser);
        }
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ReportHelper.StartTest();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ReportHelper.GenerateReport();
            KillDriverProcesses();
        }

        protected static IEnumerable<String> BrowserToRunWith()
        {
            String[] browser = { DriverType.Chrome, DriverType.Firefox, DriverType.IExplorer };

            foreach (String b in browser)
            {
                yield return b;
            }
        }

        protected void KillDriverProcesses()
        {
            const string CHROME_DRIVER = "chromedriver";
            string processName = CHROME_DRIVER;

            if (!string.IsNullOrEmpty(processName))
            {
                var processes = Process.GetProcesses().Where(p => p.ProcessName.ToLower() == processName);
                foreach (var process in processes)
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                    }
                }
            }
        }

    }
}
