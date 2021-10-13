using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebmotorsAnuncio.Clients;
using WebmotorsAnuncio.Models.Domain;
using WebmotorsAnuncio.Models.Request;
using WebmotorsAnuncio.Models.Response;
using WebmotorsAnuncio.Repositories;

namespace WebmotorsAnuncio.Services
{
    public class AnuncioService
    {
        private MakeClient _makeClient;
        private ModelClient _modelClient;
        private VersionClient _versionClient;
        private AnuncioRepository _anuncioRepository;
        public AnuncioService()
        {
            _makeClient = new MakeClient();
            _modelClient = new ModelClient();
            _versionClient = new VersionClient();
            _anuncioRepository = new AnuncioRepository();
        }

        internal AnuncioResponse ConsultarAnuncio(int id)
        {
            var anuncio = _anuncioRepository.Select(id);

            /*
            var anuncio = new Anuncio()
            {
                Ano = 2011,
                ID = 20,
                Marca = "1",
                Modelo = "1",
                Observacao = " obs",
                Quilometragem = 111,
                Versao = "6"
            };*/
            var marca = _makeClient.GetMakeByID(int.Parse(anuncio.Marca));
            var modelo = _modelClient.GetModelByMakeIDAndID(int.Parse(anuncio.Marca), int.Parse(anuncio.Modelo));
            var versao = _versionClient.GetVersionByModelIDAndID(int.Parse(anuncio.Modelo), int.Parse(anuncio.Versao));
            return new AnuncioResponse()
            {
                AnuncioID = anuncio.ID,
                Marca = marca.Name,
                Modelo = modelo.Name,
                Versao = versao.Name,
                Ano = anuncio.Ano,
                Quilometragem = anuncio.Quilometragem,
                Observacao = anuncio.Observacao
            };
        }

        internal void IncluirAnuncio(AnuncioIncluirRequest value)
        {
            _anuncioRepository.Insert(new Anuncio()
            {
                Marca = value.MarcaID.ToString(),
                Modelo = value.ModeloID.ToString(),
                Versao = value.ModeloID.ToString(),
                Ano = value.Ano,
                Quilometragem = value.Quilometragem,
                Observacao = value.Observacao,
            });
        }

        internal void AtualizarAnuncio(AnuncioAtualizarRequest value)
        {
            _anuncioRepository.Update(new Anuncio()
            {
                ID = value.AnuncioID,
                Marca = value.MarcaID.ToString(),
                Modelo = value.ModeloID.ToString(),
                Versao = value.ModeloID.ToString(),
                Ano = value.Ano,
                Quilometragem = value.Quilometragem,
                Observacao = value.Observacao,
            });
        }

        internal void RemoverAnuncio(int id)
        {
            _anuncioRepository.Delete(id);
        }
    }
}