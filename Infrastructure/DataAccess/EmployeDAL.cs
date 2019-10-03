using Infrastructure.ServicesAgent;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure
{
    /// <summary>
    /// Class of data acces layer for employe.
    /// </summary>
    public class EmployeDAL
    {
        /// <summary>
        /// Consume MasglobalTestApi GetEmployees using Service Facade.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetEmployeesAsync()
        {
            string jsonResponse = string.Empty;

            HttpClient client = ServicesFacade.GetClientMasglobalTestApi();
            HttpResponseMessage response = await client.GetAsync("/api/Employees").ConfigureAwait(false);
            
            if (response.IsSuccessStatusCode)
            {
                jsonResponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception("Ups!, i had a problem consuming MasglobalApi. ReasonPhrase:" + response.ReasonPhrase);
            }

            return jsonResponse;
        }

    }
}
