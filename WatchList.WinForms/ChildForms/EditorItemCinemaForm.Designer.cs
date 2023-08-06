using WatchList.WinForms.BindingItem.ModelBoxForm;

namespace WatchList.WinForms.ChildForms
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
            tlNamePanelEditItem = new TableLayoutPanel();
            tlFirstPanelEditItem = new TableLayoutPanel();
            tlSecondPanelEditItem = new TableLayoutPanel();
            tlPanelButtonEditItem = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cinemaModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericEditSequel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)statusModelBindingSource).BeginInit();
            tlNamePanelEditItem.SuspendLayout();
            tlFirstPanelEditItem.SuspendLayout();
            tlSecondPanelEditItem.SuspendLayout();
            tlPanelButtonEditItem.SuspendLayout();
            SuspendLayout();
            // 
            // numericGradeCinema
            // 
            numericGradeCinema.DataBindings.Add(new Binding("Value", cinemaModelBindingSource, "Grade", true));
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
            dateTimePickerCinema.Dock = DockStyle.Fill;
            dateTimePickerCinema.Location = new Point(223, 3);
            dateTimePickerCinema.MaxDate = new DateTime(2022, 8, 29, 0, 0, 0, 0);
            dateTimePickerCinema.MinDate = new DateTime(1949, 12, 31, 0, 0, 0, 0);
            dateTimePickerCinema.MinimumSize = new Size(140, 23);
            dateTimePickerCinema.Name = "dateTimePickerCinema";
            dateTimePickerCinema.Size = new Size(144, 23);
            dateTimePickerCinema.TabIndex = 26;
            dateTimePickerCinema.Value = new DateTime(2022, 8, 7, 0, 0, 0, 0);
            // 
            // numericEditSequel
            // 
            numericEditSequel.DataBindings.Add(new Binding("Value", cinemaModelBindingSource, "Sequel", true));
            numericEditSequel.Dock = DockStyle.Fill;
            numericEditSequel.Location = new Point(191, 3);
            numericEditSequel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericEditSequel.MinimumSize = new Size(60, 0);
            numericEditSequel.Name = "numericEditSequel";
            numericEditSequel.Size = new Size(60, 23);
            numericEditSequel.TabIndex = 25;
            numericEditSequel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtEditName
            // 
            txtEditName.DataBindings.Add(new Binding("Text", cinemaModelBindingSource, "Title", true));
            txtEditName.Dock = DockStyle.Fill;
            txtEditName.Location = new Point(3, 3);
            txtEditName.Multiline = true;
            txtEditName.Name = "txtEditName";
            txtEditName.Size = new Size(309, 24);
            txtEditName.TabIndex = 19;
            // 
            // labelNameCinema
            // 
            labelNameCinema.AutoSize = true;
            labelNameCinema.BackColor = SystemColors.ControlLightLight;
            labelNameCinema.Depth = 0;
            labelNameCinema.Dock = DockStyle.Fill;
            labelNameCinema.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelNameCinema.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelNameCinema.Location = new Point(318, 3);
            labelNameCinema.Margin = new Padding(3);
            labelNameCinema.MouseState = MaterialSkin.MouseState.HOVER;
            labelNameCinema.Name = "labelNameCinema";
            labelNameCinema.Size = new Size(49, 24);
            labelNameCinema.TabIndex = 29;
            labelNameCinema.Text = "Name";
            labelNameCinema.TextAlign = ContentAlignment.MiddleCenter;
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
            labelNumberSequel.TabIndex = 30;
            labelNumberSequel.Text = "Sequel";
            labelNumberSequel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGradeCinema
            // 
            labelGradeCinema.AutoSize = true;
            labelGradeCinema.BackColor = SystemColors.ControlLightLight;
            labelGradeCinema.Depth = 0;
            labelGradeCinema.Dock = DockStyle.Fill;
            labelGradeCinema.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelGradeCinema.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelGradeCinema.Location = new Point(257, 3);
            labelGradeCinema.Margin = new Padding(3);
            labelGradeCinema.MouseState = MaterialSkin.MouseState.HOVER;
            labelGradeCinema.Name = "labelGradeCinema";
            labelGradeCinema.Size = new Size(44, 24);
            labelGradeCinema.TabIndex = 31;
            labelGradeCinema.Text = "Grade";
            labelGradeCinema.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSaveEdit
            // 
            btnSaveEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSaveEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSaveEdit.Depth = 0;
            btnSaveEdit.Dock = DockStyle.Fill;
            btnSaveEdit.HighEmphasis = true;
            btnSaveEdit.Icon = null;
            btnSaveEdit.Location = new Point(5, 5);
            btnSaveEdit.Margin = new Padding(5);
            btnSaveEdit.MinimumSize = new Size(60, 20);
            btnSaveEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.NoAccentTextColor = Color.Empty;
            btnSaveEdit.Size = new Size(113, 20);
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
            btnReturnDataCinema.Dock = DockStyle.Fill;
            btnReturnDataCinema.HighEmphasis = true;
            btnReturnDataCinema.Icon = null;
            btnReturnDataCinema.Location = new Point(128, 5);
            btnReturnDataCinema.Margin = new Padding(5);
            btnReturnDataCinema.MinimumSize = new Size(60, 20);
            btnReturnDataCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnReturnDataCinema.Name = "btnReturnDataCinema";
            btnReturnDataCinema.NoAccentTextColor = Color.Empty;
            btnReturnDataCinema.Size = new Size(113, 20);
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
            btnCloseEdit.Dock = DockStyle.Fill;
            btnCloseEdit.HighEmphasis = true;
            btnCloseEdit.Icon = null;
            btnCloseEdit.Location = new Point(251, 5);
            btnCloseEdit.Margin = new Padding(5);
            btnCloseEdit.MinimumSize = new Size(60, 20);
            btnCloseEdit.MouseState = MaterialSkin.MouseState.HOVER;
            btnCloseEdit.Name = "btnCloseEdit";
            btnCloseEdit.NoAccentTextColor = Color.Empty;
            btnCloseEdit.Size = new Size(114, 20);
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
            cmbTypeCinema.Dock = DockStyle.Fill;
            cmbTypeCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeCinema.FormattingEnabled = true;
            cmbTypeCinema.Location = new Point(43, 3);
            cmbTypeCinema.MinimumSize = new Size(82, 0);
            cmbTypeCinema.Name = "cmbTypeCinema";
            cmbTypeCinema.Size = new Size(82, 23);
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
            labelType.Dock = DockStyle.Fill;
            labelType.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            labelType.Location = new Point(3, 3);
            labelType.Margin = new Padding(3);
            labelType.MinimumSize = new Size(34, 24);
            labelType.MouseState = MaterialSkin.MouseState.HOVER;
            labelType.Name = "labelType";
            labelType.Size = new Size(34, 24);
            labelType.TabIndex = 36;
            labelType.Text = "Type";
            labelType.TextAlign = ContentAlignment.MiddleCenter;
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
            labelStatus.TabIndex = 38;
            labelStatus.Text = "Status";
            labelStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbStatusCinema
            // 
            cmbStatusCinema.BackColor = SystemColors.ButtonHighlight;
            cmbStatusCinema.DataBindings.Add(new Binding("DataSource", statusModelBindingSource, "Items", true));
            cmbStatusCinema.DataBindings.Add(new Binding("SelectedValue", statusModelBindingSource, "ValueStatus", true));
            cmbStatusCinema.Dock = DockStyle.Fill;
            cmbStatusCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusCinema.FormattingEnabled = true;
            cmbStatusCinema.Location = new Point(53, 3);
            cmbStatusCinema.MinimumSize = new Size(165, 0);
            cmbStatusCinema.Name = "cmbStatusCinema";
            cmbStatusCinema.Size = new Size(165, 23);
            cmbStatusCinema.TabIndex = 37;
            cmbStatusCinema.SelectedValueChanged += CmbStatusCinema_Changed;
            // 
            // statusModelBindingSource
            // 
            statusModelBindingSource.DataSource = typeof(BindingItem.ModelAddAndEditForm.SelectableStatusCinemaModel);
            // 
            // tlNamePanelEditItem
            // 
            tlNamePanelEditItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlNamePanelEditItem.ColumnCount = 2;
            tlNamePanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlNamePanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            tlNamePanelEditItem.Controls.Add(labelNameCinema, 1, 0);
            tlNamePanelEditItem.Controls.Add(txtEditName, 0, 0);
            tlNamePanelEditItem.Location = new Point(10, 64);
            tlNamePanelEditItem.MinimumSize = new Size(370, 30);
            tlNamePanelEditItem.Name = "tlNamePanelEditItem";
            tlNamePanelEditItem.RowCount = 1;
            tlNamePanelEditItem.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlNamePanelEditItem.Size = new Size(370, 30);
            tlNamePanelEditItem.TabIndex = 39;
            // 
            // tlFirstPanelEditItem
            // 
            tlFirstPanelEditItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlFirstPanelEditItem.ColumnCount = 6;
            tlFirstPanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tlFirstPanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlFirstPanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tlFirstPanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlFirstPanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlFirstPanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlFirstPanelEditItem.Controls.Add(cmbTypeCinema, 1, 0);
            tlFirstPanelEditItem.Controls.Add(labelType, 0, 0);
            tlFirstPanelEditItem.Controls.Add(labelNumberSequel, 2, 0);
            tlFirstPanelEditItem.Controls.Add(numericEditSequel, 3, 0);
            tlFirstPanelEditItem.Controls.Add(labelGradeCinema, 4, 0);
            tlFirstPanelEditItem.Controls.Add(numericGradeCinema, 5, 0);
            tlFirstPanelEditItem.Location = new Point(10, 97);
            tlFirstPanelEditItem.MinimumSize = new Size(370, 30);
            tlFirstPanelEditItem.Name = "tlFirstPanelEditItem";
            tlFirstPanelEditItem.RowCount = 1;
            tlFirstPanelEditItem.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlFirstPanelEditItem.Size = new Size(370, 30);
            tlFirstPanelEditItem.TabIndex = 40;
            // 
            // tlSecondPanelEditItem
            // 
            tlSecondPanelEditItem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlSecondPanelEditItem.ColumnCount = 3;
            tlSecondPanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tlSecondPanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlSecondPanelEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlSecondPanelEditItem.Controls.Add(labelStatus, 0, 0);
            tlSecondPanelEditItem.Controls.Add(cmbStatusCinema, 1, 0);
            tlSecondPanelEditItem.Controls.Add(dateTimePickerCinema, 2, 0);
            tlSecondPanelEditItem.Location = new Point(10, 129);
            tlSecondPanelEditItem.MinimumSize = new Size(370, 30);
            tlSecondPanelEditItem.Name = "tlSecondPanelEditItem";
            tlSecondPanelEditItem.RowCount = 1;
            tlSecondPanelEditItem.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlSecondPanelEditItem.Size = new Size(370, 30);
            tlSecondPanelEditItem.TabIndex = 41;
            // 
            // tlPanelButtonEditItem
            // 
            tlPanelButtonEditItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlPanelButtonEditItem.ColumnCount = 3;
            tlPanelButtonEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlPanelButtonEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlPanelButtonEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlPanelButtonEditItem.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlPanelButtonEditItem.Controls.Add(btnSaveEdit, 0, 0);
            tlPanelButtonEditItem.Controls.Add(btnReturnDataCinema, 1, 0);
            tlPanelButtonEditItem.Controls.Add(btnCloseEdit, 2, 0);
            tlPanelButtonEditItem.Location = new Point(10, 157);
            tlPanelButtonEditItem.MinimumSize = new Size(370, 30);
            tlPanelButtonEditItem.Name = "tlPanelButtonEditItem";
            tlPanelButtonEditItem.RowCount = 1;
            tlPanelButtonEditItem.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlPanelButtonEditItem.Size = new Size(370, 30);
            tlPanelButtonEditItem.TabIndex = 42;
            // 
            // EditorItemCinemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnCloseEdit;
            ClientSize = new Size(390, 190);
            Controls.Add(tlPanelButtonEditItem);
            Controls.Add(tlSecondPanelEditItem);
            Controls.Add(tlFirstPanelEditItem);
            Controls.Add(tlNamePanelEditItem);
            MinimumSize = new Size(390, 190);
            Name = "EditorItemCinemaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Item";
            Load += EditorItemCinemaForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericGradeCinema).EndInit();
            ((System.ComponentModel.ISupportInitialize)cinemaModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericEditSequel).EndInit();
            ((System.ComponentModel.ISupportInitialize)typeModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)statusModelBindingSource).EndInit();
            tlNamePanelEditItem.ResumeLayout(false);
            tlNamePanelEditItem.PerformLayout();
            tlFirstPanelEditItem.ResumeLayout(false);
            tlFirstPanelEditItem.PerformLayout();
            tlSecondPanelEditItem.ResumeLayout(false);
            tlSecondPanelEditItem.PerformLayout();
            tlPanelButtonEditItem.ResumeLayout(false);
            tlPanelButtonEditItem.PerformLayout();
            ResumeLayout(false);
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
        private TableLayoutPanel tlNamePanelEditItem;
        private TableLayoutPanel tlFirstPanelEditItem;
        private TableLayoutPanel tlSecondPanelEditItem;
        private TableLayoutPanel tlPanelButtonEditItem;
    }
}
