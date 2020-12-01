using Newtonsoft.Json;

namespace src.HelloWorld
{
    public class Basket
    {
        [JsonProperty("itemName")]
        public string itemName {get;set;}

        [JsonProperty("itemQuantity")]
        public int itemQuantity {get;set;}
    }
}