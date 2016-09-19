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
    public class administradorController : Controller
    {
        // GET: administrador
        private sicseEntities db = new sicseEntities();

        public ActionResult Index()
        {
            return View();            
        }

        public ActionResult usuariosActivos()
        {
            var consultarUsuarios = from u in db.Usuario
                                    where u.idRol != 2 && u.estado =="ACTIVO"
                                    select u;
            return View(consultarUsuarios.ToList());
        }

        public ActionResult usuariosInactivos()
        {
            var consultarUsuariosInactivos = from u in db.Usuario
                                    where u.idRol != 2 && u.estado == "INACTIVO"
                                    select u;
            return View(consultarUsuariosInactivos.ToList());
        }

        public ActionResult datosAdministrador()
        {
            var consultarDatosAdmon = from u in db.Usuario
                                    where u.idRol == 2
                                    select u;

            return View(consultarDatosAdmon.ToList());
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

    }
}