using GameTracker_release.Interfaces;
using GameTracker_release.Models;
using GameTracker_release.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IGameRepository gameRepository, ShoppingCart shoppingCart)
        {
            _gameRepository = gameRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int gameid)
        {
            var selectedGame = _gameRepository.Games.FirstOrDefault(p => p.GameId == gameid);
            if(selectedGame != null)
            {
                _shoppingCart.AddToCart(selectedGame,1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int gameid)
        {
            var selectedGame = _gameRepository.Games.FirstOrDefault(p => p.GameId == gameid);
            if(selectedGame!= null)
            {
                _shoppingCart.RemoveFromCart(selectedGame);
            }

            return RedirectToAction("Index");
        }
        
    }
}
