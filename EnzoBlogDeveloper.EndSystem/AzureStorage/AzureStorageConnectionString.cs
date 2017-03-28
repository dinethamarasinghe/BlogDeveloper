using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;

namespace EnzoBlogDeveloper.EndSystem.AzureStorage
{
    public class AzureStorageConnectionString
    {
        static string account = ConfigurationManager.AppSettings["StorageAccountName"];
        static string key = ConfigurationManager.AppSettings["StorageAccountKey"];
        public static CloudStorageAccount GetConnectionString()
        {
            string connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", account, key);
            return CloudStorageAccount.Parse(connectionString);
        }
    }
}
