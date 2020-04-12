using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release.Models
{
    public class Game
    {
        public int GameId { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Imageurl { get; set;}

        public decimal Price { get; set; }

        public string ThumbnailImgName { get; set; }

        public bool isPrefeeredGame { get; set; }

        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
