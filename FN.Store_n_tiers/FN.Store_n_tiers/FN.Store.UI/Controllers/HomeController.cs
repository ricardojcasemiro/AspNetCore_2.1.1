using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Controllers
{
    public class HomeController: Controller
    {
        
        //public ViewResult Index()        
        public IActionResult Index()
        {
            return View();
            // return Json(new { }); // Exemplo pra quebrar o teste da homecontroller, pois não retorna uma View mais
        }

        public ViewResult About() => View();
    }
}
