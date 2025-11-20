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
    public partial class CompraForm : Form
    {
        private readonly BECompras _beCompras = new BECompras();
        private readonly BEProveedor _beProveedor = new BEProveedor();
        private readonly BEProducto _beProducto = new BEProducto();
        private readonly BETalle _beTalle = new BETalle();
        private readonly BETipoProducto _beTipoProducto = new BETipoProducto();

        private List<TipoProducto> _tiposProducto = new List<TipoProducto>();
        private readonly BindingList<LineaCompraEnCarga> _lineasCompra =
            new BindingList<LineaCompraEnCarga>();

        public CompraForm()
        {
            InitializeComponent();
        }

        private void CompraForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            ConfigurarDataGrid();
            dateTimePickerFecha.Value = DateTime.Now;
            ActualizarTotal();
        }
        private void CargarCombos()
        {
            _tiposProducto = _beTipoProducto.ObtenerTodos();
            if (!string.IsNullOrEmpty(_beTipoProducto.Error))
            {
                MessageBox.Show($"Error cargando tipos de producto: {_beTipoProducto.Error}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _beTipoProducto.Error = null;
            }

            var proveedores = _beProveedor.ObtenerTodos();
            if (!string.IsNullOrEmpty(_beProveedor.Error))
            {
                MessageBox.Show($"Error cargando proveedores: {_beProveedor.Error}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _beProveedor.Error = null;
            }

            comboProveedor.DataSource = proveedores;
            comboProveedor.DisplayMember = "Nombre";      // o NombreCompleto, ajustá a tu modelo
            comboProveedor.ValueMember = "ProveedorId";

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
        }
        private void ConfigurarDataGrid()
        {
            dataGridViewLineas.AutoGenerateColumns = true;
            dataGridViewLineas.DataSource = _lineasCompra;
            dataGridViewLineas.ClearSelection();
            buttonQuitarLinea.Enabled = false;
        }

        private void dataGridViewLineas_SelectionChanged(object sender, EventArgs e)
        {
            buttonQuitarLinea.Enabled = dataGridViewLineas.SelectedRows.Count > 0;
        }
        private void ActualizarTotal()
        {
            int total = _lineasCompra.Sum(l => l.Subtotal);
            textBoxTotal.Text = total.ToString();
        }

        private void LimpiarLinea(bool mantenerProveedor = true)
        {
            numericCantidad.Value = 1;
            numericPrecioUnitario.Value = 0;

            comboProducto.SelectedIndex = -1;
            comboTalle.SelectedIndex = -1;

            if (!mantenerProveedor)
            {
                comboProveedor.SelectedIndex = -1;
                textBoxTotal.Text = "0";
            }

            dataGridViewLineas.ClearSelection();
            buttonQuitarLinea.Enabled = false;
        }

        private void buttonAgregarLinea_Click(object sender, EventArgs e)
        {
            if (comboProveedor.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un proveedor.",
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

            var linea = new LineaCompraEnCarga
            {
                ProductoId = prod.ProductoId,
                ProductoNombre = prod.NombreModelo,
                TalleId = talleId,
                TalleNombre = talleNombre,
                Cantidad = (int)numericCantidad.Value,
                PrecioUnitario = (int)numericPrecioUnitario.Value
            };

            _lineasCompra.Add(linea);
            ActualizarTotal();
            LimpiarLinea(mantenerProveedor: true);
        }

        private void buttonQuitarLinea_Click(object sender, EventArgs e)
        {
            if (dataGridViewLineas.SelectedRows.Count == 0) return;

            var row = dataGridViewLineas.SelectedRows[0];
            if (row.DataBoundItem is LineaCompraEnCarga linea)
            {
                _lineasCompra.Remove(linea);
                ActualizarTotal();
                dataGridViewLineas.ClearSelection();
                buttonQuitarLinea.Enabled = false;
            }
        }

        private void buttonVender_Click(object sender, EventArgs e)
        {
            if (comboProveedor.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un proveedor.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_lineasCompra.Count == 0)
            {
                MessageBox.Show("No hay líneas de compra cargadas.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show(
                "Se registrará la compra con todas las líneas cargadas.\n¿Desea continuar?",
                "Confirmar compra",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                var proveedor = (Proveedor)comboProveedor.SelectedItem;

                var compra = new Compra
                {
                    CompraId = 0,
                    ProveedorId = proveedor.ProveedorId,
                    Fecha = dateTimePickerFecha.Value,
                    Detalles = new List<CompraDetalle>(),
                    DetallesTalle = new List<CompraTalle>()
                };

                // 1) Detalle por producto (ComprasProducto)
                var gruposProducto = _lineasCompra
                    .GroupBy(l => new { l.ProductoId, l.PrecioUnitario });

                foreach (var g in gruposProducto)
                {
                    int cantidadTotal = g.Sum(x => x.Cantidad);

                    compra.Detalles.Add(new CompraDetalle
                    {
                        CompraId = 0, // se setea en DAL
                        ProductoId = g.Key.ProductoId,
                        Cantidad = cantidadTotal,
                        Precio = g.Key.PrecioUnitario
                    });
                }

                // 2) Detalle por talle (ComprasTalles)
                foreach (var l in _lineasCompra.Where(x => x.TalleId.HasValue))
                {
                    compra.DetallesTalle.Add(new CompraTalle
                    {
                        CompraId = 0, // se setea en DAL
                        ProductoId = l.ProductoId,
                        TalleId = l.TalleId.Value,
                        Cant = l.Cantidad
                    });
                }

                int nuevaCompraId = _beCompras.CrearCompraConDetalles(compra);

                if (nuevaCompraId <= 0)
                {
                    MessageBox.Show(
                        _beCompras.Error ?? "No se pudo registrar la compra.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show($"Compra registrada correctamente. Nro: {nuevaCompraId}",
                                "OK",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // limpiar todo
                _lineasCompra.Clear();
                ActualizarTotal();
                LimpiarLinea(mantenerProveedor: false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepción al registrar la compra: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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

        private void comboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEstadoTallePorProducto();
        }
    }
}

