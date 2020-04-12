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
    public class GameController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;
        public GameController(ICategoryRepository categoryRepository, IGameRepository gameRepository)
        {
            _categoryRepository = categoryRepository;
            _gameRepository = gameRepository;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Game> games;

            string currentCategory = string.Empty;

            if(string.IsNullOrEmpty(category)){
                games = _gameRepository.Games.OrderBy(n => n.GameId);
                currentCategory = "All games";
            }
            else
            {
                if (string.Equals("Singleplayer", _category, StringComparison.OrdinalIgnoreCase))
                {
                    games = _gameRepository.Games.Where(p => p.Category.CategoryName.Equals("Singleplayer")).OrderBy(n => n.GameId);
                }
                else
                    games = _gameRepository.Games.Where(p => p.Category.CategoryName.Equals("Multiplayer")).OrderBy(n => n.GameId);
                currentCategory = _category;
            }

            var gameListViewModel = new GameListViewModel
            {
                Games = games,
                CurrentCategory = currentCategory
            };
           
            return View(gameListViewModel);

        }

      
    }
}
