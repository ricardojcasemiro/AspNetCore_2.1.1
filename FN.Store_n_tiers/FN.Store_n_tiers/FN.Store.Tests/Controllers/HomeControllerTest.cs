using FN.Store.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Tests.Controllers
{
    [TestClass]
    [TestCategory("HomeController")]
    public class HomeControllerTest
    {
        /// <summary>
        /// Dado um HomeController
        /// </summary>
        [TestMethod]
        public void OMetodoIndexDeveRetornarUmaView()
        {
            // arrange
            var homeCtrl = new HomeController();

            // action
            var result = homeCtrl.Index();

            // assert
            Assert.AreEqual(typeof(ViewResult), result.GetType()); // Compara o tipo do retorno do objeto
        }

    }
}
