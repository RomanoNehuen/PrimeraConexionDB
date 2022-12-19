namespace Primera_conexionDB
{
    partial class Form1
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
            this.dgvPokemon = new System.Windows.Forms.DataGridView();
            this.pbx = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminacionFisica = new System.Windows.Forms.Button();
            this.btnEliminacionLogica = new System.Windows.Forms.Button();
            this.lblfiltro = new System.Windows.Forms.Label();
            this.txtfiltro = new System.Windows.Forms.TextBox();
            this.btnFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPokemon
            // 
            this.dgvPokemon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPokemon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPokemon.Location = new System.Drawing.Point(26, 50);
            this.dgvPokemon.MultiSelect = false;
            this.dgvPokemon.Name = "dgvPokemon";
            this.dgvPokemon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPokemon.Size = new System.Drawing.Size(649, 180);
            this.dgvPokemon.TabIndex = 0;
            this.dgvPokemon.SelectionChanged += new System.EventHandler(this.dgvPokemon_SelectionChanged);
            // 
            // pbx
            // 
            this.pbx.Location = new System.Drawing.Point(695, 50);
            this.pbx.Name = "pbx";
            this.pbx.Size = new System.Drawing.Size(199, 180);
            this.pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx.TabIndex = 1;
            this.pbx.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(26, 258);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(107, 258);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminacionFisica
            // 
            this.btnEliminacionFisica.Location = new System.Drawing.Point(188, 258);
            this.btnEliminacionFisica.Name = "btnEliminacionFisica";
            this.btnEliminacionFisica.Size = new System.Drawing.Size(103, 23);
            this.btnEliminacionFisica.TabIndex = 4;
            this.btnEliminacionFisica.Text = "Eliminación Fisica";
            this.btnEliminacionFisica.UseVisualStyleBackColor = true;
            this.btnEliminacionFisica.Click += new System.EventHandler(this.btnEliminacionFisica_Click);
            // 
            // btnEliminacionLogica
            // 
            this.btnEliminacionLogica.Location = new System.Drawing.Point(297, 258);
            this.btnEliminacionLogica.Name = "btnEliminacionLogica";
            this.btnEliminacionLogica.Size = new System.Drawing.Size(103, 23);
            this.btnEliminacionLogica.TabIndex = 5;
            this.btnEliminacionLogica.Text = "Eliminación Lógica";
            this.btnEliminacionLogica.UseVisualStyleBackColor = true;
            this.btnEliminacionLogica.Click += new System.EventHandler(this.btnEliminacionLogica_Click);
            // 
            // lblfiltro
            // 
            this.lblfiltro.AutoSize = true;
            this.lblfiltro.Location = new System.Drawing.Point(26, 13);
            this.lblfiltro.Name = "lblfiltro";
            this.lblfiltro.Size = new System.Drawing.Size(29, 13);
            this.lblfiltro.TabIndex = 6;
            this.lblfiltro.Text = "Filtro";
            // 
            // txtfiltro
            // 
            this.txtfiltro.Location = new System.Drawing.Point(61, 10);
            this.txtfiltro.Name = "txtfiltro";
            this.txtfiltro.Size = new System.Drawing.Size(133, 20);
            this.txtfiltro.TabIndex = 7;
            // 
            // btnFiltro
            // 
            this.btnFiltro.Location = new System.Drawing.Point(200, 10);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnFiltro.TabIndex = 8;
            this.btnFiltro.Text = "Filtrar";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 304);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.txtfiltro);
            this.Controls.Add(this.lblfiltro);
            this.Controls.Add(this.btnEliminacionLogica);
            this.Controls.Add(this.btnEliminacionFisica);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbx);
            this.Controls.Add(this.dgvPokemon);
            this.Name = "Form1";
            this.Text = "Pokemons";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPokemon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPokemon;
        private System.Windows.Forms.PictureBox pbx;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminacionFisica;
        private System.Windows.Forms.Button btnEliminacionLogica;
        private System.Windows.Forms.Label lblfiltro;
        private System.Windows.Forms.TextBox txtfiltro;
        private System.Windows.Forms.Button btnFiltro;
    }
}

