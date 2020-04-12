using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameTracker_release.Controllers
{
    public class ContactController:Controller
    {
        public ViewResult index()
        {
            return View();
        }
    }
}
