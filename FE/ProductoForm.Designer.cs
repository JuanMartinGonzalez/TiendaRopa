namespace TiendaRopa.FE
{
    partial class ProductoForm
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
            comboMarca = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboTipoProducto = new ComboBox();
            label3 = new Label();
            comboTalle = new ComboBox();
            label4 = new Label();
            textBoxNombreModelo = new TextBox();
            dataGridViewProductosPendientes = new DataGridView();
            buttonGuardarTodo = new Button();
            buttonAgregarAGrilla = new Button();
            buttonQuitarDeGrilla = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductosPendientes).BeginInit();
            SuspendLayout();
            // 
            // comboMarca
            // 
            comboMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMarca.FormattingEnabled = true;
            comboMarca.Location = new Point(218, 136);
            comboMarca.Name = "comboMarca";
            comboMarca.Size = new Size(121, 23);
            comboMarca.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 144);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Marca";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 93);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Categoria";
            // 
            // comboTipoProducto
            // 
            comboTipoProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipoProducto.FormattingEnabled = true;
            comboTipoProducto.Location = new Point(218, 85);
            comboTipoProducto.Name = "comboTipoProducto";
            comboTipoProducto.Size = new Size(121, 23);
            comboTipoProducto.TabIndex = 3;
            comboTipoProducto.SelectedIndexChanged += comboTipoProducto_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 195);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 5;
            label3.Text = "Talle";
            // 
            // comboTalle
            // 
            comboTalle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTalle.FormattingEnabled = true;
            comboTalle.Location = new Point(218, 187);
            comboTalle.Name = "comboTalle";
            comboTalle.Size = new Size(121, 23);
            comboTalle.TabIndex = 4;
            comboTalle.SelectedIndexChanged += comboTalle_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 246);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 6;
            label4.Text = "Nombre producto";
            // 
            // textBoxNombreModelo
            // 
            textBoxNombreModelo.Location = new Point(218, 238);
            textBoxNombreModelo.Name = "textBoxNombreModelo";
            textBoxNombreModelo.Size = new Size(121, 23);
            textBoxNombreModelo.TabIndex = 7;
            // 
            // dataGridViewProductosPendientes
            // 
            dataGridViewProductosPendientes.AllowUserToAddRows = false;
            dataGridViewProductosPendientes.AllowUserToDeleteRows = false;
            dataGridViewProductosPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductosPendientes.Location = new Point(433, 85);
            dataGridViewProductosPendientes.MultiSelect = false;
            dataGridViewProductosPendientes.Name = "dataGridViewProductosPendientes";
            dataGridViewProductosPendientes.ReadOnly = true;
            dataGridViewProductosPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProductosPendientes.Size = new Size(818, 237);
            dataGridViewProductosPendientes.TabIndex = 8;
            // 
            // buttonGuardarTodo
            // 
            buttonGuardarTodo.Location = new Point(1044, 363);
            buttonGuardarTodo.Name = "buttonGuardarTodo";
            buttonGuardarTodo.Size = new Size(207, 50);
            buttonGuardarTodo.TabIndex = 9;
            buttonGuardarTodo.Text = "Guardar";
            buttonGuardarTodo.UseVisualStyleBackColor = true;
            buttonGuardarTodo.Click += buttonGuardarTodo_Click;
            // 
            // buttonAgregarAGrilla
            // 
            buttonAgregarAGrilla.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAgregarAGrilla.Location = new Point(433, 363);
            buttonAgregarAGrilla.Name = "buttonAgregarAGrilla";
            buttonAgregarAGrilla.Size = new Size(82, 50);
            buttonAgregarAGrilla.TabIndex = 10;
            buttonAgregarAGrilla.Text = "+";
            buttonAgregarAGrilla.UseVisualStyleBackColor = true;
            buttonAgregarAGrilla.Click += buttonAgregarAGrilla_Click;
            // 
            // buttonQuitarDeGrilla
            // 
            buttonQuitarDeGrilla.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonQuitarDeGrilla.Location = new Point(560, 363);
            buttonQuitarDeGrilla.Name = "buttonQuitarDeGrilla";
            buttonQuitarDeGrilla.Size = new Size(80, 50);
            buttonQuitarDeGrilla.TabIndex = 11;
            buttonQuitarDeGrilla.Text = "-";
            buttonQuitarDeGrilla.UseVisualStyleBackColor = true;
            buttonQuitarDeGrilla.Click += buttonQuitarDeGrilla_Click;
            // 
            // ProductoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1410, 603);
            Controls.Add(buttonQuitarDeGrilla);
            Controls.Add(buttonAgregarAGrilla);
            Controls.Add(buttonGuardarTodo);
            Controls.Add(dataGridViewProductosPendientes);
            Controls.Add(textBoxNombreModelo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboTalle);
            Controls.Add(comboTipoProducto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboMarca);
            Name = "ProductoForm";
            Text = "ProductoForm";
            Load += ProductoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductosPendientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboMarca;
        private Label label1;
        private Label label2;
        private ComboBox comboTipoProducto;
        private Label label3;
        private ComboBox comboTalle;
        private Label label4;
        private TextBox textBoxNombreModelo;
        private DataGridView dataGridViewProductosPendientes;
        private Button buttonGuardarTodo;
        private Button buttonAgregarAGrilla;
        private Button buttonQuitarDeGrilla;
    }
}