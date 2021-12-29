# Azure static web app demo with Blazor

This repo contains Azure static web app demo with Blazor. It is based on existing template, but adds query from Cosmos DB.

If you want to test this out then you have to:
0. Create Static Web App as the [instructions](https://aka.ms/blazor-swa/quickstart) say
1. Create create CosmosDB resource
2. Create DB and container to there
3. Add User(s) to container
4. Set the Settings -> Configuration values in Static Web App resource for `ConnectionString`, `DatabaseId` and `ContainerId`