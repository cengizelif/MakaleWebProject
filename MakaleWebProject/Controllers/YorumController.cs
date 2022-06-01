using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakaleWebProject.Controllers
{
    public class YorumController : Controller
    {
        // GET: Yorum
        public ActionResult YorumGoster()
        {
            return PartialView("_PartialYorum");
        }
    }
}