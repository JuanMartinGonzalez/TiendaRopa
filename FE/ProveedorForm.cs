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

namespace TiendaRopa.FE
{
    public partial class ProveedorForm : Form
    {
        private readonly BEProveedor _beProveedor = new BEProveedor();
        private List<MODELOS.Proveedor> _proveedores = new List<MODELOS.Proveedor>();

        public ProveedorForm()
        {
            InitializeComponent();
        }

        private void ProveedorForm_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }
        private void CargarProveedores()
        {
            try
            {
                _proveedores = _beProveedor.ObtenerTodos();
                if (!string.IsNullOrEmpty(_beProveedor.Error))
                {
                    MessageBox.Show($"Error al cargar proveedores: {_beProveedor.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _beProveedor.Error = null;
                }

                dataGridViewProveedores.DataSource = null;
                dataGridViewProveedores.DataSource = _proveedores;
                ActualizarBotonesSegunSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private MODELOS.Proveedor ObtenerProveedorSeleccionado()
        {
            if (dataGridViewProveedores.SelectedRows.Count == 0) return null;
            return dataGridViewProveedores.SelectedRows[0].DataBoundItem as MODELOS.Proveedor;
        }
        private void ActualizarBotonesSegunSeleccion()
        {
            bool haySeleccion = dataGridViewProveedores.SelectedRows.Count > 0;
            buttonModificar.Enabled = haySeleccion;
            buttonEliminar.Enabled = haySeleccion;
        }

        private void dataGridViewProveedores_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonesSegunSeleccion();
            var sel = ObtenerProveedorSeleccionado();
            if (sel != null)
            {
                // Mostrar datos en los TextBox al seleccionar (edición inline)
                textBoxNombre.Text = sel.Nombre;
                textBoxCUIT.Text = sel.CUIT;
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text.Trim();
            string cuit = textBoxCUIT.Text.Trim();

            // Validación mínima UI
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cuit))
            {
                MessageBox.Show("El CUIT es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCUIT.Focus();
                return;
            }

            try
            {
                var proveedor = new MODELOS.Proveedor(0, string.Empty, string.Empty)
                {
                    Nombre = nombre,
                    CUIT = cuit
                };

                int id = _beProveedor.Crear(proveedor);
                if (id <= 0)
                {
                    MessageBox.Show(_beProveedor.Error ?? "Error al crear proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Proveedor creado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                SeleccionarProveedorPorId(id);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción al crear proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerProveedorSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un proveedor para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = textBoxNombre.Text.Trim();
            string cuit = textBoxCUIT.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cuit))
            {
                MessageBox.Show("El CUIT es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCUIT.Focus();
                return;
            }

            // Actualizar objeto y guardar
            seleccionado.Nombre = nombre;
            seleccionado.CUIT = cuit;

            bool ok = _beProveedor.Modificar(seleccionado);
            if (ok)
            {
                MessageBox.Show("Proveedor modificado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                SeleccionarProveedorPorId(seleccionado.ProveedorId);
            }
            else
            {
                MessageBox.Show($"No se pudo modificar: {_beProveedor.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerProveedorSeleccionado();
            if (seleccionado == null) return;

            var resp = MessageBox.Show($"¿Eliminar proveedor '{seleccionado.Nombre}' (CUIT: {seleccionado.CUIT})?",
                                       "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;

            bool ok = _beProveedor.Eliminar(seleccionado.ProveedorId);
            if (ok)
            {
                MessageBox.Show("Proveedor eliminado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show($"No se pudo eliminar: {_beProveedor.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SeleccionarProveedorPorId(int id)
        {
            foreach (DataGridViewRow row in dataGridViewProveedores.Rows)
            {
                if (row.DataBoundItem is MODELOS.Proveedor p && p.ProveedorId == id)
                {
                    row.Selected = true;
                    dataGridViewProveedores.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }

        private void LimpiarFormulario()
        {
            textBoxNombre.Text = string.Empty;
            textBoxCUIT.Text = string.Empty;
            dataGridViewProveedores.ClearSelection();
            ActualizarBotonesSegunSeleccion();
        }

    }
}
