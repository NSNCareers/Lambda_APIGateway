using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;

namespace src.HelloWorld
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class ShoppingBasket
    {
        private string dynamoDBTable = Environment.GetEnvironmentVariable("TABLE_NAME");
        private dbContextHandler _dbContextHandler = new dbContextHandler();
       

        public async Task<PutItemResponse> PutItemInBasket(Basket basket)
        {
            var client = _dbContextHandler.ConfigureDynamoDB();
            var request = new PutItemRequest
            {
                TableName = dynamoDBTable,
                Item = new Dictionary<string, AttributeValue>
                {
                    {
                        basket.itemName,
                        new AttributeValue
                        {
                            S = basket.itemQuantity
                        }
                    }
                }
            };

            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }
            else
            {
                try
                {
                    //shoppingCat.Add(basket.itemName,basket.itemQuantity);
                    var response = await client.PutItemAsync(request);
                    return response;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<ScanResponse> GetItemsInBasket()
        {
            var client = _dbContextHandler.ConfigureDynamoDB();
            var request = new ScanRequest
            {
                TableName = dynamoDBTable
            };
            try
            {
                
                var results = await client.ScanAsync(request);
                return results;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }

         public async Task<GetItemResponse> GetItemFromBasketID(Basket basket)
        {
            var client = _dbContextHandler.ConfigureDynamoDB();
            var request = new GetItemRequest
            {
                TableName = dynamoDBTable,
                Key = new Dictionary<string, AttributeValue>
                {
                    {
                        basket.itemName,
                        new AttributeValue
                        {
                            S = basket.itemQuantity
                        }
                    }
                }
            };

            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }else
            {
                 try
            {
                //shoppingCat.TryGetValue(basket.itemName,out int Quantity);
                var response = await client.GetItemAsync(request);
                return response;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            }
        }

        public async Task<UpdateItemResponse> UpdateBasket(Basket basket)
        {
            var client = _dbContextHandler.ConfigureDynamoDB();
            var request = new UpdateItemRequest
            {
                TableName = dynamoDBTable,
                Key = new Dictionary<string, AttributeValue>
                {
                    {
                        basket.itemName,
                        new AttributeValue
                        {
                            S = basket.itemQuantity
                        }
                    }
                }
            };
            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }else
            {
                 try
            {
                //shoppingCat[basket.itemName]=basket.itemQuantity;
                var response = await client.UpdateItemAsync(request);

                return response;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            }
        }

        public async Task<DeleteItemResponse> RemoveItemFromBasket(Basket basket)
        {
             var client = _dbContextHandler.ConfigureDynamoDB();
            var request = new DeleteItemRequest
            {
                TableName = dynamoDBTable,
                Key = new Dictionary<string, AttributeValue>
                {
                    {
                        basket.itemName,
                        new AttributeValue
                        {
                            S = basket.itemQuantity
                        }
                    }
                }
            };
            
            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }else
            {
                 try
            {
                var response = await client.DeleteItemAsync(request);
                return response;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            }
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}