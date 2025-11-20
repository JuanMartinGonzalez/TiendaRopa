namespace TiendaRopa.FE
{
    partial class TalleForm
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
            textBoxTalle = new TextBox();
            label1 = new Label();
            dataGridViewTalles = new DataGridView();
            buttonModificar = new Button();
            buttonEliminar = new Button();
            buttonAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTalles).BeginInit();
            SuspendLayout();
            // 
            // textBoxTalle
            // 
            textBoxTalle.Location = new Point(164, 130);
            textBoxTalle.Margin = new Padding(3, 2, 3, 2);
            textBoxTalle.Name = "textBoxTalle";
            textBoxTalle.Size = new Size(179, 23);
            textBoxTalle.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 135);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 20;
            label1.Text = "Talle";
            // 
            // dataGridViewTalles
            // 
            dataGridViewTalles.AllowUserToAddRows = false;
            dataGridViewTalles.AllowUserToDeleteRows = false;
            dataGridViewTalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTalles.Location = new Point(372, 60);
            dataGridViewTalles.Margin = new Padding(3, 2, 3, 2);
            dataGridViewTalles.MultiSelect = false;
            dataGridViewTalles.Name = "dataGridViewTalles";
            dataGridViewTalles.ReadOnly = true;
            dataGridViewTalles.RowHeadersWidth = 51;
            dataGridViewTalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTalles.Size = new Size(594, 301);
            dataGridViewTalles.TabIndex = 19;
            dataGridViewTalles.SelectionChanged += dataGridViewTalles_SelectionChanged;
            // 
            // buttonModificar
            // 
            buttonModificar.Enabled = false;
            buttonModificar.Location = new Point(261, 200);
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
            buttonEliminar.Enabled = false;
            buttonEliminar.Location = new Point(164, 200);
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
            buttonAgregar.Location = new Point(68, 200);
            buttonAgregar.Margin = new Padding(3, 2, 3, 2);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(82, 22);
            buttonAgregar.TabIndex = 16;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // TalleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 597);
            Controls.Add(textBoxTalle);
            Controls.Add(label1);
            Controls.Add(dataGridViewTalles);
            Controls.Add(buttonModificar);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonAgregar);
            Name = "TalleForm";
            Text = "TalleForm";
            Load += TalleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTalle;
        private Label label1;
        private DataGridView dataGridViewTalles;
        private Button buttonModificar;
        private Button buttonEliminar;
        private Button buttonAgregar;
    }
}