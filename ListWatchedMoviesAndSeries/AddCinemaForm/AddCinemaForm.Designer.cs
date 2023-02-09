using ListWatchedMoviesAndSeries.BindingItem.Model;

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
            components = new System.ComponentModel.Container();
            txtAddCinema = new TextBox();
            cinemaModelsBindingSource = new BindingSource(components);
            numericSeaquel = new NumericUpDown();
            dateTimePickerCinema = new DateTimePicker();
            numericGradeCinema = new NumericUpDown();
            labelGrade = new MaterialSkin.Controls.MaterialLabel();
            labelName = new MaterialSkin.Controls.MaterialLabel();
            labelNumberSequel = new MaterialSkin.Controls.MaterialLabel();
            btnClearTxtCinema = new MaterialSkin.Controls.MaterialButton();
            btnAddCinema = new MaterialSkin.Controls.MaterialButton();
            btnBackFormCinema = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)cinemaModelsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSeaquel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).BeginInit();
            SuspendLayout();
            // 
            // txtAddCinema
            // 
            txtAddCinema.DataBindings.Add(new Binding("Text", cinemaModelsBindingSource, "Name", true));
            txtAddCinema.Location = new Point(10, 70);
            txtAddCinema.Name = "txtAddCinema";
            txtAddCinema.Size = new Size(311, 23);
            txtAddCinema.TabIndex = 1;
            // 
            // cinemaModelsBindingSource
            // 
            cinemaModelsBindingSource.DataSource = typeof(CinemaModel);
            // 
            // numericSeaquel
            // 
            numericSeaquel.DataBindings.Add(new Binding("Value", cinemaModelsBindingSource, "NumberSequel", true));
            numericSeaquel.Location = new Point(150, 100);
            numericSeaquel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericSeaquel.Name = "numericSeaquel";
            numericSeaquel.Size = new Size(45, 23);
            numericSeaquel.TabIndex = 11;
            numericSeaquel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dateTimePickerCinema
            // 
            dateTimePickerCinema.CustomFormat = "\"dd.MM.yyyy\"";
            dateTimePickerCinema.DataBindings.Add(new Binding("Value", cinemaModelsBindingSource, "Date", true));
            dateTimePickerCinema.Location = new Point(10, 130);
            dateTimePickerCinema.MaxDate = new DateTime(2022, 9, 7, 0, 0, 0, 0);
            dateTimePickerCinema.MinDate = new DateTime(1949, 12, 31, 0, 0, 0, 0);
            dateTimePickerCinema.Name = "dateTimePickerCinema";
            dateTimePickerCinema.Size = new Size(150, 23);
            dateTimePickerCinema.TabIndex = 13;
            dateTimePickerCinema.Value = new DateTime(2022, 8, 7, 0, 0, 0, 0);
            dateTimePickerCinema.ValueChanged += DtpCinema_ValueChanged;
            // 
            // numericGradeCinema
            // 
            numericGradeCinema.DataBindings.Add(new Binding("Value", cinemaModelsBindingSource, "Grade", true));
            numericGradeCinema.Enabled = false;
            numericGradeCinema.InterceptArrowKeys = false;
            numericGradeCinema.Location = new Point(260, 100);
            numericGradeCinema.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericGradeCinema.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericGradeCinema.Name = "numericGradeCinema";
            numericGradeCinema.ReadOnly = true;
            numericGradeCinema.Size = new Size(65, 23);
            numericGradeCinema.TabIndex = 17;
            numericGradeCinema.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelGrade
            // 
            labelGrade.AutoSize = true;
            labelGrade.BackColor = SystemColors.ControlLightLight;
            labelGrade.Depth = 0;
            labelGrade.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelGrade.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelGrade.Location = new Point(330, 102);
            labelGrade.MouseState = MaterialSkin.MouseState.HOVER;
            labelGrade.Name = "labelGrade";
            labelGrade.Size = new Size(43, 19);
            labelGrade.TabIndex = 20;
            labelGrade.Text = "Grade";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = SystemColors.ControlLightLight;
            labelName.Depth = 0;
            labelName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelName.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelName.Location = new Point(330, 70);
            labelName.MouseState = MaterialSkin.MouseState.HOVER;
            labelName.Name = "labelName";
            labelName.Size = new Size(43, 19);
            labelName.TabIndex = 21;
            labelName.Text = "Name";
            // 
            // labelNumberSequel
            // 
            labelNumberSequel.AutoSize = true;
            labelNumberSequel.BackColor = SystemColors.ControlLightLight;
            labelNumberSequel.Depth = 0;
            labelNumberSequel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelNumberSequel.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelNumberSequel.Location = new Point(200, 101);
            labelNumberSequel.MouseState = MaterialSkin.MouseState.HOVER;
            labelNumberSequel.Name = "labelNumberSequel";
            labelNumberSequel.Size = new Size(49, 19);
            labelNumberSequel.TabIndex = 22;
            labelNumberSequel.Text = "Sequel";
            // 
            // btnClearTxtCinema
            // 
            btnClearTxtCinema.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClearTxtCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClearTxtCinema.Depth = 0;
            btnClearTxtCinema.HighEmphasis = true;
            btnClearTxtCinema.Icon = null;
            btnClearTxtCinema.Location = new Point(250, 133);
            btnClearTxtCinema.Margin = new Padding(0);
            btnClearTxtCinema.MaximumSize = new Size(70, 20);
            btnClearTxtCinema.MinimumSize = new Size(70, 20);
            btnClearTxtCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnClearTxtCinema.Name = "btnClearTxtCinema";
            btnClearTxtCinema.NoAccentTextColor = Color.Empty;
            btnClearTxtCinema.Size = new Size(70, 20);
            btnClearTxtCinema.TabIndex = 23;
            btnClearTxtCinema.Text = "Clear";
            btnClearTxtCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClearTxtCinema.UseAccentColor = false;
            btnClearTxtCinema.UseVisualStyleBackColor = true;
            btnClearTxtCinema.Click += BtnClearTxtCinema_Click;
            // 
            // btnAddCinema
            // 
            btnAddCinema.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddCinema.Depth = 0;
            btnAddCinema.HighEmphasis = true;
            btnAddCinema.Icon = null;
            btnAddCinema.Location = new Point(170, 133);
            btnAddCinema.Margin = new Padding(0);
            btnAddCinema.MaximumSize = new Size(70, 20);
            btnAddCinema.MinimumSize = new Size(70, 20);
            btnAddCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddCinema.Name = "btnAddCinema";
            btnAddCinema.NoAccentTextColor = Color.Empty;
            btnAddCinema.Size = new Size(70, 20);
            btnAddCinema.TabIndex = 25;
            btnAddCinema.Text = "Add";
            btnAddCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddCinema.UseAccentColor = false;
            btnAddCinema.UseVisualStyleBackColor = true;
            btnAddCinema.Click += BtnAddCinema_Click;
            // 
            // btnBackFormCinema
            // 
            btnBackFormCinema.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackFormCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBackFormCinema.Depth = 0;
            btnBackFormCinema.HighEmphasis = true;
            btnBackFormCinema.Icon = null;
            btnBackFormCinema.Location = new Point(330, 133);
            btnBackFormCinema.Margin = new Padding(0);
            btnBackFormCinema.MaximumSize = new Size(60, 20);
            btnBackFormCinema.MinimumSize = new Size(60, 20);
            btnBackFormCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackFormCinema.Name = "btnBackFormCinema";
            btnBackFormCinema.NoAccentTextColor = Color.Empty;
            btnBackFormCinema.Size = new Size(60, 20);
            btnBackFormCinema.TabIndex = 26;
            btnBackFormCinema.Text = "Close";
            btnBackFormCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBackFormCinema.UseAccentColor = false;
            btnBackFormCinema.UseVisualStyleBackColor = true;
            btnBackFormCinema.Click += BtnBackFormCinema_Click;
            // 
            // AddCinemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(400, 160);
            Controls.Add(btnBackFormCinema);
            Controls.Add(btnAddCinema);
            Controls.Add(btnClearTxtCinema);
            Controls.Add(labelNumberSequel);
            Controls.Add(labelName);
            Controls.Add(labelGrade);
            Controls.Add(numericGradeCinema);
            Controls.Add(dateTimePickerCinema);
            Controls.Add(numericSeaquel);
            Controls.Add(txtAddCinema);
            MaximumSize = new Size(400, 160);
            MinimumSize = new Size(400, 160);
            Name = "AddCinemaForm";
            Text = "Add Cinema";
            ((System.ComponentModel.ISupportInitialize)cinemaModelsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSeaquel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtAddCinema;
        private NumericUpDown numericSeaquel;
        private DateTimePicker dateTimePickerCinema;
        private NumericUpDown numericGradeCinema;
        private BindingSource cinemaModelsBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelGrade;
        private MaterialSkin.Controls.MaterialLabel labelName;
        private MaterialSkin.Controls.MaterialLabel labelNumberSequel;
        private MaterialSkin.Controls.MaterialButton btnClearTxtCinema;
        private MaterialSkin.Controls.MaterialButton btnAddCinema;
        private MaterialSkin.Controls.MaterialButton btnBackFormCinema;
    }
}
