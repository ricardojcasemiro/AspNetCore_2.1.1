using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.UI
{
    // 1- fomra -> notação
    //[Controller]
    //public class Teste

    // 2- forma -> convenção
    //public class TesteController

    // 3- forma -> herança
    public class Teste: Controller
    {
        // [Route("teste/ping")] -> com o "app.UseMvcWithDefaultRoute()" não precisa desta notação
        public string Ping()
        {
            var xpto = "Teste";
            return $"Pong {xpto}";  // Interpolação de string em C#
        }
    }
}
