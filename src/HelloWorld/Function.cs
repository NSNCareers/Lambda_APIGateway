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

        public async  Task<APIGatewayProxyResponse> AddItemToCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.Body);  
            var results = await shop.PutItemInBasket(requestBody);
            APIGatewayProxyResponse result;

            if (!results)
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"{requestBody.itemName} already exist in shopping cart",
                    Headers = {{"Content-Type","application/json"}}
                };
            }
            else
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"Successfully added item: {requestBody.itemName}"
                }; 
            }

            return result;
        }

         public APIGatewayProxyResponse GetItemsFromCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var results = shop.GetItemsInBasket();
            APIGatewayProxyResponse result;

            if (results==null)
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"No Items exist in shopping cart"
                };
            }
            else
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"Successfully retrieved items{results}"
                }; 
            }

            return result;
        }

        public async  Task<APIGatewayProxyResponse> UpdateItemInCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.Body);  
            var results = await shop.UpdateBasket(requestBody);
            APIGatewayProxyResponse result;

            if (!results)
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"{requestBody.itemName} does not exist in shopping cart"
                };
            }
            else
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"Successfully updated item: {requestBody.itemName}"
                }; 
            }

            return result;
        }

         public async  Task<APIGatewayProxyResponse> DeleteItemInCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.Body);  
            var results = await shop.RemoveItemFromBasket(requestBody);
            APIGatewayProxyResponse result;

            if (!results)
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"{requestBody.itemName} does not exist in shopping cart"
                };
            }
            else
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"Successfully deleted item: {requestBody.itemName}"
                }; 
            }

            return result;
        }

         public async  Task<APIGatewayProxyResponse> GetItemFromCartWithId(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.PathParameters["itemName"]);  
            var results = await shop.RemoveItemFromBasket(requestBody);
            APIGatewayProxyResponse result;

            if (!results)
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"{requestBody.itemName} does not exist in shopping cart"
                };
            }
            else
            {
                result = new APIGatewayProxyResponse
                {
                    StatusCode = 200,
                    Body = $"Successfully deleted item: {requestBody.itemName}"
                }; 
            }

            return result;
        }
    }
}
