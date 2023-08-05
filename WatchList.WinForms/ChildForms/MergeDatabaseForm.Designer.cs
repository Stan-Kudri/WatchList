namespace WatchList.WinForms.ChildForms
{
    partial class MergeDatabaseForm
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
            cbExistGrade = new MaterialSkin.Controls.MaterialCheckbox();
            btnOk = new MaterialSkin.Controls.MaterialButton();
            btnCancel = new MaterialSkin.Controls.MaterialButton();
            btnClear = new MaterialSkin.Controls.MaterialButton();
            cmbTypeCinema = new MaterialSkin.Controls.MaterialComboBox();
            typeUploadBindingSource = new BindingSource(components);
            labelTypeCinemaLoad = new MaterialSkin.Controls.MaterialLabel();
            moreGradeBindingSource = new BindingSource(components);
            cmbGrade = new MaterialSkin.Controls.MaterialComboBox();
            labelScoreMore = new MaterialSkin.Controls.MaterialLabel();
            cbConsiderDuplicates = new MaterialSkin.Controls.MaterialCheckbox();
            clbActionsWithDuplicates = new MaterialSkin.Controls.MaterialCheckedListBox();
            tlFirstPanelLoadingData = new TableLayoutPanel();
            tlButtonPanelLoadingData = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)typeUploadBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)moreGradeBindingSource).BeginInit();
            tlFirstPanelLoadingData.SuspendLayout();
            tlButtonPanelLoadingData.SuspendLayout();
            SuspendLayout();
            // 
            // cbExistGrade
            // 
            cbExistGrade.AutoSize = true;
            cbExistGrade.Depth = 0;
            cbExistGrade.Location = new Point(10, 70);
            cbExistGrade.Margin = new Padding(0);
            cbExistGrade.MouseLocation = new Point(-1, -1);
            cbExistGrade.MouseState = MaterialSkin.MouseState.HOVER;
            cbExistGrade.Name = "cbExistGrade";
            cbExistGrade.ReadOnly = false;
            cbExistGrade.Ripple = true;
            cbExistGrade.Size = new Size(391, 37);
            cbExistGrade.TabIndex = 0;
            cbExistGrade.Text = "Delete existing grade (Set Status \"Planned Watch\")";
            cbExistGrade.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOk.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOk.Depth = 0;
            btnOk.Dock = DockStyle.Fill;
            btnOk.HighEmphasis = true;
            btnOk.Icon = null;
            btnOk.Location = new Point(4, 6);
            btnOk.Margin = new Padding(4, 6, 20, 6);
            btnOk.MinimumSize = new Size(100, 36);
            btnOk.MouseState = MaterialSkin.MouseState.HOVER;
            btnOk.Name = "btnOk";
            btnOk.NoAccentTextColor = Color.Empty;
            btnOk.Size = new Size(120, 38);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOk.UseAccentColor = false;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancel.Depth = 0;
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.HighEmphasis = true;
            btnCancel.Icon = null;
            btnCancel.Location = new Point(308, 6);
            btnCancel.Margin = new Padding(20, 6, 4, 6);
            btnCancel.MinimumSize = new Size(100, 36);
            btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancel.Name = "btnCancel";
            btnCancel.NoAccentTextColor = Color.Empty;
            btnCancel.Size = new Size(123, 38);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancel.UseAccentColor = false;
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClear.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClear.Depth = 0;
            btnClear.Dock = DockStyle.Fill;
            btnClear.HighEmphasis = true;
            btnClear.Icon = null;
            btnClear.Location = new Point(154, 6);
            btnClear.Margin = new Padding(10, 6, 10, 6);
            btnClear.MinimumSize = new Size(100, 36);
            btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            btnClear.Name = "btnClear";
            btnClear.NoAccentTextColor = Color.Empty;
            btnClear.Size = new Size(124, 38);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClear.UseAccentColor = false;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // cmbTypeCinema
            // 
            cmbTypeCinema.AutoResize = false;
            cmbTypeCinema.BackColor = Color.FromArgb(255, 255, 255);
            cmbTypeCinema.DataBindings.Add(new Binding("SelectedValue", typeUploadBindingSource, "SelectedValue", true));
            cmbTypeCinema.DataBindings.Add(new Binding("DataSource", typeUploadBindingSource, "Items", true));
            cmbTypeCinema.Depth = 0;
            cmbTypeCinema.Dock = DockStyle.Fill;
            cmbTypeCinema.DrawMode = DrawMode.OwnerDrawVariable;
            cmbTypeCinema.DropDownHeight = 174;
            cmbTypeCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeCinema.DropDownWidth = 110;
            cmbTypeCinema.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            cmbTypeCinema.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTypeCinema.FormattingEnabled = true;
            cmbTypeCinema.IntegralHeight = false;
            cmbTypeCinema.ItemHeight = 43;
            cmbTypeCinema.Location = new Point(3, 3);
            cmbTypeCinema.MaxDropDownItems = 4;
            cmbTypeCinema.MinimumSize = new Size(100, 0);
            cmbTypeCinema.MouseState = MaterialSkin.MouseState.OUT;
            cmbTypeCinema.Name = "cmbTypeCinema";
            cmbTypeCinema.Size = new Size(100, 49);
            cmbTypeCinema.StartIndex = 0;
            cmbTypeCinema.TabIndex = 4;
            // 
            // typeUploadBindingSource
            // 
            typeUploadBindingSource.DataSource = typeof(BindingItem.ModelDataLoad.ModelTypeCinemaUpload);
            // 
            // labelTypeCinemaLoad
            // 
            labelTypeCinemaLoad.AutoSize = true;
            labelTypeCinemaLoad.Depth = 0;
            labelTypeCinemaLoad.Dock = DockStyle.Fill;
            labelTypeCinemaLoad.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelTypeCinemaLoad.Location = new Point(108, 3);
            labelTypeCinemaLoad.Margin = new Padding(3);
            labelTypeCinemaLoad.MouseState = MaterialSkin.MouseState.HOVER;
            labelTypeCinemaLoad.Name = "labelTypeCinemaLoad";
            labelTypeCinemaLoad.Size = new Size(39, 45);
            labelTypeCinemaLoad.TabIndex = 5;
            labelTypeCinemaLoad.Text = "Type";
            labelTypeCinemaLoad.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // moreGradeBindingSource
            // 
            moreGradeBindingSource.DataSource = typeof(BindingItem.ModelDataLoad.ModelDownloadMoreGrade);
            // 
            // cmbGrade
            // 
            cmbGrade.AutoResize = false;
            cmbGrade.BackColor = Color.FromArgb(255, 255, 255);
            cmbGrade.DataBindings.Add(new Binding("SelectedValue", moreGradeBindingSource, "Value", true));
            cmbGrade.DataBindings.Add(new Binding("DataSource", moreGradeBindingSource, "Items", true));
            cmbGrade.Depth = 0;
            cmbGrade.Dock = DockStyle.Fill;
            cmbGrade.DrawMode = DrawMode.OwnerDrawVariable;
            cmbGrade.DropDownHeight = 174;
            cmbGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrade.DropDownWidth = 121;
            cmbGrade.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbGrade.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbGrade.FormattingEnabled = true;
            cmbGrade.IntegralHeight = false;
            cmbGrade.ItemHeight = 43;
            cmbGrade.Location = new Point(153, 3);
            cmbGrade.MaxDropDownItems = 4;
            cmbGrade.MinimumSize = new Size(170, 0);
            cmbGrade.MouseState = MaterialSkin.MouseState.OUT;
            cmbGrade.Name = "cmbGrade";
            cmbGrade.Size = new Size(189, 49);
            cmbGrade.StartIndex = 0;
            cmbGrade.TabIndex = 6;
            // 
            // labelScoreMore
            // 
            labelScoreMore.AutoSize = true;
            labelScoreMore.Depth = 0;
            labelScoreMore.Dock = DockStyle.Fill;
            labelScoreMore.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelScoreMore.Location = new Point(348, 3);
            labelScoreMore.Margin = new Padding(3);
            labelScoreMore.MouseState = MaterialSkin.MouseState.HOVER;
            labelScoreMore.Name = "labelScoreMore";
            labelScoreMore.Size = new Size(84, 45);
            labelScoreMore.TabIndex = 7;
            labelScoreMore.Text = "Score more";
            labelScoreMore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbConsiderDuplicates
            // 
            cbConsiderDuplicates.AutoSize = true;
            cbConsiderDuplicates.Depth = 0;
            cbConsiderDuplicates.Location = new Point(10, 107);
            cbConsiderDuplicates.Margin = new Padding(0);
            cbConsiderDuplicates.MouseLocation = new Point(-1, -1);
            cbConsiderDuplicates.MouseState = MaterialSkin.MouseState.HOVER;
            cbConsiderDuplicates.Name = "cbConsiderDuplicates";
            cbConsiderDuplicates.ReadOnly = false;
            cbConsiderDuplicates.Ripple = true;
            cbConsiderDuplicates.Size = new Size(174, 37);
            cbConsiderDuplicates.TabIndex = 9;
            cbConsiderDuplicates.Text = "Consider duplicates";
            cbConsiderDuplicates.UseVisualStyleBackColor = true;
            cbConsiderDuplicates.CheckedChanged += CbConsiderDuplicates_CheckedChanged;
            // 
            // clbActionsWithDuplicates
            // 
            clbActionsWithDuplicates.AutoScroll = true;
            clbActionsWithDuplicates.BackColor = SystemColors.Control;
            clbActionsWithDuplicates.Depth = 0;
            clbActionsWithDuplicates.Enabled = false;
            clbActionsWithDuplicates.Location = new Point(187, 107);
            clbActionsWithDuplicates.MouseState = MaterialSkin.MouseState.HOVER;
            clbActionsWithDuplicates.Name = "clbActionsWithDuplicates";
            clbActionsWithDuplicates.Size = new Size(234, 80);
            clbActionsWithDuplicates.Striped = false;
            clbActionsWithDuplicates.StripeDarkColor = Color.Empty;
            clbActionsWithDuplicates.TabIndex = 10;
            // 
            // tlFirstPanelLoadingData
            // 
            tlFirstPanelLoadingData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlFirstPanelLoadingData.ColumnCount = 4;
            tlFirstPanelLoadingData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlFirstPanelLoadingData.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
            tlFirstPanelLoadingData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tlFirstPanelLoadingData.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlFirstPanelLoadingData.Controls.Add(labelScoreMore, 3, 0);
            tlFirstPanelLoadingData.Controls.Add(cmbTypeCinema, 0, 0);
            tlFirstPanelLoadingData.Controls.Add(labelTypeCinemaLoad, 1, 0);
            tlFirstPanelLoadingData.Controls.Add(cmbGrade, 2, 0);
            tlFirstPanelLoadingData.Location = new Point(9, 190);
            tlFirstPanelLoadingData.MinimumSize = new Size(435, 51);
            tlFirstPanelLoadingData.Name = "tlFirstPanelLoadingData";
            tlFirstPanelLoadingData.RowCount = 1;
            tlFirstPanelLoadingData.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlFirstPanelLoadingData.Size = new Size(435, 51);
            tlFirstPanelLoadingData.TabIndex = 11;
            // 
            // tlButtonPanelLoadingData
            // 
            tlButtonPanelLoadingData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlButtonPanelLoadingData.ColumnCount = 3;
            tlButtonPanelLoadingData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlButtonPanelLoadingData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlButtonPanelLoadingData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlButtonPanelLoadingData.Controls.Add(btnOk, 0, 0);
            tlButtonPanelLoadingData.Controls.Add(btnClear, 1, 0);
            tlButtonPanelLoadingData.Controls.Add(btnCancel, 2, 0);
            tlButtonPanelLoadingData.Location = new Point(9, 245);
            tlButtonPanelLoadingData.Name = "tlButtonPanelLoadingData";
            tlButtonPanelLoadingData.RowCount = 1;
            tlButtonPanelLoadingData.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlButtonPanelLoadingData.Size = new Size(435, 50);
            tlButtonPanelLoadingData.TabIndex = 12;
            // 
            // MergeDatabaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(450, 300);
            Controls.Add(tlButtonPanelLoadingData);
            Controls.Add(tlFirstPanelLoadingData);
            Controls.Add(clbActionsWithDuplicates);
            Controls.Add(cbConsiderDuplicates);
            Controls.Add(cbExistGrade);
            MinimumSize = new Size(450, 300);
            Name = "MergeDatabaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading data";
            Load += DatabaseForm_Load;
            ((System.ComponentModel.ISupportInitialize)typeUploadBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)moreGradeBindingSource).EndInit();
            tlFirstPanelLoadingData.ResumeLayout(false);
            tlFirstPanelLoadingData.PerformLayout();
            tlButtonPanelLoadingData.ResumeLayout(false);
            tlButtonPanelLoadingData.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox cbExistGrade;
        private MaterialSkin.Controls.MaterialButton btnOk;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialComboBox cmbTypeCinema;
        private BindingSource typeUploadBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelTypeCinemaLoad;
        private BindingSource moreGradeBindingSource;
        private MaterialSkin.Controls.MaterialComboBox cmbGrade;
        private MaterialSkin.Controls.MaterialLabel labelScoreMore;
        private MaterialSkin.Controls.MaterialCheckbox cbConsiderDuplicates;
        private MaterialSkin.Controls.MaterialCheckedListBox clbActionsWithDuplicates;
        private TableLayoutPanel tlFirstPanelLoadingData;
        private TableLayoutPanel tlButtonPanelLoadingData;
    }
}
