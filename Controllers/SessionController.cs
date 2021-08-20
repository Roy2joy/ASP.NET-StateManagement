using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StateProj.Models;

using Microsoft.AspNetCore.Http; //for the use of session
using Newtonsoft.Json; //for JsonConvert


namespace StateProj.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Test(string name, string pwd)
        {
            string localname = name;
            if ((name == "abc1" || name=="abc2" || name == "abc3") && pwd == "123")
            {
                User obj = new User
                {
                    name = "test user:"+localname,
                    pwd = "1234"
                };

                //-------------------------------------session code --(store 2 variable in session)

                //to store single value.
                HttpContext.Session.SetString("name", name); 
                /*to store object,you have to convert it into string,for that you can use seriailization
                 *technique ,convert object in series of string(like JSON stringigy in JS)
                 */
                HttpContext.Session.SetString("item",JsonConvert.SerializeObject(obj) ); 

                
                return RedirectToAction("Display");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public IActionResult Display()
        {
            if (HttpContext.Session.GetString("name") != null && HttpContext.Session.GetString("name") !="")
            {
                var user = JsonConvert.DeserializeObject<User>( HttpContext.Session.GetString("item") );
                
                ViewBag.temp = HttpContext.Session.GetString("name");
                ViewBag.UserName = user.name;
                ViewBag.Pwd = user.pwd;
            }
            else
            {
                ViewBag.temp = "anonymous";
            }
            return View();
        }

        public IActionResult DeleteCookie()
        {
            
            
            if (HttpContext.Session.GetString("name") != null)
            {
                HttpContext.Session.SetString("name", "");
                HttpContext.Session.SetString("item", "");

            }
            return RedirectToAction("Display");
        }
    }
}
