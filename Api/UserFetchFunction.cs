using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using BlazorApp.Shared;

namespace BlazorApp.Api
{
    public static class UserFetchFunction
    {
        [FunctionName("GetUsers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<User> users = null;

            try
            {
                string connectionString = System.Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process);
                string databaseId = System.Environment.GetEnvironmentVariable("DatabaseId", EnvironmentVariableTarget.Process);
                string containerId = System.Environment.GetEnvironmentVariable("ContainerId", EnvironmentVariableTarget.Process);
                
                users = await CosmosFunctionalities.GetUsers(connectionString, databaseId, containerId);
            }
            catch (Exception e)
            {
                log.LogError($"Error in GetUsers: {e}");
                var result = new ObjectResult("Error getting users!");
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }      

            return new OkObjectResult(users);
        }
    }
}
