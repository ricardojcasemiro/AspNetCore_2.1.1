using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Tests
{    
    [TestClass]
    public class HelloWorldTest
    {
        // Tem que ser publico o teste
        // Tem que ser void o método
        [TestMethod]
        public void TestandoAtravesDoHelloWorld()
        {
            //arrange (ambiente do seu teste)
            var helloworld = "valor do helloworld";

            //action (ação a ser testada)
            var random = new Random().Next(0, 4);
            if (random > 3) helloworld = string.Empty;

            //assert (o que esta sendo testado => resultado da action)
            Assert.AreEqual("valor do helloworld", helloworld);
        }
        
    }
}
