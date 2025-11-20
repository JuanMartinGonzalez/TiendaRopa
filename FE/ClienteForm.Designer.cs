namespace TiendaRopa.FE
{
    partial class ClienteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxDNI = new TextBox();
            label2 = new Label();
            textBoxNombre = new TextBox();
            label1 = new Label();
            dataGridViewClientes = new DataGridView();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            buttonAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
            SuspendLayout();
            // 
            // textBoxDNI
            // 
            textBoxDNI.Location = new Point(165, 114);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.Size = new Size(204, 27);
            textBoxDNI.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 121);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 14;
            label2.Text = "DNI";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(165, 53);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(204, 27);
            textBoxNombre.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 60);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 12;
            label1.Text = "Nombre";
            // 
            // dataGridViewClientes
            // 
            dataGridViewClientes.AllowUserToAddRows = false;
            dataGridViewClientes.AllowUserToDeleteRows = false;
            dataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClientes.Location = new Point(417, 36);
            dataGridViewClientes.MultiSelect = false;
            dataGridViewClientes.Name = "dataGridViewClientes";
            dataGridViewClientes.ReadOnly = true;
            dataGridViewClientes.RowHeadersWidth = 51;
            dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClientes.Size = new Size(679, 401);
            dataGridViewClientes.TabIndex = 11;
            dataGridViewClientes.SelectionChanged += dataGridViewClientes_SelectionChanged;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(275, 207);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(94, 29);
            buttonModificar.TabIndex = 10;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(165, 207);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(94, 29);
            buttonEliminar.TabIndex = 9;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(55, 207);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(94, 29);
            buttonAgregar.TabIndex = 8;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // ClienteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 472);
            Controls.Add(textBoxDNI);
            Controls.Add(label2);
            Controls.Add(textBoxNombre);
            Controls.Add(label1);
            Controls.Add(dataGridViewClientes);
            Controls.Add(buttonModificar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonAgregar);
            Name = "ClienteForm";
            Text = "ClienteForm";
            Load += ClienteForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxDNI;
        private Label label2;
        private TextBox textBoxNombre;
        private Label label1;
        private DataGridView dataGridViewClientes;
        private Button buttonModificar;
        private Button buttonEliminar;
        private Button buttonAgregar;
    }
}