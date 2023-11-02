namespace Jardines2023.Windows
{
    partial class frmDetalleVenta
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
			this.DetallePanel = new System.Windows.Forms.Panel();
			this.dgvDatos = new System.Windows.Forms.DataGridView();
			this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalesPanel = new System.Windows.Forms.Panel();
			this.TotalVtaTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.EncabezadoPanel = new System.Windows.Forms.Panel();
			this.FechaVtaTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ClienteTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.VentaNroTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnImprimir = new System.Windows.Forms.Button();
			this.DetallePanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
			this.TotalesPanel.SuspendLayout();
			this.EncabezadoPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// DetallePanel
			// 
			this.DetallePanel.Controls.Add(this.dgvDatos);
			this.DetallePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetallePanel.Location = new System.Drawing.Point(0, 107);
			this.DetallePanel.Name = "DetallePanel";
			this.DetallePanel.Size = new System.Drawing.Size(798, 305);
			this.DetallePanel.TabIndex = 5;
			// 
			// dgvDatos
			// 
			this.dgvDatos.AllowUserToAddRows = false;
			this.dgvDatos.AllowUserToDeleteRows = false;
			this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProducto,
            this.colCantidad,
            this.colPrecioUnitario,
            this.colSubtotal});
			this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDatos.Location = new System.Drawing.Point(0, 0);
			this.dgvDatos.Name = "dgvDatos";
			this.dgvDatos.ReadOnly = true;
			this.dgvDatos.Size = new System.Drawing.Size(798, 305);
			this.dgvDatos.TabIndex = 0;
			// 
			// colProducto
			// 
			this.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colProducto.HeaderText = "Producto";
			this.colProducto.Name = "colProducto";
			this.colProducto.ReadOnly = true;
			// 
			// colCantidad
			// 
			this.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colCantidad.HeaderText = "Cantidad";
			this.colCantidad.Name = "colCantidad";
			this.colCantidad.ReadOnly = true;
			this.colCantidad.Width = 74;
			// 
			// colPrecioUnitario
			// 
			this.colPrecioUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colPrecioUnitario.HeaderText = "P. Unit.";
			this.colPrecioUnitario.Name = "colPrecioUnitario";
			this.colPrecioUnitario.ReadOnly = true;
			this.colPrecioUnitario.Width = 67;
			// 
			// colSubtotal
			// 
			this.colSubtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.colSubtotal.HeaderText = "Subtotal";
			this.colSubtotal.Name = "colSubtotal";
			this.colSubtotal.ReadOnly = true;
			this.colSubtotal.Width = 71;
			// 
			// TotalesPanel
			// 
			this.TotalesPanel.Controls.Add(this.TotalVtaTextBox);
			this.TotalesPanel.Controls.Add(this.label4);
			this.TotalesPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TotalesPanel.Location = new System.Drawing.Point(0, 412);
			this.TotalesPanel.Name = "TotalesPanel";
			this.TotalesPanel.Size = new System.Drawing.Size(798, 75);
			this.TotalesPanel.TabIndex = 4;
			// 
			// TotalVtaTextBox
			// 
			this.TotalVtaTextBox.Enabled = false;
			this.TotalVtaTextBox.Location = new System.Drawing.Point(728, 6);
			this.TotalVtaTextBox.Name = "TotalVtaTextBox";
			this.TotalVtaTextBox.Size = new System.Drawing.Size(60, 20);
			this.TotalVtaTextBox.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(688, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Total:";
			// 
			// EncabezadoPanel
			// 
			this.EncabezadoPanel.BackColor = System.Drawing.Color.LightGray;
			this.EncabezadoPanel.Controls.Add(this.btnImprimir);
			this.EncabezadoPanel.Controls.Add(this.FechaVtaTextBox);
			this.EncabezadoPanel.Controls.Add(this.label3);
			this.EncabezadoPanel.Controls.Add(this.ClienteTextBox);
			this.EncabezadoPanel.Controls.Add(this.label2);
			this.EncabezadoPanel.Controls.Add(this.VentaNroTextBox);
			this.EncabezadoPanel.Controls.Add(this.label1);
			this.EncabezadoPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.EncabezadoPanel.Location = new System.Drawing.Point(0, 0);
			this.EncabezadoPanel.Name = "EncabezadoPanel";
			this.EncabezadoPanel.Size = new System.Drawing.Size(798, 107);
			this.EncabezadoPanel.TabIndex = 3;
			// 
			// FechaVtaTextBox
			// 
			this.FechaVtaTextBox.Enabled = false;
			this.FechaVtaTextBox.Location = new System.Drawing.Point(90, 63);
			this.FechaVtaTextBox.Name = "FechaVtaTextBox";
			this.FechaVtaTextBox.Size = new System.Drawing.Size(131, 20);
			this.FechaVtaTextBox.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(25, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Fecha Vta:";
			// 
			// ClienteTextBox
			// 
			this.ClienteTextBox.Enabled = false;
			this.ClienteTextBox.Location = new System.Drawing.Point(90, 37);
			this.ClienteTextBox.Name = "ClienteTextBox";
			this.ClienteTextBox.Size = new System.Drawing.Size(435, 20);
			this.ClienteTextBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Cliente:";
			// 
			// VentaNroTextBox
			// 
			this.VentaNroTextBox.Enabled = false;
			this.VentaNroTextBox.Location = new System.Drawing.Point(90, 11);
			this.VentaNroTextBox.Name = "VentaNroTextBox";
			this.VentaNroTextBox.Size = new System.Drawing.Size(84, 20);
			this.VentaNroTextBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(25, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Venta Nro:";
			// 
			// btnImprimir
			// 
			this.btnImprimir.Image = global::Jardines2023.Windows.Properties.Resources.print_32px;
			this.btnImprimir.Location = new System.Drawing.Point(610, 24);
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(112, 54);
			this.btnImprimir.TabIndex = 2;
			this.btnImprimir.Text = "Imprimir";
			this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnImprimir.UseVisualStyleBackColor = true;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// frmDetalleVenta
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 487);
			this.Controls.Add(this.DetallePanel);
			this.Controls.Add(this.TotalesPanel);
			this.Controls.Add(this.EncabezadoPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmDetalleVenta";
			this.Text = "frmDetalleVenta";
			this.DetallePanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
			this.TotalesPanel.ResumeLayout(false);
			this.TotalesPanel.PerformLayout();
			this.EncabezadoPanel.ResumeLayout(false);
			this.EncabezadoPanel.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DetallePanel;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Panel TotalesPanel;
        private System.Windows.Forms.TextBox TotalVtaTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel EncabezadoPanel;
        private System.Windows.Forms.TextBox FechaVtaTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ClienteTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox VentaNroTextBox;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnImprimir;
	}
}