using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityAndBundleConfing.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}