using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sicse.Models;

namespace sicse.Controllers
{
    public class coordinadorController : Controller
    {
        private sicseEntities db = new sicseEntities();

        // GET: coordinador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult proyectos()
        {
            var consultarProyectosActivos = from p in db.Proyecto
                                            select p;

            return View(consultarProyectosActivos.ToList());
        }

        public ActionResult ascensores()
        {
            var consultarEquipos = from e in db.Equipos
                                   where e.tipoEquipo == 1
                                   select e;

            return View(consultarEquipos.ToList());
        }

        public ActionResult escaleras()
        {
            var consultarEquipos = from e in db.Equipos
                                   where e.tipoEquipo == 2
                                   select e;

            return View(consultarEquipos.ToList());
        }

        public ActionResult programacion()
        {
            var consultarProgramaciones = from p in db.Programacion
                                   select p;

            return View(consultarProgramaciones.ToList());
        }
    }
}