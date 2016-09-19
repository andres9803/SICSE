using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sicse.Controllers
{
    public class plantillaController : Controller
    {
        // GET: plantilla
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult plantillaAdministrador()
        {
            return View();
        }

        public ActionResult plantillaCoordinador()
        {
            return View();
        }

        public ActionResult plantillaInspector()
        {
            return View();
        }

        public ActionResult plantillaIngeniero()
        {
            return View();
        }
    }
}