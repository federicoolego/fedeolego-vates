using Core;
using Core.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using PagesProject;
using PagesProject.MobilePages;

namespace MobileTestProject.AndroidPages
{
    [TestFixture]
    public class AndroidCalculatorTest : BaseTest
    {
        public TestContext testContext;
        AndroidCalculator androidCalculator;
        AppiumDriver<AppiumWebElement> driver;


        [SetUp]
        public void Setup()
        {
            testContext = TestContext.CurrentContext;
            driver = GetMobileDriver(DriverType.Android);
            androidCalculator = new AndroidCalculator(driver);
        }


        [TearDown]
        public void TearDown()
        {
            ReportHelper.AddTestToReport(testContext, androidCalculator);
            androidCalculator.DriverQuit();
        }
    }
}
