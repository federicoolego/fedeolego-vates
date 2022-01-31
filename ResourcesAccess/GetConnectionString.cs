using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace ResourcesAccess
{
    public static class GetConnectionString
    {
        private static AppSettingsConfiguration config = new AppSettingsConfiguration();
        private static string environment = config.Enviroment;
        private static string tstConnection = "Connection string ambiente test";
        private static string devConnection = "Connection string ambiente dev";
        private static string stgConnection = "Connection string ambiente stg";

        public static string GetConnectionStringByEnviroment()
        {
            switch (environment)
            {
                case "dev":
                    return devConnection;
                case "test":
                    return tstConnection;
                case "stg":
                    return stgConnection;
                default:
                    throw new Exception($"La variable 'Enviroment' ({environment}) en el archivo de configuración no corresponde a los esperados (dev, test o stg). ");
            }
        }
    }
}
