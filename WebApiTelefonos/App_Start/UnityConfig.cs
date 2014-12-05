using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Repositorios;
using Unity.WebApi;
using WebApiTelefonos.Models;
using WebApiTelefonos.Models.ViewModel;

namespace WebApiTelefonos
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            container.RegisterType<DbContext, VentaTelefonoEntities>();
            container.RegisterType
                <IRepositorio<DispositivoViewModel,Dispositivo>,
                Repositorio<DispositivoViewModel,Dispositivo>>();
            container.RegisterType
                <IRepositorio<SubastasViewModel, Subastas>,
                Repositorio<SubastasViewModel, Subastas>>();
            container.RegisterType
                <IRepositorio<PujasViewModel, Pujas>,
                Repositorio<PujasViewModel, Pujas>>();

        }
    }
}