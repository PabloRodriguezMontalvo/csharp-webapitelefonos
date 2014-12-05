using Repositorios;

namespace WebApiTelefonos.Models.ViewModel
{
    public class DispositivoViewModel:IViewModel<Dispositivo>
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string foto { get; set; }
        public string descripcion { get; set; }
        public Dispositivo ToBaseDatos()
        {
            var model = new Dispositivo()
            {
                descripcion = descripcion,
                marca = marca,
                modelo = modelo,
                foto = foto,
                id = id
            };
            return model;
        }

        public void FromBaseDatos(Dispositivo model)
        {
            descripcion = model.descripcion;
            marca = model.marca;
            modelo = model.modelo;
            foto = model.foto;
            id = model.id;
        }

        public void UpdateBaseDatos(Dispositivo model)
        {
            model.descripcion = descripcion;
            model.marca = marca;
            model.modelo = modelo;
            model.foto = foto;
            model.id = id;
        }

        public int[] GetPk()
        {
            return new[] {id};
        }
    }
}