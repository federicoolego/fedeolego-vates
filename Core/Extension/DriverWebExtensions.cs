using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Text;
using Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Core.Extension
{
    public static class DriverWebExtensions
    {
        public static bool FindElementIfExists(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void MoveToElement(this IWebDriver driver, IWebElement element)
        {
            Actions select = new Actions(driver);
            select.MoveToElement(element).Click();
            select.Perform();
        }

        public static void MoveToElement(this IWebDriver driver, IWebElement element, int x, int y)
        {
            Actions select = new Actions(driver);
            select.MoveToElement(element, x, y).Click();
            select.Perform();
        }

        public static Boolean Javas(this IWebDriver driver, String jav)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(jav);
            return true;
        }

        public static void DocumentReady(this IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString().Equals("complete");            
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("return document.readyState").toString().equals("complete");
        }

        public static void RemoveAtributte(this IWebDriver driver, IWebElement element, string atributte)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].removeAttribute('" + atributte + "')", element);
        }

        public static void Scroll(this IWebDriver driver)
        {
            Javas(driver, $"window.scrollTo(0,document.body.scrollHeight)");
        }

        public static void Scroll(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        public static void Scroll(this IWebDriver driver, string x, string y)
        {
            Javas(driver, $"window.scrollBy(" + x + ", " + y + ")");
        }

        public static void ScrollUp(this IWebDriver driver)
        {
            Javas(driver, $"window.scrollTo(document.body.scrollHeight,0)");
        }

        public static void PrintScreen(this IWebDriver driver, string fileName, ScreenshotImageFormat imageFormat, string path = null)
        {
            if (String.IsNullOrEmpty(path))
                path = ConfigurationManager.AppSettings["DefaultImagePath"];
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var file = path + fileName + "." + imageFormat.ToString();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(file);
        }

        #region ExplicitWait

        public static IWebElement ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, IWebElement> func)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            return wait.Until(func);
        }

        public static Boolean ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, Boolean> func)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            return wait.Until(func);
        }

        public static void ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, IWebDriver> func)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(func);
        }

        public static IAlert ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, IAlert> func)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            return wait.Until(func);
        }

        public static ReadOnlyCollection<IWebElement> ExplicitWait(this IWebDriver driver, int time, Func<IWebDriver, ReadOnlyCollection<IWebElement>> func)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            return wait.Until(func);
        }

        public static void JSClick(this IWebDriver driver, IWebElement element)
        { 
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()",  element);
        }

        #endregion
        
    }
}
