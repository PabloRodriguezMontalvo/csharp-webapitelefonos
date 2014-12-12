using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Repositorios;
using WebApiTelefonos.Models;
using WebApiTelefonos.Utils;

namespace WebApiTelefonos.Extensions
{
    public class ManejadorMensajesAutenticacion:DelegatingHandler
    {
        private VentaTelefonoEntities _datos;

        public ManejadorMensajesAutenticacion(VentaTelefonoEntities datos)
        {
            _datos = datos;
        }

        private GenericPrincipal Autenticar(String usuario, String password)
        {
            var pwd = SeguridadUtils.Sha1Hash(password);

            var us = _datos.Usuario.
               FirstOrDefault(o => o.login == usuario && o.password == pwd);

            if (us != null)
            {
                IIdentity identity=new GenericIdentity(usuario);
                var principal = new GenericPrincipal(identity, 
                    us.Rol.Select(o => o.nombre).ToArray());

                return principal;

            }
            return null;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            if (request.Headers.Authorization != null 
                && request.Headers.Authorization.Scheme == "Basic")
            {
                var datos = request.Headers.Authorization.Parameter.Trim();
                var uspass = 
               Encoding.Default.GetString(Convert.FromBase64String(datos));
                var user = uspass.Split(':')[0];
                var pwd = uspass.Split(':')[1];

                var principal = Autenticar(user, pwd);

                if (principal != null)
                {
                    request.GetRequestContext().Principal = principal;
                }
                else
                {
                    response = 
                        request.CreateResponse(HttpStatusCode.Unauthorized);
                    response.Headers.Add("www-Authenticate","Basic");
                    return response;
                }

            }
            response = await base.SendAsync(request, cancellationToken);
            if(response.StatusCode==HttpStatusCode.Unauthorized)
                response.Headers.Add("www-Authenticate", "Basic");

            return response;
        }
    }
}