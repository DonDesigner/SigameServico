using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UIWeb.Controllers
{
    public class ArteFinalController : ApiController
    {

        public IEnumerable<string> Get(string texto)
        {
            return new string[] { "NovoValor1", texto };
        }

        //GET api/valeus
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       
    }
}
