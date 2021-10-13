namespace WebmotorsAnuncio.Models.Request
{
    public class AnuncioAtualizarRequest
    {
        public int AnuncioID { get; set; }
        public int MarcaID { get; set; }
        public int ModeloID { get; set; }
        public int VersaoID { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }
}