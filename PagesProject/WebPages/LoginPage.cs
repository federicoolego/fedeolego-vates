using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ClosedXML.Excel;
using Core.Extension;
using OpenQA.Selenium;
using ResourcesAccess;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PagesProject.WebPages
{
    public class LoginPage : HomePage
    {
        #region ELEMENTOS


        #endregion

        public LoginPage(IWebDriver _driver) : base(_driver)
        {

        }

    }
}
