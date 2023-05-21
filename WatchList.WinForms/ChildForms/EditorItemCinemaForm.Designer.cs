using WatchList.WinForms.BindingItem.ModelBoxForm;

namespace WatchList.WinForms.EditorForm
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
            numericGradeCinema = new NumericUpDown();
            cinemaModelBindingSource = new BindingSource(components);
            dateTimePickerCinema = new DateTimePicker();
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
            labelType = new MaterialSkin.Controls.MaterialLabel();
            labelStatus = new MaterialSkin.Controls.MaterialLabel();
            cmbStatusCinema = new ComboBox();
            statusModelBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cinemaModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEditSequel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)statusModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // numericGradeCinema
            // 
            numericGradeCinema.DataBindings.Add(new Binding("Value", cinemaModelBindingSource, "Grade", true));
            numericGradeCinema.Enabled = false;
            numericGradeCinema.InterceptArrowKeys = false;
            numericGradeCinema.Location = new Point(240, 128);
            numericGradeCinema.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericGradeCinema.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericGradeCinema.Name = "numericGradeCinema";
            numericGradeCinema.ReadOnly = true;
            numericGradeCinema.Size = new Size(60, 23);
            numericGradeCinema.TabIndex = 27;
            numericGradeCinema.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cinemaModelBindingSource
            // 
            cinemaModelBindingSource.DataSource = typeof(CinemaModel);
            //
            // dateTimePickerCinema
            // 
            dateTimePickerCinema.CustomFormat = "\"dd.MM.yyyy\"";
            dateTimePickerCinema.DataBindings.Add(new Binding("Value", cinemaModelBindingSource, "Date", true));
            dateTimePickerCinema.Location = new Point(10, 155);
            dateTimePickerCinema.MaxDate = new DateTime(2022, 8, 29, 0, 0, 0, 0);
            dateTimePickerCinema.MinDate = new DateTime(1949, 12, 31, 0, 0, 0, 0);
            dateTimePickerCinema.Name = "dateTimePickerCinema";
            dateTimePickerCinema.Size = new Size(155, 23);
            dateTimePickerCinema.TabIndex = 26;
            dateTimePickerCinema.Value = new DateTime(2022, 8, 7, 0, 0, 0, 0);
            // 
            // numericEditSequel
            // 
            numericEditSequel.DataBindings.Add(new Binding("Value", cinemaModelBindingSource, "Sequel", true));
            numericEditSequel.Location = new Point(240, 100);
            numericEditSequel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericEditSequel.Name = "numericEditSequel";
            numericEditSequel.Size = new Size(55, 23);
            numericEditSequel.TabIndex = 25;
            numericEditSequel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtEditName
            // 
            txtEditName.DataBindings.Add(new Binding("Text", cinemaModelBindingSource, "Title", true));
            txtEditName.Location = new Point(10, 70);
            txtEditName.Multiline = true;
            txtEditName.Name = "txtEditName";
            txtEditName.Size = new Size(290, 23);
            txtEditName.TabIndex = 19;
            // 
            // labelNameCinema
            // 
            labelNameCinema.AutoSize = true;
            labelNameCinema.BackColor = SystemColors.ControlLightLight;
            labelNameCinema.Depth = 0;
            labelNameCinema.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelNameCinema.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelNameCinema.Location = new Point(310, 72);
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
            labelNumberSequel.Location = new Point(305, 102);
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
            labelGradeCinema.Location = new Point(310, 130);
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
            btnSaveEdit.Location = new Point(170, 156);
            btnSaveEdit.Margin = new Padding(4, 6, 4, 6);
            btnSaveEdit.MaximumSize = new Size(60, 20);
            btnSaveEdit.MinimumSize = new Size(60, 20);
            btnSaveEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.NoAccentTextColor = Color.Empty;
            btnSaveEdit.Size = new Size(60, 20);
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
            btnReturnDataCinema.Location = new Point(235, 156);
            btnReturnDataCinema.Margin = new Padding(4, 6, 4, 6);
            btnReturnDataCinema.MaximumSize = new Size(60, 20);
            btnReturnDataCinema.MinimumSize = new Size(60, 20);
            btnReturnDataCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnReturnDataCinema.Name = "btnReturnDataCinema";
            btnReturnDataCinema.NoAccentTextColor = Color.Empty;
            btnReturnDataCinema.Size = new Size(60, 20);
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
            btnCloseEdit.Location = new Point(300, 156);
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
            cmbTypeCinema.BackColor = SystemColors.ButtonHighlight;
            cmbTypeCinema.DataBindings.Add(new Binding("SelectedValue", typeModelBindingSource, "SelectedValue", true));
            cmbTypeCinema.DataBindings.Add(new Binding("DataSource", typeModelBindingSource, "Items", true));
            cmbTypeCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeCinema.FormattingEnabled = true;
            cmbTypeCinema.Location = new Point(10, 100);
            cmbTypeCinema.Name = "cmbTypeCinema";
            cmbTypeCinema.Size = new Size(155, 23);
            cmbTypeCinema.TabIndex = 35;
            cmbTypeCinema.SelectedValueChanged += CmbTypeCinema_Changed;
            // 
            // typeModelBindingSource
            // 
            typeModelBindingSource.DataSource = typeof(BindingItem.ModelAddAndEditForm.SelectableTypeCinemaModel);
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.BackColor = SystemColors.ControlLightLight;
            labelType.Depth = 0;
            labelType.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelType.Location = new Point(175, 102);
            labelType.MouseState = MaterialSkin.MouseState.HOVER;
            labelType.Name = "labelType";
            labelType.Size = new Size(36, 19);
            labelType.TabIndex = 36;
            labelType.Text = "Type";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.BackColor = SystemColors.ControlLightLight;
            labelStatus.Depth = 0;
            labelStatus.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelStatus.Location = new Point(175, 130);
            labelStatus.MouseState = MaterialSkin.MouseState.HOVER;
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(47, 19);
            labelStatus.TabIndex = 38;
            labelStatus.Text = "Status";
            // 
            // cmbStatusCinema
            // 
            cmbStatusCinema.BackColor = SystemColors.ButtonHighlight;
            cmbStatusCinema.DataBindings.Add(new Binding("DataSource", statusModelBindingSource, "Items", true));
            cmbStatusCinema.DataBindings.Add(new Binding("SelectedValue", statusModelBindingSource, "ValueStatus", true));
            cmbStatusCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusCinema.FormattingEnabled = true;
            cmbStatusCinema.Location = new Point(10, 128);
            cmbStatusCinema.Name = "cmbStatusCinema";
            cmbStatusCinema.Size = new Size(155, 23);
            cmbStatusCinema.TabIndex = 37;
            cmbStatusCinema.SelectedValueChanged += CmbStatusCinema_Changed;
            // 
            // statusModelBindingSource
            // 
            statusModelBindingSource.DataSource = typeof(BindingItem.ModelAddAndEditForm.SelectableStatusCinemaModel);
            // 
            // EditorItemCinemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnCloseEdit;
            ClientSize = new Size(370, 185);
            Controls.Add(labelStatus);
            Controls.Add(cmbStatusCinema);
            Controls.Add(labelType);
            Controls.Add(cmbTypeCinema);
            Controls.Add(btnCloseEdit);
            Controls.Add(btnReturnDataCinema);
            Controls.Add(btnSaveEdit);
            Controls.Add(labelGradeCinema);
            Controls.Add(labelNumberSequel);
            Controls.Add(labelNameCinema);
            Controls.Add(numericGradeCinema);
            Controls.Add(dateTimePickerCinema);
            Controls.Add(numericEditSequel);
            Controls.Add(txtEditName);
            Location = new Point(370, 185);
            MaximumSize = new Size(370, 185);
            Name = "EditorItemCinemaForm";
            Text = "Edit Item";
            Load += EditorItemCinemaForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).EndInit();
            ((System.ComponentModel.ISupportInitialize)cinemaModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEditSequel).EndInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)statusModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtEditName;
        protected NumericUpDown numericGradeCinema;
        protected DateTimePicker dateTimePickerCinema;
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
        private MaterialSkin.Controls.MaterialLabel labelType;
        private MaterialSkin.Controls.MaterialLabel labelStatus;
        private ComboBox cmbStatusCinema;
        private BindingSource statusModelBindingSource;
    }
}
