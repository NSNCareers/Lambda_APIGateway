using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

namespace HelloWorld.Tests
{
    public class FunctionTest
  {

    [Fact]
    public async  Task AddItemTest()
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
            var response = await function.AddItemToCart(request, context);

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse.Body, response.Body);
    }

    [Fact]
    public void GetItemTest()
    {

            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext();

            var function = new Function();
            var response = function.GetItemsFromCart(request, context);

             var expectedResponse = new APIGatewayProxyResponse
            {
              StatusCode = 200,
              Body = $"Successfully retrieved items{response} from Cat"
            };

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse.Body, response.Body);
    }

    [Fact]
    public async  Task DeleteItemTest()
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
            var response = await function.DeleteItemInCart(request, context);

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async  Task UpdateItemTest()
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
            var response = await function.UpdateItemInCart(request, context);

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse, response);
    }

    [Fact]
    public async  Task GetItemWithIdTest()
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
            var response = await function.GetItemFromCartWithId(request, context);

            Assert.Equal(expectedResponse.StatusCode, response.StatusCode);
            Assert.Equal(expectedResponse, response);
    }
  }
}