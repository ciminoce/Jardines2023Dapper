namespace Jardines2023.Windows
{
	partial class frmPagos
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
			this.components = new System.ComponentModel.Container();
			this.gboxTarjeta = new System.Windows.Forms.GroupBox();
			this.btnAutorizar = new System.Windows.Forms.Button();
			this.cboAnio = new System.Windows.Forms.ComboBox();
			this.cboMes = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.mtxtCVV = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.mtxtTarjeta = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.AmexButton = new System.Windows.Forms.Button();
			this.MasterButton = new System.Windows.Forms.Button();
			this.VisaButton = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.VisaDebitoButton = new System.Windows.Forms.Button();
			this.MasterDebitoButton = new System.Windows.Forms.Button();
			this.EfectivoButton = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.VueltoLabel = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.ImporteRecibidoLabel = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ImporteLabel = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.gboxTarjeta.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// gboxTarjeta
			// 
			this.gboxTarjeta.Controls.Add(this.btnAutorizar);
			this.gboxTarjeta.Controls.Add(this.cboAnio);
			this.gboxTarjeta.Controls.Add(this.cboMes);
			this.gboxTarjeta.Controls.Add(this.label3);
			this.gboxTarjeta.Controls.Add(this.label2);
			this.gboxTarjeta.Controls.Add(this.mtxtCVV);
			this.gboxTarjeta.Controls.Add(this.label4);
			this.gboxTarjeta.Controls.Add(this.mtxtTarjeta);
			this.gboxTarjeta.Controls.Add(this.label1);
			this.gboxTarjeta.Location = new System.Drawing.Point(12, 269);
			this.gboxTarjeta.Name = "gboxTarjeta";
			this.gboxTarjeta.Size = new System.Drawing.Size(631, 162);
			this.gboxTarjeta.TabIndex = 19;
			this.gboxTarjeta.TabStop = false;
			this.gboxTarjeta.Text = "Datos de la Tarjeta ";
			// 
			// btnAutorizar
			// 
			this.btnAutorizar.Location = new System.Drawing.Point(490, 47);
			this.btnAutorizar.Name = "btnAutorizar";
			this.btnAutorizar.Size = new System.Drawing.Size(129, 58);
			this.btnAutorizar.TabIndex = 3;
			this.btnAutorizar.Text = "Autorizar";
			this.btnAutorizar.UseVisualStyleBackColor = true;
			this.btnAutorizar.Click += new System.EventHandler(this.btnAutorizar_Click);
			// 
			// cboAnio
			// 
			this.cboAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboAnio.FormattingEnabled = true;
			this.cboAnio.Location = new System.Drawing.Point(167, 67);
			this.cboAnio.Name = "cboAnio";
			this.cboAnio.Size = new System.Drawing.Size(52, 28);
			this.cboAnio.TabIndex = 2;
			// 
			// cboMes
			// 
			this.cboMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboMes.FormattingEnabled = true;
			this.cboMes.Location = new System.Drawing.Point(98, 67);
			this.cboMes.Name = "cboMes";
			this.cboMes.Size = new System.Drawing.Size(52, 28);
			this.cboMes.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(151, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(12, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "/";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Vencimiento:";
			// 
			// mtxtCVV
			// 
			this.mtxtCVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mtxtCVV.Location = new System.Drawing.Point(98, 106);
			this.mtxtCVV.Name = "mtxtCVV";
			this.mtxtCVV.Size = new System.Drawing.Size(52, 26);
			this.mtxtCVV.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 109);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "CVV:";
			// 
			// mtxtTarjeta
			// 
			this.mtxtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mtxtTarjeta.Location = new System.Drawing.Point(98, 26);
			this.mtxtTarjeta.Name = "mtxtTarjeta";
			this.mtxtTarjeta.Size = new System.Drawing.Size(344, 26);
			this.mtxtTarjeta.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nro. Tarjeta:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox6);
			this.groupBox2.Controls.Add(this.groupBox5);
			this.groupBox2.Controls.Add(this.EfectivoButton);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(12, 89);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(642, 174);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Medios de Pago";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.AmexButton);
			this.groupBox6.Controls.Add(this.MasterButton);
			this.groupBox6.Controls.Add(this.VisaButton);
			this.groupBox6.Location = new System.Drawing.Point(125, 23);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(275, 138);
			this.groupBox6.TabIndex = 2;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = " Crédito";
			// 
			// AmexButton
			// 
			this.AmexButton.Image = global::Jardines2023.Windows.Properties.Resources.amex_50px;
			this.AmexButton.Location = new System.Drawing.Point(184, 32);
			this.AmexButton.Name = "AmexButton";
			this.AmexButton.Size = new System.Drawing.Size(83, 89);
			this.AmexButton.TabIndex = 0;
			this.AmexButton.Tag = "Amex Credito";
			this.AmexButton.Text = "Amex";
			this.AmexButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.AmexButton.UseVisualStyleBackColor = true;
			this.AmexButton.Click += new System.EventHandler(this.AmexButton_Click);
			// 
			// MasterButton
			// 
			this.MasterButton.Image = global::Jardines2023.Windows.Properties.Resources.mastercard_50px;
			this.MasterButton.Location = new System.Drawing.Point(95, 32);
			this.MasterButton.Name = "MasterButton";
			this.MasterButton.Size = new System.Drawing.Size(83, 89);
			this.MasterButton.TabIndex = 0;
			this.MasterButton.Tag = "Master Crédito";
			this.MasterButton.Text = "Master";
			this.MasterButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.MasterButton.UseVisualStyleBackColor = true;
			this.MasterButton.Click += new System.EventHandler(this.MasterButton_Click);
			// 
			// VisaButton
			// 
			this.VisaButton.Image = global::Jardines2023.Windows.Properties.Resources.visa_50px;
			this.VisaButton.Location = new System.Drawing.Point(6, 33);
			this.VisaButton.Name = "VisaButton";
			this.VisaButton.Size = new System.Drawing.Size(83, 89);
			this.VisaButton.TabIndex = 0;
			this.VisaButton.Tag = "Visa Credito";
			this.VisaButton.Text = "Visa";
			this.VisaButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.VisaButton.UseVisualStyleBackColor = true;
			this.VisaButton.Click += new System.EventHandler(this.VisaButton_Click);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.VisaDebitoButton);
			this.groupBox5.Controls.Add(this.MasterDebitoButton);
			this.groupBox5.Location = new System.Drawing.Point(417, 22);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(187, 139);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = " Débito ";
			// 
			// VisaDebitoButton
			// 
			this.VisaDebitoButton.Image = global::Jardines2023.Windows.Properties.Resources.visad_50px;
			this.VisaDebitoButton.Location = new System.Drawing.Point(6, 32);
			this.VisaDebitoButton.Name = "VisaDebitoButton";
			this.VisaDebitoButton.Size = new System.Drawing.Size(83, 89);
			this.VisaDebitoButton.TabIndex = 0;
			this.VisaDebitoButton.Tag = "Visa Débito";
			this.VisaDebitoButton.Text = "Visa";
			this.VisaDebitoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.VisaDebitoButton.UseVisualStyleBackColor = true;
			this.VisaDebitoButton.Click += new System.EventHandler(this.VisaDebitoButton_Click);
			// 
			// MasterDebitoButton
			// 
			this.MasterDebitoButton.Image = global::Jardines2023.Windows.Properties.Resources.maestro_50px;
			this.MasterDebitoButton.Location = new System.Drawing.Point(95, 32);
			this.MasterDebitoButton.Name = "MasterDebitoButton";
			this.MasterDebitoButton.Size = new System.Drawing.Size(83, 89);
			this.MasterDebitoButton.TabIndex = 0;
			this.MasterDebitoButton.Tag = "Master Débito";
			this.MasterDebitoButton.Text = "Master";
			this.MasterDebitoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.MasterDebitoButton.UseVisualStyleBackColor = true;
			this.MasterDebitoButton.Click += new System.EventHandler(this.MasterDebitoButton_Click);
			// 
			// EfectivoButton
			// 
			this.EfectivoButton.Image = global::Jardines2023.Windows.Properties.Resources.money_50px;
			this.EfectivoButton.Location = new System.Drawing.Point(24, 55);
			this.EfectivoButton.Name = "EfectivoButton";
			this.EfectivoButton.Size = new System.Drawing.Size(83, 89);
			this.EfectivoButton.TabIndex = 0;
			this.EfectivoButton.Tag = "Efectivo";
			this.EfectivoButton.Text = "Efectivo";
			this.EfectivoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.EfectivoButton.UseVisualStyleBackColor = true;
			this.EfectivoButton.Click += new System.EventHandler(this.EfectivoButton_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.VueltoLabel);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.Location = new System.Drawing.Point(13, 525);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(559, 66);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Vuelto";
			// 
			// VueltoLabel
			// 
			this.VueltoLabel.BackColor = System.Drawing.Color.White;
			this.VueltoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VueltoLabel.Location = new System.Drawing.Point(6, 20);
			this.VueltoLabel.Name = "VueltoLabel";
			this.VueltoLabel.Size = new System.Drawing.Size(547, 35);
			this.VueltoLabel.TabIndex = 0;
			this.VueltoLabel.Text = "0.00";
			this.VueltoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.ImporteRecibidoLabel);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(12, 437);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(559, 80);
			this.groupBox3.TabIndex = 16;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Importe a Recibido";
			// 
			// ImporteRecibidoLabel
			// 
			this.ImporteRecibidoLabel.BackColor = System.Drawing.Color.White;
			this.ImporteRecibidoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ImporteRecibidoLabel.Location = new System.Drawing.Point(6, 19);
			this.ImporteRecibidoLabel.Name = "ImporteRecibidoLabel";
			this.ImporteRecibidoLabel.Size = new System.Drawing.Size(547, 44);
			this.ImporteRecibidoLabel.TabIndex = 0;
			this.ImporteRecibidoLabel.Text = "0.00";
			this.ImporteRecibidoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ImporteLabel);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(559, 71);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Importe a Cobrar";
			// 
			// ImporteLabel
			// 
			this.ImporteLabel.BackColor = System.Drawing.Color.White;
			this.ImporteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ImporteLabel.Location = new System.Drawing.Point(6, 20);
			this.ImporteLabel.Name = "ImporteLabel";
			this.ImporteLabel.Size = new System.Drawing.Size(547, 36);
			this.ImporteLabel.TabIndex = 0;
			this.ImporteLabel.Text = "0.00";
			this.ImporteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = global::Jardines2023.Windows.Properties.Resources.cancel_24px;
			this.btnCancelar.Location = new System.Drawing.Point(402, 607);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(102, 49);
			this.btnCancelar.TabIndex = 21;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnOk
			// 
			this.btnOk.Image = global::Jardines2023.Windows.Properties.Resources.ok_24px;
			this.btnOk.Location = new System.Drawing.Point(124, 607);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(102, 49);
			this.btnOk.TabIndex = 20;
			this.btnOk.Text = "OK";
			this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// frmPagos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 662);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.gboxTarjeta);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmPagos";
			this.Text = "frmPagos";
			this.Load += new System.EventHandler(this.frmPagos_Load);
			this.gboxTarjeta.ResumeLayout(false);
			this.gboxTarjeta.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gboxTarjeta;
		private System.Windows.Forms.Button btnAutorizar;
		private System.Windows.Forms.ComboBox cboAnio;
		private System.Windows.Forms.ComboBox cboMes;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MaskedTextBox mtxtCVV;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MaskedTextBox mtxtTarjeta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button AmexButton;
		private System.Windows.Forms.Button MasterButton;
		private System.Windows.Forms.Button VisaButton;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Button VisaDebitoButton;
		private System.Windows.Forms.Button MasterDebitoButton;
		private System.Windows.Forms.Button EfectivoButton;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label VueltoLabel;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label ImporteRecibidoLabel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label ImporteLabel;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ErrorProvider errorProvider1;
	}
}