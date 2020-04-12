

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameTracker_release.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingClass> ShoppingCartItems { get; set; }
        
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Game game, int amount)
        {
            var shoppingCartItem = _appDbContext.ShoppingClass.SingleOrDefault(
                    s => s.Game.GameId == game.GameId && s.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingClass
                {
                    ShoppingCartId = ShoppingCartId,
                    Game = game,
                    Amount = 1
                };
                _appDbContext.ShoppingClass.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Game game)
        {
            var shoppingCartItem = _appDbContext.ShoppingClass.SingleOrDefault(
                    s => s.Game.GameId == game.GameId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem == null)
            {
               if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingClass.Remove(shoppingCartItem);
                }
                
            }                      
            _appDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingClass> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems =
                           _appDbContext.ShoppingClass.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Game).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingClass
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);
            _appDbContext.ShoppingClass.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingClass.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Game.Price * c.Amount).Sum();
            return total;
        }

    }
 }

