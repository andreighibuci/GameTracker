using GameTracker_release.Interfaces;
using GameTracker_release.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release.mocks
{
    public class MockGameRepository : IGameRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Game> Games { get
            {
                return new List<Game>
                {
                new Game
                {
                    Name = "Witcher 3 : Wild Hunt",
                    Price =10.99M, ShortDescription = "Enter a new massive rpg world",
                    LongDescription= " Become Geralt of Rivia and slay your monsters for money. Witcher 3 is an massive open world game, and it is one of the greatest. Relive that era and save your daughter.",
                    Category = _categoryRepository.Categories.Last(),
                    Imageurl = "https://img-eshop.cdn.nintendo.net/i/3d7d3f78ddc3afd1bc5f924b4e078426467ee94423b8a27f876052f016a487ae.jpg?w=1000",
                    ThumbnailImgName = "Witcher3_img.jpg",
                    InStock = true,
                    isPrefeeredGame = true   
                },
                new Game
                {
                    Name = "Gears of war",
                    Price =1.00M, ShortDescription = "Time to fight for survival",
                    LongDescription= "Gears of war is an old game, but it is one of the best. This 3rd person shooter game is allready a brand itself as series developed further up to six games at the moment. In this game you have to fight for the survival of the planet as there is a new species on earth and this species almost exterminate human race.",
                    Category = _categoryRepository.Categories.Last(),
                    Imageurl = "https://icdn3.digitaltrends.com/image/digitaltrends/gears-of-war-4-featured.jpg",
                    ThumbnailImgName = "GearsOfWar_img.jpg",
                    InStock = true,
                    isPrefeeredGame = false
                },
                 new Game
                {
                    Name = "Prey",
                    Price =10.99M, ShortDescription = "It is not easy to live among aliens",
                    LongDescription= "Do you want to feel as a cat overruned by a dog ? Then Prey is your game. It is exciting and nervous. This game knows how to shake you down and tear apart. It is not about humanity nor aliens but it is in the same time. This games is about you running down a ship full of alliens and has an exciting finale.",
                    Category = _categoryRepository.Categories.Last(),
                    Imageurl = "https://s.yimg.com/uu/api/res/1.2/B_zkHHb5eUeL1BMOv2fl3g--~B/dz0xODAwO2g9MTAxMzthcHBpZD15dGFjaHlvbg--/https://o.aolcdn.com/hss/storage/midas/e7092f626fb47e432c449ab8b732968a/206443466/moon1-ed.jpg",
                    ThumbnailImgName = "Prey_img.jpg",
                    InStock = true,
                    isPrefeeredGame = true
                }
                };
            }
            set => throw new NotImplementedException(); }
        public IEnumerable<Game> PrefeeredGames { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Game GetGameById(int gameid)
        {
            throw new NotImplementedException();
        }
    }
}
