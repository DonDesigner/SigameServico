using Domain.Entities;
using HtmlAgilityPack;
using Repository.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Services.Noticias
{
    public class NoticiaServicos
    {

        string website = "http://gcn.net.br/";

        public List<Noticia> Lista = new List<Noticia>();
        private static string caminho = System.Web.HttpContext.Current.Server.MapPath("~/db");
        private static string arquivo = caminho + "\\noticia.json";

        public string AtualizarBaseDados()
        {
            try
            {
                Atualizar();
                Salvar(false);
            }
            catch (Exception ex)
            {
                return "#Erro: " + ex.Message;
            }
            return "Base de Dados NOTÍCIAS atualizada com sucesso as: " + DateTime.Now.ToShortDateString().ToString();
        }

        private void Atualizar()
        {
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
            HtmlDocument document = web.Load(website);
            //HtmlDocument document = web.Load(@"D:\aa\horoscopo\oglobo2.html");

            HtmlNode[] aNode = document.DocumentNode.SelectNodes("//div[@class='gcn-sac']").ToArray();

            int index = 0;

            if (aNode != null)
            {
                Noticia noticia;

                foreach (HtmlNode item in aNode)
                {
                    noticia = new Noticia();

                    noticia.Titulo = item.Descendants("h3").ToList()[0].InnerHtml;
                    noticia.Corpo = item.Descendants("p").ToList()[0].InnerHtml;
                    noticia.Link = item.Descendants("a").ToList()[0].GetAttributeValue("href", null);
                    noticia.Imagem = website + item.Descendants("img").ToList()[0].GetAttributeValue("src", null);
                    noticia.Imagem = SalvarImagens("img0" + index, noticia.Imagem);
                    noticia.Id = index++;

                    Lista.Add(noticia);
                }
            }
            if (document.DocumentNode.SelectNodes("//div[@class='gcn-sec']") != null)
            {
                HtmlNode[] bNode = document.DocumentNode.SelectNodes("//div[@class='gcn-sec']").ToArray();

                if (bNode != null)
                {
                    Noticia noticia;


                    foreach (HtmlNode item in bNode)
                    {
                        noticia = new Noticia();

                        noticia.Titulo = item.Descendants("h3").ToList()[0].InnerHtml;
                        noticia.Corpo = item.Descendants("p").ToList()[0].InnerHtml;
                        noticia.Link = item.Descendants("a").ToList()[0].GetAttributeValue("href", null);
                        noticia.Imagem = website + item.Descendants("img").ToList()[0].GetAttributeValue("src", null);
                        noticia.Imagem = SalvarImagens("img0" + index, noticia.Imagem);
                        noticia.Id = index++;

                        Lista.Add(noticia);
                    }
                }
            }
        }

        private void Salvar(bool Adicionar)
        {
            try
            {
                string json = new JavaScriptSerializer().Serialize(Lista);

                JSonRepository jr = new JSonRepository();
                jr.Salvar(arquivo, json, Adicionar);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        public List<Noticia> Listardados()
        {
            try
            {
                JSonRepository jr = new JSonRepository();
                string texto = jr.Carregar(arquivo);

                List<Noticia> objNoticia = new List<Noticia>();
                objNoticia = new JavaScriptSerializer().Deserialize<List<Noticia>>(texto);

                return objNoticia;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private string SalvarImagens(string file_name, string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            Stream strem = response.GetResponseStream();

            ImagensRepositorios ir = new ImagensRepositorios();

            file_name = caminho + "\\img\\" + file_name + ".jpg";

            ir.SalvarImagens(strem, file_name);

            response.Close();
                      
            return file_name;

        }

    }
}
