using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Services
{
    public class ArteFinalServicos
    {
        private void Salvar()
        {

        }

        private void Editar()
        {

        }

        public void Atualizar(int id = 0)
        {
            if (id > 0)
                Editar();
            else
                Salvar();             
        }

        public List<ArteFinal> Localizar (string texto)
        {

            //http://stackoverflow.com/questions/20264112/how-to-return-a-list-in-entity-framework

            using (var db = new BDContext())
            {
                return (from c in db.ArteFinal where c.Trabalho == texto
                             select c).ToList();
            }          
        }

        
    }
}
