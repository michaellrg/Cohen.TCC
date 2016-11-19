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
using Cohen.TCC.Web.Models;

namespace Cohen.TCC.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private Utils utils = new Utils();
        private TCCDbContext db = new TCCDbContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                return View(db.usuarios.ToList().Where(c => c.dt_inativo.ToString() == "01/01/0001 00:00:00"));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] == null)
            {
                ViewBag.id_tipo_usuario = new SelectList(db.tp_usuarios.ToList(), "id_tipo_usuario", "nm_nome");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_usuario,id_usuario,nm_email,nm_senha,dt_cadastro,dt_inativo")] Usuario usuario)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] == null)
            {
                if (ModelState.IsValid)
                {
                    string nm_email = usuario.nm_email;

                    if (db.usuarios.SingleOrDefault(user => user.nm_email == nm_email) == null)

                    {
                        usuario.dt_cadastro = DateTime.Now;
                        string nm_senha = utils.CodificarSenha(usuario.nm_senha);
                        usuario.nm_senha = nm_senha;
                        db.usuarios.Add(usuario);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(usuario);
                    }
                }

                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_usuario,id_usuario,nm_email,nm_senha,dt_cadastro,dt_inativo")] Usuario usuario)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                Usuario usuario = db.usuarios.Find(id);
                db.usuarios.Remove(usuario);
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
