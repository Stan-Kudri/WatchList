using WatchList.WinForms.BindingItem.ModelBoxForm;

namespace WatchList.WinForms.ChildForms
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
            numericSequel = new NumericUpDown();
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
            tlPanelButtonAddCinema = new TableLayoutPanel();
            tlFirstPanelAddCinema = new TableLayoutPanel();
            tlSecondPanelAddCinema = new TableLayoutPanel();
            tlNamePanelAddCinema = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)cinemaModelsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSequel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)statusModelBindingSource).BeginInit();
            tlPanelButtonAddCinema.SuspendLayout();
            tlFirstPanelAddCinema.SuspendLayout();
            tlSecondPanelAddCinema.SuspendLayout();
            tlNamePanelAddCinema.SuspendLayout();
            SuspendLayout();
            // 
            // txtAddCinema
            // 
            txtAddCinema.DataBindings.Add(new Binding("Text", cinemaModelsBindingSource, "Title", true));
            txtAddCinema.Dock = DockStyle.Fill;
            txtAddCinema.Location = new Point(3, 3);
            txtAddCinema.MinimumSize = new Size(309, 23);
            txtAddCinema.Name = "txtAddCinema";
            txtAddCinema.Size = new Size(309, 23);
            txtAddCinema.TabIndex = 1;
            // 
            // cinemaModelsBindingSource
            // 
            cinemaModelsBindingSource.DataSource = typeof(CinemaModel);
            // 
            // numericSequel
            // 
            numericSequel.DataBindings.Add(new Binding("Value", cinemaModelsBindingSource, "Sequel", true));
            numericSequel.Dock = DockStyle.Fill;
            numericSequel.Location = new Point(191, 3);
            numericSequel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericSequel.MinimumSize = new Size(60, 0);
            numericSequel.Name = "numericSequel";
            numericSequel.Size = new Size(60, 23);
            numericSequel.TabIndex = 11;
            numericSequel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dateTimePickerCinema
            // 
            dateTimePickerCinema.CustomFormat = "\"dd.MM.yyyy\"";
            dateTimePickerCinema.DataBindings.Add(new Binding("Value", cinemaModelsBindingSource, "Date", true));
            dateTimePickerCinema.Dock = DockStyle.Fill;
            dateTimePickerCinema.Location = new Point(223, 3);
            dateTimePickerCinema.MaxDate = new DateTime(2023, 8, 5, 0, 0, 0, 0);
            dateTimePickerCinema.MaximumSize = new Size(140, 23);
            dateTimePickerCinema.MinDate = new DateTime(1949, 12, 31, 0, 0, 0, 0);
            dateTimePickerCinema.MinimumSize = new Size(140, 23);
            dateTimePickerCinema.Name = "dateTimePickerCinema";
            dateTimePickerCinema.Size = new Size(140, 23);
            dateTimePickerCinema.TabIndex = 13;
            dateTimePickerCinema.Value = new DateTime(2023, 8, 5, 0, 0, 0, 0);
            // 
            // numericGradeCinema
            // 
            numericGradeCinema.DataBindings.Add(new Binding("Value", cinemaModelsBindingSource, "Grade", true));
            numericGradeCinema.Dock = DockStyle.Fill;
            numericGradeCinema.Enabled = false;
            numericGradeCinema.InterceptArrowKeys = false;
            numericGradeCinema.Location = new Point(307, 3);
            numericGradeCinema.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericGradeCinema.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericGradeCinema.MinimumSize = new Size(60, 0);
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
            labelGrade.Dock = DockStyle.Fill;
            labelGrade.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelGrade.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelGrade.Location = new Point(257, 3);
            labelGrade.Margin = new Padding(3);
            labelGrade.MouseState = MaterialSkin.MouseState.HOVER;
            labelGrade.Name = "labelGrade";
            labelGrade.Size = new Size(44, 24);
            labelGrade.TabIndex = 20;
            labelGrade.Text = "Grade";
            labelGrade.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = SystemColors.ControlLightLight;
            labelName.Depth = 0;
            labelName.Dock = DockStyle.Fill;
            labelName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelName.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelName.Location = new Point(318, 3);
            labelName.Margin = new Padding(3);
            labelName.MouseState = MaterialSkin.MouseState.HOVER;
            labelName.Name = "labelName";
            labelName.Size = new Size(49, 24);
            labelName.TabIndex = 21;
            labelName.Text = "Name";
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelNumberSequel
            // 
            labelNumberSequel.AutoSize = true;
            labelNumberSequel.BackColor = SystemColors.ControlLightLight;
            labelNumberSequel.Depth = 0;
            labelNumberSequel.Dock = DockStyle.Fill;
            labelNumberSequel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelNumberSequel.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelNumberSequel.Location = new Point(131, 3);
            labelNumberSequel.Margin = new Padding(3);
            labelNumberSequel.MouseState = MaterialSkin.MouseState.HOVER;
            labelNumberSequel.Name = "labelNumberSequel";
            labelNumberSequel.Size = new Size(54, 24);
            labelNumberSequel.TabIndex = 22;
            labelNumberSequel.Text = "Sequel";
            labelNumberSequel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClearTxtCinema
            // 
            btnClearTxtCinema.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClearTxtCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClearTxtCinema.Depth = 0;
            btnClearTxtCinema.Dock = DockStyle.Fill;
            btnClearTxtCinema.HighEmphasis = true;
            btnClearTxtCinema.Icon = null;
            btnClearTxtCinema.Location = new Point(128, 5);
            btnClearTxtCinema.Margin = new Padding(5);
            btnClearTxtCinema.MinimumSize = new Size(60, 20);
            btnClearTxtCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnClearTxtCinema.Name = "btnClearTxtCinema";
            btnClearTxtCinema.NoAccentTextColor = Color.Empty;
            btnClearTxtCinema.Size = new Size(113, 20);
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
            btnAddCinema.Dock = DockStyle.Fill;
            btnAddCinema.HighEmphasis = true;
            btnAddCinema.Icon = null;
            btnAddCinema.Location = new Point(5, 5);
            btnAddCinema.Margin = new Padding(5);
            btnAddCinema.MinimumSize = new Size(60, 20);
            btnAddCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddCinema.Name = "btnAddCinema";
            btnAddCinema.NoAccentTextColor = Color.Empty;
            btnAddCinema.Size = new Size(113, 20);
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
            btnBackFormCinema.Dock = DockStyle.Fill;
            btnBackFormCinema.HighEmphasis = true;
            btnBackFormCinema.Icon = null;
            btnBackFormCinema.Location = new Point(251, 5);
            btnBackFormCinema.Margin = new Padding(5);
            btnBackFormCinema.MaximumSize = new Size(0, 20);
            btnBackFormCinema.MinimumSize = new Size(60, 20);
            btnBackFormCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackFormCinema.Name = "btnBackFormCinema";
            btnBackFormCinema.NoAccentTextColor = Color.Empty;
            btnBackFormCinema.Size = new Size(114, 20);
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
            cmbTypeCinema.Dock = DockStyle.Fill;
            cmbTypeCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeCinema.FormattingEnabled = true;
            cmbTypeCinema.Location = new Point(43, 3);
            cmbTypeCinema.MinimumSize = new Size(82, 0);
            cmbTypeCinema.Name = "cmbTypeCinema";
            cmbTypeCinema.Size = new Size(82, 23);
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
            cmbStatusCinema.Dock = DockStyle.Fill;
            cmbStatusCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusCinema.FormattingEnabled = true;
            cmbStatusCinema.Location = new Point(53, 3);
            cmbStatusCinema.MinimumSize = new Size(165, 0);
            cmbStatusCinema.Name = "cmbStatusCinema";
            cmbStatusCinema.Size = new Size(165, 23);
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
            labelStatus.Dock = DockStyle.Fill;
            labelStatus.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelStatus.Location = new Point(3, 3);
            labelStatus.Margin = new Padding(3);
            labelStatus.MouseState = MaterialSkin.MouseState.HOVER;
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(44, 24);
            labelStatus.TabIndex = 29;
            labelStatus.Text = "Status";
            labelStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.BackColor = SystemColors.ControlLightLight;
            labelType.Depth = 0;
            labelType.Dock = DockStyle.Fill;
            labelType.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelType.Location = new Point(3, 3);
            labelType.Margin = new Padding(3);
            labelType.MouseState = MaterialSkin.MouseState.HOVER;
            labelType.Name = "labelType";
            labelType.Size = new Size(34, 24);
            labelType.TabIndex = 30;
            labelType.Text = "Type";
            labelType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlPanelButtonAddCinema
            // 
            tlPanelButtonAddCinema.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlPanelButtonAddCinema.ColumnCount = 3;
            tlPanelButtonAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlPanelButtonAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlPanelButtonAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlPanelButtonAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlPanelButtonAddCinema.Controls.Add(btnAddCinema, 0, 0);
            tlPanelButtonAddCinema.Controls.Add(btnClearTxtCinema, 1, 0);
            tlPanelButtonAddCinema.Controls.Add(btnBackFormCinema, 2, 0);
            tlPanelButtonAddCinema.Location = new Point(10, 157);
            tlPanelButtonAddCinema.MinimumSize = new Size(370, 30);
            tlPanelButtonAddCinema.Name = "tlPanelButtonAddCinema";
            tlPanelButtonAddCinema.RowCount = 1;
            tlPanelButtonAddCinema.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlPanelButtonAddCinema.Size = new Size(370, 30);
            tlPanelButtonAddCinema.TabIndex = 31;
            // 
            // tlFirstPanelAddCinema
            // 
            tlFirstPanelAddCinema.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlFirstPanelAddCinema.ColumnCount = 6;
            tlFirstPanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tlFirstPanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlFirstPanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tlFirstPanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlFirstPanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlFirstPanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlFirstPanelAddCinema.Controls.Add(labelType, 0, 0);
            tlFirstPanelAddCinema.Controls.Add(cmbTypeCinema, 1, 0);
            tlFirstPanelAddCinema.Controls.Add(labelNumberSequel, 2, 0);
            tlFirstPanelAddCinema.Controls.Add(numericSequel, 3, 0);
            tlFirstPanelAddCinema.Controls.Add(labelGrade, 4, 0);
            tlFirstPanelAddCinema.Controls.Add(numericGradeCinema, 5, 0);
            tlFirstPanelAddCinema.Location = new Point(10, 97);
            tlFirstPanelAddCinema.MinimumSize = new Size(370, 30);
            tlFirstPanelAddCinema.Name = "tlFirstPanelAddCinema";
            tlFirstPanelAddCinema.RowCount = 1;
            tlFirstPanelAddCinema.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlFirstPanelAddCinema.Size = new Size(370, 30);
            tlFirstPanelAddCinema.TabIndex = 32;
            // 
            // tlSecondPanelAddCinema
            // 
            tlSecondPanelAddCinema.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlSecondPanelAddCinema.ColumnCount = 3;
            tlSecondPanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlSecondPanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlSecondPanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlSecondPanelAddCinema.Controls.Add(dateTimePickerCinema, 2, 0);
            tlSecondPanelAddCinema.Controls.Add(cmbStatusCinema, 1, 0);
            tlSecondPanelAddCinema.Controls.Add(labelStatus, 0, 0);
            tlSecondPanelAddCinema.Location = new Point(10, 129);
            tlSecondPanelAddCinema.MinimumSize = new Size(370, 30);
            tlSecondPanelAddCinema.Name = "tlSecondPanelAddCinema";
            tlSecondPanelAddCinema.RowCount = 1;
            tlSecondPanelAddCinema.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlSecondPanelAddCinema.Size = new Size(370, 30);
            tlSecondPanelAddCinema.TabIndex = 33;
            // 
            // tlNamePanelAddCinema
            // 
            tlNamePanelAddCinema.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlNamePanelAddCinema.ColumnCount = 2;
            tlNamePanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlNamePanelAddCinema.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            tlNamePanelAddCinema.Controls.Add(txtAddCinema, 0, 0);
            tlNamePanelAddCinema.Controls.Add(labelName, 1, 0);
            tlNamePanelAddCinema.Location = new Point(10, 64);
            tlNamePanelAddCinema.MinimumSize = new Size(370, 30);
            tlNamePanelAddCinema.Name = "tlNamePanelAddCinema";
            tlNamePanelAddCinema.RowCount = 1;
            tlNamePanelAddCinema.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlNamePanelAddCinema.Size = new Size(370, 30);
            tlNamePanelAddCinema.TabIndex = 34;
            // 
            // AddCinemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnBackFormCinema;
            ClientSize = new Size(390, 190);
            Controls.Add(tlNamePanelAddCinema);
            Controls.Add(tlSecondPanelAddCinema);
            Controls.Add(tlFirstPanelAddCinema);
            Controls.Add(tlPanelButtonAddCinema);
            MinimumSize = new Size(390, 190);
            Name = "AddCinemaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Cinema";
            Load += AddCinemaForm_Load;
            ((System.ComponentModel.ISupportInitialize)cinemaModelsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSequel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).EndInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)statusModelBindingSource).EndInit();
            tlPanelButtonAddCinema.ResumeLayout(false);
            tlPanelButtonAddCinema.PerformLayout();
            tlFirstPanelAddCinema.ResumeLayout(false);
            tlFirstPanelAddCinema.PerformLayout();
            tlSecondPanelAddCinema.ResumeLayout(false);
            tlSecondPanelAddCinema.PerformLayout();
            tlNamePanelAddCinema.ResumeLayout(false);
            tlNamePanelAddCinema.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtAddCinema;
        private NumericUpDown numericSequel;
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
        private TableLayoutPanel tlPanelButtonAddCinema;
        private TableLayoutPanel tlFirstPanelAddCinema;
        private TableLayoutPanel tlSecondPanelAddCinema;
        private TableLayoutPanel tlNamePanelAddCinema;
    }
}
