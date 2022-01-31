﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public class AppSettingsConfiguration
    {
        private string webDriverPath;
        private string mobileDriverPath;
        private string webDriverType;
        private string enviroment;
        private string headdless;
        private string htmlReportsPath;
        private string remoteDriver;
        private string remoteUrl;
        private string urlHub;
        private string evidenciaTestPass;

        public AppSettingsConfiguration()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var config = new ConfigurationBuilder()
            .AddJsonFile(path, false)
            .Build();

            var appSetting = config.GetSection("ReportSection");
            htmlReportsPath = appSetting["HtmlReportsPath"];

            appSetting = config.GetSection("DriverSection");
            webDriverPath = appSetting["WebDriverPath"];
            mobileDriverPath = appSetting["MobileDriverPath"];
            webDriverType = appSetting["WebDriverType"];
            enviroment = appSetting["Enviroment"];
            headdless = appSetting["Headdless"];
            remoteDriver = appSetting["RemoteDriver"];
            remoteUrl = appSetting["RemoteUrl"];
            urlHub = appSetting["UrlHub"];
            evidenciaTestPass = appSetting["EvidenciaTestPass"];
        }

        public string WebDriverPath
        {
            get => webDriverPath;
        }

        public string MobileDriverPath
        {
            get => mobileDriverPath;
        }

        public string WebDriverType
        {
            get => webDriverType;
        }

        public string Enviroment
        {
            get => enviroment;
        }

        public string Headdless
        {
            get => headdless;
        }

        public string HtmlReportsPath
        {
            get => htmlReportsPath;
        }

        public string RemoteDriver
        {
            get => remoteDriver;
        }

        public string RemoteUrl
        {
            get => remoteUrl;
        }

        public string UrlHub
        {
            get => urlHub;
        }

        public string EvidenciaTestPass
        {
            get => evidenciaTestPass;
        }
    }
}
