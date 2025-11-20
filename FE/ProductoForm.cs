using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiendaRopa.BE;
using TiendaRopa.MODELOS;

namespace TiendaRopa.FE
{
    public partial class ProductoForm : Form
    {
        private readonly BEProducto _beProducto = new BEProducto();
        private readonly BETalleProducto _beTalleProducto = new BETalleProducto();
        private readonly BETalle _beTalle = new BETalle();
        private readonly BEMarca _beMarca = new BEMarca();
        private readonly BETipoProducto _beTipoProducto = new BETipoProducto();

        private readonly BindingList<ProductoEnCarga> _productosPendientes = new BindingList<ProductoEnCarga>();

        public ProductoForm()
        {
            InitializeComponent();
        }

        private void ProductoForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ConfigurarDataGrid();
            ActualizarEstadoTallePorTipo();
        }
        private void CargarCombos()
        {
            // MARCAS
            var marcas = _beMarca.ObtenerTodos();
            if (!string.IsNullOrEmpty(_beMarca.Error))
            {
                MessageBox.Show($"Error cargando marcas: {_beMarca.Error}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _beMarca.Error = null;
            }
            comboMarca.DataSource = marcas;
            comboMarca.DisplayMember = "Nombre";
            comboMarca.ValueMember = "MarcaId";

            // TIPOS DE PRODUCTO
            var tipos = _beTipoProducto.ObtenerTodos();
            if (!string.IsNullOrEmpty(_beTipoProducto.Error))
            {
                MessageBox.Show($"Error cargando tipos de producto: {_beTipoProducto.Error}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _beTipoProducto.Error = null;
            }
            comboTipoProducto.DataSource = tipos;
            comboTipoProducto.DisplayMember = "Nombre";
            comboTipoProducto.ValueMember = "TipoProductoId";

            // TALLES
            var talles = _beTalle.ObtenerTodos();
            if (!string.IsNullOrEmpty(_beTalle.Error))
            {
                MessageBox.Show($"Error cargando talles: {_beTalle.Error}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _beTalle.Error = null;
            }
            comboTalle.DataSource = talles;
            comboTalle.DisplayMember = "Talles";
            comboTalle.ValueMember = "TalleId";

            ActualizarEstadoTallePorTipo();
        }

        private void ConfigurarDataGrid()
        {
            dataGridViewProductosPendientes.AutoGenerateColumns = true;
            dataGridViewProductosPendientes.DataSource = _productosPendientes;
            dataGridViewProductosPendientes.ClearSelection();
        }


        private void comboTalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEstadoTallePorTipo();
        }
        private void ActualizarEstadoTallePorTipo()
        {
            if (comboTipoProducto.SelectedItem is TipoProducto tipo)
            {
                if (tipo.PoseeTalle)
                {
                    comboTalle.Enabled = true;
                }
                else
                {
                    comboTalle.Enabled = false;
                    comboTalle.SelectedIndex = -1;
                }
            }
            else
            {
                comboTalle.Enabled = false;
                comboTalle.SelectedIndex = -1;
            }
        }

        private void buttonAgregarAGrilla_Click(object sender, EventArgs e)
        {
            if (comboMarca.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una marca.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboTipoProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de producto.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreModelo = textBoxNombreModelo.Text.Trim();
            if (string.IsNullOrEmpty(nombreModelo))
            {
                MessageBox.Show("Ingrese el nombre/modelo del producto.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNombreModelo.Focus();
                return;
            }

            var marca = (Marca)comboMarca.SelectedItem;
            var tipo = (TipoProducto)comboTipoProducto.SelectedItem;

            int? talleId = null;
            string talleNombre = null;

            if (tipo.PoseeTalle)
            {
                if (comboTalle.SelectedItem == null)
                {
                    MessageBox.Show("Este tipo de producto requiere talle. Seleccione un talle.",
                                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var talle = (Talle)comboTalle.SelectedItem;
                talleId = talle.TalleId;
                talleNombre = talle.Talles;
            }

            var item = new ProductoEnCarga
            {
                NombreModelo = nombreModelo,
                MarcaId = marca.MarcaId,
                MarcaNombre = marca.Nombre,
                TipoProductoId = tipo.TipoProductoId,
                TipoProductoNombre = tipo.Nombre,
                PoseeTalle = tipo.PoseeTalle,
                TalleId = talleId,
                TalleNombre = talleNombre
            };

            _productosPendientes.Add(item);
            LimpiarCamposCarga(keepMarcaYTipo: true);
        }

        private void buttonQuitarDeGrilla_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductosPendientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto en la grilla para quitar.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dataGridViewProductosPendientes.SelectedRows[0];
            if (row.DataBoundItem is ProductoEnCarga item)
            {
                _productosPendientes.Remove(item);
            }
        }

        private void buttonGuardarTodo_Click(object sender, EventArgs e)
        {
            if (_productosPendientes.Count == 0)
            {
                MessageBox.Show("No hay productos en la grilla para guardar.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmar = MessageBox.Show(
                "Se guardarán todos los productos de la grilla en la base de datos.\n" +
                "Los productos con mismo NombreModelo, Marca y Tipo se crearán como UN solo producto con varios talles.\n\n" +
                "¿Desea continuar?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                var lista = _productosPendientes.ToList();

                bool ok = _beProducto.GuardarLoteDesdeCarga(lista);

                if (ok)
                {
                    MessageBox.Show("Todos los productos fueron guardados correctamente.",
                                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _productosPendientes.Clear();
                    dataGridViewProductosPendientes.ClearSelection();
                    LimpiarCamposCarga(keepMarcaYTipo: false);
                }
                else
                {
                    MessageBox.Show(
                        $"No se pudo guardar el lote de productos: {_beProducto.Error}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción al guardar productos: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCamposCarga(bool keepMarcaYTipo)
        {

            if (!keepMarcaYTipo)
            {
                textBoxNombreModelo.Text = string.Empty;
                comboMarca.SelectedIndex = -1;
                comboTipoProducto.SelectedIndex = -1;
                comboTalle.SelectedIndex = -1;
                comboTalle.Enabled = false;
            }

            textBoxNombreModelo.Focus();
        }

        private void comboTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEstadoTallePorTipo();
        }
    }
}