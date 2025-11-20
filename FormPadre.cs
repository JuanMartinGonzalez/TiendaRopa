using Microsoft.Data.SqlClient;
using TiendaRopa.FE;

namespace TiendaRopa
{
    public partial class FormPadre : Form
    {
        public FormPadre()
        {
            InitializeComponent();
        }
        public class ConexionBD
        {
            private readonly string _connectionString;

            public ConexionBD()
            {

                _connectionString = Environment.GetEnvironmentVariable("TiendaDB")
                                    ?? throw new InvalidOperationException("❌ No se encontró la variable de entorno CADENA_CONEXION_SQL_EmpresaManzanilla");
            }

            public SqlConnection ObtenerConexion()
            {
                return new SqlConnection(_connectionString);
            }
        }
        private void OpenChildForm(Form child)
        {
            // Si ya existe una instancia del mismo tipo, la activamos
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == child.GetType())
                {
                    frm.Activate();
                    return;
                }
            }

            // Configurar y mostrar la nueva instancia
            child.MdiParent = this;
            child.WindowState = FormWindowState.Maximized;
            child.Show();
        }
        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClienteForm());
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProveedorForm());
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MarcaForm());
        }

        private void tallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TalleForm());
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductoForm());
        }

        private void categoriaProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TipoProductoForm());
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CompraForm());
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VentaForm());
        }
    }
}
