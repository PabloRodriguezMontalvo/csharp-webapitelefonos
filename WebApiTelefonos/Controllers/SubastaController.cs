using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repositorios;
using WebApiTelefonos.Models;
using WebApiTelefonos.Models.ViewModel;

namespace WebApiTelefonos.Controllers
{
    public class SubastaController : ApiController
    {
        private IRepositorio<SubastasViewModel, Subastas> _repositorio;

        public SubastaController(IRepositorio<SubastasViewModel, Subastas> repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/Subasta
        public IEnumerable<SubastasViewModel> Get()
        {
            return _repositorio.Get();
        }

        // GET: api/Subasta/5
        public SubastasViewModel Get(int id)
        {
            return _repositorio.Get(id);
        }

        // POST: api/Subasta
        public void Post([FromBody]SubastasViewModel value)
        {
            _repositorio.Add(value);
        }

        // PUT: api/Subasta/5
        public void Put(int id, [FromBody]SubastasViewModel value)
        {
            _repositorio.Actualizar(value);
        }

        // DELETE: api/Subasta/5
        public void Delete(int id)
        {
            _repositorio.Borrar(id);
        }
    }
}
