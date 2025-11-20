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
    public partial class TalleForm : Form
    {
        private readonly BETalle _beTalle = new BETalle();
        private List<Talle> _talles = new List<Talle>();
        public TalleForm()
        {
            InitializeComponent();
        }

        private void TalleForm_Load(object sender, EventArgs e)
        {
            CargarTalles();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string nombreTalle = textBoxTalle.Text.Trim();

            if (string.IsNullOrEmpty(nombreTalle))
            {
                MessageBox.Show("El nombre del talle es obligatorio.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBoxTalle.Focus();
                return;
            }

            try
            {
                var talle = new Talle
                {
                    TalleId = 0,
                    Talles = nombreTalle
                };

                int nuevoId = _beTalle.Crear(talle);

                if (nuevoId <= 0)
                {
                    MessageBox.Show(
                        _beTalle.Error ?? "Error al registrar el talle.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Talle creado correctamente.",
                                "OK",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                CargarTalles();
                SeleccionarTallePorId(nuevoId);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Excepción al registrar el talle: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerTalleSeleccionado();
            if (seleccionado == null) return;

            var resp = MessageBox.Show(
                $"¿Eliminar talle '{seleccionado.Talles}'?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            bool ok = _beTalle.Eliminar(seleccionado.TalleId);
            if (ok)
            {
                MessageBox.Show("Talle eliminado.",
                                "OK",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                CargarTalles();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show(
                    $"No se pudo eliminar: {_beTalle.Error}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerTalleSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un talle para modificar.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string nombreTalle = textBoxTalle.Text.Trim();

            if (string.IsNullOrEmpty(nombreTalle))
            {
                MessageBox.Show("El nombre del talle es obligatorio.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBoxTalle.Focus();
                return;
            }

            seleccionado.Talles = nombreTalle;

            bool ok = _beTalle.Modificar(seleccionado);
            if (ok)
            {
                MessageBox.Show("Talle modificado correctamente.",
                                "OK",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                CargarTalles();
                SeleccionarTallePorId(seleccionado.TalleId);
            }
            else
            {
                MessageBox.Show(
                    $"No se pudo modificar: {_beTalle.Error}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void CargarTalles()
        {
            try
            {
                _talles = _beTalle.ObtenerTodos();
                if (!string.IsNullOrEmpty(_beTalle.Error))
                {
                    MessageBox.Show($"Error al cargar talles: {_beTalle.Error}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    _beTalle.Error = null;
                }

                dataGridViewTalles.DataSource = null;
                dataGridViewTalles.DataSource = _talles;
                ActualizarBotonesSegunSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private Talle ObtenerTalleSeleccionado()
        {
            if (dataGridViewTalles.SelectedRows.Count == 0) return null;
            return dataGridViewTalles.SelectedRows[0].DataBoundItem as Talle;
        }

        private void ActualizarBotonesSegunSeleccion()
        {
            bool haySeleccion = dataGridViewTalles.SelectedRows.Count > 0;
            buttonModificar.Enabled = haySeleccion;
            buttonEliminar.Enabled = haySeleccion;
        }

        private void dataGridViewTalles_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonesSegunSeleccion();
            var sel = ObtenerTalleSeleccionado();
            if (sel != null)
            {
                textBoxTalle.Text = sel.Talles;
            }
        }
        private void SeleccionarTallePorId(int id)
        {
            foreach (DataGridViewRow row in dataGridViewTalles.Rows)
            {
                if (row.DataBoundItem is Talle t && t.TalleId == id)
                {
                    row.Selected = true;
                    dataGridViewTalles.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }

        private void LimpiarFormulario()
        {
            textBoxTalle.Text = string.Empty;
            dataGridViewTalles.ClearSelection();
            ActualizarBotonesSegunSeleccion();
        }
    }
}
