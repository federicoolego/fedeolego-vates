using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Core.Extension
{
    public static class WebElementsExtensions
    {
        public static bool isEnable(this IWebElement element)
        {
            string enable = element.GetAttribute("aria-disabled");
            
            if (bool.Parse(enable))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static void WaitUntilElementIsEnable(this IWebElement element)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(500);
                if (!bool.Parse(element.GetAttribute("aria-disabled")))
                {
                    break;
                }
            }            
        }

        public static void WaitUntilElementIsNotDisable(this IWebElement element)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(500);
                if (!element.GetAttribute("class").Contains("disabled"))
                {
                    break;
                }
            }
        }

        public static void BorrarContenido(this IWebElement element)
        {
            while(element.GetAttribute("value").Length > 0)
            {
                element.SendKeys(Keys.Backspace);
            }
        }
    }
}
