
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using GameTracker_release.Models;
using Microsoft.AspNetCore.Builder;

namespace GameTracker_release.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Games.Any())
            {
                context.AddRange
                (
                    new Game
                    {
                        Name = "Witcher 3",
                        Price = 7.95M,
                        Category = Categories["Singleplayer"],
                        InStock = true,                        
                        ShortDescription = "Enter a new massive rpg world",
                        LongDescription = " Become Geralt of Rivia and slay your monsters for money. Witcher 3 is an massive open world game, and it is one of the greatest. Relive that era and save your daughter.",                       
                        Imageurl = "https://img-eshop.cdn.nintendo.net/i/3d7d3f78ddc3afd1bc5f924b4e078426467ee94423b8a27f876052f016a487ae.jpg?w=1000",
                        ThumbnailImgName = "Witcher3_img.jpg",               
                        isPrefeeredGame = true
                    },
                     new Game
                     {
                         Name = "Gears of war",
                         Price = 1.00M,
                         ShortDescription = "Time to fight for survival",
                         LongDescription = "Gears of war is an old game, but it is one of the best. This 3rd person shooter game is allready a brand itself as series developed further up to six games at the moment. In this game you have to fight for the survival of the planet as there is a new species on earth and this species almost exterminate human race.",
                         Category = Categories["Singleplayer"],
                         Imageurl = "https://icdn3.digitaltrends.com/image/digitaltrends/gears-of-war-4-featured.jpg",
                         ThumbnailImgName = "GearsOfWar_img.jpg",
                         InStock = true,
                         isPrefeeredGame = false
                     },
                    new Game
                    {
                        Name = "Prey",
                        Price = 10.99M,
                        ShortDescription = "It is not easy to live among aliens",
                        LongDescription = "Do you want to feel as a cat overruned by a dog ? Then Prey is your game. It is exciting and nervous. This game knows how to shake you down and tear apart. It is not about humanity nor aliens but it is in the same time. This games is about you running down a ship full of alliens and has an exciting finale.",
                        Category = Categories["Singleplayer"],
                        Imageurl = "https://s.yimg.com/uu/api/res/1.2/B_zkHHb5eUeL1BMOv2fl3g--~B/dz0xODAwO2g9MTAxMzthcHBpZD15dGFjaHlvbg--/https://o.aolcdn.com/hss/storage/midas/e7092f626fb47e432c449ab8b732968a/206443466/moon1-ed.jpg",
                        ThumbnailImgName = "Prey_img.jpg",
                        InStock = true,
                        isPrefeeredGame = true
                    },
                     new Game
                     {
                         Name = "Spider-Man",
                         Price = 25.00M,
                         ShortDescription = "Who is your favorite super-hero ?",
                         LongDescription = "Are you a ready to embark on this new spider-man journey ? Then it's time for you to become the friendly-neighbourhood spider and fight against crime and vilany. Or be Peter Parker and help Aunt May. Live a new story brought by Marvel Studios, don't miss it buy it now",
                         Category = Categories["Singleplayer"],
                         Imageurl = "https://images.squarespace-cdn.com/content/5ae5edddf407b4362a8852cb/1536964064787-T0PD8JGKL5DXEALHF4E0/spider-man-puddle-1131908.jpeg?content-type=image%2Fjpeg",
                         ThumbnailImgName = "SpiderMan_img.jpg",
                         InStock = true,
                         isPrefeeredGame = true
                     },
                     new Game
                     {
                         Name = "The Last Of Us",
                         Price = 5.99M,
                         ShortDescription = "Survive the horror",
                         LongDescription = "Crawl for your live, fight for your survival. It's a matter of life of death. Are you ready to take the survival of the mankind upon your shoulders ? Then it's time for you to embark on this epic journey and survive. This game is a masterpiece and has allready won multiple awards. Take it now and prove your man enough",
                         Category = Categories["Singleplayer"],
                         Imageurl = "https://cdn.vox-cdn.com/thumbor/JDCeC5UoVn024wUnj6JVq4iBqcg=/0x0:1000x555/1200x800/filters:focal(420x198:580x358)/cdn.vox-cdn.com/uploads/chorus_image/image/60067105/the_last_of_us.0.png",
                         ThumbnailImgName = "TheLastOfUs_img.jpg",
                         InStock = true,
                         isPrefeeredGame = false
                     },
                      new Game
                      {
                          Name = "God Of War",
                          Price = 20.99M,
                          ShortDescription = "Become God of War and face Odin and Thor",
                          LongDescription = "God of War is an action-adventure game developed by Santa Monica Studio and published by Sony Interactive Entertainment (SIE). Released on April 20, 2018, for the PlayStation 4 (PS4), it is the eighth installment in the God of War series, the eighth chronologically, and the sequel to 2010's God of War III. Unlike previous games, which were loosely based on Greek mythology, this installment is rooted in Norse mythology, with the majority of it set in ancient Norway in the realm of Midgard. For the first time in the series, there are two protagonists: Kratos, the former Greek God of War who remains the only playable character, and his young son Atreus. Following the death of Kratos' second wife and Atreus' mother, they journey to fulfill her request that her ashes be spread at the highest peak of the nine realms. Kratos keeps his troubled past a secret from Atreus, who is unaware of his divine nature. Along their journey, they encounter monsters and gods of the Norse world. ",
                          Category = Categories["Singleplayer"],
                          Imageurl = "https://psmedia.playstation.com/is/image/psmedia/god-of-war-screen-05-ps4-eu-16jun17?$MediaCarousel_Original$",
                          ThumbnailImgName = "GodOfWar_img.jpg",
                          InStock = true,
                          isPrefeeredGame = false
                      },
                    new Game
                    {
                        Name = "Red Dead Redemption 2",
                        Price = 50.00M,
                        ShortDescription = "Live as an outlaw, die like a dog",
                        LongDescription = "Red Dead Redemption 2[a] is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and is a prequel to the 2010 game Red Dead Redemption. The story is set in 1899 in a fictionalized representation of the Western, Midwestern and Southern United States and follows outlaw Arthur Morgan, a member of the Van der Linde gang. Arthur must deal with the decline of the Wild West whilst attempting to survive against government forces, rival gangs, and other adversaries. The story also follows fellow gang member John Marston, the protagonist of Red Dead Redemption.",
                        Category = Categories["Singleplayer"],
                        Imageurl = "https://static.techspot.com/images2/news/bigimage/2018/12/2018-12-19-image-18.jpg",
                        InStock = true,
                        isPrefeeredGame = true,
                        ThumbnailImgName = "RedDeadRedemption_img.jpg"
                    },
                   new Game
                   {
                       Name = "Fortnite",
                       Price = 00.00M,
                       ShortDescription = "Call your friends and start play now",
                       LongDescription = "Fortnite is an online video game developed by Epic Games and released in 2017. It is available in three distinct game mode versions that otherwise share the same general gameplay and game engine: Fortnite: Save the World, a cooperative shooter-survival game for up to four players to fight off zombie-like creatures and defend objects with fortifications they can build; Fortnite Battle Royale, a free-to-play battle royale game where up to 100 players fight to be the last person standing; and Fortnite Creative, where players are given complete freedom to create worlds and battle arenas. The first two-game modes were released in 2017 as early access titles and Creative was released on December 6, 2018. Save the World is available only for Windows, macOS, PlayStation 4, and Xbox One, while Battle Royale and Creative released for those platforms, in addition for Nintendo Switch, iOS and Android devices.",
                       Category = Categories["Multiplayer"],
                       Imageurl = "https://psmedia.playstation.com/is/image/psmedia/fortnite-battle-royale-screen-04-ps4-en-13may19_1557736731566?$MediaCarousel_Original$",
                       InStock = true,
                       isPrefeeredGame = false,
                       ThumbnailImgName = "Fortnite_img.jpg"
                   },

                     new Game
                     {
                         Name = "World of Warcraft",
                         Price = 50.00M,
                         ShortDescription = "Ooh..Who on this world haven't heard about Warcraft",
                         LongDescription = "World of Warcraft (WoW) is a massively multiplayer online role-playing game (MMORPG) released in 2004 by Blizzard Entertainment. It is the fourth released game set in the Warcraft fantasy universe.[3] World of Warcraft takes place within the Warcraft world of Azeroth, approximately four years after the events at the conclusion of Blizzard's previous Warcraft release, Warcraft III: The Frozen Throne.[4] The game was announced in 2001, and was released for the 10th anniversary of the Warcraft franchise on November 23, 2004. Since launch, World of Warcraft has had eight major expansion packs produced for it: The Burning Crusade, Wrath of the Lich King, Cataclysm, Mists of Pandaria, Warlords of Draenor, Legion, Battle for Azeroth and Shadowlands.",
                         Category = Categories["Multiplayer"],
                         Imageurl = "https://venturebeat.com/wp-content/uploads/2020/01/wow-vulpera.jpg?fit=1280%2C720&strip=all",
                         InStock = true,
                         isPrefeeredGame = true,
                         ThumbnailImgName = "wow_img.jpg"
                     },
                    new Game
                    {
                        Name = "Call Of Duty Warzone",
                        Price = 00.00M,
                        ShortDescription = "Enjoy a nice clean kill",
                        LongDescription = "Call of Duty: Warzone is a 2020 free-to-play battle royale video game released on March 10, 2020, for Xbox One, PlayStation 4, and PC. The game is a part of the 2019 title Call of Duty: Modern Warfare, but does not require purchase of it. Warzone was developed by Infinity Ward and Raven Software and published by Activision.[1] Warzone allows online multiplayer combat among 150 players set in the fictional city of Verdansk, which is loosely based on Donetsk city in Eastern Ukraine.[2] The game features both cross-platform play and cross-platform progression between both games.",
                        Category = Categories["Multiplayer"],
                        Imageurl = "https://res.cloudinary.com/lmn/image/upload/c_limit,h_360,w_640/e_sharpen:100/f_auto,fl_lossy,q_auto/v1/gameskinnyc/c/a/l/call-duty-warzone-buy-stations-everything-you-need-know-d8d71.jpg",
                        InStock = true,
                        isPrefeeredGame = true,
                        ThumbnailImgName = "COD_img.jpg"
                    },
                    new Game
                    {
                        Name = "Assassins Creed : Odyssey",
                        Price = 15.00M,
                        ShortDescription = "Time to rise and shine for your creed",
                        LongDescription = "Assassin's Creed is an action-adventure stealth video game franchise created by Patrice Désilets, Jade Raymond and Corey May, developed mainly by Ubisoft Montreal using the game engine Anvil and its more advanced derivatives. It depicts a centuries-old struggle, now and then, between the Assassins, who fight for peace with free will, and the Templars, who desire peace through control. The series features historical fiction, science fiction and characters, intertwined with real-world historical events and figures. For the majority of time players control an Assassin in the past history, while they also play as Desmond Miles or an Assassin Initiate in the present day, who hunt down their Templar targets.",
                        Category = Categories["Singleplayer"],
                        Imageurl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/assassins-creed-odyssey-1547743453.jpgerything-you-need-know-d8d71.jpg",
                        InStock = true,
                        isPrefeeredGame = true,
                        ThumbnailImgName = "Assassins_img.jpg"
                    }

                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Singleplayer", Description="All singleplayer games" },
                        new Category { CategoryName = "Multiplayer", Description="All multiplayer games" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }

}
