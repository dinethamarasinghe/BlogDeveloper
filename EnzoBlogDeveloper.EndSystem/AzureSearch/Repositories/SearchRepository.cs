using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnzoBlogDeveloper.EndSystem.AzureSearch.Repositories
{
    public class SearchRepository
    {
        private static SearchServiceClient searchClient;
        private static ISearchIndexClient indexClient;

        static SearchRepository()
        {
            string searchServiceName = ConfigurationManager.AppSettings["SearchServiceName"];
            string apiKey = ConfigurationManager.AppSettings["SearchServiceApiKey"];

            searchClient = new SearchServiceClient(searchServiceName, new SearchCredentials(apiKey));
            indexClient = searchClient.Indexes.GetClient("enzoblobsearchindex");
        }


        public DocumentSearchResult GenaralSearch(string searchKey)
        {
            try
            {
                SearchParameters parameters = new SearchParameters() { SearchMode = SearchMode.All };
                return indexClient.Documents.Search(searchKey, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error index: {0}\r\n" + ex.Message);
            }
        }
    }
}
