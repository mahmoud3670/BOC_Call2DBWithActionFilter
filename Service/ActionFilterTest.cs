using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class ActionFilterTest : IActionFilter
    {
        private IConfiguration Configuration;
        private BarcodTaskDBContext _contextFactory;
        private object CustomService { get; } // this must be resolved
        public ActionFilterTest(IConfiguration _configuration, BarcodTaskDBContext contextFactory)
        {
            Configuration = _configuration;
            _contextFactory=contextFactory;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
          
        }

        public  void OnActionExecuting(ActionExecutingContext context)
        {
            var dbname =string.IsNullOrEmpty( context.HttpContext.Request.Query["dbname"])?"con" : context.HttpContext.Request.Query["dbname"].ToString();
            var x = typeof(StringConst).GetField(dbname).GetValue(typeof(string)).ToString();
            var dbContext =(BarcodTaskDBContext) context.HttpContext.RequestServices.GetService(typeof(BarcodTaskDBContext));
            dbContext.ConnectionString=Configuration.GetConnectionString(x);
        }
    }
}
