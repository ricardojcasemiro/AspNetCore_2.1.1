﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Controllers
{
    public class HomeController: Controller
    {
        
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult About() => View();
    }
}
