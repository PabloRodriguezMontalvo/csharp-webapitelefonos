using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositorios;

namespace WebApiTelefonos.Models.ViewModel
{
    public class PujasViewModel:IViewModel<Pujas>
    {
        public int idPuja { get; set; }
        public int idSubasta { get; set; }
        public decimal valor { get; set; }
        public Pujas ToBaseDatos()
        {
            var model = new Pujas()
            {
                idSubasta = idSubasta,
                idPuja = idPuja,
                valor = valor

            };
            return model;
        }

        public void FromBaseDatos(Pujas model)
        {
            idSubasta = model.idSubasta;
            idPuja = model.idPuja;
            valor = model.valor;
        }

        public void UpdateBaseDatos(Pujas model)
        {
            model.idSubasta = idSubasta;
            model.idPuja = idPuja;
            model.valor = valor;
        }

        public int[] GetPk()
        {
            return new[] {idPuja};
        }
    }
}