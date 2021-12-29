using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;

namespace BlazorApp.Api
{
    public static class CosmosFunctionalities
    {
        public static async Task<List<BlazorApp.Shared.User>> GetUsers(string connectionString, string databaseId, string containerId)
        {
            CosmosClient cosmosClient = new CosmosClient(connectionString);
            Container container = cosmosClient.GetContainer(databaseId, containerId);

            string sqlQueryText = "SELECT * FROM c";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);

            FeedIterator<BlazorApp.Shared.User> queryResultSetIterator = container.GetItemQueryIterator<BlazorApp.Shared.User>(queryDefinition);

            List<BlazorApp.Shared.User> users = new List<BlazorApp.Shared.User>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<BlazorApp.Shared.User> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (BlazorApp.Shared.User user in currentResultSet)
                {
                    users.Add(user);
                }
            }

            return users;
        }
    }
}