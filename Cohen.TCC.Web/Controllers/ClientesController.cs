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
    public class ClientesController : Controller
    {
        private TCCDbContext db = new TCCDbContext();
        private Utils utils = new Utils();
        // GET: Clientes
        public ActionResult Index()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
               
                return View(db.clientes.ToList().Where(c => c.dt_inativo.ToString() == "01/01/0001 00:00:00"));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cliente cliente = db.clientes.Find(id);
                if (cliente == null)
                {
                    return HttpNotFound();
                }
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {

                ViewBag.id_tipo_cliente = new SelectList(db.tp_clientes.ToList(), "id_tipo_cliente", "nm_tipo");

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_cliente,id_cliente,nm_cliente,nm_email,cnh_cliente,dt_cadastro,dt_inativo")] Cliente cliente)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = new Usuario();

                    cliente.dt_cadastro = DateTime.Now;
                    db.clientes.Add(cliente);
                    string senha = utils.CriaSenha();
                    utils.enviaEmailSenha(cliente, senha);
                    usuario.nm_email = cliente.nm_email;
                    usuario.nm_senha = utils.CodificarSenha(senha);
                    usuario.id_tipo_usuario = 2;
                    usuario.dt_cadastro = DateTime.Now;
                    db.usuarios.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

               // ViewBag.id_cliente = new SelectList(db.veiculos_cliente, "id_cliente", "id_cliente", cliente.id_cliente);
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cliente cliente = db.clientes.Find(id);
                if (cliente == null)
                {
                    return HttpNotFound();
                }
                ViewBag.id_tipo_cliente = new SelectList(db.tp_clientes.ToList(), "id_tipo_cliente", "nm_tipo");
                
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_cliente,id_cliente,nm_cliente,nm_email,cnh_cliente,dt_cadastro,dt_inativo")] Cliente cliente)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (ModelState.IsValid)
                {
                    ViewBag.id_tipo_cliente = new SelectList(db.tp_clientes.ToList(), "id_tipo_cliente", "nm_tipo");
                    db.Entry(cliente).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.id_tipo_cliente = new SelectList(db.tp_clientes.ToList(), "id_tipo_cliente", "nm_tipo", cliente.id_tipo_cliente);
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cliente cliente = db.clientes.Find(id);
                if (cliente == null)
                {
                    return HttpNotFound();
                }
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                Cliente cliente = db.clientes.Find(id);
                db.clientes.Remove(cliente);
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
