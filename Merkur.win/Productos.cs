using Merkur.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merkur.win
{
    public partial class Productos : Form
    {
        ProductosBL _productosBL;
        CategoriasBL _categorias;
        TiposBL _tipos;
        public Productos()
        {
            
            InitializeComponent();

            _productosBL = new ProductosBL();
            listadeProductosBindingSource.DataSource = _productosBL.Obtenerproductos();

            _categorias = new CategoriasBL();
            listaCategoriaBindingSource.DataSource = _categorias.ObtenerCategoria();

            _tipos = new TiposBL();
            listaTiposBindingSource.DataSource = _tipos.ObtenerTipos();
            
        }

        private void listadeProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            var nuevoProducto = new Producto();
            nuevoProducto.Descripcion = descripcionTextBox.Text;
            nuevoProducto.Destino = destinoTextBox.Text;
            nuevoProducto.FechadeEntrega = fechadeEntregaDateTimePicker.Value;
            nuevoProducto.Activo = activoCheckBox.Checked;
           
            MessageBox.Show("Produto Guardado");
            descripcionTextBox.Clear();
            descripcionTextBox.Focus();
            listadeProductosBindingSource.EndEdit();
            var producto =(Producto) listadeProductosBindingSource.Current;
            var resultado = _productosBL.GuardarProductos(producto);


            if(resultado.Exitoso== true)
            {
                listadeProductosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);

            }else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e )
        {
            _productosBL.AgregarProducto();
            listadeProductosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled=valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;

            toolStripButtoncancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {


            if (idTextBox.Text != "")
            {
                var id = Convert.ToInt32(idTextBox.Text);
                var resultado = MessageBox.Show("¿Desea eliminar este resgistro?", "Elimina", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    Eliminar(id);
                }

                
            }
        }

        private void Eliminar(int id)
        {
            
            var resultado = _productosBL.EliminarProducto(id);
            if (resultado == true)
            {
                listadeProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el Producto");
            }

            
        }

        private void toolStripButtoncancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            var id = int.Parse(idTextBox.Text);
            var descripcion = descripcionTextBox.Text;

            _productosBL.Actualizar(id, descripcion);
            MessageBox.Show("Datos Actualizados");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listadeProductosBindingSource1.DataSource = null;
            listadeProductosBindingSource1.DataSource = _productosBL.Obtener();
        }

        private void descripcionLabel1_Click(object sender, EventArgs e)
        {

        }

        private void productosBLDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
