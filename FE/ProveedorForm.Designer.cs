namespace TiendaRopa.FE
{
    partial class ProveedorForm
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
            textBoxCUIT = new TextBox();
            label2 = new Label();
            textBoxNombre = new TextBox();
            label1 = new Label();
            dataGridViewProveedores = new DataGridView();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            buttonAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProveedores).BeginInit();
            SuspendLayout();
            // 
            // textBoxCUIT
            // 
            textBoxCUIT.Location = new Point(157, 105);
            textBoxCUIT.Name = "textBoxCUIT";
            textBoxCUIT.Size = new Size(204, 27);
            textBoxCUIT.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 112);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 22;
            label2.Text = "CUIT";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(157, 44);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(204, 27);
            textBoxNombre.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 51);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 20;
            label1.Text = "Nombre";
            // 
            // dataGridViewProveedores
            // 
            dataGridViewProveedores.AllowUserToAddRows = false;
            dataGridViewProveedores.AllowUserToDeleteRows = false;
            dataGridViewProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProveedores.Location = new Point(409, 27);
            dataGridViewProveedores.MultiSelect = false;
            dataGridViewProveedores.Name = "dataGridViewProveedores";
            dataGridViewProveedores.ReadOnly = true;
            dataGridViewProveedores.RowHeadersWidth = 51;
            dataGridViewProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProveedores.Size = new Size(679, 401);
            dataGridViewProveedores.TabIndex = 19;
            dataGridViewProveedores.SelectionChanged += dataGridViewProveedores_SelectionChanged;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(267, 198);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(94, 29);
            buttonModificar.TabIndex = 18;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(157, 198);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(94, 29);
            buttonEliminar.TabIndex = 17;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(47, 198);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(94, 29);
            buttonAgregar.TabIndex = 16;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // ProveedorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 454);
            Controls.Add(textBoxCUIT);
            Controls.Add(label2);
            Controls.Add(textBoxNombre);
            Controls.Add(label1);
            Controls.Add(dataGridViewProveedores);
            Controls.Add(buttonModificar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonAgregar);
            Name = "ProveedorForm";
            Text = "ProveedorForm";
            Load += ProveedorForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxCUIT;
        private Label label2;
        private TextBox textBoxNombre;
        private Label label1;
        private DataGridView dataGridViewProveedores;
        private Button buttonModificar;
        private Button buttonEliminar;
        private Button buttonAgregar;
    }
}