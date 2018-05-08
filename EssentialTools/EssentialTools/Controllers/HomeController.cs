using EssentialTools.Models;
using System.Web.Mvc;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        private IValueCalculator calc;
        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }
        public ActionResult Index()
        {
            //创建用于与Ninject进行通信的内核实例
            //IKernel ninjectKernel = new StandardKernel();
            //绑定接口与其对应的实现方法
            //ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            //Get（）方法告诉Ninject用户感兴趣的接口，返回To（）方法指定的实例
            //IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();

            //IValueCalculator calc = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(calc) { Products = products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}