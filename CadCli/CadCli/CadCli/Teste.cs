using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadCli
{
    [Controller]
    public class Teste
    {
        [Route("teste/ping")]
        public string Ping()
        {
            return "Pong";
        }

        [Route("ping2")]
        public string Ping2()
        {
            return "Pong 2";
        }

    }
}
