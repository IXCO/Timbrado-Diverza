namespace Timbrado_Diverza
{
    partial class Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.BuscarBtn = new System.Windows.Forms.Button();
            this.ProgresoTxt = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DirectorioSeleccionadoTxt = new System.Windows.Forms.TextBox();
            this.CopyrigthLbl = new System.Windows.Forms.Label();
            this.ProgresoTituloLbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SeleccionarBtn = new System.Windows.Forms.Button();
            this.DirectorioRegresoTxt = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.AyudaLbl = new System.Windows.Forms.LinkLabel();
            this.OperacionTituloLbl = new System.Windows.Forms.Label();
            this.OperacionComBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuscarBtn
            // 
            this.BuscarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuscarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuscarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuscarBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BuscarBtn.Location = new System.Drawing.Point(177, 56);
            this.BuscarBtn.Name = "BuscarBtn";
            this.BuscarBtn.Size = new System.Drawing.Size(86, 31);
            this.BuscarBtn.TabIndex = 0;
            this.BuscarBtn.Text = "Buscar";
            this.BuscarBtn.UseVisualStyleBackColor = true;
            this.BuscarBtn.Click += new System.EventHandler(this.BuscarBtn_Click);
            // 
            // ProgresoTxt
            // 
            this.ProgresoTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProgresoTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProgresoTxt.Location = new System.Drawing.Point(29, 299);
            this.ProgresoTxt.Name = "ProgresoTxt";
            this.ProgresoTxt.ReadOnly = true;
            this.ProgresoTxt.Size = new System.Drawing.Size(456, 133);
            this.ProgresoTxt.TabIndex = 2;
            this.ProgresoTxt.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DirectorioSeleccionadoTxt);
            this.groupBox1.Controls.Add(this.BuscarBtn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(29, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 93);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccione el directorio donde se buscaran los XML";
            // 
            // DirectorioSeleccionadoTxt
            // 
            this.DirectorioSeleccionadoTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DirectorioSeleccionadoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectorioSeleccionadoTxt.Location = new System.Drawing.Point(25, 30);
            this.DirectorioSeleccionadoTxt.Name = "DirectorioSeleccionadoTxt";
            this.DirectorioSeleccionadoTxt.ReadOnly = true;
            this.DirectorioSeleccionadoTxt.Size = new System.Drawing.Size(419, 20);
            this.DirectorioSeleccionadoTxt.TabIndex = 5;
            // 
            // CopyrigthLbl
            // 
            this.CopyrigthLbl.AutoSize = true;
            this.CopyrigthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyrigthLbl.Location = new System.Drawing.Point(204, 445);
            this.CopyrigthLbl.Name = "CopyrigthLbl";
            this.CopyrigthLbl.Size = new System.Drawing.Size(89, 13);
            this.CopyrigthLbl.TabIndex = 6;
            this.CopyrigthLbl.Text = "Copyright © IXCO";
            // 
            // ProgresoTituloLbl
            // 
            this.ProgresoTituloLbl.AutoSize = true;
            this.ProgresoTituloLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgresoTituloLbl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ProgresoTituloLbl.Location = new System.Drawing.Point(35, 280);
            this.ProgresoTituloLbl.Name = "ProgresoTituloLbl";
            this.ProgresoTituloLbl.Size = new System.Drawing.Size(139, 15);
            this.ProgresoTituloLbl.TabIndex = 7;
            this.ProgresoTituloLbl.Text = "Archivos Procesados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SeleccionarBtn);
            this.groupBox2.Controls.Add(this.DirectorioRegresoTxt);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(29, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 99);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccione el directorio donde se guardaran los CFDi";
            // 
            // SeleccionarBtn
            // 
            this.SeleccionarBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SeleccionarBtn.Enabled = false;
            this.SeleccionarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SeleccionarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeleccionarBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SeleccionarBtn.Location = new System.Drawing.Point(177, 61);
            this.SeleccionarBtn.Name = "SeleccionarBtn";
            this.SeleccionarBtn.Size = new System.Drawing.Size(86, 32);
            this.SeleccionarBtn.TabIndex = 2;
            this.SeleccionarBtn.Text = "Seleccionar";
            this.SeleccionarBtn.UseVisualStyleBackColor = true;
            this.SeleccionarBtn.Click += new System.EventHandler(this.SeleccionarBtn_Click);
            // 
            // DirectorioRegresoTxt
            // 
            this.DirectorioRegresoTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DirectorioRegresoTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectorioRegresoTxt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DirectorioRegresoTxt.Location = new System.Drawing.Point(25, 35);
            this.DirectorioRegresoTxt.Name = "DirectorioRegresoTxt";
            this.DirectorioRegresoTxt.ReadOnly = true;
            this.DirectorioRegresoTxt.Size = new System.Drawing.Size(419, 20);
            this.DirectorioRegresoTxt.TabIndex = 1;
            // 
            // AyudaLbl
            // 
            this.AyudaLbl.AutoSize = true;
            this.AyudaLbl.Cursor = System.Windows.Forms.Cursors.Help;
            this.AyudaLbl.Location = new System.Drawing.Point(448, 444);
            this.AyudaLbl.Name = "AyudaLbl";
            this.AyudaLbl.Size = new System.Drawing.Size(37, 13);
            this.AyudaLbl.TabIndex = 9;
            this.AyudaLbl.TabStop = true;
            this.AyudaLbl.Text = "Ayuda";
            this.AyudaLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AyudaLbl_LinkClicked);
            // 
            // OperacionTituloLbl
            // 
            this.OperacionTituloLbl.AutoSize = true;
            this.OperacionTituloLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.OperacionTituloLbl.Location = new System.Drawing.Point(35, 28);
            this.OperacionTituloLbl.Name = "OperacionTituloLbl";
            this.OperacionTituloLbl.Size = new System.Drawing.Size(142, 15);
            this.OperacionTituloLbl.TabIndex = 10;
            this.OperacionTituloLbl.Text = "Operación a realizar:";
            // 
            // OperacionComBox
            // 
            this.OperacionComBox.FormattingEnabled = true;
            this.OperacionComBox.Items.AddRange(new object[] {
            "Timbrar",
            "Cancelar"});
            this.OperacionComBox.Location = new System.Drawing.Point(207, 27);
            this.OperacionComBox.Name = "OperacionComBox";
            this.OperacionComBox.Size = new System.Drawing.Size(155, 21);
            this.OperacionComBox.TabIndex = 11;
            this.OperacionComBox.SelectedIndexChanged += new System.EventHandler(this.OperacionComBox_SelectedIndexChanged);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 462);
            this.Controls.Add(this.OperacionComBox);
            this.Controls.Add(this.OperacionTituloLbl);
            this.Controls.Add(this.AyudaLbl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ProgresoTituloLbl);
            this.Controls.Add(this.CopyrigthLbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProgresoTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Interface";
            this.Text = "CFDi Nominas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button BuscarBtn;
        private System.Windows.Forms.RichTextBox ProgresoTxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DirectorioSeleccionadoTxt;
        private System.Windows.Forms.Label CopyrigthLbl;
        private System.Windows.Forms.Label ProgresoTituloLbl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SeleccionarBtn;
        private System.Windows.Forms.TextBox DirectorioRegresoTxt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.LinkLabel AyudaLbl;
        private System.Windows.Forms.Label OperacionTituloLbl;
        private System.Windows.Forms.ComboBox OperacionComBox;
    }
}

