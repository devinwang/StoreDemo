using RefactorMe.Services;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace RefactorMe.Controllers
{
    public class ApiController : Controller
    {
        [Dependency]
        public IConsolidatorService service { get; set; }
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProductList(string currencyName, int order, bool desc)
        {
            return Json(
                service.GetProductList(currencyName, (ListOrder)order, desc), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrencyList()
        {
            return Json(
                service.GetCurrencyNames(), JsonRequestBehavior.AllowGet
                );
        }
    }
}