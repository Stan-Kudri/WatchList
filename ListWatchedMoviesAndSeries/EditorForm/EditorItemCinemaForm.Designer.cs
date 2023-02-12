using ListWatchedMoviesAndSeries.BindingItem.Model;

namespace ListWatchedMoviesAndSeries.EditorForm
{
    partial class EditorItemCinemaForm
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
            numericEditGradeCinema = new NumericUpDown();
            cinemaModelBindingSource = new BindingSource(components);
            dateTPCinema = new DateTimePicker();
            numericEditSequel = new NumericUpDown();
            txtEditName = new TextBox();
            labelNameCinema = new MaterialSkin.Controls.MaterialLabel();
            labelNumberSequel = new MaterialSkin.Controls.MaterialLabel();
            labelGradeCinema = new MaterialSkin.Controls.MaterialLabel();
            btnSaveEdit = new MaterialSkin.Controls.MaterialButton();
            btnReturnDataCinema = new MaterialSkin.Controls.MaterialButton();
            btnCloseEdit = new MaterialSkin.Controls.MaterialButton();
            cmbTypeCinema = new ComboBox();
            typeModelBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)numericEditGradeCinema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cinemaModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEditSequel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // numericEditGradeCinema
            // 
            numericEditGradeCinema.DataBindings.Add(new Binding("Value", cinemaModelBindingSource, "Grade", true));
            numericEditGradeCinema.Enabled = false;
            numericEditGradeCinema.InterceptArrowKeys = false;
            numericEditGradeCinema.Location = new Point(275, 100);
            numericEditGradeCinema.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericEditGradeCinema.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericEditGradeCinema.Name = "numericEditGradeCinema";
            numericEditGradeCinema.ReadOnly = true;
            numericEditGradeCinema.Size = new Size(65, 23);
            numericEditGradeCinema.TabIndex = 27;
            numericEditGradeCinema.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cinemaModelBindingSource
            // 
            cinemaModelBindingSource.DataSource = typeof(CinemaModel);
            // 
            // dateTPCinema
            // 
            dateTPCinema.CustomFormat = "\"dd.MM.yyyy\"";
            dateTPCinema.DataBindings.Add(new Binding("Value", cinemaModelBindingSource, "Date", true));
            dateTPCinema.Location = new Point(10, 130);
            dateTPCinema.MaxDate = new DateTime(2022, 8, 29, 0, 0, 0, 0);
            dateTPCinema.MinDate = new DateTime(1949, 12, 31, 0, 0, 0, 0);
            dateTPCinema.Name = "dateTPCinema";
            dateTPCinema.Size = new Size(150, 23);
            dateTPCinema.TabIndex = 26;
            dateTPCinema.Value = new DateTime(2022, 8, 7, 0, 0, 0, 0);
            dateTPCinema.ValueChanged += DateTimePick_ValueChanged;
            // 
            // numericEditSequel
            // 
            numericEditSequel.DataBindings.Add(new Binding("Value", cinemaModelBindingSource, "NumberSequel", true));
            numericEditSequel.Location = new Point(165, 100);
            numericEditSequel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericEditSequel.Name = "numericEditSequel";
            numericEditSequel.Size = new Size(45, 23);
            numericEditSequel.TabIndex = 25;
            numericEditSequel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtEditName
            // 
            txtEditName.DataBindings.Add(new Binding("Text", cinemaModelBindingSource, "Name", true));
            txtEditName.Location = new Point(10, 70);
            txtEditName.Multiline = true;
            txtEditName.Name = "txtEditName";
            txtEditName.Size = new Size(330, 23);
            txtEditName.TabIndex = 19;
            // 
            // labelNameCinema
            // 
            labelNameCinema.AutoSize = true;
            labelNameCinema.BackColor = SystemColors.ControlLightLight;
            labelNameCinema.Depth = 0;
            labelNameCinema.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelNameCinema.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelNameCinema.Location = new Point(345, 70);
            labelNameCinema.MouseState = MaterialSkin.MouseState.HOVER;
            labelNameCinema.Name = "labelNameCinema";
            labelNameCinema.Size = new Size(43, 19);
            labelNameCinema.TabIndex = 29;
            labelNameCinema.Text = "Name";
            // 
            // labelNumberSequel
            // 
            labelNumberSequel.AutoSize = true;
            labelNumberSequel.BackColor = SystemColors.ControlLightLight;
            labelNumberSequel.Depth = 0;
            labelNumberSequel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelNumberSequel.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelNumberSequel.Location = new Point(215, 102);
            labelNumberSequel.MouseState = MaterialSkin.MouseState.HOVER;
            labelNumberSequel.Name = "labelNumberSequel";
            labelNumberSequel.Size = new Size(49, 19);
            labelNumberSequel.TabIndex = 30;
            labelNumberSequel.Text = "Sequel";
            // 
            // labelGradeCinema
            // 
            labelGradeCinema.AutoSize = true;
            labelGradeCinema.BackColor = SystemColors.ControlLightLight;
            labelGradeCinema.Depth = 0;
            labelGradeCinema.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelGradeCinema.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelGradeCinema.Location = new Point(345, 102);
            labelGradeCinema.MouseState = MaterialSkin.MouseState.HOVER;
            labelGradeCinema.Name = "labelGradeCinema";
            labelGradeCinema.Size = new Size(43, 19);
            labelGradeCinema.TabIndex = 31;
            labelGradeCinema.Text = "Grade";
            // 
            // btnSaveEdit
            // 
            btnSaveEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaveEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSaveEdit.Depth = 0;
            btnSaveEdit.HighEmphasis = true;
            btnSaveEdit.Icon = null;
            btnSaveEdit.Location = new Point(170, 133);
            btnSaveEdit.Margin = new Padding(4, 6, 4, 6);
            btnSaveEdit.MaximumSize = new Size(70, 20);
            btnSaveEdit.MinimumSize = new Size(70, 20);
            btnSaveEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.NoAccentTextColor = Color.Empty;
            btnSaveEdit.Size = new Size(70, 20);
            btnSaveEdit.TabIndex = 32;
            btnSaveEdit.Text = "Save";
            btnSaveEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSaveEdit.UseAccentColor = false;
            btnSaveEdit.UseVisualStyleBackColor = true;
            btnSaveEdit.Click += BtnSaveEdit_Click;
            // 
            // btnReturnDataCinema
            // 
            btnReturnDataCinema.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnReturnDataCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnReturnDataCinema.Depth = 0;
            btnReturnDataCinema.HighEmphasis = true;
            btnReturnDataCinema.Icon = null;
            btnReturnDataCinema.Location = new Point(250, 133);
            btnReturnDataCinema.Margin = new Padding(4, 6, 4, 6);
            btnReturnDataCinema.MaximumSize = new Size(70, 20);
            btnReturnDataCinema.MinimumSize = new Size(70, 20);
            btnReturnDataCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnReturnDataCinema.Name = "btnReturnDataCinema";
            btnReturnDataCinema.NoAccentTextColor = Color.Empty;
            btnReturnDataCinema.Size = new Size(70, 20);
            btnReturnDataCinema.TabIndex = 33;
            btnReturnDataCinema.Text = "Return";
            btnReturnDataCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnReturnDataCinema.UseAccentColor = false;
            btnReturnDataCinema.UseVisualStyleBackColor = true;
            btnReturnDataCinema.Click += BtnReturnDataCinema_Click;
            // 
            // btnCloseEdit
            // 
            btnCloseEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCloseEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCloseEdit.Depth = 0;
            btnCloseEdit.HighEmphasis = true;
            btnCloseEdit.Icon = null;
            btnCloseEdit.Location = new Point(330, 133);
            btnCloseEdit.Margin = new Padding(4, 6, 4, 6);
            btnCloseEdit.MaximumSize = new Size(60, 20);
            btnCloseEdit.MinimumSize = new Size(60, 20);
            btnCloseEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnCloseEdit.Name = "btnCloseEdit";
            btnCloseEdit.NoAccentTextColor = Color.Empty;
            btnCloseEdit.Size = new Size(60, 20);
            btnCloseEdit.TabIndex = 34;
            btnCloseEdit.Text = "Close";
            btnCloseEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCloseEdit.UseAccentColor = false;
            btnCloseEdit.UseVisualStyleBackColor = true;
            // 
            // cmbTypeCinema
            // 
            cmbTypeCinema.DataBindings.Add(new Binding("SelectedValue", typeModelBindingSource, "SelectedValue", true, DataSourceUpdateMode.OnPropertyChanged));
            cmbTypeCinema.DataBindings.Add(new Binding("DataSource", typeModelBindingSource, "Items", true, DataSourceUpdateMode.OnPropertyChanged));
            cmbTypeCinema.FormattingEnabled = true;
            cmbTypeCinema.Location = new Point(10, 100);
            cmbTypeCinema.Name = "cmbTypeCinema";
            cmbTypeCinema.Size = new Size(150, 23);
            cmbTypeCinema.TabIndex = 35;
            cmbTypeCinema.SelectedValueChanged += CmbTypeCinema_Changed;
            // 
            // typeModelBindingSource
            // 
            typeModelBindingSource.DataSource = typeof(BindingItem.ModelAddAndEditForm.SelectableTypeCinemaModel);
            // 
            // EditorItemCinemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnCloseEdit;
            ClientSize = new Size(400, 160);
            Controls.Add(cmbTypeCinema);
            Controls.Add(btnCloseEdit);
            Controls.Add(btnReturnDataCinema);
            Controls.Add(btnSaveEdit);
            Controls.Add(labelGradeCinema);
            Controls.Add(labelNumberSequel);
            Controls.Add(labelNameCinema);
            Controls.Add(numericEditGradeCinema);
            Controls.Add(dateTPCinema);
            Controls.Add(numericEditSequel);
            Controls.Add(txtEditName);
            Location = new Point(400, 160);
            MaximumSize = new Size(400, 160);
            Name = "EditorItemCinemaForm";
            Text = "Edit Item";
            Load += EditorItemCinemaForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericEditGradeCinema).EndInit();
            ((System.ComponentModel.ISupportInitialize)cinemaModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEditSequel).EndInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtEditName;
        protected NumericUpDown numericEditGradeCinema;
        protected DateTimePicker dateTPCinema;
        protected NumericUpDown numericEditSequel;
        private BindingSource cinemaModelBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelNameCinema;
        private MaterialSkin.Controls.MaterialLabel labelNumberSequel;
        private MaterialSkin.Controls.MaterialLabel labelGradeCinema;
        private MaterialSkin.Controls.MaterialButton btnSaveEdit;
        private MaterialSkin.Controls.MaterialButton btnReturnDataCinema;
        private MaterialSkin.Controls.MaterialButton btnCloseEdit;
        private ComboBox cmbTypeCinema;
        private BindingSource typeModelBindingSource;
    }
}
