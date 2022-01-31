using Core;
using Core.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using PagesProject;
using PagesProject.WebPages;
using System;

namespace WebTestProject.ExampleTest
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        TestContext testContext;
        LoginPage loign;
        IWebDriver driver;


        [SetUp]
        public void Initialize()
        {
            testContext = TestContext.CurrentContext;
            driver = GetWebDriver(DriverType.Chrome);
            loign = new LoginPage(driver);
        }

        [Test]
        [TestCase(TestName = "Login No Valido - Vates", Category = "Login, test")]
        public void LoginNoValidoVates()
        {     
          string mensaje = loign.Login(Usuarios.LockedOut, false);
          Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", mensaje);
        }

        [Test]
        [TestCase(TestName = "Login Valido - Vates", Category = "Login, test")]
        public void LoginValidoVates()
        {
            string mensaje = loign.Login(Usuarios.Standard, true);
            Assert.AreEqual("PRODUCTS", mensaje);
        }

        [TearDown]
        public void CleanUp()
        {
            ReportHelper.AddTestToReport(testContext, loign);
            loign.DriverQuit();
        }
    }
}
