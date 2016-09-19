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
    public class usuarioController : Controller
    {
        private sicseEntities db = new sicseEntities();

        // GET: usuario
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Administrador).Include(u => u.Coordinador).Include(u => u.Inspector).Include(u => u.Rol);
            return View(usuario.ToList());
        }

        // GET: usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: usuario/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Administrador, "idAdministrador", "tipoadmon");
            ViewBag.idUsuario = new SelectList(db.Coordinador, "idCoordinador", "Descripcion");
            ViewBag.idUsuario = new SelectList(db.Inspector, "idInspector", "Tipo");
            ViewBag.idRol = new SelectList(db.Rol, "idRol", "nombre");
            return View();
        }

        // POST: usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,nombres,primerApellido,segundoApellido,tipoDocumento,documento,correo,clave,estado,telefono,celular,idRol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Administrador, "idAdministrador", "tipoadmon", usuario.idUsuario);
            ViewBag.idUsuario = new SelectList(db.Coordinador, "idCoordinador", "Descripcion", usuario.idUsuario);
            ViewBag.idUsuario = new SelectList(db.Inspector, "idInspector", "Tipo", usuario.idUsuario);
            ViewBag.idRol = new SelectList(db.Rol, "idRol", "nombre", usuario.idRol);
            return View(usuario);
        }

        // GET: usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuario = new SelectList(db.Administrador, "idAdministrador", "tipoadmon", usuario.idUsuario);
            ViewBag.idUsuario = new SelectList(db.Coordinador, "idCoordinador", "Descripcion", usuario.idUsuario);
            ViewBag.idUsuario = new SelectList(db.Inspector, "idInspector", "Tipo", usuario.idUsuario);
            ViewBag.idRol = new SelectList(db.Rol, "idRol", "nombre", usuario.idRol);
            return View(usuario);
        }

        // POST: usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,nombres,primerApellido,segundoApellido,tipoDocumento,documento,correo,clave,estado,telefono,celular,idRol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Administrador, "idAdministrador", "tipoadmon", usuario.idUsuario);
            ViewBag.idUsuario = new SelectList(db.Coordinador, "idCoordinador", "Descripcion", usuario.idUsuario);
            ViewBag.idUsuario = new SelectList(db.Inspector, "idInspector", "Tipo", usuario.idUsuario);
            ViewBag.idRol = new SelectList(db.Rol, "idRol", "nombre", usuario.idRol);
            return View(usuario);
        }

        // GET: usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult registrarCoordinador()
        {

            Rol rol = new Rol();
            rol.idRol = 2;

            Usuario usuario = new Usuario();

            usuario.nombres = Request.Params["nombres"];
            usuario.primerApellido = Request.Params["primerApellido"];
            usuario.segundoApellido = Request.Params["segundoApellido"];
            usuario.tipoDocumento = Request.Params["tipoDocumento"];
            usuario.documento = long.Parse(Request.Params["documento"]);
            usuario.correo = Request.Params["correo"];
            usuario.clave = Request.Params["clave"];
            usuario.estado = Request.Params["estado"];
            usuario.telefono = long.Parse(Request.Params["telefono"]);
            usuario.celular = long.Parse(Request.Params["celular"]);
            usuario.estado = "ACTIVO";
            usuario.idRol = rol.idRol;
            db.Usuario.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult registrarInspector()
        {

            Rol rol = new Rol();
            rol.idRol = 3;

            Usuario usuario = new Usuario();

            usuario.nombres = Request.Params["nombres"];
            usuario.primerApellido = Request.Params["primerApellido"];
            usuario.segundoApellido = Request.Params["segundoApellido"];
            usuario.tipoDocumento = Request.Params["tipoDocumento"];
            usuario.documento = long.Parse(Request.Params["documento"]);
            usuario.correo = Request.Params["correo"];
            usuario.clave = Request.Params["clave"];
            usuario.estado = Request.Params["estado"];
            usuario.telefono = long.Parse(Request.Params["telefono"]);
            usuario.celular = long.Parse(Request.Params["celular"]);
            usuario.idRol = rol.idRol;
            db.Usuario.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult registrarIngeniero()
        {

            Rol rol = new Rol();
            rol.idRol = 4;

            Usuario usuario = new Usuario();

            usuario.nombres = Request.Params["nombres"];
            usuario.primerApellido = Request.Params["primerApellido"];
            usuario.segundoApellido = Request.Params["segundoApellido"];
            usuario.tipoDocumento = Request.Params["tipoDocumento"];
            usuario.documento = long.Parse(Request.Params["documento"]);
            usuario.correo = Request.Params["correo"];
            usuario.clave = Request.Params["clave"];
            usuario.estado = Request.Params["estado"];
            usuario.telefono = long.Parse(Request.Params["telefono"]);
            usuario.celular = long.Parse(Request.Params["celular"]);
            usuario.idRol = rol.idRol;
            db.Usuario.Add(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
