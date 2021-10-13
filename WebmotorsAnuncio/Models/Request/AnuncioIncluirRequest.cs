using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebmotorsAnuncio.Models.Request
{
    public class AnuncioIncluirRequest
    {
        public int MarcaID { get; set; }
        public int ModeloID { get; set; }
        public int VersaoID { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }
}