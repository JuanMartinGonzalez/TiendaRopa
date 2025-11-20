namespace TiendaRopa
{
    partial class FormPadre
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            proveedorToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            marcasToolStripMenuItem = new ToolStripMenuItem();
            tallesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { clienteToolStripMenuItem, proveedorToolStripMenuItem, productosToolStripMenuItem, marcasToolStripMenuItem, tallesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(69, 24);
            clienteToolStripMenuItem.Text = "Cliente";
            clienteToolStripMenuItem.Click += clienteToolStripMenuItem_Click;
            // 
            // proveedorToolStripMenuItem
            // 
            proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            proveedorToolStripMenuItem.Size = new Size(91, 24);
            proveedorToolStripMenuItem.Text = "Proveedor";
            proveedorToolStripMenuItem.Click += proveedorToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(89, 24);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // marcasToolStripMenuItem
            // 
            marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            marcasToolStripMenuItem.Size = new Size(70, 24);
            marcasToolStripMenuItem.Text = "Marcas";
            marcasToolStripMenuItem.Click += marcasToolStripMenuItem_Click;
            // 
            // tallesToolStripMenuItem
            // 
            tallesToolStripMenuItem.Name = "tallesToolStripMenuItem";
            tallesToolStripMenuItem.Size = new Size(59, 24);
            tallesToolStripMenuItem.Text = "Talles";
            // 
            // FormPadre
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormPadre";
            Text = "FormPadre";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem proveedorToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem marcasToolStripMenuItem;
        private ToolStripMenuItem tallesToolStripMenuItem;
    }
}
