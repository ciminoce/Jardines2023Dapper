﻿namespace Jardines2023.Windows
{
	partial class frmFecha
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
			this.label1 = new System.Windows.Forms.Label();
			this.dtpFechaFiltro = new System.Windows.Forms.DateTimePicker();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Fecha:";
			// 
			// dtpFechaFiltro
			// 
			this.dtpFechaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaFiltro.Location = new System.Drawing.Point(88, 38);
			this.dtpFechaFiltro.Name = "dtpFechaFiltro";
			this.dtpFechaFiltro.Size = new System.Drawing.Size(105, 20);
			this.dtpFechaFiltro.TabIndex = 1;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = global::Jardines2023.Windows.Properties.Resources.cancel_24px;
			this.btnCancelar.Location = new System.Drawing.Point(171, 95);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 49);
			this.btnCancelar.TabIndex = 7;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnOk
			// 
			this.btnOk.Image = global::Jardines2023.Windows.Properties.Resources.ok_24px;
			this.btnOk.Location = new System.Drawing.Point(21, 95);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 49);
			this.btnOk.TabIndex = 8;
			this.btnOk.Text = "OK";
			this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// errorProvider2
			// 
			this.errorProvider2.ContainerControl = this;
			// 
			// frmFecha
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 170);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.dtpFechaFiltro);
			this.Controls.Add(this.label1);
			this.Name = "frmFecha";
			this.Text = "frmFecha";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpFechaFiltro;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.ErrorProvider errorProvider2;
	}
}