using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Core.Helpers
{
    public static class ReportHelper
    {
        private static AppSettingsConfiguration config = new AppSettingsConfiguration();
        private static string filePath = Path.Combine(Directory.GetCurrentDirectory(), config.HtmlReportsPath);
        private static string fileName = String.Format("Reporte {0}", DateTime.Now.ToString("dd MMM yyyy HHmmss"));
        private static string ReporteImgPath = @"img\";
        private static string imgPath = $@"{filePath}{fileName}\{ReporteImgPath}";
        private static ExtentHtmlReporter htmlReport = new ExtentHtmlReporter($@"{filePath}{fileName}\{fileName}");
        private static ExtentReports ExtentReport =  new ExtentReports();
        private static List<List<string>> imagesAndDetails = new List<List<string>>();
        private static DateTime startTest;
        private static string EvidenciaPass = config.EvidenciaTestPass;

        public static void StartTest()
        {
            DeleteDirectory();
            ConfigureDirectories();
            ExtentReport.AttachReporter(htmlReport);
            startTest = DateTime.Now;
        }

        public static void AddTestToReport(TestContext testContext, CommonsFunctions page)
        {            
            string testName = testContext.Test.Name;

            if (string.IsNullOrEmpty(testName))
            {
                testName = testContext.Test.MethodName;
            }

            ExtentTest test = ExtentReport.CreateTest(testName);           
            test.Model.StartTime = startTest;
            var status = testContext.Result.Outcome.Status;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-ES");

            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            var testClassName = testContext.Test.ClassName.Split('.').Last().Replace("Test", "");
            test.AssignCategory(testClassName);            

            foreach (var item in imagesAndDetails)
            {
                test.Log(Status.Info, item[1], MediaEntityBuilder.CreateScreenCaptureFromPath(ReporteImgPath + item[0]).Build());
            }

            if (Convert.ToBoolean(EvidenciaPass) || logstatus == Status.Fail || logstatus == Status.Warning)
            {
                var _fileName = String.Format("{0}_{1}_{2}", logstatus, testName, DateTime.Now.ToString("yyyyMMdd_HHmm"));
                page.PrintScreen(_fileName, ScreenshotImageFormat.Jpeg, imgPath);
                var file = ReporteImgPath + _fileName + "." + ScreenshotImageFormat.Jpeg;
                test.Log(logstatus, testContext.Result.Message);
                test.Log(logstatus, "El test ha finalizado con estado " + logstatus, MediaEntityBuilder.CreateScreenCaptureFromPath(file).Build());

            }
            else
            {
                test.Log(logstatus, "El test ha finalizado con estado " + logstatus);
            }

            imagesAndDetails.Clear();
        }        

        public static void GenerateReport()
        {
            ExtentReport.Flush();
        }

        /// <summary>
        /// Add screenshot of the current execution moment.
        /// Can add details as string (optionally).
        /// </summary>
        /// <param name="imageName"></param>
        /// <param name="details"></param>
        public static void AddScreenCaptureToStep(CommonsFunctions page, string imageName, string details = "")
        {
            ConfigureDirectories();
            imageName = imageName + "_" + DateTime.Now.ToString("dd MMM yyyy HHmmss");
            page.PrintScreen(imageName, ScreenshotImageFormat.Jpeg, imgPath);

            List<string> imgDetails = new List<string>();
            imgDetails.Add(imageName + ".jpeg");
            imgDetails.Add(details);
            imagesAndDetails.Add(imgDetails);
        }

        public static void DeleteDirectory()
        {
            var directories = Directory.GetDirectories(filePath);

            foreach (var item in directories)
            {
                string _path = imgPath.Replace("\\img\\", "");
                if (item != _path)
                {
                    Directory.Delete(item, true);
                }
            }
        }

        private static void ConfigureDirectories()
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            if (!Directory.Exists(imgPath))
            {
                Directory.CreateDirectory(imgPath);
            }
        }
    }
}
