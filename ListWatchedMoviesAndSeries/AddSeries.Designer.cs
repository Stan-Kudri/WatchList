namespace ListWatchedMoviesAndSeries
{
    partial class TVSeriesForm
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
            this.txtAddSeries = new System.Windows.Forms.TextBox();
            this.labelNameSeries = new System.Windows.Forms.Label();
            this.labelNumberSeason = new System.Windows.Forms.Label();
            this.btnAddSeries = new System.Windows.Forms.Button();
            this.btnClearTxtSeries = new System.Windows.Forms.Button();
            this.btnBackFormSeries = new System.Windows.Forms.Button();
            this.numericSeason = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeason)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddSeries
            // 
            this.txtAddSeries.Location = new System.Drawing.Point(10, 12);
            this.txtAddSeries.Name = "txtAddSeries";
            this.txtAddSeries.Size = new System.Drawing.Size(299, 23);
            this.txtAddSeries.TabIndex = 1;
            // 
            // labelNameSeries
            // 
            this.labelNameSeries.AutoSize = true;
            this.labelNameSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelNameSeries.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNameSeries.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNameSeries.Location = new System.Drawing.Point(315, 16);
            this.labelNameSeries.Name = "labelNameSeries";
            this.labelNameSeries.Size = new System.Drawing.Size(45, 19);
            this.labelNameSeries.TabIndex = 5;
            this.labelNameSeries.Text = "Name";
            // 
            // labelNumberSeason
            // 
            this.labelNumberSeason.AutoSize = true;
            this.labelNumberSeason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelNumberSeason.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNumberSeason.Location = new System.Drawing.Point(308, 44);
            this.labelNumberSeason.Name = "labelNumberSeason";
            this.labelNumberSeason.Size = new System.Drawing.Size(52, 19);
            this.labelNumberSeason.TabIndex = 6;
            this.labelNumberSeason.Text = "Season";
            // 
            // btnAddSeries
            // 
            this.btnAddSeries.AutoEllipsis = true;
            this.btnAddSeries.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSeries.Location = new System.Drawing.Point(10, 70);
            this.btnAddSeries.Name = "btnAddSeries";
            this.btnAddSeries.Size = new System.Drawing.Size(80, 30);
            this.btnAddSeries.TabIndex = 8;
            this.btnAddSeries.Text = "Add";
            this.btnAddSeries.UseVisualStyleBackColor = false;
            this.btnAddSeries.Click += new System.EventHandler(this.btnAddSeries_Click);
            // 
            // btnClearTxtSeries
            // 
            this.btnClearTxtSeries.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClearTxtSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTxtSeries.Location = new System.Drawing.Point(145, 70);
            this.btnClearTxtSeries.Name = "btnClearTxtSeries";
            this.btnClearTxtSeries.Size = new System.Drawing.Size(80, 30);
            this.btnClearTxtSeries.TabIndex = 9;
            this.btnClearTxtSeries.Text = "Clear";
            this.btnClearTxtSeries.UseVisualStyleBackColor = false;
            this.btnClearTxtSeries.Click += new System.EventHandler(this.btnClearTxtSeries_Click);
            // 
            // btnBackFormSeries
            // 
            this.btnBackFormSeries.BackColor = System.Drawing.Color.LightCoral;
            this.btnBackFormSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackFormSeries.Location = new System.Drawing.Point(280, 70);
            this.btnBackFormSeries.Name = "btnBackFormSeries";
            this.btnBackFormSeries.Size = new System.Drawing.Size(80, 30);
            this.btnBackFormSeries.TabIndex = 10;
            this.btnBackFormSeries.Text = "Close";
            this.btnBackFormSeries.UseVisualStyleBackColor = false;
            this.btnBackFormSeries.Click += new System.EventHandler(this.btnBackFormSeries_Click);
            // 
            // numericSeason
            // 
            this.numericSeason.Location = new System.Drawing.Point(189, 40);
            this.numericSeason.Name = "numericSeason";
            this.numericSeason.Size = new System.Drawing.Size(120, 23);
            this.numericSeason.TabIndex = 11;
            // 
            // TVSeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(369, 111);
            this.Controls.Add(this.numericSeason);
            this.Controls.Add(this.btnBackFormSeries);
            this.Controls.Add(this.btnClearTxtSeries);
            this.Controls.Add(this.btnAddSeries);
            this.Controls.Add(this.labelNumberSeason);
            this.Controls.Add(this.labelNameSeries);
            this.Controls.Add(this.txtAddSeries);
            this.MaximumSize = new System.Drawing.Size(385, 150);
            this.MinimumSize = new System.Drawing.Size(385, 150);
            this.Name = "TVSeriesForm";
            this.Text = "Series";
            ((System.ComponentModel.ISupportInitialize)(this.numericSeason)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelNameSeries;
        private Label labelNumberSeason;
        private Button btnClearTxtSeries;
        private Button btnBackFormSeries;
        private Button btnAddSeries;
        private TextBox txtAddSeries;
        private NumericUpDown numericSeason;
    }
}