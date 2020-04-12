using GameTracker_release.Interfaces;
using GameTracker_release.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _appDbContext;
        public GameRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }
        public IEnumerable<Game> Games => _appDbContext.Games.Include(c => c.Category);
        public IEnumerable<Game> PrefeeredGames => _appDbContext.Games.Where(p => p.isPrefeeredGame).Include(c => c.Category);


        public Game GetGameById(int gameid) => _appDbContext.Games.FirstOrDefault(p => p.GameId == gameid);
       
    }
}
