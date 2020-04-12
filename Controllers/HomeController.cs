using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameTracker_release.Interfaces;
using GameTracker_release.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameTracker_release.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public HomeController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PrefferedGames = _gameRepository.PrefeeredGames
            };

            return View(homeViewModel);
        }
    }
}