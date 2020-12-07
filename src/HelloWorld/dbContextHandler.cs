using System;
using Amazon;
using Amazon.DynamoDBv2;
using Microsoft.EntityFrameworkCore;

namespace src.HelloWorld
{
    public class dbContextHandler
    {
        private  AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();

        public EFContext ConfigureDB()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
                      .UseInMemoryDatabase(databaseName: "BasketDB")
                      .Options;
            var context = new EFContext(options);

            return context;
        }

        public AmazonDynamoDBClient ConfigureDynamoDB()
        {
            clientConfig.RegionEndpoint = RegionEndpoint.EUWest2;
            AmazonDynamoDBClient client = new AmazonDynamoDBClient(clientConfig);

            return client;
        }
    }
}