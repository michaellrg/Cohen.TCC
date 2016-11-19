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
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Cohen.TCC.Web.Controllers
{
    public class TipoClientesController : Controller
    {
        private TCCDbContext db = new TCCDbContext();

        // GET: TipoClientes
        public ActionResult Index()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                return View(db.tp_clientes.ToList().Where(c => c.dt_inativo.ToString() == "01/01/0001 00:00:00"));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoClientes/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TipoCliente tipoCliente = db.tp_clientes.Find(id);
                if (tipoCliente == null)
                {
                    return HttpNotFound();
                }
                return View(tipoCliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoClientes/Create
        public ActionResult Create()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TipoClientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_cliente,nm_tipo,nm_descricao,dt_cadastro,dt_inativo")] TipoCliente tipoCliente)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        tipoCliente.dt_cadastro = DateTime.Now;
                        db.tp_clientes.Add(tipoCliente);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
                return View(tipoCliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TipoCliente tipoCliente = db.tp_clientes.Find(id);
                if (tipoCliente == null)
                {
                    return HttpNotFound();
                }
                return View(tipoCliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TipoClientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_cliente,nm_tipo,nm_descricao,dt_cadastro,dt_inativo")] TipoCliente tipoCliente)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tipoCliente).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(tipoCliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TipoCliente tipoCliente = db.tp_clientes.Find(id);
                if (tipoCliente == null)
                {
                    return HttpNotFound();
                }
                return View(tipoCliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TipoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                TipoCliente tipoCliente = db.tp_clientes.Find(id);
                db.tp_clientes.Remove(tipoCliente);
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
