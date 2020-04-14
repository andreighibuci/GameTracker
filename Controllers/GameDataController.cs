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

        [Route("api/[controller]")]
        public class DrinkDataController : Controller
        {
            private readonly IGameRepository _gameRepository;

            public DrinkDataController(IGameRepository gameRepository)
            {
                _gameRepository = gameRepository;
            }

            [HttpGet]
            public IEnumerable<GameViewModel> LoadMoreGames()
            {
                IEnumerable<Game> dbGames = null;

                dbGames = _gameRepository.Games.OrderBy(p => p.GameId).Take(10);

                List<GameViewModel> games = new List<GameViewModel>();

                foreach (var dbGame in dbGames)
                {
                    games.Add(MapDbGameToGameViewModel(dbGame));
                }
                return games;
            }

            private GameViewModel MapDbGameToGameViewModel(Game dbGame) => new GameViewModel()
            {
                GameId = dbGame.GameId,
                Name = dbGame.Name,
                Price = dbGame.Price,
                ShortDescription = dbGame.ShortDescription,
                ImageThumbnailUrl = dbGame.ThumbnailImgName
            };

        }
}
