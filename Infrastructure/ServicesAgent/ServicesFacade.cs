using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Infrastructure.ServicesAgent
{
    /// <summary>
    /// Consumption facade for different types of services.
    /// </summary>
    public class ServicesFacade
    {
        /// <summary>
        /// Set object HttpClient with conditions for use MasglobalTestApi.
        /// </summary>
        /// <returns >HttpClient</returns>
        [Obsolete("In a future version will parametrized URI Api, and this class should have singleton pattern =).")]
        public static HttpClient GetClientMasglobalTestApi()
        {
            HttpClient clientHttp = new HttpClient();
            //http://masglobaltestapi.azurewebsites.net/api/Employees

            clientHttp.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/");
            clientHttp.DefaultRequestHeaders.Accept.Clear();
            clientHttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            clientHttp.Timeout = TimeSpan.FromSeconds(10);
            return clientHttp;
        }


    }
}
