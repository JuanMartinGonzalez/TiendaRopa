namespace TiendaRopa.FE
{
    partial class TipoProductoForm
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
            textBoxNombreTipo = new TextBox();
            label1 = new Label();
            dataGridViewTipoProducto = new DataGridView();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            buttonAgregar = new Button();
            checkBoxPoseeTalle = new CheckBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTipoProducto).BeginInit();
            SuspendLayout();
            // 
            // textBoxNombreTipo
            // 
            textBoxNombreTipo.Location = new Point(155, 88);
            textBoxNombreTipo.Margin = new Padding(3, 2, 3, 2);
            textBoxNombreTipo.MaxLength = 100;
            textBoxNombreTipo.Name = "textBoxNombreTipo";
            textBoxNombreTipo.Size = new Size(179, 23);
            textBoxNombreTipo.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 96);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 20;
            label1.Text = "Nombre categoria";
            // 
            // dataGridViewTipoProducto
            // 
            dataGridViewTipoProducto.AllowUserToAddRows = false;
            dataGridViewTipoProducto.AllowUserToDeleteRows = false;
            dataGridViewTipoProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTipoProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTipoProducto.Location = new Point(395, 42);
            dataGridViewTipoProducto.Margin = new Padding(3, 2, 3, 2);
            dataGridViewTipoProducto.MultiSelect = false;
            dataGridViewTipoProducto.Name = "dataGridViewTipoProducto";
            dataGridViewTipoProducto.ReadOnly = true;
            dataGridViewTipoProducto.RowHeadersWidth = 51;
            dataGridViewTipoProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTipoProducto.Size = new Size(594, 301);
            dataGridViewTipoProducto.TabIndex = 19;
            // 
            // buttonModificar
            // 
            buttonModificar.Location = new Point(252, 238);
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
            buttonEliminar.Location = new Point(155, 238);
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
            buttonAgregar.Location = new Point(59, 238);
            buttonAgregar.Margin = new Padding(3, 2, 3, 2);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(82, 22);
            buttonAgregar.TabIndex = 16;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // checkBoxPoseeTalle
            // 
            checkBoxPoseeTalle.AutoSize = true;
            checkBoxPoseeTalle.Location = new Point(155, 148);
            checkBoxPoseeTalle.Name = "checkBoxPoseeTalle";
            checkBoxPoseeTalle.Size = new Size(15, 14);
            checkBoxPoseeTalle.TabIndex = 22;
            checkBoxPoseeTalle.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 147);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 23;
            label2.Text = "Posee talle";
            // 
            // TipoProductoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1366, 584);
            Controls.Add(label2);
            Controls.Add(checkBoxPoseeTalle);
            Controls.Add(textBoxNombreTipo);
            Controls.Add(label1);
            Controls.Add(dataGridViewTipoProducto);
            Controls.Add(buttonModificar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonAgregar);
            Name = "TipoProductoForm";
            Text = "TipoProductoForm";
            Load += TipoProductoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTipoProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNombreTipo;
        private Label label1;
        private DataGridView dataGridViewTipoProducto;
        private Button buttonModificar;
        private Button buttonEliminar;
        private Button buttonAgregar;
        private CheckBox checkBoxPoseeTalle;
        private Label label2;
    }
}