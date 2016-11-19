using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cohen.TCC.AcessoDados.Entity.Context;
using Cohen.TCC.Dominio;

namespace Cohen.TCC.Web.Controllers
{
    public class TipoUsuariosController : Controller
    {
        private TCCDbContext db = new TCCDbContext();

        // GET: TipoUsuarios
        public ActionResult Index()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                return View(db.tp_usuarios.ToList().Where(c => c.dt_inativo.ToString() == "01/01/0001 00:00:00"));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.tp_usuarios.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TipoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_usuario,nm_nome,nm_descricao,dt_cadastro,dt_inativo")] TipoUsuario tipoUsuario)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] == null)
            {
                if (ModelState.IsValid)
            {
                tipoUsuario.dt_cadastro = DateTime.Now;
                db.tp_usuarios.Add(tipoUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoUsuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.tp_usuarios.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TipoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_usuario,nm_nome,nm_descricao,dt_cadastro,dt_inativo")] TipoUsuario tipoUsuario)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Entry(tipoUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoUsuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = db.tp_usuarios.Find(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                TipoUsuario tipoUsuario = db.tp_usuarios.Find(id);
            db.tp_usuarios.Remove(tipoUsuario);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
