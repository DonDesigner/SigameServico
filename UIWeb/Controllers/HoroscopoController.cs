using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIWeb.Controllers
{
    public class HoroscopoController : Controller
    {
        HoroscopoServicos hs = new HoroscopoServicos();

        // GET: Horoscopo
        public ActionResult Index()
        {
            return View(hs.Listardados());
        }

        public ActionResult Create()
        {
            return View();
        }

        
        public ActionResult Atualizar()
        {
            try
            {
                hs.AtualizarBaseDados();
                ViewBag.Sucesso = "Dados Atualizados com Sucesso";
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }            

            return View();
        }

    }
}