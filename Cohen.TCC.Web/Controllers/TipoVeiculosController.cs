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
    public class TipoVeiculosController : Controller
    {
        private TCCDbContext db = new TCCDbContext();

        // GET: TipoVeiculos
        public ActionResult Index()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                return View(db.tp_veiculos.ToList().Where(c => c.dt_inativo.ToString() == "01/01/0001 00:00:00"));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoVeiculos/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVeiculo tipoVeiculo = db.tp_veiculos.Find(id);
            if (tipoVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipoVeiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoVeiculos/Create
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

        // POST: TipoVeiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_veiculo,nm_tipo,nm_descricao,dt_cadastro,dt_inativo")] TipoVeiculo tipoVeiculo)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (ModelState.IsValid)
            {
                tipoVeiculo.dt_cadastro = DateTime.Now;
                db.tp_veiculos.Add(tipoVeiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoVeiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoVeiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVeiculo tipoVeiculo = db.tp_veiculos.Find(id);
            if (tipoVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipoVeiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TipoVeiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_veiculo,nm_tipo,nm_descricao,dt_cadastro,dt_inativo")] TipoVeiculo tipoVeiculo)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (ModelState.IsValid)
            {
                db.Entry(tipoVeiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoVeiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: TipoVeiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVeiculo tipoVeiculo = db.tp_veiculos.Find(id);
            if (tipoVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipoVeiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: TipoVeiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                TipoVeiculo tipoVeiculo = db.tp_veiculos.Find(id);
            db.tp_veiculos.Remove(tipoVeiculo);
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
