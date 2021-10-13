using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebmotorsAnuncio.Models.Request;
using WebmotorsAnuncio.Models.Response;
using WebmotorsAnuncio.Services;

namespace WebmotorsAnuncio.Controllers
{
    public class AnunciosController : ApiController
    {
        private AnuncioService _anuncioService;
        public AnunciosController()
        {
            _anuncioService = new AnuncioService();
        }

        // GET api/anuncios/5
        public AnuncioResponse Get(int id)
        {
            return _anuncioService.ConsultarAnuncio(id);
        }

        // POST api/anuncios
        public void Post([FromBody] AnuncioIncluirRequest value)
        {
            _anuncioService.IncluirAnuncio(value);
        }

        // PUT api/anuncios/5
        public void Put(int id, [FromBody] AnuncioAtualizarRequest value)
        {
            _anuncioService.AtualizarAnuncio(value);
        }

        // DELETE api/anuncios/5
        public void Delete(int id)
        {
            _anuncioService.RemoverAnuncio(id);
        }
    }
}
