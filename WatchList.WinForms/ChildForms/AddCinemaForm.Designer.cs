using WatchList.WinForms.BindingItem.ModelBoxForm;

namespace WatchList.WinForms
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
            cmbTypeCinema = new ComboBox();
            typeModelBindingSource = new BindingSource(components);
            cmbStatusCinema = new ComboBox();
            statusModelBindingSource = new BindingSource(components);
            labelStatus = new MaterialSkin.Controls.MaterialLabel();
            labelType = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)cinemaModelsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSeaquel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)statusModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // txtAddCinema
            // 
            txtAddCinema.DataBindings.Add(new Binding("Text", cinemaModelsBindingSource, "Title", true));
            txtAddCinema.Location = new Point(10, 70);
            txtAddCinema.Name = "txtAddCinema";
            txtAddCinema.Size = new Size(290, 23);
            txtAddCinema.TabIndex = 1;
            // 
            // cinemaModelsBindingSource
            // 
            cinemaModelsBindingSource.DataSource = typeof(CinemaModel);
            // 
            // numericSequel
            // 
            numericSeaquel.DataBindings.Add(new Binding("Value", cinemaModelsBindingSource, "Sequel", true));
            numericSeaquel.Location = new Point(240, 100);
            numericSeaquel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericSeaquel.Name = "numericSequel";
            numericSeaquel.Size = new Size(55, 23);
            numericSeaquel.TabIndex = 11;
            numericSeaquel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dateTimePickerCinema
            // 
            dateTimePickerCinema.CustomFormat = "\"dd.MM.yyyy\"";
            dateTimePickerCinema.DataBindings.Add(new Binding("Value", cinemaModelsBindingSource, "Date", true));
            dateTimePickerCinema.Location = new Point(10, 155);
            dateTimePickerCinema.MaxDate = new DateTime(2022, 9, 7, 0, 0, 0, 0);
            dateTimePickerCinema.MinDate = new DateTime(1949, 12, 31, 0, 0, 0, 0);
            dateTimePickerCinema.Name = "dateTimePickerCinema";
            dateTimePickerCinema.Size = new Size(155, 23);
            dateTimePickerCinema.TabIndex = 13;
            dateTimePickerCinema.Value = new DateTime(2022, 8, 7, 0, 0, 0, 0);
            // 
            // numericGradeCinema
            // 
            numericGradeCinema.DataBindings.Add(new Binding("Value", cinemaModelsBindingSource, "Grade", true));
            numericGradeCinema.Enabled = false;
            numericGradeCinema.InterceptArrowKeys = false;
            numericGradeCinema.Location = new Point(240, 128);
            numericGradeCinema.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericGradeCinema.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericGradeCinema.Name = "numericGradeCinema";
            numericGradeCinema.ReadOnly = true;
            numericGradeCinema.Size = new Size(60, 23);
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
            labelGrade.Location = new Point(310, 130);
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
            labelName.Location = new Point(310, 72);
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
            labelNumberSequel.Location = new Point(305, 102);
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
            btnClearTxtCinema.Location = new Point(235, 156);
            btnClearTxtCinema.Margin = new Padding(0);
            btnClearTxtCinema.MaximumSize = new Size(60, 20);
            btnClearTxtCinema.MinimumSize = new Size(60, 20);
            btnClearTxtCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnClearTxtCinema.Name = "btnClearTxtCinema";
            btnClearTxtCinema.NoAccentTextColor = Color.Empty;
            btnClearTxtCinema.Size = new Size(60, 20);
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
            btnAddCinema.Location = new Point(170, 156);
            btnAddCinema.Margin = new Padding(0);
            btnAddCinema.MaximumSize = new Size(60, 20);
            btnAddCinema.MinimumSize = new Size(60, 20);
            btnAddCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddCinema.Name = "btnAddCinema";
            btnAddCinema.NoAccentTextColor = Color.Empty;
            btnAddCinema.Size = new Size(60, 20);
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
            btnBackFormCinema.DialogResult = DialogResult.Cancel;
            btnBackFormCinema.HighEmphasis = true;
            btnBackFormCinema.Icon = null;
            btnBackFormCinema.Location = new Point(300, 156);
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
            // 
            // cmbTypeCinema
            // 
            cmbTypeCinema.DataBindings.Add(new Binding("SelectedValue", typeModelBindingSource, "SelectedValue", true));
            cmbTypeCinema.DataBindings.Add(new Binding("DataSource", typeModelBindingSource, "Items", true));
            cmbTypeCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeCinema.FormattingEnabled = true;
            cmbTypeCinema.Location = new Point(10, 100);
            cmbTypeCinema.Name = "cmbTypeCinema";
            cmbTypeCinema.Size = new Size(155, 23);
            cmbTypeCinema.TabIndex = 27;
            cmbTypeCinema.SelectedIndexChanged += CmbTypeCinema_Changed;
            // 
            // typeModelBindingSource
            // 
            typeModelBindingSource.DataSource = typeof(BindingItem.ModelAddAndEditForm.SelectableTypeCinemaModel);
            // 
            // cmbStatusCinema
            // 
            cmbStatusCinema.DataBindings.Add(new Binding("SelectedValue", statusModelBindingSource, "ValueStatus", true));
            cmbStatusCinema.DataBindings.Add(new Binding("DataSource", statusModelBindingSource, "Items", true));
            cmbStatusCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusCinema.FormattingEnabled = true;
            cmbStatusCinema.Location = new Point(10, 128);
            cmbStatusCinema.Name = "cmbStatusCinema";
            cmbStatusCinema.Size = new Size(155, 23);
            cmbStatusCinema.TabIndex = 28;
            cmbStatusCinema.SelectedValueChanged += CmbStatusCinema_Changed;
            // 
            // statusModelBindingSource
            // 
            statusModelBindingSource.DataSource = typeof(BindingItem.ModelAddAndEditForm.SelectableStatusCinemaModel);
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
            labelStatus.TabIndex = 29;
            labelStatus.Text = "Status";
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
            labelType.TabIndex = 30;
            labelType.Text = "Type";
            // 
            // AddCinemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnBackFormCinema;
            ClientSize = new Size(370, 185);
            Controls.Add(labelType);
            Controls.Add(labelStatus);
            Controls.Add(cmbStatusCinema);
            Controls.Add(cmbTypeCinema);
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
            MaximumSize = new Size(370, 185);
            MinimumSize = new Size(370, 185);
            Name = "AddCinemaForm";
            Text = "Add Cinema";
            Load += AddCinemaForm_Load;
            ((System.ComponentModel.ISupportInitialize)cinemaModelsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSeaquel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).EndInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)statusModelBindingSource).EndInit();
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
        private ComboBox cmbTypeCinema;
        private BindingSource typeModelBindingSource;
        private ComboBox cmbStatusCinema;
        private MaterialSkin.Controls.MaterialLabel labelStatus;
        private MaterialSkin.Controls.MaterialLabel labelType;
        private BindingSource statusModelBindingSource;
    }
}
