using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace MyNoteSite
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        // POST: HomeController/Login
        [HttpPost]
        public ActionResult Login(IFormCollection collection)
        {
            try
            {
                Debug.WriteLine($"Login = {collection["Login"]} Password={collection["Password"]}");
                return Redirect("/");
            }
            catch
            {
                return View();
            }
        }
        // POST: HomeController/Reg
        [HttpPost]
        public ActionResult Reg(IFormCollection collection)
        {
            try
            {
                Debug.WriteLine($"Login = {collection["Login"]} Password={collection["Password"]} Repeat Password={collection["Password2"]}");
                if(collection["Password"] == collection["Password2"])
                {
                    return Redirect("/Login");

                }
                else 
                { 
                    
                    return Redirect("/Reg");
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
