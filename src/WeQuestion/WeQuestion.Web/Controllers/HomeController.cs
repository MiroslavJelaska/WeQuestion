using System.Web.Mvc;
using WeQuestion.Domain.Queries;

namespace WeQuestion.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(GetAllSurveysQuery getAllSurveysQuery)
        {
            _getAllSurveysQuery = getAllSurveysQuery;
        }

        private readonly GetAllSurveysQuery _getAllSurveysQuery;


        public ActionResult Index()
        {
            return View();
        }
    }
}
