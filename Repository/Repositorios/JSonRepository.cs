using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorios
{
    public class JSonRepository
    {
        public void Salvar(string Arquivo, string DadosJson, bool Adicionar)
        {
            try
            {
                if (!File.Exists(Arquivo))
                {
                    File.Create(Arquivo);
                    TextWriter tw = new StreamWriter(Arquivo, Adicionar, Encoding.UTF8);
                    tw.WriteLine(DadosJson);
                    tw.Close();
                }
                else if (File.Exists(Arquivo))
                {
                    TextWriter tw = new StreamWriter(Arquivo, false, Encoding.UTF8);
                    tw.WriteLine(DadosJson);
                    tw.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public string Carregar(string arquivo)
        {
            try
            {
                if (File.Exists(arquivo))
                {
                    string texto = File.ReadAllText(arquivo);
                    return texto;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return null;
        }
    }
}
