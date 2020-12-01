using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

namespace HelloWorld.Tests
{
  public class FunctionTest
  {

    [Fact]
    public void AddItemTest()
    {
            var jsonString = @"
            {
              'itemName':'Bread',
              'itemQuantity': 32
            }
            ";

            var itemName = "Bread";

            var request = new APIGatewayProxyRequest
            {
              Body = jsonString,
            };
            var context = new TestLambdaContext();

            var expectedResponse = new APIGatewayProxyResponse
            {
              StatusCode = 200,
              Body = $"Successfully added item: {itemName}"
            };

            var function = new Function();
            var response = function.AddItemToCart(request, context);

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse.Body, response.Body);
    }

    [Fact]
    public void GetItemTest()
    {
            var count = 1;

            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext();

            var expectedResponse = new APIGatewayProxyResponse
            {
              StatusCode = 200,
              Body = $"Successfully retrieved {count} items from Cat"
            };

            var function = new Function();
            var response = function.GetItemsFromCart(request, context);

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse.Body, response.Body);
    }

    [Fact]
    public void DeleteItemTest()
    {
           var jsonString = @"
            {
              'itemName':'Bread',
              'itemQuantity': 40,
            }
            ";

            var itemName = "Bread";

            var request = new APIGatewayProxyRequest
            {
              Body = jsonString,
            };
            var context = new TestLambdaContext();

            var expectedResponse = new APIGatewayProxyResponse
            {
              StatusCode = 200,
              Body = $"Successfully deleted item: {itemName}"
            };

            var function = new Function();
            var response = function.DeleteItemInCart(request, context);

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public void UpdateItemTest()
    {
           var jsonString = @"
            {
              'itemName':'Bread',
              'itemQuantity': 40,
            }
            ";

            var itemName = "Bread";

            var request = new APIGatewayProxyRequest
            {
              Body = jsonString,
            };
            var context = new TestLambdaContext();

            var expectedResponse = new APIGatewayProxyResponse
            {
              StatusCode = 200,
              Body = $"Successfully updated item: {itemName}"
            };

            var function = new Function();
            var response = function.UpdateItemInCart(request, context);

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public void GetItemWithIdTest()
    {
           var dictionary = new Dictionary<string,string>
           {
             {"itemName","Bread"}
           };

            var itemName = "Bread";

            var request = new APIGatewayProxyRequest
            {
              PathParameters=dictionary
            };
            var context = new TestLambdaContext();

            var expectedResponse = new APIGatewayProxyResponse
            {
              StatusCode = 200,
              Body = $"Successfully updated item: {itemName}"
            };

            var function = new Function();
            var response = function.GetItemFromCartWithId(request, context);

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse, response);
    }
  }
}