namespace ListWatchedMoviesAndSeries
{
    partial class AddCinemaForm
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
            this.txtAddCinema = new System.Windows.Forms.TextBox();
            this.cinemaModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericSeaquel = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerCinema = new System.Windows.Forms.DateTimePicker();
            this.watchDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericGradeCinema = new System.Windows.Forms.NumericUpDown();
            this.labelGrade = new MaterialSkin.Controls.MaterialLabel();
            this.labelName = new MaterialSkin.Controls.MaterialLabel();
            this.labelNumberSeaquel = new MaterialSkin.Controls.MaterialLabel();
            this.btnClearTxtCinema = new MaterialSkin.Controls.MaterialButton();
            this.btnAddCinema = new MaterialSkin.Controls.MaterialButton();
            this.btnBackFormCinema = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaModelsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeaquel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGradeCinema)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddCinema
            // 
            this.txtAddCinema.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cinemaModelsBindingSource, "Name", true));
            this.txtAddCinema.Location = new System.Drawing.Point(10, 70);
            this.txtAddCinema.Name = "txtAddCinema";
            this.txtAddCinema.Size = new System.Drawing.Size(311, 23);
            this.txtAddCinema.TabIndex = 1;
            // 
            // cinemaModelsBindingSource
            // 
            this.cinemaModelsBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.Models.CinemaModel);
            // 
            // numericSeaquel
            // 
            this.numericSeaquel.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cinemaModelsBindingSource, "NumberSequel", true));
            this.numericSeaquel.Location = new System.Drawing.Point(175, 100);
            this.numericSeaquel.Name = "numericSeaquel";
            this.numericSeaquel.Size = new System.Drawing.Size(146, 23);
            this.numericSeaquel.TabIndex = 11;
            // 
            // dateTimePickerCinema
            // 
            this.dateTimePickerCinema.CustomFormat = "\"dd.MM.yyyy\"";
            this.dateTimePickerCinema.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.watchDetailBindingSource, "DateWatch", true));
            this.dateTimePickerCinema.Location = new System.Drawing.Point(10, 137);
            this.dateTimePickerCinema.MaxDate = new System.DateTime(2022, 9, 7, 0, 0, 0, 0);
            this.dateTimePickerCinema.MinDate = new System.DateTime(1949, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerCinema.Name = "dateTimePickerCinema";
            this.dateTimePickerCinema.Size = new System.Drawing.Size(158, 23);
            this.dateTimePickerCinema.TabIndex = 13;
            this.dateTimePickerCinema.Value = new System.DateTime(2022, 8, 7, 0, 0, 0, 0);
            this.dateTimePickerCinema.ValueChanged += new System.EventHandler(this.DtpCinema_ValueChanged);
            // 
            // watchDetailBindingSource
            // 
            this.watchDetailBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.Models.Item.WatchDetail);
            // 
            // numericGradeCinema
            // 
            this.numericGradeCinema.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.watchDetailBindingSource, "Grade", true));
            this.numericGradeCinema.Enabled = false;
            this.numericGradeCinema.InterceptArrowKeys = false;
            this.numericGradeCinema.Location = new System.Drawing.Point(10, 100);
            this.numericGradeCinema.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericGradeCinema.Name = "numericGradeCinema";
            this.numericGradeCinema.ReadOnly = true;
            this.numericGradeCinema.Size = new System.Drawing.Size(101, 23);
            this.numericGradeCinema.TabIndex = 17;
            // 
            // labelGrade
            // 
            this.labelGrade.AutoSize = true;
            this.labelGrade.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelGrade.Depth = 0;
            this.labelGrade.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelGrade.Location = new System.Drawing.Point(120, 100);
            this.labelGrade.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(43, 19);
            this.labelGrade.TabIndex = 20;
            this.labelGrade.Text = "Grade";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelName.Depth = 0;
            this.labelName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelName.Location = new System.Drawing.Point(330, 70);
            this.labelName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(43, 19);
            this.labelName.TabIndex = 21;
            this.labelName.Text = "Name";
            // 
            // labelNumberSeaquel
            // 
            this.labelNumberSeaquel.AutoSize = true;
            this.labelNumberSeaquel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNumberSeaquel.Depth = 0;
            this.labelNumberSeaquel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNumberSeaquel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNumberSeaquel.Location = new System.Drawing.Point(330, 100);
            this.labelNumberSeaquel.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelNumberSeaquel.Name = "labelNumberSeaquel";
            this.labelNumberSeaquel.Size = new System.Drawing.Size(58, 19);
            this.labelNumberSeaquel.TabIndex = 22;
            this.labelNumberSeaquel.Text = "Seaquel";
            // 
            // btnClearTxtCinema
            // 
            this.btnClearTxtCinema.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClearTxtCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnClearTxtCinema.Depth = 0;
            this.btnClearTxtCinema.HighEmphasis = true;
            this.btnClearTxtCinema.Icon = null;
            this.btnClearTxtCinema.Location = new System.Drawing.Point(251, 130);
            this.btnClearTxtCinema.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearTxtCinema.MaximumSize = new System.Drawing.Size(70, 30);
            this.btnClearTxtCinema.MinimumSize = new System.Drawing.Size(70, 30);
            this.btnClearTxtCinema.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnClearTxtCinema.Name = "btnClearTxtCinema";
            this.btnClearTxtCinema.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnClearTxtCinema.Size = new System.Drawing.Size(70, 30);
            this.btnClearTxtCinema.TabIndex = 23;
            this.btnClearTxtCinema.Text = "Clear";
            this.btnClearTxtCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnClearTxtCinema.UseAccentColor = false;
            this.btnClearTxtCinema.UseVisualStyleBackColor = true;
            this.btnClearTxtCinema.Click += new System.EventHandler(this.BtnClearTxtCinema_Click);
            // 
            // btnAddCinema
            // 
            this.btnAddCinema.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAddCinema.Depth = 0;
            this.btnAddCinema.HighEmphasis = true;
            this.btnAddCinema.Icon = null;
            this.btnAddCinema.Location = new System.Drawing.Point(175, 130);
            this.btnAddCinema.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddCinema.MaximumSize = new System.Drawing.Size(70, 30);
            this.btnAddCinema.MinimumSize = new System.Drawing.Size(70, 30);
            this.btnAddCinema.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddCinema.Name = "btnAddCinema";
            this.btnAddCinema.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAddCinema.Size = new System.Drawing.Size(70, 30);
            this.btnAddCinema.TabIndex = 25;
            this.btnAddCinema.Text = "Add";
            this.btnAddCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddCinema.UseAccentColor = false;
            this.btnAddCinema.UseVisualStyleBackColor = true;
            this.btnAddCinema.Click += new System.EventHandler(this.BtnAddCinema_Click);
            // 
            // btnBackFormCinema
            // 
            this.btnBackFormCinema.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBackFormCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBackFormCinema.Depth = 0;
            this.btnBackFormCinema.HighEmphasis = true;
            this.btnBackFormCinema.Icon = null;
            this.btnBackFormCinema.Location = new System.Drawing.Point(330, 130);
            this.btnBackFormCinema.Margin = new System.Windows.Forms.Padding(0);
            this.btnBackFormCinema.MaximumSize = new System.Drawing.Size(60, 30);
            this.btnBackFormCinema.MinimumSize = new System.Drawing.Size(60, 30);
            this.btnBackFormCinema.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBackFormCinema.Name = "btnBackFormCinema";
            this.btnBackFormCinema.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBackFormCinema.Size = new System.Drawing.Size(60, 30);
            this.btnBackFormCinema.TabIndex = 26;
            this.btnBackFormCinema.Text = "Close";
            this.btnBackFormCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBackFormCinema.UseAccentColor = false;
            this.btnBackFormCinema.UseVisualStyleBackColor = true;
            this.btnBackFormCinema.Click += new System.EventHandler(this.BtnBackFormCinema_Click);
            // 
            // AddCinemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(400, 170);
            this.Controls.Add(this.btnBackFormCinema);
            this.Controls.Add(this.btnAddCinema);
            this.Controls.Add(this.btnClearTxtCinema);
            this.Controls.Add(this.labelNumberSeaquel);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelGrade);
            this.Controls.Add(this.numericGradeCinema);
            this.Controls.Add(this.dateTimePickerCinema);
            this.Controls.Add(this.numericSeaquel);
            this.Controls.Add(this.txtAddCinema);
            this.MaximumSize = new System.Drawing.Size(400, 170);
            this.MinimumSize = new System.Drawing.Size(400, 170);
            this.Name = "AddCinemaForm";
            this.Text = "Add Cinema";
            ((System.ComponentModel.ISupportInitialize)(this.cinemaModelsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeaquel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGradeCinema)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtAddCinema;
        private NumericUpDown numericSeaquel;
        private DateTimePicker dateTimePickerCinema;
        private NumericUpDown numericGradeCinema;
        private BindingSource cinemaModelsBindingSource;
        private BindingSource watchDetailBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelGrade;
        private MaterialSkin.Controls.MaterialLabel labelName;
        private MaterialSkin.Controls.MaterialLabel labelNumberSeaquel;
        private MaterialSkin.Controls.MaterialButton btnClearTxtCinema;
        private MaterialSkin.Controls.MaterialButton btnAddCinema;
        private MaterialSkin.Controls.MaterialButton btnBackFormCinema;
    }
}
