using Domain.Entities;
using HtmlAgilityPack;
using Repository.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Services.Horoscopos
{
    public class HoroscopoServicos
    {
        private List<Horoscopo> Lista = new List<Horoscopo>();
        private static string caminho = System.Web.HttpContext.Current.Server.MapPath("~/db");
        private string arquivo = caminho + "\\horoscopo.json";


        public string AtualizarBaseDados()
        {
            try
            {
                Atualizar();
                Salvar();
            }
            catch (Exception ex)
            {
                return "#Erro: " + ex.Message;
            }
            return "Base de Dados HOROSCOPO atualizada com sucesso as: " + DateTime.Now.ToShortDateString().ToString();
        }

        private void Atualizar()
        {
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8;
            HtmlDocument document = web.Load("http://oglobo.globo.com/horoscopo/");
            //HtmlDocument document = web.Load(@"D:\aa\horoscopo\oglobo2.html");

            Horoscopo horoscopo;
            int index = 0;

            List<string> listaHoroscopos = new List<string>() { "aquario", "aries", "cancer", "capricornio", "escorpiao", "gemeos", "leao", "libra", "peixes", "sagitario", "touro", "virgem" };

            foreach (var horo in listaHoroscopos)
            {
                HtmlNode[] aNode = document.DocumentNode.SelectNodes("//ul[@class='lista']//li[@id='" + horo + "']").ToArray();

                if (aNode != null)
                {

                    foreach (HtmlNode item in aNode)
                    {
                        horoscopo = new Horoscopo();
                        horoscopo.Nome = item.Descendants("b").ToList()[0].InnerHtml;
                        horoscopo.Data = item.Descendants("p").ToList()[0].InnerHtml;
                        horoscopo.Imagem = "img/icons/horoscopo/" + horo.ToString() + ".png";  //item.Descendants("img").ToList()[0].GetAttributeValue("src", null);
                        horoscopo.Previsao = item.Descendants("p").ToList()[1].InnerHtml;
                        horoscopo.Id = index++;

                        Lista.Add(horoscopo);
                    }
                }
            }
        }

        private void Salvar()
        {
            try
            {
                string json = new JavaScriptSerializer().Serialize(Lista);

                JSonRepository jr = new JSonRepository();
                jr.Salvar(arquivo, json, false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public List<Horoscopo> Listardados()
        {
            try
            {
                JSonRepository jr = new JSonRepository();
                string texto = jr.Carregar(arquivo);

                List<Horoscopo> objHoroscopo = new List<Horoscopo>();
                objHoroscopo = new JavaScriptSerializer().Deserialize<List<Horoscopo>>(texto);

                return objHoroscopo;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
