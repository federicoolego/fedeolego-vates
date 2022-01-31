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

        [FindsBy(How = How.XPath, Using = "//a[text()=' Apertura de cuentas']")]
        private IWebElement btnAperturaCuenta;
        [FindsBy(How = How.XPath, Using = "//a[text()=' Clientes']")]
        private IWebElement btnClientes;

        #region Filtros
        [FindsBy(How = How.XPath, Using = "//span[text()=' filter_alt ']")]
        private IWebElement btnFiltrar;


        [FindsBy(How = How.XPath, Using = "//mat-icon[text()='search']")]
        private IWebElement btnBuscar;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='buscadorSolicitud']")]
        private IWebElement inputBuscar;

        [FindsBy(How = How.XPath, Using = "//mat-expansion-panel-header/span/mat-panel-title[text()=' Estado ']")]
        private IWebElement panelEstado;
        [FindsBy(How = How.XPath, Using = "//span[text()='Pendiente de aprobación']/../div")]
        private IWebElement checkPendienteAprobacion;
        [FindsBy(How = How.XPath, Using = "//span[text()='Aceptado']/../div")]
        private IWebElement checkAceptado;
        [FindsBy(How = How.XPath, Using = "//span[text()='Rechazado']/../div")]
        private IWebElement checkRechazado;
        [FindsBy(How = How.XPath, Using = "//span[text()='Cuenta operativa']/../div")]
        private IWebElement checkCuentaOperativa;

        [FindsBy(How = How.XPath, Using = "//span[text()='Filtrar']")]
        private IWebElement btnAplicarFiltros;

        [FindsBy(How = How.XPath, Using = "//mat-icon[text()='more_vert']")]
        private IWebElement btnAceptarRechazarSolicitud;
        [FindsBy(How = How.XPath, Using = "//button/span[text()='Aceptar']")]
        private IWebElement btnAceptarSolicitud;
        [FindsBy(How = How.XPath, Using = "//button/span[text()='Rechazar']")]
        private IWebElement btnRechazarSolicitud;
        [FindsBy(How = How.XPath, Using = "//span[text()='Aceptar solicitudes']")]
        private IWebElement btnAceptarSolicitudes;
        [FindsBy(How = How.XPath, Using = "//span[text()='Rechazar solicitudes']")]
        private IWebElement btnRechazarSolicitudes;


        [FindsBy(How = How.XPath, Using = "//span[text()='Aprobar']")]
        private IWebElement btnAprobar;



        #endregion

        #endregion

        public LoginPage(IWebDriver _driver) : base(_driver)
        {

        }

    }
}
