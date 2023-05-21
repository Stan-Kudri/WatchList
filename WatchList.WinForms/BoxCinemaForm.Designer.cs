using WatchList.WinForms.BindingItem.ModelBoxForm;

namespace WatchList.WinForms
{
    partial class BoxCinemaForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cinemaBindingSource = new BindingSource(components);
            openFileDialog = new OpenFileDialog();
            dgvCinema = new DataGridView();
            NameCinema = new DataGridViewTextBoxColumn();
            NumberCinema = new DataGridViewTextBoxColumn();
            WatchedCinema = new DataGridViewTextBoxColumn();
            DataWatchedCinema = new DataGridViewTextBoxColumn();
            GradeCinema = new DataGridViewTextBoxColumn();
            IdCinema = new DataGridViewTextBoxColumn();
            Cinema = new DataGridViewTextBoxColumn();
            btnAddCinema = new MaterialSkin.Controls.MaterialButton();
            btnEditCinema = new MaterialSkin.Controls.MaterialButton();
            btnDeleteMovie = new MaterialSkin.Controls.MaterialButton();
            btnReplaceData = new MaterialSkin.Controls.MaterialButton();
            btnUseFilter = new MaterialSkin.Controls.MaterialButton();
            btnClearFilter = new MaterialSkin.Controls.MaterialButton();
            cmbFilterType = new MaterialSkin.Controls.MaterialComboBox();
            filterModelBindingSource = new BindingSource(components);
            cmbFilterStatus = new MaterialSkin.Controls.MaterialComboBox();
            cmbPageSize = new ComboBox();
            pageModelBindingSource = new BindingSource(components);
            btnBackPage = new MaterialSkin.Controls.MaterialButton();
            btnNextPage = new MaterialSkin.Controls.MaterialButton();
            btnStartPage = new MaterialSkin.Controls.MaterialButton();
            btnEndPage = new MaterialSkin.Controls.MaterialButton();
            textBoxPage = new TextBox();
            labelTotalPage = new MaterialSkin.Controls.MaterialLabel();
            labelTextSizePage = new MaterialSkin.Controls.MaterialLabel();
            labelSortType = new MaterialSkin.Controls.MaterialLabel();
            cmbSortType = new ComboBox();
            sortModelBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)cinemaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCinema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filterModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pageModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sortModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "ReplaceDataFromFile ";
            // 
            // dgvCinema
            // 
            dgvCinema.AllowUserToAddRows = false;
            dgvCinema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCinema.Columns.AddRange(new DataGridViewColumn[] { NameCinema, NumberCinema, WatchedCinema, DataWatchedCinema, GradeCinema, IdCinema, Cinema });
            dgvCinema.Location = new Point(5, 120);
            dgvCinema.MaximumSize = new Size(630, 240);
            dgvCinema.MinimumSize = new Size(630, 240);
            dgvCinema.Name = "dgvCinema";
            dgvCinema.ReadOnly = true;
            dgvCinema.RowTemplate.Height = 25;
            dgvCinema.Size = new Size(630, 240);
            dgvCinema.TabIndex = 16;
            dgvCinema.Tag = "Cinema";
            // 
            // NameCinema
            // 
            NameCinema.FillWeight = 160F;
            NameCinema.HeaderText = "Title";
            NameCinema.Name = "NameCinema";
            NameCinema.ReadOnly = true;
            NameCinema.SortMode = DataGridViewColumnSortMode.Programmatic;
            NameCinema.Width = 160;
            // 
            // NumberCinema
            // 
            NumberCinema.FillWeight = 80F;
            NumberCinema.HeaderText = "Season/Part";
            NumberCinema.Name = "NumberCinema";
            NumberCinema.ReadOnly = true;
            NumberCinema.SortMode = DataGridViewColumnSortMode.Programmatic;
            NumberCinema.Width = 80;
            // 
            // WatchedCinema
            // 
            WatchedCinema.FillWeight = 106F;
            WatchedCinema.HeaderText = "Status";
            WatchedCinema.Name = "WatchedCinema";
            WatchedCinema.ReadOnly = true;
            WatchedCinema.SortMode = DataGridViewColumnSortMode.Programmatic;
            WatchedCinema.Width = 106;
            // 
            // DataWatchedCinema
            // 
            DataWatchedCinema.HeaderText = "Data";
            DataWatchedCinema.Name = "DataWatchedCinema";
            DataWatchedCinema.ReadOnly = true;
            DataWatchedCinema.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // GradeCinema
            // 
            GradeCinema.FillWeight = 50F;
            GradeCinema.HeaderText = "Grade";
            GradeCinema.Name = "GradeCinema";
            GradeCinema.ReadOnly = true;
            GradeCinema.SortMode = DataGridViewColumnSortMode.Programmatic;
            GradeCinema.Width = 50;
            // 
            // IdCinema
            // 
            IdCinema.HeaderText = "ID";
            IdCinema.Name = "IdCinema";
            IdCinema.ReadOnly = true;
            IdCinema.Visible = false;
            // 
            // Cinema
            // 
            Cinema.HeaderText = "Type";
            Cinema.Name = "Cinema";
            Cinema.ReadOnly = true;
            Cinema.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // btnAddCinema
            // 
            btnAddCinema.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddCinema.Depth = 0;
            btnAddCinema.HighEmphasis = true;
            btnAddCinema.Icon = null;
            btnAddCinema.Location = new Point(5, 395);
            btnAddCinema.Margin = new Padding(4, 6, 4, 6);
            btnAddCinema.MaximumSize = new Size(150, 20);
            btnAddCinema.MinimumSize = new Size(150, 20);
            btnAddCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddCinema.Name = "btnAddCinema";
            btnAddCinema.NoAccentTextColor = Color.Empty;
            btnAddCinema.Size = new Size(150, 20);
            btnAddCinema.TabIndex = 32;
            btnAddCinema.Text = "Add Cinema";
            btnAddCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddCinema.UseAccentColor = false;
            btnAddCinema.UseVisualStyleBackColor = true;
            btnAddCinema.Click += BtnAddCinema_Click;
            // 
            // btnEditCinema
            // 
            btnEditCinema.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditCinema.Depth = 0;
            btnEditCinema.HighEmphasis = true;
            btnEditCinema.Icon = null;
            btnEditCinema.Location = new Point(165, 395);
            btnEditCinema.Margin = new Padding(4, 6, 4, 6);
            btnEditCinema.MaximumSize = new Size(150, 20);
            btnEditCinema.MinimumSize = new Size(150, 20);
            btnEditCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditCinema.Name = "btnEditCinema";
            btnEditCinema.NoAccentTextColor = Color.Empty;
            btnEditCinema.Size = new Size(150, 20);
            btnEditCinema.TabIndex = 36;
            btnEditCinema.Text = "Edit";
            btnEditCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEditCinema.UseAccentColor = false;
            btnEditCinema.UseVisualStyleBackColor = true;
            btnEditCinema.Click += BtnEditRow_Click;
            // 
            // btnDeleteMovie
            // 
            btnDeleteMovie.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDeleteMovie.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDeleteMovie.Depth = 0;
            btnDeleteMovie.HighEmphasis = true;
            btnDeleteMovie.Icon = null;
            btnDeleteMovie.Location = new Point(325, 395);
            btnDeleteMovie.Margin = new Padding(4, 6, 4, 6);
            btnDeleteMovie.MaximumSize = new Size(150, 20);
            btnDeleteMovie.MinimumSize = new Size(150, 20);
            btnDeleteMovie.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteMovie.Name = "btnDeleteMovie";
            btnDeleteMovie.NoAccentTextColor = Color.Empty;
            btnDeleteMovie.Size = new Size(150, 20);
            btnDeleteMovie.TabIndex = 37;
            btnDeleteMovie.Text = "Delete";
            btnDeleteMovie.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDeleteMovie.UseAccentColor = false;
            btnDeleteMovie.UseVisualStyleBackColor = true;
            btnDeleteMovie.Click += BtnDeleteMovie_Click;
            // 
            // btnReplaceData
            // 
            btnReplaceData.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnReplaceData.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnReplaceData.Depth = 0;
            btnReplaceData.HighEmphasis = true;
            btnReplaceData.Icon = null;
            btnReplaceData.Location = new Point(485, 395);
            btnReplaceData.Margin = new Padding(4, 6, 4, 6);
            btnReplaceData.MaximumSize = new Size(150, 20);
            btnReplaceData.MinimumSize = new Size(150, 20);
            btnReplaceData.MouseState = MaterialSkin.MouseState.HOVER;
            btnReplaceData.Name = "btnReplaceData";
            btnReplaceData.NoAccentTextColor = Color.Empty;
            btnReplaceData.Size = new Size(150, 20);
            btnReplaceData.TabIndex = 38;
            btnReplaceData.Text = "Replace data";
            btnReplaceData.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnReplaceData.UseAccentColor = false;
            btnReplaceData.UseVisualStyleBackColor = true;
            btnReplaceData.Click += BtnReplaceFile_Click;
            // 
            // btnUseFilter
            // 
            btnUseFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUseFilter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUseFilter.Depth = 0;
            btnUseFilter.HighEmphasis = true;
            btnUseFilter.Icon = null;
            btnUseFilter.Location = new Point(495, 95);
            btnUseFilter.Margin = new Padding(4, 6, 4, 6);
            btnUseFilter.MaximumSize = new Size(140, 20);
            btnUseFilter.MinimumSize = new Size(140, 20);
            btnUseFilter.MouseState = MaterialSkin.MouseState.HOVER;
            btnUseFilter.Name = "btnUseFilter";
            btnUseFilter.NoAccentTextColor = Color.Empty;
            btnUseFilter.Size = new Size(140, 20);
            btnUseFilter.TabIndex = 39;
            btnUseFilter.Text = "Use Filter";
            btnUseFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUseFilter.UseAccentColor = false;
            btnUseFilter.UseVisualStyleBackColor = true;
            btnUseFilter.Click += BtnUseFilter_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClearFilter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClearFilter.Depth = 0;
            btnClearFilter.HighEmphasis = true;
            btnClearFilter.Icon = null;
            btnClearFilter.Location = new Point(495, 70);
            btnClearFilter.Margin = new Padding(4, 6, 4, 6);
            btnClearFilter.MaximumSize = new Size(140, 20);
            btnClearFilter.MinimumSize = new Size(140, 20);
            btnClearFilter.MouseState = MaterialSkin.MouseState.HOVER;
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.NoAccentTextColor = Color.Empty;
            btnClearFilter.Size = new Size(140, 20);
            btnClearFilter.TabIndex = 40;
            btnClearFilter.Text = "Clear Filter";
            btnClearFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClearFilter.UseAccentColor = false;
            btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Click += BtnCancelFilter_Click;
            // 
            // cmbFilterType
            // 
            cmbFilterType.AutoResize = false;
            cmbFilterType.BackColor = Color.FromArgb(255, 255, 255);
            cmbFilterType.DataBindings.Add(new Binding("SelectedValue", filterModelBindingSource, "Type", true));
            cmbFilterType.DataBindings.Add(new Binding("DataSource", filterModelBindingSource, "TypeItem", true));
            cmbFilterType.Depth = 0;
            cmbFilterType.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFilterType.DropDownHeight = 174;
            cmbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterType.DropDownWidth = 121;
            cmbFilterType.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbFilterType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbFilterType.FormattingEnabled = true;
            cmbFilterType.IntegralHeight = false;
            cmbFilterType.ItemHeight = 43;
            cmbFilterType.Location = new Point(5, 70);
            cmbFilterType.MaxDropDownItems = 4;
            cmbFilterType.MaximumSize = new Size(235, 0);
            cmbFilterType.MinimumSize = new Size(235, 0);
            cmbFilterType.MouseState = MaterialSkin.MouseState.OUT;
            cmbFilterType.Name = "cmbFilterType";
            cmbFilterType.Size = new Size(235, 49);
            cmbFilterType.StartIndex = 0;
            cmbFilterType.TabIndex = 41;
            // 
            // filterModelBindingSource
            // 
            filterModelBindingSource.DataSource = typeof(FilterModel);
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.AutoResize = false;
            cmbFilterStatus.BackColor = Color.FromArgb(255, 255, 255);
            cmbFilterStatus.DataBindings.Add(new Binding("SelectedValue", filterModelBindingSource, "Status", true));
            cmbFilterStatus.DataBindings.Add(new Binding("DataSource", filterModelBindingSource, "StatusItem", true));
            cmbFilterStatus.Depth = 0;
            cmbFilterStatus.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFilterStatus.DropDownHeight = 174;
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.DropDownWidth = 121;
            cmbFilterStatus.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cmbFilterStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbFilterStatus.IntegralHeight = false;
            cmbFilterStatus.ItemHeight = 43;
            cmbFilterStatus.Location = new Point(250, 70);
            cmbFilterStatus.MaxDropDownItems = 4;
            cmbFilterStatus.MaximumSize = new Size(235, 0);
            cmbFilterStatus.MinimumSize = new Size(235, 0);
            cmbFilterStatus.MouseState = MaterialSkin.MouseState.OUT;
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(235, 49);
            cmbFilterStatus.StartIndex = 0;
            cmbFilterStatus.TabIndex = 42;
            // 
            // cmbPageSize
            // 
            cmbPageSize.DataBindings.Add(new Binding("SelectedValue", pageModelBindingSource, "Size", true));
            cmbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPageSize.FormattingEnabled = true;
            cmbPageSize.Location = new Point(115, 365);
            cmbPageSize.Name = "cmbPageSize";
            cmbPageSize.Size = new Size(120, 23);
            cmbPageSize.TabIndex = 43;
            cmbPageSize.SelectedIndexChanged += CmbPageSize_Changed;
            // 
            // pageModelBindingSource
            // 
            pageModelBindingSource.DataSource = typeof(PageModel);
            // 
            // btnBackPage
            // 
            btnBackPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBackPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBackPage.Depth = 0;
            btnBackPage.HighEmphasis = true;
            btnBackPage.Icon = null;
            btnBackPage.Location = new Point(270, 366);
            btnBackPage.Margin = new Padding(4, 6, 4, 6);
            btnBackPage.MaximumSize = new Size(20, 20);
            btnBackPage.MinimumSize = new Size(20, 20);
            btnBackPage.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackPage.Name = "btnBackPage";
            btnBackPage.NoAccentTextColor = Color.Empty;
            btnBackPage.Size = new Size(20, 20);
            btnBackPage.TabIndex = 44;
            btnBackPage.Text = "<";
            btnBackPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBackPage.UseAccentColor = false;
            btnBackPage.UseVisualStyleBackColor = true;
            btnBackPage.Click += BtnBackPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNextPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNextPage.Depth = 0;
            btnNextPage.HighEmphasis = true;
            btnNextPage.Icon = null;
            btnNextPage.Location = new Point(370, 366);
            btnNextPage.Margin = new Padding(4, 6, 4, 6);
            btnNextPage.MaximumSize = new Size(20, 20);
            btnNextPage.MinimumSize = new Size(20, 20);
            btnNextPage.MouseState = MaterialSkin.MouseState.HOVER;
            btnNextPage.Name = "btnNextPage";
            btnNextPage.NoAccentTextColor = Color.Empty;
            btnNextPage.Size = new Size(20, 20);
            btnNextPage.TabIndex = 45;
            btnNextPage.Text = ">";
            btnNextPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNextPage.UseAccentColor = false;
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += BtnNextPage_Click;
            // 
            // btnStartPage
            // 
            btnStartPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnStartPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnStartPage.Depth = 0;
            btnStartPage.HighEmphasis = true;
            btnStartPage.Icon = null;
            btnStartPage.Location = new Point(245, 366);
            btnStartPage.Margin = new Padding(4, 6, 4, 6);
            btnStartPage.MaximumSize = new Size(20, 20);
            btnStartPage.MinimumSize = new Size(20, 20);
            btnStartPage.MouseState = MaterialSkin.MouseState.HOVER;
            btnStartPage.Name = "btnStartPage";
            btnStartPage.NoAccentTextColor = Color.Empty;
            btnStartPage.Size = new Size(20, 20);
            btnStartPage.TabIndex = 49;
            btnStartPage.Text = "<<";
            btnStartPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStartPage.UseAccentColor = false;
            btnStartPage.UseVisualStyleBackColor = true;
            btnStartPage.Click += BtnStartPage_Click;
            // 
            // btnEndPage
            // 
            btnEndPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEndPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEndPage.Depth = 0;
            btnEndPage.HighEmphasis = true;
            btnEndPage.Icon = null;
            btnEndPage.Location = new Point(395, 366);
            btnEndPage.Margin = new Padding(4, 6, 4, 6);
            btnEndPage.MaximumSize = new Size(20, 20);
            btnEndPage.MinimumSize = new Size(20, 20);
            btnEndPage.MouseState = MaterialSkin.MouseState.HOVER;
            btnEndPage.Name = "btnEndPage";
            btnEndPage.NoAccentTextColor = Color.Empty;
            btnEndPage.Size = new Size(20, 20);
            btnEndPage.TabIndex = 50;
            btnEndPage.Text = ">>";
            btnEndPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnEndPage.UseAccentColor = false;
            btnEndPage.UseVisualStyleBackColor = true;
            btnEndPage.Click += BtnEndPage_Click;
            // 
            // textBoxPage
            // 
            textBoxPage.DataBindings.Add(new Binding("Text", pageModelBindingSource, "Number", true));
            textBoxPage.Location = new Point(295, 366);
            textBoxPage.MaximumSize = new Size(40, 20);
            textBoxPage.MinimumSize = new Size(40, 20);
            textBoxPage.Name = "textBoxPage";
            textBoxPage.Size = new Size(40, 20);
            textBoxPage.TabIndex = 51;
            textBoxPage.TextChanged += TextBoxPage_TextChanged;
            // 
            // labelTotalPage
            // 
            labelTotalPage.AutoSize = true;
            labelTotalPage.Depth = 0;
            labelTotalPage.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelTotalPage.Location = new Point(341, 366);
            labelTotalPage.MouseState = MaterialSkin.MouseState.HOVER;
            labelTotalPage.Name = "labelTotalPage";
            labelTotalPage.Size = new Size(17, 19);
            labelTotalPage.TabIndex = 52;
            labelTotalPage.Text = "/1";
            // 
            // labelTextSizePage
            // 
            labelTextSizePage.AutoSize = true;
            labelTextSizePage.BackColor = SystemColors.Control;
            labelTextSizePage.Depth = 0;
            labelTextSizePage.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelTextSizePage.Location = new Point(6, 367);
            labelTextSizePage.MouseState = MaterialSkin.MouseState.HOVER;
            labelTextSizePage.Name = "labelTextSizePage";
            labelTextSizePage.Size = new Size(102, 19);
            labelTextSizePage.TabIndex = 53;
            labelTextSizePage.Text = "Show on page";
            // 
            // labelSortType
            // 
            labelSortType.AutoSize = true;
            labelSortType.BackColor = SystemColors.Control;
            labelSortType.Depth = 0;
            labelSortType.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelSortType.Location = new Point(422, 367);
            labelSortType.MouseState = MaterialSkin.MouseState.HOVER;
            labelSortType.Name = "labelSortType";
            labelSortType.Size = new Size(51, 19);
            labelSortType.TabIndex = 54;
            labelSortType.Text = "Sort by";
            // 
            // cmbSortType
            // 
            cmbSortType.DataBindings.Add(new Binding("SelectedValue", sortModelBindingSource, "Type", true));
            cmbSortType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortType.FormattingEnabled = true;
            cmbSortType.Location = new Point(480, 365);
            cmbSortType.Name = "cmbSortType";
            cmbSortType.Size = new Size(155, 23);
            cmbSortType.TabIndex = 55;
            cmbSortType.SelectedIndexChanged += CmbSort_ChangedItem;
            // 
            // sortModelBindingSource
            // 
            sortModelBindingSource.DataSource = typeof(SortModel);
            // 
            // BoxCinemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(650, 425);
            Controls.Add(cmbSortType);
            Controls.Add(labelSortType);
            Controls.Add(labelTextSizePage);
            Controls.Add(labelTotalPage);
            Controls.Add(textBoxPage);
            Controls.Add(btnEndPage);
            Controls.Add(btnStartPage);
            Controls.Add(btnNextPage);
            Controls.Add(btnBackPage);
            Controls.Add(cmbPageSize);
            Controls.Add(cmbFilterStatus);
            Controls.Add(cmbFilterType);
            Controls.Add(btnClearFilter);
            Controls.Add(btnUseFilter);
            Controls.Add(btnReplaceData);
            Controls.Add(btnDeleteMovie);
            Controls.Add(btnEditCinema);
            Controls.Add(btnAddCinema);
            Controls.Add(dgvCinema);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(650, 425);
            MinimumSize = new Size(650, 425);
            Name = "BoxCinemaForm";
            Text = "BoxCinema";
            ((System.ComponentModel.ISupportInitialize)cinemaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCinema).EndInit();
            ((System.ComponentModel.ISupportInitialize)filterModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pageModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)sortModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource cinemaBindingSource;
        private OpenFileDialog openFileDialog;
        private DataGridView dgvCinema;
        private MaterialSkin.Controls.MaterialButton btnAddCinema;
        private MaterialSkin.Controls.MaterialButton btnEditCinema;
        private MaterialSkin.Controls.MaterialButton btnDeleteMovie;
        private MaterialSkin.Controls.MaterialButton btnReplaceData;
        private MaterialSkin.Controls.MaterialButton btnUseFilter;
        private MaterialSkin.Controls.MaterialButton btnClearFilter;
        private MaterialSkin.Controls.MaterialComboBox cmbFilterType;
        private MaterialSkin.Controls.MaterialComboBox cmbFilterStatus;
        private ComboBox cmbPageSize;
        private MaterialSkin.Controls.MaterialButton btnBackPage;
        private MaterialSkin.Controls.MaterialButton btnNextPage;
        private MaterialSkin.Controls.MaterialButton btnStartPage;
        private MaterialSkin.Controls.MaterialButton btnEndPage;
        private TextBox textBoxPage;
        private MaterialSkin.Controls.MaterialLabel labelTotalPage;
        private BindingSource pageModelBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelTextSizePage;
        private MaterialSkin.Controls.MaterialLabel labelSortType;
        private ComboBox cmbSortType;
        private DataGridViewTextBoxColumn NameCinema;
        private DataGridViewTextBoxColumn NumberCinema;
        private DataGridViewTextBoxColumn WatchedCinema;
        private DataGridViewTextBoxColumn DataWatchedCinema;
        private DataGridViewTextBoxColumn GradeCinema;
        private DataGridViewTextBoxColumn IdCinema;
        private DataGridViewTextBoxColumn Cinema;
        private BindingSource filterModelBindingSource;
        private BindingSource sortModelBindingSource;
    }
}
