using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OuiFund.WebAPI;
using OuiFund.WebAPI.Controllers;

namespace OuiFund.WebAPI.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disposer
            HomeController controller = new HomeController();

            // Agir
            ViewResult result = controller.Index() as ViewResult;

            // Affirmer
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
