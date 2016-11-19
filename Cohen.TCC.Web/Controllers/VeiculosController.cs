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
using System.Collections;

namespace Cohen.TCC.Web.Controllers
{
    public class VeiculosController : Controller
    {
        private TCCDbContext db = new TCCDbContext();

        // GET: Veiculos
        public ActionResult Index()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                return View(db.veiculos.ToList().Where(c => c.dt_inativo.ToString() == "01/01/0001 00:00:00"));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Veiculo veiculo = db.veiculos.Find(id);
                if (veiculo == null)
                {
                    return HttpNotFound();
                }
                return View(veiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Veiculos/Create
        public ActionResult Create()
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                ViewBag.id_tipo_veiculo = new SelectList(db.tp_veiculos.ToList(), "id_tipo_veiculo", "nm_tipo");
                ViewBag.id_cliente = new SelectList(db.clientes.ToList(), "id_cliente", "nm_cliente");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_veiculo,id_veiculo,nu_placa,dt_ano,nm_cor,nu_porta,dt_cadastro,dt_inativo")] Veiculo veiculo)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (ModelState.IsValid)
                {
                    veiculo.dt_cadastro = DateTime.Now;
                    db.veiculos.Add(veiculo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(veiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Veiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Veiculo veiculo = db.veiculos.Find(id);
                if (veiculo == null)
                {
                    return HttpNotFound();
                }
                return View(veiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_veiculo,id_veiculo,nu_placa,dt_ano,nm_cor,nu_porta,dt_cadastro,dt_inativo")] Veiculo veiculo)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(veiculo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(veiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Veiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Veiculo veiculo = db.veiculos.Find(id);
                if (veiculo == null)
                {
                    return HttpNotFound();
                }
                return View(veiculo);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.user = Session["usuarioEmail"];
            if (Session["usuarioEmail"] != null)
            {
                Veiculo veiculo = db.veiculos.Find(id);
                db.veiculos.Remove(veiculo);
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


        //Teste Angular.js #GoHell
        List<Veiculo> veiculos = new List<Veiculo>();



        public string AtualizaVeiculo(Veiculo veiculo)
        {

            if (veiculo != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(veiculo).State = EntityState.Modified;
                    db.SaveChanges();

                   
                    return "Registro atualizado com sucesso.";
                }
                else
                {
                    return "Registro inválido.";

                }
            }
            return "Registro inválido.";

        }

        public string AdicionaVeiculo(Veiculo tipo)
        {
            if (ModelState.IsValid)
            {
                tipo.dt_cadastro = DateTime.Now;
                veiculos.Add(tipo);
                db.veiculos.Add(tipo);
                db.SaveChanges();
                return "Registro efetuado com sucesso.";
                
            }
            else
            {
                return "Registro inválido.";
            }
            return "Registro inválido.";
        }

        public string DeletaVeiculo(Veiculo veiculo) {
            if (veiculo != null) {
                db.veiculos.Remove(veiculo);
                db.SaveChanges();
                veiculos.Remove(veiculo);
                return "Delete efetuado com sucesso.";
            }
            return "Delete inválido.";
        }

        public JsonResult GetTodosVeiculos()
        {

            IEnumerable<Veiculo> model = veiculos;
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetTiposVeiculos()
        {

            IEnumerable<TipoVeiculo> model = db.tp_veiculos.ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
