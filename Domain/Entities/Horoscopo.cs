using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Horoscopo
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Previsao { get; set; }
        public string Link { get; set; }
    }
}
