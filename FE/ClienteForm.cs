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
    public partial class ClienteForm : Form
    {
        private readonly BECliente _beCliente = new BECliente();
        private List<MODELOS.Cliente> _clientes = new List<MODELOS.Cliente>();

        public ClienteForm()
        {
            InitializeComponent();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text.Trim();
            string dni = textBoxDNI.Text.Trim();

            try
            {
                var cliente = new MODELOS.Cliente(0, string.Empty, string.Empty)
                {
                    Nombre = nombre,
                    DNI = dni
                };

                int resultadoId = _beCliente.Crear(cliente);

                if (resultadoId <= 0)
                {
                    MessageBox.Show(
                        _beCliente.Error ?? "Error al registrar el cliente.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Cliente creado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
                SeleccionarClientePorId(resultadoId);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Excepción al registrar el cliente: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerClienteSeleccionado();
            if (seleccionado == null) return;

            var resp = MessageBox.Show($"¿Eliminar cliente '{seleccionado.Nombre}' (DNI: {seleccionado.DNI})?",
                                       "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;

            bool ok = _beCliente.Eliminar(seleccionado.ClienteId);
            if (ok)
            {
                MessageBox.Show("Cliente eliminado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show($"No se pudo eliminar: {_beCliente.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerClienteSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un cliente para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Leer valores actuales desde los textboxes (que llenás al seleccionar)
            string nombre = textBoxNombre.Text.Trim();
            string dni = textBoxDNI.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNombre.Focus();
                return;
            }

            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("El DNI es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDNI.Focus();
                return;
            }

            // Actualizar el objeto seleccionado
            seleccionado.Nombre = nombre;
            seleccionado.DNI = dni;

            bool ok = _beCliente.Modificar(seleccionado);
            if (ok)
            {
                MessageBox.Show("Cliente modificado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
                SeleccionarClientePorId(seleccionado.ClienteId);
            }
            else
            {
                MessageBox.Show($"No se pudo modificar: {_beCliente.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClienteForm_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void CargarClientes()
        {
            try
            {
                _clientes = _beCliente.ObtenerTodos();
                if (!string.IsNullOrEmpty(_beCliente.Error))
                {
                    MessageBox.Show($"Error al cargar clientes: {_beCliente.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _beCliente.Error = null;
                }

                dataGridViewClientes.DataSource = null;
                dataGridViewClientes.DataSource = _clientes;
                ActualizarBotonesSegunSeleccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Devuelve el cliente seleccionado en la grilla (o null)
        private MODELOS.Cliente ObtenerClienteSeleccionado()
        {
            if (dataGridViewClientes.SelectedRows.Count == 0) return null;
            return dataGridViewClientes.SelectedRows[0].DataBoundItem as MODELOS.Cliente;
        }

        // Habilita/deshabilita botones según selección en la grilla
        private void ActualizarBotonesSegunSeleccion()
        {
            bool haySeleccion = dataGridViewClientes.SelectedRows.Count > 0;
            buttonModificar.Enabled = haySeleccion;
            buttonEliminar.Enabled = haySeleccion;
        }

        private void dataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonesSegunSeleccion();
            var sel = ObtenerClienteSeleccionado();
            if (sel != null)
            {
                // Si querés mostrar los datos en los textboxes al seleccionar:
                textBoxNombre.Text = sel.Nombre;
                textBoxDNI.Text = sel.DNI;
            }
        }
        // Selecciona en la grilla el cliente con el id indicado
        private void SeleccionarClientePorId(int id)
        {
            foreach (DataGridViewRow row in dataGridViewClientes.Rows)
            {
                if (row.DataBoundItem is MODELOS.Cliente c && c.ClienteId == id)
                {
                    row.Selected = true;
                    dataGridViewClientes.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }
        // Limpia los controles del formulario (si querés usarlos para nuevos registros)
        private void LimpiarFormulario()
        {
            textBoxNombre.Text = string.Empty;
            textBoxDNI.Text = string.Empty;
            dataGridViewClientes.ClearSelection();
            ActualizarBotonesSegunSeleccion();
        }

    }
}
