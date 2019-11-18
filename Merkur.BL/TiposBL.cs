using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merkur.BL
{
    public class TiposBL
    {
        Contexto _contexto;
        public BindingList<Tipos> ListaTipos { get; set; }
        public TiposBL()
        {
            _contexto = new Contexto();
            ListaTipos = new BindingList<Tipos>();
        }

        public BindingList<Tipos> ObtenerTipos()
        {
            _contexto.Tipos.Load();
            ListaTipos = _contexto.Tipos.Local.ToBindingList();

            return ListaTipos;

        }
    }

    public class Tipos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
