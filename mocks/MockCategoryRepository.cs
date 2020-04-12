using GameTracker_release.Interfaces;
using GameTracker_release.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release.mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName ="Multiplayer",Description = "All multiplayer games"},
                    new Category{CategoryName ="Singleplayer",Description="All singleplayer games"}
                };
            }
        }
    }
}
