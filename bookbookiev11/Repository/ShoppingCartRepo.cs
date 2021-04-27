using bookbookiev11.Data;
using bookbookiev11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookbookiev11.Repository
{
    public class ShoppingCartRepo
    {
        private readonly ApplicationDbContext _Context;

        public ShoppingCartRepo(ApplicationDbContext context)
        {
            context = _Context;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCartRepo GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = service.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("cartId", cartId);

            return new ShoppingCartRepo(context) { ShoppingCartId = cartId };

        }

        public void AddToCart(BookModel book, int amount)
        {
            var shoppingCartItem = _Context.cartItems.SingleOrDefault(s => s.book.Id == book.Id && s.ShoppingCartId == ShoppingCartId);
            
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    book = book,
                    amount = 1
                };
                _Context.cartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.amount++;
            }
            _Context.SaveChanges();
        }
        public int RemoveFromCart(BookModel book)
        {
            var shoppingCartItem = _Context.cartItems.SingleOrDefault(s => s.book.Id == book.Id && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.amount > 1)
                {
                    shoppingCartItem.amount--;
                    localAmount = shoppingCartItem.amount;
                }
                else
                {
                    _Context.cartItems.Remove(shoppingCartItem);
                }
            }
            _Context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _Context.cartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.book).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _Context.cartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _Context.cartItems.RemoveRange(cartItems);

            _Context.SaveChanges();
        }

        public int GetShoppingCartTotal()
        {
            var total = _Context.cartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.book.price * c.amount).Sum();
            return total;
        }
    }
}
