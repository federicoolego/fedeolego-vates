using System;
using Core.Extension;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using SeleniumExtras.PageObjects;

namespace Core
{
    public abstract class CommonsFunctions
    {
        public string Title { get; set; }
        public string Url { get; set; }
        protected IWebDriver driver;
        protected AppiumDriver<AppiumWebElement> mobileDriver;
        protected Boolean isMobile = false;

        public void GoToUrl()
        {
            AppSettingsConfiguration appSettings = new AppSettingsConfiguration();

            switch (appSettings.Enviroment)
            {
                case "dev":
                    driver.Navigate().GoToUrl(EnviromentUrl.dev);
                    break;
                case "test":
                    driver.Navigate().GoToUrl(EnviromentUrl.test);
                    break;
                case "stg":
                    driver.Navigate().GoToUrl(EnviromentUrl.stg);
                    break;
                default:
                    throw new Exception("No existe Url para el ambiente especificado" + appSettings.Enviroment);
            }
        }

        public void PageInit(IWebDriver _driver, object page)
        {
            PageFactory.InitElements(_driver, page);
        }

        public void DriverQuit()
        {
            if (isMobile)
            {
                mobileDriver.Quit();
            }
            else
            {
                driver.Quit();
            }
        }

        public ISearchContext WebDriver
        {
            get
            {
                return driver;
            }
        }

        public void PrintScreen(string fileName, ScreenshotImageFormat imageFormat, string path = null)
        {
            driver.PrintScreen(fileName, imageFormat, path);
        }
    }
}