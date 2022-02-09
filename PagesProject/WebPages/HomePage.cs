using System;
using System.IO;
using System.Threading;
using ClosedXML.Excel;
using Core;
using Core.Extension;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PagesProject.WebPages
{
    public class HomePage : CommonsFunctions
    {
        #region
        //LOGIN
        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement inputEmail;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement inputPassword;
        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement btnLogin;



        #endregion

        public HomePage(IWebDriver _driver)
        {
            driver = _driver;
            PageInit(driver, this);
            GoToUrl();
        }

        public string Login(Usuarios usuario, bool valido)
        {
            GetUsuarios getUsuario = new GetUsuarios(usuario);
            string mensaje = string.Empty;

            driver.ExplicitWait(15, ExpectedConditions.ElementToBeClickable(inputEmail)).SendKeys(getUsuario.Usuario.Email);            
            driver.ExplicitWait(15, ExpectedConditions.ElementToBeClickable(inputPassword)).SendKeys(getUsuario.Usuario.Password);
            btnLogin.Click();

            if (valido)
                mensaje = driver.FindElement(By.XPath("//span[contains(text(),'Products')]")).Text.ToUpper();
            
            else
                mensaje = driver.FindElement(By.XPath("//h3[@data-test='error']")).Text;                            
            
            return mensaje;
        }

    }
}
