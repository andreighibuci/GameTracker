using GameTracker_release.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Game> PrefferedGames{ get; set; }
    }
}
