namespace ListWatchedMoviesAndSeries
{
    partial class TVSeries
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
            this.txtAddNumberSeason = new System.Windows.Forms.TextBox();
            this.labelNameSeries = new System.Windows.Forms.Label();
            this.labelNumberSeason = new System.Windows.Forms.Label();
            this.btnAddSeries = new System.Windows.Forms.Button();
            this.btnClearTxtSeries = new System.Windows.Forms.Button();
            this.btnBackFormSeries = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAddSeries
            // 
            this.txtAddSeries.Location = new System.Drawing.Point(12, 12);
            this.txtAddSeries.Name = "txtAddSeries";
            this.txtAddSeries.Size = new System.Drawing.Size(320, 23);
            this.txtAddSeries.TabIndex = 1;
            // 
            // txtAddNumberSeason
            // 
            this.txtAddNumberSeason.Location = new System.Drawing.Point(207, 41);
            this.txtAddNumberSeason.Name = "txtAddNumberSeason";
            this.txtAddNumberSeason.Size = new System.Drawing.Size(125, 23);
            this.txtAddNumberSeason.TabIndex = 3;
            this.txtAddNumberSeason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberSason);
            // 
            // labelNameSeries
            // 
            this.labelNameSeries.AutoSize = true;
            this.labelNameSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelNameSeries.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNameSeries.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNameSeries.Location = new System.Drawing.Point(350, 13);
            this.labelNameSeries.Name = "labelNameSeries";
            this.labelNameSeries.Size = new System.Drawing.Size(45, 19);
            this.labelNameSeries.TabIndex = 5;
            this.labelNameSeries.Text = "Name";
            // 
            // labelNumberSeason
            // 
            this.labelNumberSeason.AutoSize = true;
            this.labelNumberSeason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelNumberSeason.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNumberSeason.Location = new System.Drawing.Point(350, 45);
            this.labelNumberSeason.Name = "labelNumberSeason";
            this.labelNumberSeason.Size = new System.Drawing.Size(52, 19);
            this.labelNumberSeason.TabIndex = 6;
            this.labelNumberSeason.Text = "Season";
            // 
            // btnAddSeries
            // 
            this.btnAddSeries.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAddSeries.Location = new System.Drawing.Point(10, 100);
            this.btnAddSeries.Name = "btnAddSeries";
            this.btnAddSeries.Size = new System.Drawing.Size(120, 40);
            this.btnAddSeries.TabIndex = 8;
            this.btnAddSeries.Text = "Add";
            this.btnAddSeries.UseVisualStyleBackColor = false;
            this.btnAddSeries.Click += new System.EventHandler(this.btnAddSeries_Click);
            // 
            // btnClearTxtSeries
            // 
            this.btnClearTxtSeries.BackColor = System.Drawing.Color.Yellow;
            this.btnClearTxtSeries.Location = new System.Drawing.Point(150, 100);
            this.btnClearTxtSeries.Name = "btnClearTxtSeries";
            this.btnClearTxtSeries.Size = new System.Drawing.Size(120, 40);
            this.btnClearTxtSeries.TabIndex = 9;
            this.btnClearTxtSeries.Text = "Clear";
            this.btnClearTxtSeries.UseVisualStyleBackColor = false;
            this.btnClearTxtSeries.Click += new System.EventHandler(this.btnClearTxtSeries_Click);
            // 
            // btnBackFormSeries
            // 
            this.btnBackFormSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBackFormSeries.Location = new System.Drawing.Point(290, 100);
            this.btnBackFormSeries.Name = "btnBackFormSeries";
            this.btnBackFormSeries.Size = new System.Drawing.Size(120, 40);
            this.btnBackFormSeries.TabIndex = 10;
            this.btnBackFormSeries.Text = "Close";
            this.btnBackFormSeries.UseVisualStyleBackColor = false;
            this.btnBackFormSeries.Click += new System.EventHandler(this.btnBackFormSeries_Click);
            // 
            // TVSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(419, 151);
            this.Controls.Add(this.btnBackFormSeries);
            this.Controls.Add(this.btnClearTxtSeries);
            this.Controls.Add(this.btnAddSeries);
            this.Controls.Add(this.labelNumberSeason);
            this.Controls.Add(this.labelNameSeries);
            this.Controls.Add(this.txtAddNumberSeason);
            this.Controls.Add(this.txtAddSeries);
            this.MaximumSize = new System.Drawing.Size(435, 190);
            this.MinimumSize = new System.Drawing.Size(435, 190);
            this.Name = "TVSeries";
            this.Text = "Series";
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
        private TextBox txtAddNumberSeason;
    }
}