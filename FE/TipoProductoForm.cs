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
    public partial class TipoProductoForm : Form
    {
        private readonly BETipoProducto _beTipoProducto = new BETipoProducto();
        private List<MODELOS.TipoProducto> _tipoProductos = new List<MODELOS.TipoProducto>();

        public TipoProductoForm()
        {
            InitializeComponent();
        }

        private void TipoProductoForm_Load(object sender, EventArgs e)
        {
            CargarTipoProductos();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombreTipo.Text.Trim();
            bool poseeTalle = checkBoxPoseeTalle.Checked;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre del tipo de producto es obligatorio.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBoxNombreTipo.Focus();
                return;
            }

            try
            {
                var tipo = new MODELOS.TipoProducto
                {
                    TipoProductoId = 0,
                    Nombre = nombre,
                    PoseeTalle = poseeTalle
                };

                int nuevoId = _beTipoProducto.Crear(tipo);

                if (nuevoId <= 0)
                {
                    MessageBox.Show(
                        _beTipoProducto.Error ?? "Error al registrar el tipo de producto.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Tipo de producto creado correctamente.",
                                "OK",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                CargarTipoProductos();
                SeleccionarTipoPorId(nuevoId);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción al registrar el tipo de producto: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerTipoSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un tipo de producto para modificar.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string nombre = textBoxNombreTipo.Text.Trim();
            bool poseeTalle = checkBoxPoseeTalle.Checked;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre del tipo de producto es obligatorio.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBoxNombreTipo.Focus();
                return;
            }

            seleccionado.Nombre = nombre;
            seleccionado.PoseeTalle = poseeTalle;

            bool ok = _beTipoProducto.Modificar(seleccionado);
            if (ok)
            {
                MessageBox.Show("Tipo de producto modificado correctamente.",
                                "OK",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                CargarTipoProductos();
                SeleccionarTipoPorId(seleccionado.TipoProductoId);
            }
            else
            {
                MessageBox.Show(
                    _beTipoProducto.Error ?? "No se pudo modificar el tipo de producto.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerTipoSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un tipo de producto para eliminar.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var resp = MessageBox.Show(
                $"¿Eliminar el tipo de producto '{seleccionado.Nombre}'?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            bool ok = _beTipoProducto.Eliminar(seleccionado.TipoProductoId);
            if (ok)
            {
                MessageBox.Show("Tipo de producto eliminado.",
                                "OK",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                CargarTipoProductos();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show(
                    _beTipoProducto.Error ?? "No se pudo eliminar el tipo de producto.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void CargarTipoProductos()
        {
            try
            {
                _tipoProductos = _beTipoProducto.ObtenerTodos();
                if (!string.IsNullOrEmpty(_beTipoProducto.Error))
                {
                    MessageBox.Show($"Error al cargar tipos de producto: {_beTipoProducto.Error}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    _beTipoProducto.Error = null;
                }

                dataGridViewTipoProducto.DataSource = null;
                dataGridViewTipoProducto.DataSource = _tipoProductos;
                ActualizarBotonesSegunSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción al cargar tipos de producto: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private MODELOS.TipoProducto ObtenerTipoSeleccionado()
        {
            if (dataGridViewTipoProducto.SelectedRows.Count == 0) return null;
            return dataGridViewTipoProducto.SelectedRows[0].DataBoundItem as MODELOS.TipoProducto;
        }

        private void ActualizarBotonesSegunSeleccion()
        {
            bool haySeleccion = dataGridViewTipoProducto.SelectedRows.Count > 0;
            buttonModificar.Enabled = haySeleccion;
            buttonEliminar.Enabled = haySeleccion;
        }

        private void dataGridViewTipoProducto_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonesSegunSeleccion();

            var sel = ObtenerTipoSeleccionado();
            if (sel != null)
            {
                textBoxNombreTipo.Text = sel.Nombre;
                checkBoxPoseeTalle.Checked = sel.PoseeTalle;
            }
        }

        private void SeleccionarTipoPorId(int id)
        {
            foreach (DataGridViewRow row in dataGridViewTipoProducto.Rows)
            {
                if (row.DataBoundItem is MODELOS.TipoProducto t &&
                    t.TipoProductoId == id)
                {
                    row.Selected = true;
                    dataGridViewTipoProducto.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void LimpiarFormulario()
        {
            textBoxNombreTipo.Text = string.Empty;
            checkBoxPoseeTalle.Checked = false;
            dataGridViewTipoProducto.ClearSelection();
            ActualizarBotonesSegunSeleccion();
        }
    }
}
