using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositorios;

namespace WebApiTelefonos.Models.ViewModel
{
    public class SubastasViewModel:IViewModel<Subastas>
    {
        public int idSubasta { get; set; }
        public int idDispositivo { get; set; }
        public decimal precioInicial { get; set; }
        public DateTime fin { get; set; }
        public String Dispositivo { get; set; }
        public Subastas ToBaseDatos()
        {
            var model = new Subastas()
            {
                idDispositivo = idDispositivo,
                idSubasta = idSubasta,
                precioInicial = precioInicial,
                fin = fin

            };
            return model;
        }

        public void FromBaseDatos(Subastas model)
        {
            idDispositivo = model.idDispositivo;
            idSubasta = model.idSubasta;
            precioInicial = model.precioInicial;
            fin = model.fin;

            try
            {
                Dispositivo = model.Dispositivo.marca + " "
                              + model.Dispositivo.modelo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateBaseDatos(Subastas model)
        {
            model.idDispositivo = idDispositivo;
            model.idSubasta = idSubasta;
            model.precioInicial = precioInicial;
            model.fin = fin;
        }

        public int[] GetPk()
        {
            return new[] {idSubasta};
        }
    }
}