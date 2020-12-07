using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using src.HelloWorld;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HelloWorld
{

    public class Function
    {
        private ShoppingBasket shop = new ShoppingBasket();
        private APIGatewayProxyResponse response;

        public async  Task<APIGatewayProxyResponse> AddItemToCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.Body);  
            var results = await shop.PutItemInBasket(requestBody);
            if (results.HttpStatusCode.ToString() != "200")
            {
                response = new APIGatewayProxyResponse
                {
                    StatusCode = (int)results.HttpStatusCode,
                    Body = $"Request was not successfull"
                };
            return response;
            }else
            {
                 response = new APIGatewayProxyResponse
                {
                    StatusCode = (int)results.HttpStatusCode,
                    Body = $"Successfully added item: {requestBody.itemName}"
                };
            return response;
            }
        }

         public APIGatewayProxyResponse GetItemsFromCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var results = shop.GetItemsInBasket();
            if (!results.IsCompletedSuccessfully)
            {
                response = new APIGatewayProxyResponse
                {
                    Body = $"Request was not successfull"
                };
            return response;
            }else
            {
                 response = new APIGatewayProxyResponse
                {
                    Body = $"Successfully retrived items: {results}"
                };
            return response;
            }
        }

        public async  Task<APIGatewayProxyResponse> UpdateItemInCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.Body);  
            var results = await shop.UpdateBasket(requestBody);
            if (results.HttpStatusCode.ToString() != "200")
            {
                response = new APIGatewayProxyResponse
                {
                    StatusCode = (int)results.HttpStatusCode,
                    Body = $"Request was not successfull"
                };
            return response;
            }else
            {
                 response = new APIGatewayProxyResponse
                {
                    StatusCode = (int)results.HttpStatusCode,
                    Body = $"Successfully updated item: {requestBody.itemName}"
                };
            return response;
            }
        }

         public async  Task<APIGatewayProxyResponse> DeleteItemInCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.Body);  
            var results = await shop.RemoveItemFromBasket(requestBody);
            if (results.HttpStatusCode.ToString() != "200")
            {
                response = new APIGatewayProxyResponse
                {
                    StatusCode = (int)results.HttpStatusCode,
                    Body = $"Request was not successfull"
                };
            return response;
            }else
            {
                 response = new APIGatewayProxyResponse
                {
                    StatusCode = (int)results.HttpStatusCode,
                    Body = $"Successfully deleted item: {requestBody.itemName}"
                };
            return response;
            }
        }

         public async  Task<APIGatewayProxyResponse> GetItemFromCartWithId(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.PathParameters["itemName"]);  
            var results = await shop.GetItemFromBasketID(requestBody);
            if (results.HttpStatusCode.ToString() != "200")
            {
                response = new APIGatewayProxyResponse
                {
                    StatusCode = (int)results.HttpStatusCode,
                    Body = $"Request was not successfull"
                };
            return response;
            }else
            {
                 response = new APIGatewayProxyResponse
                {
                    StatusCode = (int)results.HttpStatusCode,
                    Body = $"Successfully retyrieved item: {results}"
                };
            return response;
            }
        }
    }
}
