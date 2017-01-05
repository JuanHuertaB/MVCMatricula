using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMatricula.Models;

namespace MvcMatricula.Controllers
{
    public class HomeController : Controller
    {
        clinicaEntities obj = new clinicaEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComboEspe()
        {
            SelectList especialidades;

            var list = from e in obj.tabesp
                       select new { code = e.code, nome = e.nome};
            especialidades = new SelectList(list.ToList(), "code", "nome");

            ViewData["esp"]=especialidades;
            

            return View();

        }

        public ActionResult getMedico(string id)
        {
            var list = from m in obj.Medicos
                       select new ClassMedico
                       {
                           codmed = m.codmed,
                           nombre = m.nombre,
                           colegiatura = (int)m.colegiatura,
                           codes=m.codes
                       };

           // Session["nombre"] = nom;
            return View(list.ToList());
        }

        public ActionResult getCitas(string id,string nom, string codes)
        {
            var list = from c in obj.Citas
                       join e in obj.tabesp
                       on codes equals e.code
                       where c.codmed.Equals(id)
                       select c;
            Session["nombre"] = nom;
            //ViewBag.nomes=

            return View(list.ToList());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}