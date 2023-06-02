namespace Juegas_Puzlee_Final___
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.picorigen = new System.Windows.Forms.PictureBox();
            this.btncarimgen = new System.Windows.Forms.Button();
            this.dgv_puzlee = new System.Windows.Forms.DataGridView();
            this.btn_jugar = new System.Windows.Forms.Button();
            this.numupdow_filas = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numupdow_columnas = new System.Windows.Forms.NumericUpDown();
            this.btnResultado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picorigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_puzlee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupdow_filas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupdow_columnas)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // picorigen
            // 
            this.picorigen.Location = new System.Drawing.Point(33, 71);
            this.picorigen.Name = "picorigen";
            this.picorigen.Size = new System.Drawing.Size(269, 289);
            this.picorigen.TabIndex = 1;
            this.picorigen.TabStop = false;
            // 
            // btncarimgen
            // 
            this.btncarimgen.Location = new System.Drawing.Point(33, 12);
            this.btncarimgen.Name = "btncarimgen";
            this.btncarimgen.Size = new System.Drawing.Size(141, 34);
            this.btncarimgen.TabIndex = 2;
            this.btncarimgen.Text = "Cargar Imagen";
            this.btncarimgen.UseVisualStyleBackColor = true;
            this.btncarimgen.Click += new System.EventHandler(this.btncarimgen_Click);
            // 
            // dgv_puzlee
            // 
            this.dgv_puzlee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_puzlee.Location = new System.Drawing.Point(352, 71);
            this.dgv_puzlee.Name = "dgv_puzlee";
            this.dgv_puzlee.Size = new System.Drawing.Size(397, 289);
            this.dgv_puzlee.TabIndex = 3;
            this.dgv_puzlee.Click += new System.EventHandler(this.dgv_puzlee_Click);
            this.dgv_puzlee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_puzlee_KeyDown);
            // 
            // btn_jugar
            // 
            this.btn_jugar.Location = new System.Drawing.Point(605, 29);
            this.btn_jugar.Name = "btn_jugar";
            this.btn_jugar.Size = new System.Drawing.Size(75, 23);
            this.btn_jugar.TabIndex = 4;
            this.btn_jugar.Text = "Jugar";
            this.btn_jugar.UseVisualStyleBackColor = true;
            this.btn_jugar.Click += new System.EventHandler(this.btn_jugar_Click);
            // 
            // numupdow_filas
            // 
            this.numupdow_filas.Location = new System.Drawing.Point(394, 27);
            this.numupdow_filas.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numupdow_filas.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numupdow_filas.Name = "numupdow_filas";
            this.numupdow_filas.Size = new System.Drawing.Size(60, 25);
            this.numupdow_filas.TabIndex = 5;
            this.numupdow_filas.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Columnas";
            // 
            // numupdow_columnas
            // 
            this.numupdow_columnas.Location = new System.Drawing.Point(539, 27);
            this.numupdow_columnas.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numupdow_columnas.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numupdow_columnas.Name = "numupdow_columnas";
            this.numupdow_columnas.Size = new System.Drawing.Size(60, 25);
            this.numupdow_columnas.TabIndex = 7;
            this.numupdow_columnas.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnResultado
            // 
            this.btnResultado.Location = new System.Drawing.Point(686, 29);
            this.btnResultado.Name = "btnResultado";
            this.btnResultado.Size = new System.Drawing.Size(75, 23);
            this.btnResultado.TabIndex = 9;
            this.btnResultado.Text = "Resultado";
            this.btnResultado.UseVisualStyleBackColor = true;
            this.btnResultado.Click += new System.EventHandler(this.btnResultado_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 392);
            this.Controls.Add(this.btnResultado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numupdow_columnas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numupdow_filas);
            this.Controls.Add(this.btn_jugar);
            this.Controls.Add(this.dgv_puzlee);
            this.Controls.Add(this.btncarimgen);
            this.Controls.Add(this.picorigen);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Prototipo Puzlee 3";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picorigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_puzlee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupdow_filas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numupdow_columnas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox picorigen;
        private System.Windows.Forms.Button btncarimgen;
        private System.Windows.Forms.DataGridView dgv_puzlee;
        private System.Windows.Forms.Button btn_jugar;
        private System.Windows.Forms.NumericUpDown numupdow_filas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numupdow_columnas;
        private System.Windows.Forms.Button btnResultado;
    }
}

