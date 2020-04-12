using GameTracker_release.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
