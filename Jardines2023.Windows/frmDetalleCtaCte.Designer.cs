namespace Jardines2023.Windows
{
    partial class frmDetalleCtaCte
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
			System.Windows.Forms.Label nameLabel;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label address1Label;
			System.Windows.Forms.Label cityLabel;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtLocalidad = new System.Windows.Forms.TextBox();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.txtDireccion = new System.Windows.Forms.TextBox();
			this.txtProvincia = new System.Windows.Forms.TextBox();
			this.txtCP = new System.Windows.Forms.TextBox();
			this.btnBuscarCliente = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnImprimirCtaCte = new System.Windows.Forms.Button();
			this.btnIngresarPago = new System.Windows.Forms.Button();
			this.txtSaldo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgvDatos = new System.Windows.Forms.DataGridView();
			this.cmnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmnMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmnDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmnHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			nameLabel = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			address1Label = new System.Windows.Forms.Label();
			cityLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
			this.SuspendLayout();
			// 
			// nameLabel
			// 
			nameLabel.AutoSize = true;
			nameLabel.Location = new System.Drawing.Point(18, 23);
			nameLabel.Name = "nameLabel";
			nameLabel.Size = new System.Drawing.Size(42, 13);
			nameLabel.TabIndex = 18;
			nameLabel.Text = "Cliente:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(20, 76);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 13);
			label1.TabIndex = 20;
			label1.Text = "Localidad:";
			// 
			// address1Label
			// 
			address1Label.AutoSize = true;
			address1Label.Location = new System.Drawing.Point(20, 50);
			address1Label.Name = "address1Label";
			address1Label.Size = new System.Drawing.Size(55, 13);
			address1Label.TabIndex = 20;
			address1Label.Text = "Dirección:";
			// 
			// cityLabel
			// 
			cityLabel.AutoSize = true;
			cityLabel.Location = new System.Drawing.Point(18, 102);
			cityLabel.Name = "cityLabel";
			cityLabel.Size = new System.Drawing.Size(63, 13);
			cityLabel.TabIndex = 23;
			cityLabel.Text = "Pcia. , C.P.:";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel1.Controls.Add(this.btnBuscarCliente);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnOK);
			this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
			this.splitContainer1.Panel2.Controls.Add(this.btnImprimirCtaCte);
			this.splitContainer1.Panel2.Controls.Add(this.btnIngresarPago);
			this.splitContainer1.Panel2.Controls.Add(this.txtSaldo);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.panel1);
			this.splitContainer1.Size = new System.Drawing.Size(1073, 643);
			this.splitContainer1.SplitterDistance = 155;
			this.splitContainer1.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(nameLabel);
			this.groupBox1.Controls.Add(label1);
			this.groupBox1.Controls.Add(address1Label);
			this.groupBox1.Controls.Add(this.txtLocalidad);
			this.groupBox1.Controls.Add(this.txtCliente);
			this.groupBox1.Controls.Add(this.txtDireccion);
			this.groupBox1.Controls.Add(cityLabel);
			this.groupBox1.Controls.Add(this.txtProvincia);
			this.groupBox1.Controls.Add(this.txtCP);
			this.groupBox1.Location = new System.Drawing.Point(12, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(491, 134);
			this.groupBox1.TabIndex = 72;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Cliente ";
			// 
			// txtLocalidad
			// 
			this.txtLocalidad.Location = new System.Drawing.Point(83, 73);
			this.txtLocalidad.Name = "txtLocalidad";
			this.txtLocalidad.ReadOnly = true;
			this.txtLocalidad.Size = new System.Drawing.Size(375, 20);
			this.txtLocalidad.TabIndex = 21;
			this.txtLocalidad.TabStop = false;
			// 
			// txtCliente
			// 
			this.txtCliente.Location = new System.Drawing.Point(83, 19);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.ReadOnly = true;
			this.txtCliente.Size = new System.Drawing.Size(375, 20);
			this.txtCliente.TabIndex = 21;
			this.txtCliente.TabStop = false;
			// 
			// txtDireccion
			// 
			this.txtDireccion.Location = new System.Drawing.Point(84, 47);
			this.txtDireccion.Name = "txtDireccion";
			this.txtDireccion.ReadOnly = true;
			this.txtDireccion.Size = new System.Drawing.Size(375, 20);
			this.txtDireccion.TabIndex = 21;
			this.txtDireccion.TabStop = false;
			// 
			// txtProvincia
			// 
			this.txtProvincia.Location = new System.Drawing.Point(83, 99);
			this.txtProvincia.Name = "txtProvincia";
			this.txtProvincia.ReadOnly = true;
			this.txtProvincia.Size = new System.Drawing.Size(173, 20);
			this.txtProvincia.TabIndex = 24;
			this.txtProvincia.TabStop = false;
			// 
			// txtCP
			// 
			this.txtCP.Location = new System.Drawing.Point(275, 99);
			this.txtCP.Name = "txtCP";
			this.txtCP.ReadOnly = true;
			this.txtCP.Size = new System.Drawing.Size(100, 20);
			this.txtCP.TabIndex = 26;
			this.txtCP.TabStop = false;
			// 
			// btnBuscarCliente
			// 
			this.btnBuscarCliente.Location = new System.Drawing.Point(546, 36);
			this.btnBuscarCliente.Name = "btnBuscarCliente";
			this.btnBuscarCliente.Size = new System.Drawing.Size(113, 66);
			this.btnBuscarCliente.TabIndex = 79;
			this.btnBuscarCliente.Text = "Buscar Cliente";
			this.btnBuscarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnBuscarCliente.UseVisualStyleBackColor = true;
			this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(55, 371);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(90, 50);
			this.btnOK.TabIndex = 16;
			this.btnOK.Text = "OK";
			this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancelar
			// 
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(546, 371);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(90, 50);
			this.btnCancelar.TabIndex = 17;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			// 
			// btnImprimirCtaCte
			// 
			this.btnImprimirCtaCte.Location = new System.Drawing.Point(926, 15);
			this.btnImprimirCtaCte.Name = "btnImprimirCtaCte";
			this.btnImprimirCtaCte.Size = new System.Drawing.Size(113, 66);
			this.btnImprimirCtaCte.TabIndex = 79;
			this.btnImprimirCtaCte.Text = "Imprimir Cta. Cte.";
			this.btnImprimirCtaCte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnImprimirCtaCte.UseVisualStyleBackColor = true;
			// 
			// btnIngresarPago
			// 
			this.btnIngresarPago.Location = new System.Drawing.Point(926, 97);
			this.btnIngresarPago.Name = "btnIngresarPago";
			this.btnIngresarPago.Size = new System.Drawing.Size(113, 60);
			this.btnIngresarPago.TabIndex = 78;
			this.btnIngresarPago.Text = "Ingresar Pagos";
			this.btnIngresarPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnIngresarPago.UseVisualStyleBackColor = true;
			this.btnIngresarPago.Click += new System.EventHandler(this.btnIngresarPago_Click);
			// 
			// txtSaldo
			// 
			this.txtSaldo.Enabled = false;
			this.txtSaldo.Location = new System.Drawing.Point(801, 363);
			this.txtSaldo.Name = "txtSaldo";
			this.txtSaldo.Size = new System.Drawing.Size(107, 20);
			this.txtSaldo.TabIndex = 76;
			this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(736, 366);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 75;
			this.label3.Text = "Saldo:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgvDatos);
			this.panel1.Location = new System.Drawing.Point(55, 15);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(853, 340);
			this.panel1.TabIndex = 74;
			// 
			// dgvDatos
			// 
			this.dgvDatos.AllowUserToAddRows = false;
			this.dgvDatos.AllowUserToDeleteRows = false;
			this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnFecha,
            this.cmnMovimiento,
            this.cmnDebe,
            this.cmnHaber,
            this.colSaldo});
			this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDatos.Location = new System.Drawing.Point(0, 0);
			this.dgvDatos.Name = "dgvDatos";
			this.dgvDatos.ReadOnly = true;
			this.dgvDatos.RowHeadersVisible = false;
			this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDatos.Size = new System.Drawing.Size(853, 340);
			this.dgvDatos.TabIndex = 0;
			// 
			// cmnFecha
			// 
			this.cmnFecha.HeaderText = "Fecha";
			this.cmnFecha.Name = "cmnFecha";
			this.cmnFecha.ReadOnly = true;
			// 
			// cmnMovimiento
			// 
			this.cmnMovimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.cmnMovimiento.HeaderText = "Movimiento";
			this.cmnMovimiento.Name = "cmnMovimiento";
			this.cmnMovimiento.ReadOnly = true;
			// 
			// cmnDebe
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.Format = "C2";
			dataGridViewCellStyle1.NullValue = null;
			this.cmnDebe.DefaultCellStyle = dataGridViewCellStyle1;
			this.cmnDebe.HeaderText = "Debe";
			this.cmnDebe.Name = "cmnDebe";
			this.cmnDebe.ReadOnly = true;
			// 
			// cmnHaber
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Format = "C2";
			dataGridViewCellStyle2.NullValue = null;
			this.cmnHaber.DefaultCellStyle = dataGridViewCellStyle2;
			this.cmnHaber.HeaderText = "Haber";
			this.cmnHaber.Name = "cmnHaber";
			this.cmnHaber.ReadOnly = true;
			// 
			// colSaldo
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle3.Format = "C2";
			dataGridViewCellStyle3.NullValue = null;
			this.colSaldo.DefaultCellStyle = dataGridViewCellStyle3;
			this.colSaldo.HeaderText = "Saldo";
			this.colSaldo.Name = "colSaldo";
			this.colSaldo.ReadOnly = true;
			// 
			// frmDetalleCtaCte
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1073, 643);
			this.Controls.Add(this.splitContainer1);
			this.Name = "frmDetalleCtaCte";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmDetalleCtaCte";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimirCtaCte;
        private System.Windows.Forms.Button btnIngresarPago;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaldo;
    }
}