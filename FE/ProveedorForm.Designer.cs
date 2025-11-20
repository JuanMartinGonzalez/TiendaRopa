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
            textBoxCUIT.Location = new Point(137, 79);
            textBoxCUIT.Margin = new Padding(3, 2, 3, 2);
            textBoxCUIT.Name = "textBoxCUIT";
            textBoxCUIT.Size = new Size(179, 23);
            textBoxCUIT.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 84);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 22;
            label2.Text = "CUIT";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(137, 33);
            textBoxNombre.Margin = new Padding(3, 2, 3, 2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(179, 23);
            textBoxNombre.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 38);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 20;
            label1.Text = "Nombre";
            // 
            // dataGridViewProveedores
            // 
            dataGridViewProveedores.AllowUserToAddRows = false;
            dataGridViewProveedores.AllowUserToDeleteRows = false;
            dataGridViewProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProveedores.Location = new Point(358, 20);
            dataGridViewProveedores.Margin = new Padding(3, 2, 3, 2);
            dataGridViewProveedores.MultiSelect = false;
            dataGridViewProveedores.Name = "dataGridViewProveedores";
            dataGridViewProveedores.ReadOnly = true;
            dataGridViewProveedores.RowHeadersWidth = 51;
            dataGridViewProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProveedores.Size = new Size(594, 301);
            dataGridViewProveedores.TabIndex = 19;
            dataGridViewProveedores.SelectionChanged += dataGridViewProveedores_SelectionChanged;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(234, 148);
            buttonModificar.Margin = new Padding(3, 2, 3, 2);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(82, 22);
            buttonModificar.TabIndex = 18;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(137, 148);
            buttonEliminar.Margin = new Padding(3, 2, 3, 2);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(82, 22);
            buttonEliminar.TabIndex = 17;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(41, 148);
            buttonAgregar.Margin = new Padding(3, 2, 3, 2);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(82, 22);
            buttonAgregar.TabIndex = 16;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // ProveedorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 340);
            Controls.Add(textBoxCUIT);
            Controls.Add(label2);
            Controls.Add(textBoxNombre);
            Controls.Add(label1);
            Controls.Add(dataGridViewProveedores);
            Controls.Add(buttonModificar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonAgregar);
            Margin = new Padding(3, 2, 3, 2);
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