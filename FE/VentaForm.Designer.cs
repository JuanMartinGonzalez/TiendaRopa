namespace TiendaRopa.FE
{
    partial class VentaForm
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
            buttonVender = new Button();
            label6 = new Label();
            numericPrecioUnitario = new NumericUpDown();
            buttonQuitarLinea = new Button();
            buttonAgregarLinea = new Button();
            dataGridViewLineas = new DataGridView();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            numericCantidad = new NumericUpDown();
            comboTalle = new ComboBox();
            comboProducto = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            textBoxTotal = new TextBox();
            dateTimePickerFecha = new DateTimePicker();
            comboCliente = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericPrecioUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLineas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCantidad).BeginInit();
            SuspendLayout();
            // 
            // buttonVender
            // 
            buttonVender.Location = new Point(610, 468);
            buttonVender.Name = "buttonVender";
            buttonVender.Size = new Size(232, 35);
            buttonVender.TabIndex = 33;
            buttonVender.Text = "Vender";
            buttonVender.UseVisualStyleBackColor = true;
            buttonVender.Click += buttonVender_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(161, 285);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 32;
            label6.Text = "Precio unitario";
            // 
            // numericPrecioUnitario
            // 
            numericPrecioUnitario.Location = new Point(257, 283);
            numericPrecioUnitario.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericPrecioUnitario.Name = "numericPrecioUnitario";
            numericPrecioUnitario.Size = new Size(120, 23);
            numericPrecioUnitario.TabIndex = 31;
            // 
            // buttonQuitarLinea
            // 
            buttonQuitarLinea.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonQuitarLinea.Location = new Point(297, 373);
            buttonQuitarLinea.Name = "buttonQuitarLinea";
            buttonQuitarLinea.Size = new Size(80, 50);
            buttonQuitarLinea.TabIndex = 30;
            buttonQuitarLinea.Text = "-";
            buttonQuitarLinea.UseVisualStyleBackColor = true;
            buttonQuitarLinea.Click += buttonQuitarLinea_Click;
            // 
            // buttonAgregarLinea
            // 
            buttonAgregarLinea.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAgregarLinea.Location = new Point(170, 373);
            buttonAgregarLinea.Name = "buttonAgregarLinea";
            buttonAgregarLinea.Size = new Size(82, 50);
            buttonAgregarLinea.TabIndex = 29;
            buttonAgregarLinea.Text = "+";
            buttonAgregarLinea.UseVisualStyleBackColor = true;
            buttonAgregarLinea.Click += buttonAgregarLinea_Click;
            // 
            // dataGridViewLineas
            // 
            dataGridViewLineas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLineas.Location = new Point(469, 134);
            dataGridViewLineas.Name = "dataGridViewLineas";
            dataGridViewLineas.Size = new Size(712, 318);
            dataGridViewLineas.TabIndex = 28;
            dataGridViewLineas.SelectionChanged += dataGridViewLineas_SelectionChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(161, 327);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 27;
            label5.Text = "Cantidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(161, 244);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 26;
            label4.Text = "Talle";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(161, 202);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 25;
            label3.Text = "Producto";
            // 
            // numericCantidad
            // 
            numericCantidad.Location = new Point(257, 325);
            numericCantidad.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericCantidad.Name = "numericCantidad";
            numericCantidad.Size = new Size(120, 23);
            numericCantidad.TabIndex = 24;
            // 
            // comboTalle
            // 
            comboTalle.FormattingEnabled = true;
            comboTalle.Location = new Point(257, 241);
            comboTalle.Name = "comboTalle";
            comboTalle.Size = new Size(121, 23);
            comboTalle.TabIndex = 23;
            // 
            // comboProducto
            // 
            comboProducto.FormattingEnabled = true;
            comboProducto.Location = new Point(257, 199);
            comboProducto.Name = "comboProducto";
            comboProducto.Size = new Size(121, 23);
            comboProducto.TabIndex = 22;
            comboProducto.SelectedIndexChanged += comboProducto_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 160);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 21;
            label2.Text = "Cliente";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(925, 483);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 20;
            label1.Text = "Total";
            // 
            // textBoxTotal
            // 
            textBoxTotal.Location = new Point(1005, 475);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.Size = new Size(176, 23);
            textBoxTotal.TabIndex = 19;
            // 
            // dateTimePickerFecha
            // 
            dateTimePickerFecha.Location = new Point(161, 69);
            dateTimePickerFecha.Name = "dateTimePickerFecha";
            dateTimePickerFecha.Size = new Size(242, 23);
            dateTimePickerFecha.TabIndex = 18;
            // 
            // comboCliente
            // 
            comboCliente.FormattingEnabled = true;
            comboCliente.Location = new Point(257, 157);
            comboCliente.Name = "comboCliente";
            comboCliente.Size = new Size(121, 23);
            comboCliente.TabIndex = 17;
            // 
            // VentaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1343, 573);
            Controls.Add(buttonVender);
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
            Controls.Add(comboCliente);
            Name = "VentaForm";
            Text = "VentaForm";
            Load += VentaForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericPrecioUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLineas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonVender;
        private Label label6;
        private NumericUpDown numericPrecioUnitario;
        private Button buttonQuitarLinea;
        private Button buttonAgregarLinea;
        private DataGridView dataGridViewLineas;
        private Label label5;
        private Label label4;
        private Label label3;
        private NumericUpDown numericCantidad;
        private ComboBox comboTalle;
        private ComboBox comboProducto;
        private Label label2;
        private Label label1;
        private TextBox textBoxTotal;
        private DateTimePicker dateTimePickerFecha;
        private ComboBox comboCliente;
    }
}