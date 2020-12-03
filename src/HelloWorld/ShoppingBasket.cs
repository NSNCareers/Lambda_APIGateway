using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace src.HelloWorld
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class ShoppingBasket
    {
        private static Dictionary<string,int> shoppingCat = new Dictionary<string, int>();

        private static dbContextHandler db = new dbContextHandler();

        public async Task<bool> PutItemInBasket(Basket basket)
        {
            var dbContext = db.ConfigureDB();
            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }
            else if (await dbContext.FindAsync<Basket>(basket.itemName)!=null)
            {
                return false;
            }else
            {
                try
                {
                    //shoppingCat.Add(basket.itemName,basket.itemQuantity);
                    var set = dbContext.Set<Basket>();
                    set.Add(basket);
                    await dbContext.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return true;
        }

        public IAsyncEnumerable<Basket> GetItemsInBasket()
        {
            var dbContext = db.ConfigureDB();
            try
            {
                
                var results = dbContext.Basket.AsAsyncEnumerable();
                return results;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }

         public async Task<Basket> GetItemFromBasketID(Basket basket)
        {
            var dbContext = db.ConfigureDB();

            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }else
            {
                 try
            {
                //shoppingCat.TryGetValue(basket.itemName,out int Quantity);
                var set = dbContext.Set<Basket>();
                var Quantity = await set.FindAsync(basket.itemName);
                return Quantity;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            }
        }

        public async Task<bool> UpdateBasket(Basket basket)
        {
            var dbContext = db.ConfigureDB();
            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }else
            {
                 try
            {
                //shoppingCat[basket.itemName]=basket.itemQuantity;
                var set = dbContext.Set<Basket>();
                set.Update(basket);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            }
        }

        public async Task<bool> RemoveItemFromBasket(Basket basket)
        {
            var dbContext = db.ConfigureDB();
            
            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }else
            {
                 try
            {
                shoppingCat.Remove(basket.itemName);
                await dbContext.SaveChangesAsync();
                return true;
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