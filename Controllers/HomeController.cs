using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    
    public class HomeController : Controller
    {
        private IConfiguration Configuration;
        private BarcodTaskDBContext _contextFactory;
     
        public HomeController(IConfiguration _configuration, BarcodTaskDBContext contextFactory)
        {
            Configuration = _configuration;
            _contextFactory=contextFactory;
        }

        [ServiceFilter(typeof(ActionFilterTest))]
        public IActionResult Index(string? dbname= "con")
        {

            return Ok(new { data=_contextFactory.EntityForm.ToList()});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}