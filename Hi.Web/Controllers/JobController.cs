using Job.Common;
using Job.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Hi.Web.Controllers
{
    public class JobController : Controller
    {      
        public ActionResult Index()
        {
            return View();
        }  
        public ActionResult Messg()
        {
            return View();
        }   
    }     
}
