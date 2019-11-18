using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Merkur.BL
{
    public class DatosdeIncio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var usuarioadmin = new Usuarios();
            usuarioadmin.Nombre = "Admin";
            usuarioadmin.Contrasena = "123";
            contexto.Usuarios.Add(usuarioadmin);

            var categoria1 = new Categoria();
            categoria1.Descripcion = "Fragil";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Pesado";
            contexto.Categorias.Add(categoria2);

            var categoria3 = new Categoria();
            categoria3.Descripcion = "Documentacion";
            contexto.Categorias.Add(categoria3);

            var categoria4 = new Categoria();
            categoria4.Descripcion = "Peligroso";
            contexto.Categorias.Add(categoria4);

            var tipo1 = new Tipos();
            tipo1.Descripcion = "Urgente";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipos();
            tipo2.Descripcion = "No Urgente";
            contexto.Tipos.Add(tipo2);
            
            base.Seed(contexto);
        }
    }
}
