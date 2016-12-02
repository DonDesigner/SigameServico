using Domain.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UIWeb.Controllers
{
    public class NoticiasController : Controller
    {
        NoticiaServicos ns = new NoticiaServicos();

        // GET: Noticias
        public ActionResult Index()
        {
            return View(ns.Listardados());
        }

        // GET: noticias/Create
        public ActionResult Create()
        {
            return View();
        }

        //recado:Atualizar noticias para conferir se está tudo ok e se está salvando certo
        public ActionResult Atualizar()
        {
            try
            {
                ns.AtualizarBaseDados();
                ViewBag.Sucesso = "Dados atualizados com sucesso!";
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Noticia noticia = ns.Listardados().Find(x => x.Id == id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = ns.Listardados().Find(x => x.Id == id);
            if(noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }


    }
}