using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public string Imagem { get; set; }
        public string Link { get; set; }
        public string Data { get; set; }
    }
}
