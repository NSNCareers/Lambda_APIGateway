using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using src.HelloWorld;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace HelloWorld
{

    public class Function
    {
        private ShoppingBasket shop = new ShoppingBasket();

        public APIGatewayProxyResponse AddItemToCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.Body);  
            var results = shop.PutItemInBasket(requestBody);
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
                    Body = $"Successfully added item: {requestBody.itemName}",
                    Headers = {{"Content-Type","application/json"}}
                }; 
            }

            return result;
        }

         public APIGatewayProxyResponse GetItemsFromCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var results = shop.GetItemsInBasket();
            APIGatewayProxyResponse result;
            var count = results.Count;

            if (count==0)
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
                    Body = $"Successfully retrieved {count} items from Cat"
                }; 
            }

            return result;
        }

        public APIGatewayProxyResponse UpdateItemInCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.Body);  
            var results = shop.UpdateBasket(requestBody);
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

         public APIGatewayProxyResponse DeleteItemInCart(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.Body);  
            var results = shop.RemoveItemFromBasket(requestBody);
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

         public APIGatewayProxyResponse GetItemFromCartWithId(APIGatewayProxyRequest request, ILambdaContext context)
        {
            
            var requestBody = JsonConvert.DeserializeObject<Basket>(request.PathParameters["itemName"]);  
            var results = shop.RemoveItemFromBasket(requestBody);
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
