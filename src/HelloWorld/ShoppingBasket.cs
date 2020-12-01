using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace src.HelloWorld
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class ShoppingBasket
    {
        private static Dictionary<string,int> shoppingCat = new Dictionary<string, int>();

        public bool PutItemInBasket(Basket basket)
        {
            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }
            else if (shoppingCat.ContainsKey(basket.itemName))
            {
                return false;
            }else
            {
                try
                {
                    shoppingCat.Add(basket.itemName,basket.itemQuantity);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return true;
        }

        public Dictionary<string,int> GetItemsInBasket()
        {
            try
            {
                return shoppingCat;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
        }

         public int GetItemFromBasketID(Basket basket)
        {
            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }else
            {
                 try
            {
                shoppingCat.TryGetValue(basket.itemName,out int Quantity);
                return Quantity;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            }
        }

        public bool UpdateBasket(Basket basket)
        {
            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }else
            {
                 try
            {
                shoppingCat[basket.itemName]=basket.itemQuantity;
                return true;
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            }
        }

        public bool RemoveItemFromBasket(Basket basket)
        {
            if (basket is null)
            {
                throw new ArgumentNullException(nameof(basket));
            }else
            {
                 try
            {
                shoppingCat.Remove(basket.itemName);
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