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
    public partial class VentaForm : Form
    {
        private readonly BEVentas _beVentas = new BEVentas();
        private readonly BECliente _beCliente = new BECliente();
        private readonly BEProducto _beProducto = new BEProducto();
        private readonly BETalle _beTalle = new BETalle();
        private readonly BETipoProducto _beTipoProducto = new BETipoProducto();

        private List<TipoProducto> _tiposProducto = new List<TipoProducto>();
        private readonly BindingList<LineaVentaEnCarga> _lineasVenta =
            new BindingList<LineaVentaEnCarga>();
        public VentaForm()
        {
            InitializeComponent();
        }

        private void VentaForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ConfigurarDataGrid();
            dateTimePickerFecha.Value = DateTime.Now;
            ActualizarTotal();
        }
        private void CargarCombos()
        {
            // TIPOS DE PRODUCTO (NUEVO)
            _tiposProducto = _beTipoProducto.ObtenerTodos();
            if (!string.IsNullOrEmpty(_beTipoProducto.Error))
            {
                MessageBox.Show($"Error cargando tipos de producto: {_beTipoProducto.Error}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _beTipoProducto.Error = null;
            }
            // CLIENTES
            var clientes = _beCliente.ObtenerTodos();
            if (!string.IsNullOrEmpty(_beCliente.Error))
            {
                MessageBox.Show($"Error cargando clientes: {_beCliente.Error}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _beCliente.Error = null;
            }

            comboCliente.DataSource = clientes;
            comboCliente.DisplayMember = "Nombre";      // o NombreCompleto, ajustá a tu modelo
            comboCliente.ValueMember = "ClienteId";

            // PRODUCTOS
            var productos = _beProducto.ObtenerTodos();
            if (!string.IsNullOrEmpty(_beProducto.Error))
            {
                MessageBox.Show($"Error cargando productos: {_beProducto.Error}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _beProducto.Error = null;
            }

            comboProducto.DataSource = productos;
            comboProducto.DisplayMember = "NombreModelo";   // ajustá si tu propiedad se llama distinto
            comboProducto.ValueMember = "ProductoId";

            // TALLES (todos los talles disponibles)
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

            comboTalle.SelectedIndex = -1;  // sin talle por defecto
            ActualizarEstadoTallePorProducto();
        }
        private void ConfigurarDataGrid()
        {
            dataGridViewLineas.AutoGenerateColumns = true;
            dataGridViewLineas.DataSource = _lineasVenta;
            dataGridViewLineas.ClearSelection();
            buttonQuitarLinea.Enabled = false;
        }

        private void dataGridViewLineas_SelectionChanged(object sender, EventArgs e)
        {
            buttonQuitarLinea.Enabled = dataGridViewLineas.SelectedRows.Count > 0;
        }
        private void ActualizarTotal()
        {
            int total = _lineasVenta.Sum(l => l.Subtotal);
            textBoxTotal.Text = total.ToString();
        }

        private void LimpiarLinea(bool mantenerCliente = true)
        {
            numericCantidad.Value = 1;
            numericPrecioUnitario.Value = 0;

            comboProducto.SelectedIndex = -1;
            comboTalle.SelectedIndex = -1;

            if (!mantenerCliente)
            {
                comboCliente.SelectedIndex = -1;
                textBoxTotal.Text = "0";
            }

            dataGridViewLineas.ClearSelection();
            buttonQuitarLinea.Enabled = false;
        }

        private void buttonAgregarLinea_Click(object sender, EventArgs e)
        {
            if (comboCliente.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericPrecioUnitario.Value <= 0)
            {
                MessageBox.Show("El precio unitario debe ser mayor a cero.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var prod = (Producto)comboProducto.SelectedItem;

            int? talleId = null;
            string talleNombre = null;

            if (comboTalle.SelectedItem != null)
            {
                var talle = (Talle)comboTalle.SelectedItem;
                talleId = talle.TalleId;
                talleNombre = talle.Talles;
            }

            var linea = new LineaVentaEnCarga
            {
                ProductoId = prod.ProductoId,
                ProductoNombre = prod.NombreModelo,
                TalleId = talleId,
                TalleNombre = talleNombre,
                Cantidad = (int)numericCantidad.Value,
                PrecioUnitario = (int)numericPrecioUnitario.Value
            };

            _lineasVenta.Add(linea);
            ActualizarTotal();
            LimpiarLinea(mantenerCliente: true);
        }

        private void buttonQuitarLinea_Click(object sender, EventArgs e)
        {
            if (dataGridViewLineas.SelectedRows.Count == 0) return;

            var row = dataGridViewLineas.SelectedRows[0];
            if (row.DataBoundItem is LineaVentaEnCarga linea)
            {
                _lineasVenta.Remove(linea);
                ActualizarTotal();
                dataGridViewLineas.ClearSelection();
                buttonQuitarLinea.Enabled = false;
            }
        }
        private void ActualizarEstadoTallePorProducto()
        {
            comboTalle.Enabled = false;
            comboTalle.SelectedIndex = -1;

            if (comboProducto.SelectedItem is Producto prod)
            {
                var tipo = _tiposProducto
                    .FirstOrDefault(t => t.TipoProductoId == prod.TipoProductoId);

                if (tipo != null && tipo.PoseeTalle)
                {
                    comboTalle.Enabled = true;
                }
            }
        }


        private void buttonVender_Click(object sender, EventArgs e)
        {
            if (comboCliente.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_lineasVenta.Count == 0)
            {
                MessageBox.Show("No hay líneas de venta cargadas.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show(
                "Se registrará la venta con todas las líneas cargadas.\n¿Desea continuar?",
                "Confirmar venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                var cliente = (Cliente)comboCliente.SelectedItem;

                var venta = new Venta
                {
                    VentaId = 0,
                    ClienteId = cliente.ClienteId,
                    Fecha = dateTimePickerFecha.Value,
                    Detalles = new List<VentaDetalle>(),
                    DetallesTalle = new List<VentaTalle>()
                };

                // 1) Detalle por producto (VentasProducto)
                var gruposProducto = _lineasVenta
                    .GroupBy(l => new { l.ProductoId, l.PrecioUnitario });

                foreach (var g in gruposProducto)
                {
                    int cantidadTotal = g.Sum(x => x.Cantidad);

                    venta.Detalles.Add(new VentaDetalle
                    {
                        VentaId = 0, // se setea en DAL
                        ProductoId = g.Key.ProductoId,
                        Cantidad = cantidadTotal,
                        Precio = g.Key.PrecioUnitario
                    });
                }

                // 2) Detalle por talle (VentasTalles)
                foreach (var l in _lineasVenta.Where(x => x.TalleId.HasValue))
                {
                    venta.DetallesTalle.Add(new VentaTalle
                    {
                        VentaId = 0, // se setea en DAL
                        ProductoId = l.ProductoId,
                        TalleId = l.TalleId.Value,
                        Cant = l.Cantidad
                    });
                }

                int nuevaVentaId = _beVentas.CrearVentaConDetalles(venta);

                if (nuevaVentaId <= 0)
                {
                    MessageBox.Show(
                        _beVentas.Error ?? "No se pudo registrar la venta.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Venta registrada correctamente. Nro: {nuevaVentaId}",
                                "OK",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // limpiar todo
                _lineasVenta.Clear();
                ActualizarTotal();
                LimpiarLinea(mantenerCliente: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción al registrar la venta: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void comboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEstadoTallePorProducto();
        }
    }
}
