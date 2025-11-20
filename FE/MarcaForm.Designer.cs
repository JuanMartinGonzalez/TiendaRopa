namespace TiendaRopa.FE
{
    partial class MarcaForm
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
            textBoxNombre = new TextBox();
            label1 = new Label();
            dataGridViewMarcas = new DataGridView();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            buttonAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarcas).BeginInit();
            SuspendLayout();
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(132, 35);
            textBoxNombre.Margin = new Padding(3, 2, 3, 2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(179, 23);
            textBoxNombre.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 40);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 28;
            label1.Text = "Nombre";
            // 
            // dataGridViewMarcas
            // 
            dataGridViewMarcas.AllowUserToAddRows = false;
            dataGridViewMarcas.AllowUserToDeleteRows = false;
            dataGridViewMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMarcas.Location = new Point(353, 22);
            dataGridViewMarcas.Margin = new Padding(3, 2, 3, 2);
            dataGridViewMarcas.MultiSelect = false;
            dataGridViewMarcas.Name = "dataGridViewMarcas";
            dataGridViewMarcas.ReadOnly = true;
            dataGridViewMarcas.RowHeadersWidth = 51;
            dataGridViewMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMarcas.Size = new Size(594, 301);
            dataGridViewMarcas.TabIndex = 27;
            dataGridViewMarcas.SelectionChanged += dataGridViewMarcas_SelectionChanged;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(228, 151);
            buttonModificar.Margin = new Padding(3, 2, 3, 2);
            buttonModificar.Name = "buttonModificar";
            buttonModificar.Size = new Size(82, 22);
            buttonModificar.TabIndex = 26;
            buttonModificar.Text = "Modificar";
            buttonModificar.UseVisualStyleBackColor = true;
            buttonModificar.Click += buttonModificar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Location = new Point(132, 151);
            buttonEliminar.Margin = new Padding(3, 2, 3, 2);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(82, 22);
            buttonEliminar.TabIndex = 25;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Location = new Point(36, 151);
            buttonAgregar.Margin = new Padding(3, 2, 3, 2);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(82, 22);
            buttonAgregar.TabIndex = 24;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // MarcaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 345);
            Controls.Add(textBoxNombre);
            Controls.Add(label1);
            Controls.Add(dataGridViewMarcas);
            Controls.Add(buttonModificar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonAgregar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MarcaForm";
            Text = "MarcaForm";
            Load += MarcaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarcas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxCUIT;
        private Label label2;
        private TextBox textBoxNombre;
        private Label label1;
        private DataGridView dataGridViewMarcas;
        private Button buttonModificar;
        private Button buttonEliminar;
        private Button buttonAgregar;
    }
}