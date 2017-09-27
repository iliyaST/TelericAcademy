using System.Web.Mvc;

namespace BirthdaySite.Controllers
{
    public class BirthdaysController : Controller
    {
        public ActionResult Index()
        {           
            return View();
        }
    }
}