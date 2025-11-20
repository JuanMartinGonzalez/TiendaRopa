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

    public partial class MarcaForm : Form
    {
        private readonly BEMarca _beMarca = new BEMarca();
        private List<MODELOS.Marca> _marcas = new List<MODELOS.Marca>();
        public MarcaForm()
        {
            InitializeComponent();
        }

        private void MarcaForm_Load(object sender, EventArgs e)
        {
            CargarMarcas();
        }
        private void CargarMarcas()
        {
            try
            {
                _marcas = _beMarca.ObtenerTodos();
                if (!string.IsNullOrEmpty(_beMarca.Error))
                {
                    MessageBox.Show($"Error al cargar marcas: {_beMarca.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _beMarca.Error = null;
                }

                dataGridViewMarcas.DataSource = null;
                dataGridViewMarcas.DataSource = _marcas;
                ActualizarBotonesSegunSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private MODELOS.Marca ObtenerMarcaSeleccionada()
        {
            if (dataGridViewMarcas.SelectedRows.Count == 0) return null;
            return dataGridViewMarcas.SelectedRows[0].DataBoundItem as MODELOS.Marca;
        }

        private void ActualizarBotonesSegunSeleccion()
        {
            bool haySeleccion = dataGridViewMarcas.SelectedRows.Count > 0;
            buttonModificar.Enabled = haySeleccion;
            buttonEliminar.Enabled = haySeleccion;
        }

        private void dataGridViewMarcas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonesSegunSeleccion();
            var sel = ObtenerMarcaSeleccionada();
            if (sel != null)
            {
                // Mostrar nombre en el TextBox al seleccionar (edición inline)
                textBoxNombre.Text = sel.Nombre;
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNombre.Focus();
                return;
            }

            try
            {
                var marca = new MODELOS.Marca(0, string.Empty)
                {
                    Nombre = nombre
                };

                int id = _beMarca.Crear(marca);
                if (id <= 0)
                {
                    MessageBox.Show(_beMarca.Error ?? "Error al crear marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Marca creada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMarcas();
                SeleccionarMarcaPorId(id);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción al crear marca: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerMarcaSeleccionada();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione una marca para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = textBoxNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNombre.Focus();
                return;
            }

            seleccionado.Nombre = nombre;

            bool ok = _beMarca.Modificar(seleccionado);
            if (ok)
            {
                MessageBox.Show("Marca modificada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMarcas();
                SeleccionarMarcaPorId(seleccionado.MarcaId);
            }
            else
            {
                MessageBox.Show($"No se pudo modificar: {_beMarca.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerMarcaSeleccionada();
            if (seleccionado == null) return;

            var resp = MessageBox.Show($"¿Eliminar marca '{seleccionado.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;

            bool ok = _beMarca.Eliminar(seleccionado.MarcaId);
            if (ok)
            {
                MessageBox.Show("Marca eliminada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMarcas();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show($"No se pudo eliminar: {_beMarca.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SeleccionarMarcaPorId(int id)
        {
            foreach (DataGridViewRow row in dataGridViewMarcas.Rows)
            {
                if (row.DataBoundItem is MODELOS.Marca m && m.MarcaId == id)
                {
                    row.Selected = true;
                    dataGridViewMarcas.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }

        private void LimpiarFormulario()
        {
            textBoxNombre.Text = string.Empty;
            dataGridViewMarcas.ClearSelection();
            ActualizarBotonesSegunSeleccion();
        }

    }
}
