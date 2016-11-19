using Cohen.TCC.AcessoDados.Entity.Context;
using Cohen.TCC.Dominio;
using Cohen.TCC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cohen.TCC.Web.Controllers
{
    public class HomeController : Controller
    {
        private Utils utils = new Utils();
        private TCCDbContext db = new TCCDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                string nm_email = login.nm_email;
                Usuario usuario = db.usuarios.SingleOrDefault(user => user.nm_email == nm_email);
                if (usuario == null)
                {
                    return View(login);
                }
                else
                {
                    string senha = utils.CodificarSenha(login.nm_senha);
                    if (usuario.nm_senha.Equals(senha))
                    {
                        Session["usuarioEmail"] = usuario.nm_email;
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        return View(login);
                    }
                }

            }
            return View(login);
        }
        public ActionResult Dashboard()
        {
            if (Session["usuarioEmail"] != null)
            {
                ViewBag.user = Session["usuarioEmail"];
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}