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
    [Authorize]
    public class DispositivoController : ApiController
    {

        private IRepositorio<DispositivoViewModel, Dispositivo> _repositorio;

        public DispositivoController(
            IRepositorio<DispositivoViewModel, Dispositivo> repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/Dispositivo
        public IEnumerable<DispositivoViewModel> Get()
        {
            return _repositorio.Get();
        }

        // GET: api/Dispositivo/5
        [Authorize(Roles = "Administrador")]
        public DispositivoViewModel Get(int id)
        {
            return _repositorio.Get(id);
        }

        // POST: api/Dispositivo
        public void Post([FromBody]DispositivoViewModel value)
        {
            _repositorio.Add(value);
        }

        // PUT: api/Dispositivo/5
        public void Put( [FromBody]DispositivoViewModel value)
        {
            _repositorio.Actualizar(value);
        }

        // DELETE: api/Dispositivo/5
        public void Delete(int id)
        {
            _repositorio.Borrar(id);
        }
    }
}
