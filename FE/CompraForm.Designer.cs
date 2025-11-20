namespace TiendaRopa.FE
{
    partial class CompraForm
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
            comboProveedor = new ComboBox();
            dateTimePickerFecha = new DateTimePicker();
            textBoxTotal = new TextBox();
            label1 = new Label();
            label2 = new Label();
            comboProducto = new ComboBox();
            comboTalle = new ComboBox();
            numericCantidad = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dataGridViewLineas = new DataGridView();
            buttonQuitarLinea = new Button();
            buttonAgregarLinea = new Button();
            label6 = new Label();
            numericPrecioUnitario = new NumericUpDown();
            buttonComprar = new Button();
            ((System.ComponentModel.ISupportInitialize)numericCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLineas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPrecioUnitario).BeginInit();
            SuspendLayout();
            // 
            // comboProveedor
            // 
            comboProveedor.FormattingEnabled = true;
            comboProveedor.Location = new Point(118, 100);
            comboProveedor.Name = "comboProveedor";
            comboProveedor.Size = new Size(121, 23);
            comboProveedor.TabIndex = 0;
            // 
            // dateTimePickerFecha
            // 
            dateTimePickerFecha.Location = new Point(22, 12);
            dateTimePickerFecha.Name = "dateTimePickerFecha";
            dateTimePickerFecha.Size = new Size(242, 23);
            dateTimePickerFecha.TabIndex = 1;
            // 
            // textBoxTotal
            // 
            textBoxTotal.Location = new Point(866, 418);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.Size = new Size(176, 23);
            textBoxTotal.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(786, 426);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 3;
            label1.Text = "Total";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 103);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 4;
            label2.Text = "Proveedor";
            // 
            // comboProducto
            // 
            comboProducto.FormattingEnabled = true;
            comboProducto.Location = new Point(118, 142);
            comboProducto.Name = "comboProducto";
            comboProducto.Size = new Size(121, 23);
            comboProducto.TabIndex = 5;
            comboProducto.SelectedIndexChanged += comboProducto_SelectedIndexChanged;
            // 
            // comboTalle
            // 
            comboTalle.FormattingEnabled = true;
            comboTalle.Location = new Point(118, 184);
            comboTalle.Name = "comboTalle";
            comboTalle.Size = new Size(121, 23);
            comboTalle.TabIndex = 6;
            // 
            // numericCantidad
            // 
            numericCantidad.Location = new Point(118, 268);
            numericCantidad.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericCantidad.Name = "numericCantidad";
            numericCantidad.Size = new Size(120, 23);
            numericCantidad.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 145);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 8;
            label3.Text = "Producto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 187);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 9;
            label4.Text = "Talle";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 270);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 10;
            label5.Text = "Cantidad";
            // 
            // dataGridViewLineas
            // 
            dataGridViewLineas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLineas.Location = new Point(330, 77);
            dataGridViewLineas.Name = "dataGridViewLineas";
            dataGridViewLineas.Size = new Size(712, 318);
            dataGridViewLineas.TabIndex = 11;
            dataGridViewLineas.SelectionChanged += dataGridViewLineas_SelectionChanged;
            // 
            // buttonQuitarLinea
            // 
            buttonQuitarLinea.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonQuitarLinea.Location = new Point(158, 316);
            buttonQuitarLinea.Name = "buttonQuitarLinea";
            buttonQuitarLinea.Size = new Size(80, 50);
            buttonQuitarLinea.TabIndex = 13;
            buttonQuitarLinea.Text = "-";
            buttonQuitarLinea.UseVisualStyleBackColor = true;
            buttonQuitarLinea.Click += buttonQuitarLinea_Click;
            // 
            // buttonAgregarLinea
            // 
            buttonAgregarLinea.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAgregarLinea.Location = new Point(31, 316);
            buttonAgregarLinea.Name = "buttonAgregarLinea";
            buttonAgregarLinea.Size = new Size(82, 50);
            buttonAgregarLinea.TabIndex = 12;
            buttonAgregarLinea.Text = "+";
            buttonAgregarLinea.UseVisualStyleBackColor = true;
            buttonAgregarLinea.Click += buttonAgregarLinea_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 228);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 15;
            label6.Text = "Precio unitario";
            // 
            // numericPrecioUnitario
            // 
            numericPrecioUnitario.Location = new Point(118, 226);
            numericPrecioUnitario.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericPrecioUnitario.Name = "numericPrecioUnitario";
            numericPrecioUnitario.Size = new Size(120, 23);
            numericPrecioUnitario.TabIndex = 14;
            // 
            // buttonComprar
            // 
            buttonComprar.Location = new Point(471, 411);
            buttonComprar.Name = "buttonComprar";
            buttonComprar.Size = new Size(232, 35);
            buttonComprar.TabIndex = 16;
            buttonComprar.Text = "Comprar";
            buttonComprar.UseVisualStyleBackColor = true;
            buttonComprar.Click += buttonVender_Click;
            // 
            // CompraForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1229, 522);
            Controls.Add(buttonComprar);
            Controls.Add(label6);
            Controls.Add(numericPrecioUnitario);
            Controls.Add(buttonQuitarLinea);
            Controls.Add(buttonAgregarLinea);
            Controls.Add(dataGridViewLineas);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(numericCantidad);
            Controls.Add(comboTalle);
            Controls.Add(comboProducto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxTotal);
            Controls.Add(dateTimePickerFecha);
            Controls.Add(comboProveedor);
            Name = "CompraForm";
            Text = "CompraForm";
            Load += CompraForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLineas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPrecioUnitario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboProveedor;
        private DateTimePicker dateTimePickerFecha;
        private TextBox textBoxTotal;
        private Label label1;
        private Label label2;
        private ComboBox comboProducto;
        private ComboBox comboTalle;
        private NumericUpDown numericCantidad;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dataGridViewLineas;
        private Button buttonQuitarLinea;
        private Button buttonAgregarLinea;
        private Label label6;
        private NumericUpDown numericPrecioUnitario;
        private Button buttonComprar;
    }
}