using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WC7.Data;

namespace WC7.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext _context;

        public string ShoppingCartId { get; set; } // Session-based Id for the cart.
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        private ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            // Brings in support for sessions outside controller.
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId }; // Invokes private constructor.
        }

        public void AddToCart(Screening screening, byte amount)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                s => s.Screening.Id == screening.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null) {
                shoppingCartItem = new ShoppingCartItem {
                    ShoppingCartId = ShoppingCartId,
                    Screening = screening,
                    Amount = amount
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            } else {
                shoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }

        public int RemoveFromCart(Screening screening)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                s => s.Screening.Id == screening.Id && s.ShoppingCartId == ShoppingCartId);

            var amount = 0;

            if (shoppingCartItem != null) {
                if (shoppingCartItem.Amount > 1) {
                    shoppingCartItem.Amount--;
                    amount = shoppingCartItem.Amount;
                } else {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();

            return amount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            // ShoppingCartItems is null on every new request.
            if (ShoppingCartItems is null) {
                ShoppingCartItems = _context.ShoppingCartItems
                    .Where(c => c.ShoppingCartId == ShoppingCartId)
                    .Include(s => s.Screening)
                    .ToList();
            }

            return ShoppingCartItems;
        }

        public void ClearCart()
        {
            var cartItems = _context
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }
    }
}
