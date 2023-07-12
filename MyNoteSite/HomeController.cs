using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNoteSite.Models;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace MyNoteSite.Controllers
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
                if (Repository.IsRegestrated(collection))
                {
                    foreach (var item in Repository.Responses) {
                        if (item["Login"] == collection["Login"]) 
                        {
                            if (item["Password"]== collection["Password"])
                            {
                                return Redirect("/");
                            }
                            break;
                        }
                    }
                    return View("Пароль не підходить.");
                }
                else
                {
                    return View("Цей логін не зареєстрований.");
                }
                
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
                    if (!Repository.IsRegestrated(collection))
                    {
                        Repository.AddResponse(collection);
                        return Redirect("/Login");
                    }
                    else
                    {
                        return View("Цей логін вже зареєстрований.");
                    }
                }                                 
                return View();
                
            }
            catch
            {
                return View();
            }
        }
    }
}
