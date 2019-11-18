using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merkur.BL
{
    public class ProductosBL
    {
        Contexto _contexto;
        public BindingList<Producto> ListadeProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new BindingList<Producto>();
                       
        }
        public BindingList<Producto> Obtenerproductos()
        {
            _contexto.Productos.Load();
            ListadeProductos = _contexto.Productos.Local.ToBindingList();

            return ListadeProductos;
        }
        public Resultado GuardarProductos(Producto producto)
        {
            var resultado = Validar(producto); 
            if (resultado.Exitoso == false )
            {

                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;            
            return resultado;
        }
        public void AgregarProducto()
        {
            var nuevoProducto = new Producto();

            ListadeProductos.Add(nuevoProducto);
            
        }
     
        public bool EliminarProducto(int id)
        {
            foreach (var producto in ListadeProductos)
            {
                if (producto.Id == id)
                {
                    ListadeProductos.Remove(producto);
                    _contexto.SaveChanges();
                    return true;
                }
               
            }
            return false;
        }
        private Resultado Validar (Producto producto)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if(producto.Descripcion== " ")
            {
                resultado.Mensaje = "Ingrese una Descripcion";
                resultado.Exitoso = false;
            }

            if (producto.Id<0)
            {
                resultado.Mensaje = "el Id debe ser mayor que 0";
                resultado.Exitoso = false;
            }


            return resultado;
        }

        public void Actualizar(int id, string descripcion)
        {
            var productoExistente = _contexto.Productos.Find(id);

            productoExistente.Descripcion = descripcion;

            _contexto.SaveChanges();
        }
        public List<Producto> Obtener()
        {
            return _contexto.Productos.ToList();
        }
    }
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Destino { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categorias { get; set; }
        public int TipoId { get; set; }
        public Tipos Tipos { get; set; }
        public DateTime FechadeEntrega { get; set; }
        public bool Activo { get; set; }

    }
    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }

}
