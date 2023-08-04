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
            var dataGridViewCellStyle1 = new DataGridViewCellStyle();
            var dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            btnAddData = new MaterialSkin.Controls.MaterialButton();
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
            tlPanelActionsWithElements = new TableLayoutPanel();
            tlPanelPage = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)cinemaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCinema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filterModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pageModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sortModelBindingSource).BeginInit();
            tlPanelActionsWithElements.SuspendLayout();
            tlPanelPage.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "ReplaceDataFromFile ";
            // 
            // dgvCinema
            // 
            dgvCinema.AllowUserToAddRows = false;
            dgvCinema.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCinema.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCinema.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCinema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCinema.Columns.AddRange(new DataGridViewColumn[] { NameCinema, NumberCinema, WatchedCinema, DataWatchedCinema, GradeCinema, IdCinema, Cinema });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCinema.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCinema.Location = new Point(5, 120);
            dgvCinema.MinimumSize = new Size(665, 240);
            dgvCinema.Name = "dgvCinema";
            dgvCinema.ReadOnly = true;
            dgvCinema.RowTemplate.Height = 25;
            dgvCinema.Size = new Size(665, 240);
            dgvCinema.TabIndex = 16;
            dgvCinema.Tag = "Cinema";
            // 
            // NameCinema
            // 
            NameCinema.FillWeight = 180F;
            NameCinema.HeaderText = "Title";
            NameCinema.Name = "NameCinema";
            NameCinema.ReadOnly = true;
            NameCinema.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // NumberCinema
            // 
            NumberCinema.FillWeight = 80F;
            NumberCinema.HeaderText = "Season/Part";
            NumberCinema.Name = "NumberCinema";
            NumberCinema.ReadOnly = true;
            NumberCinema.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // WatchedCinema
            // 
            WatchedCinema.HeaderText = "Status";
            WatchedCinema.Name = "WatchedCinema";
            WatchedCinema.ReadOnly = true;
            WatchedCinema.SortMode = DataGridViewColumnSortMode.Programmatic;
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
            GradeCinema.FillWeight = 55F;
            GradeCinema.HeaderText = "Grade";
            GradeCinema.Name = "GradeCinema";
            GradeCinema.ReadOnly = true;
            GradeCinema.SortMode = DataGridViewColumnSortMode.Programmatic;
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
            Cinema.FillWeight = 90F;
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
            btnAddCinema.Dock = DockStyle.Fill;
            btnAddCinema.HighEmphasis = true;
            btnAddCinema.Icon = null;
            btnAddCinema.Location = new Point(4, 6);
            btnAddCinema.Margin = new Padding(4, 6, 4, 6);
            btnAddCinema.MinimumSize = new Size(155, 20);
            btnAddCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddCinema.Name = "btnAddCinema";
            btnAddCinema.NoAccentTextColor = Color.Empty;
            btnAddCinema.Size = new Size(158, 20);
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
            btnEditCinema.Dock = DockStyle.Fill;
            btnEditCinema.HighEmphasis = true;
            btnEditCinema.Icon = null;
            btnEditCinema.Location = new Point(170, 6);
            btnEditCinema.Margin = new Padding(4, 6, 4, 6);
            btnEditCinema.MinimumSize = new Size(155, 20);
            btnEditCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditCinema.Name = "btnEditCinema";
            btnEditCinema.NoAccentTextColor = Color.Empty;
            btnEditCinema.Size = new Size(158, 20);
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
            btnDeleteMovie.Dock = DockStyle.Fill;
            btnDeleteMovie.HighEmphasis = true;
            btnDeleteMovie.Icon = null;
            btnDeleteMovie.Location = new Point(336, 6);
            btnDeleteMovie.Margin = new Padding(4, 6, 4, 6);
            btnDeleteMovie.MinimumSize = new Size(155, 20);
            btnDeleteMovie.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteMovie.Name = "btnDeleteMovie";
            btnDeleteMovie.NoAccentTextColor = Color.Empty;
            btnDeleteMovie.Size = new Size(158, 20);
            btnDeleteMovie.TabIndex = 37;
            btnDeleteMovie.Text = "Delete";
            btnDeleteMovie.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDeleteMovie.UseAccentColor = false;
            btnDeleteMovie.UseVisualStyleBackColor = true;
            btnDeleteMovie.Click += BtnDeleteMovie_Click;
            // 
            // btnAddData
            // 
            btnAddData.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAddData.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAddData.Depth = 0;
            btnAddData.Dock = DockStyle.Fill;
            btnAddData.HighEmphasis = true;
            btnAddData.Icon = null;
            btnAddData.Location = new Point(502, 6);
            btnAddData.Margin = new Padding(4, 6, 4, 6);
            btnAddData.MinimumSize = new Size(155, 20);
            btnAddData.MouseState = MaterialSkin.MouseState.HOVER;
            btnAddData.Name = "btnAddData";
            btnAddData.NoAccentTextColor = Color.Empty;
            btnAddData.Size = new Size(159, 20);
            btnAddData.TabIndex = 38;
            btnAddData.Text = "Add data";
            btnAddData.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAddData.UseAccentColor = false;
            btnAddData.UseVisualStyleBackColor = true;
            btnAddData.Click += BtnDownloadDataFile_Click;
            // 
            // btnUseFilter
            // 
            btnUseFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUseFilter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnUseFilter.Depth = 0;
            btnUseFilter.Dock = DockStyle.Fill;
            btnUseFilter.HighEmphasis = true;
            btnUseFilter.Icon = null;
            btnUseFilter.Location = new Point(4, 33);
            btnUseFilter.Margin = new Padding(4, 6, 4, 6);
            btnUseFilter.MinimumSize = new Size(155, 20);
            btnUseFilter.MouseState = MaterialSkin.MouseState.HOVER;
            btnUseFilter.Name = "btnUseFilter";
            btnUseFilter.NoAccentTextColor = Color.Empty;
            btnUseFilter.Size = new Size(155, 20);
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
            btnClearFilter.Dock = DockStyle.Fill;
            btnClearFilter.HighEmphasis = true;
            btnClearFilter.Icon = null;
            btnClearFilter.Location = new Point(4, 6);
            btnClearFilter.Margin = new Padding(4, 6, 4, 6);
            btnClearFilter.MinimumSize = new Size(155, 20);
            btnClearFilter.MouseState = MaterialSkin.MouseState.HOVER;
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.NoAccentTextColor = Color.Empty;
            btnClearFilter.Size = new Size(155, 20);
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
            cmbFilterType.MaximumSize = new Size(240, 0);
            cmbFilterType.MinimumSize = new Size(240, 0);
            cmbFilterType.MouseState = MaterialSkin.MouseState.OUT;
            cmbFilterType.Name = "cmbFilterType";
            cmbFilterType.Size = new Size(240, 49);
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
            cmbFilterStatus.Location = new Point(260, 70);
            cmbFilterStatus.MaxDropDownItems = 4;
            cmbFilterStatus.MaximumSize = new Size(240, 0);
            cmbFilterStatus.MinimumSize = new Size(240, 0);
            cmbFilterStatus.MouseState = MaterialSkin.MouseState.OUT;
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(240, 49);
            cmbFilterStatus.StartIndex = 0;
            cmbFilterStatus.TabIndex = 42;
            // 
            // cmbPageSize
            // 
            cmbPageSize.DataBindings.Add(new Binding("SelectedValue", pageModelBindingSource, "Size", true));
            cmbPageSize.Dock = DockStyle.Fill;
            cmbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPageSize.FormattingEnabled = true;
            cmbPageSize.Location = new Point(113, 3);
            cmbPageSize.Name = "cmbPageSize";
            cmbPageSize.Size = new Size(124, 23);
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
            btnBackPage.Dock = DockStyle.Fill;
            btnBackPage.HighEmphasis = true;
            btnBackPage.Icon = null;
            btnBackPage.Location = new Point(275, 6);
            btnBackPage.Margin = new Padding(4, 6, 4, 6);
            btnBackPage.MinimumSize = new Size(20, 20);
            btnBackPage.MouseState = MaterialSkin.MouseState.HOVER;
            btnBackPage.Name = "btnBackPage";
            btnBackPage.NoAccentTextColor = Color.Empty;
            btnBackPage.Size = new Size(23, 20);
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
            btnNextPage.Dock = DockStyle.Fill;
            btnNextPage.HighEmphasis = true;
            btnNextPage.Icon = null;
            btnNextPage.Location = new Point(377, 6);
            btnNextPage.Margin = new Padding(4, 6, 4, 6);
            btnNextPage.MinimumSize = new Size(20, 20);
            btnNextPage.MouseState = MaterialSkin.MouseState.HOVER;
            btnNextPage.Name = "btnNextPage";
            btnNextPage.NoAccentTextColor = Color.Empty;
            btnNextPage.Size = new Size(23, 20);
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
            btnStartPage.Dock = DockStyle.Fill;
            btnStartPage.HighEmphasis = true;
            btnStartPage.Icon = null;
            btnStartPage.Location = new Point(244, 6);
            btnStartPage.Margin = new Padding(4, 6, 4, 6);
            btnStartPage.MinimumSize = new Size(20, 20);
            btnStartPage.MouseState = MaterialSkin.MouseState.HOVER;
            btnStartPage.Name = "btnStartPage";
            btnStartPage.NoAccentTextColor = Color.Empty;
            btnStartPage.Size = new Size(23, 20);
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
            btnEndPage.Dock = DockStyle.Fill;
            btnEndPage.HighEmphasis = true;
            btnEndPage.Icon = null;
            btnEndPage.Location = new Point(408, 6);
            btnEndPage.Margin = new Padding(4, 6, 4, 6);
            btnEndPage.MinimumSize = new Size(20, 20);
            btnEndPage.MouseState = MaterialSkin.MouseState.HOVER;
            btnEndPage.Name = "btnEndPage";
            btnEndPage.NoAccentTextColor = Color.Empty;
            btnEndPage.Size = new Size(23, 20);
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
            textBoxPage.Dock = DockStyle.Fill;
            textBoxPage.Location = new Point(305, 3);
            textBoxPage.MinimumSize = new Size(40, 20);
            textBoxPage.Name = "textBoxPage";
            textBoxPage.Size = new Size(42, 23);
            textBoxPage.TabIndex = 51;
            textBoxPage.TextChanged += TextBoxPage_TextChanged;
            // 
            // labelTotalPage
            // 
            labelTotalPage.AutoSize = true;
            labelTotalPage.Depth = 0;
            labelTotalPage.Dock = DockStyle.Fill;
            labelTotalPage.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelTotalPage.Location = new Point(353, 0);
            labelTotalPage.MouseState = MaterialSkin.MouseState.HOVER;
            labelTotalPage.Name = "labelTotalPage";
            labelTotalPage.Size = new Size(17, 30);
            labelTotalPage.TabIndex = 52;
            labelTotalPage.Text = "/1";
            labelTotalPage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTextSizePage
            // 
            labelTextSizePage.AutoSize = true;
            labelTextSizePage.BackColor = SystemColors.Control;
            labelTextSizePage.Depth = 0;
            labelTextSizePage.Dock = DockStyle.Fill;
            labelTextSizePage.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelTextSizePage.Location = new Point(3, 0);
            labelTextSizePage.MouseState = MaterialSkin.MouseState.HOVER;
            labelTextSizePage.Name = "labelTextSizePage";
            labelTextSizePage.Size = new Size(104, 30);
            labelTextSizePage.TabIndex = 53;
            labelTextSizePage.Text = "Show on page";
            labelTextSizePage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelSortType
            // 
            labelSortType.AutoSize = true;
            labelSortType.BackColor = SystemColors.Control;
            labelSortType.Depth = 0;
            labelSortType.Dock = DockStyle.Fill;
            labelSortType.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelSortType.Location = new Point(438, 0);
            labelSortType.MouseState = MaterialSkin.MouseState.HOVER;
            labelSortType.Name = "labelSortType";
            labelSortType.Size = new Size(54, 30);
            labelSortType.TabIndex = 54;
            labelSortType.Text = "Sort by";
            labelSortType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cmbSortType
            // 
            cmbSortType.DataBindings.Add(new Binding("SelectedValue", sortModelBindingSource, "Type", true));
            cmbSortType.Dock = DockStyle.Fill;
            cmbSortType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSortType.FormattingEnabled = true;
            cmbSortType.Location = new Point(498, 3);
            cmbSortType.Name = "cmbSortType";
            cmbSortType.Size = new Size(164, 23);
            cmbSortType.TabIndex = 55;
            cmbSortType.SelectedIndexChanged += CmbSort_ChangedItem;
            // 
            // sortModelBindingSource
            // 
            sortModelBindingSource.DataSource = typeof(SortModel);
            // 
            // tlPanelActionsWithElements
            // 
            tlPanelActionsWithElements.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlPanelActionsWithElements.ColumnCount = 4;
            tlPanelActionsWithElements.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlPanelActionsWithElements.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlPanelActionsWithElements.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlPanelActionsWithElements.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlPanelActionsWithElements.Controls.Add(btnAddCinema, 0, 0);
            tlPanelActionsWithElements.Controls.Add(btnEditCinema, 1, 0);
            tlPanelActionsWithElements.Controls.Add(btnDeleteMovie, 2, 0);
            tlPanelActionsWithElements.Controls.Add(btnAddData, 3, 0);
            tlPanelActionsWithElements.Location = new Point(5, 395);
            tlPanelActionsWithElements.Name = "tlPanelActionsWithElements";
            tlPanelActionsWithElements.RowCount = 1;
            tlPanelActionsWithElements.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlPanelActionsWithElements.Size = new Size(665, 30);
            tlPanelActionsWithElements.TabIndex = 56;
            // 
            // tlPanelPage
            // 
            tlPanelPage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlPanelPage.ColumnCount = 10;
            tlPanelPage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlPanelPage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlPanelPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlPanelPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlPanelPage.ColumnStyles.Add(new ColumnStyle());
            tlPanelPage.ColumnStyles.Add(new ColumnStyle());
            tlPanelPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlPanelPage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlPanelPage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tlPanelPage.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tlPanelPage.Controls.Add(labelTextSizePage, 0, 0);
            tlPanelPage.Controls.Add(cmbPageSize, 1, 0);
            tlPanelPage.Controls.Add(cmbSortType, 9, 0);
            tlPanelPage.Controls.Add(btnStartPage, 2, 0);
            tlPanelPage.Controls.Add(btnBackPage, 3, 0);
            tlPanelPage.Controls.Add(btnEndPage, 7, 0);
            tlPanelPage.Controls.Add(labelTotalPage, 5, 0);
            tlPanelPage.Controls.Add(btnNextPage, 6, 0);
            tlPanelPage.Controls.Add(textBoxPage, 4, 0);
            tlPanelPage.Controls.Add(labelSortType, 8, 0);
            tlPanelPage.Location = new Point(5, 362);
            tlPanelPage.Name = "tlPanelPage";
            tlPanelPage.RowCount = 1;
            tlPanelPage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlPanelPage.Size = new Size(665, 30);
            tlPanelPage.TabIndex = 57;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnClearFilter, 0, 0);
            tableLayoutPanel1.Controls.Add(btnUseFilter, 0, 1);
            tableLayoutPanel1.Location = new Point(510, 65);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(160, 54);
            tableLayoutPanel1.TabIndex = 58;
            // 
            // BoxCinemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(680, 425);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tlPanelPage);
            Controls.Add(tlPanelActionsWithElements);
            Controls.Add(cmbFilterStatus);
            Controls.Add(cmbFilterType);
            Controls.Add(dgvCinema);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(680, 425);
            Name = "BoxCinemaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BoxCinema";
            ((System.ComponentModel.ISupportInitialize)cinemaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCinema).EndInit();
            ((System.ComponentModel.ISupportInitialize)filterModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pageModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)sortModelBindingSource).EndInit();
            tlPanelActionsWithElements.ResumeLayout(false);
            tlPanelActionsWithElements.PerformLayout();
            tlPanelPage.ResumeLayout(false);
            tlPanelPage.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource cinemaBindingSource;
        private OpenFileDialog openFileDialog;
        private DataGridView dgvCinema;
        private MaterialSkin.Controls.MaterialButton btnAddCinema;
        private MaterialSkin.Controls.MaterialButton btnEditCinema;
        private MaterialSkin.Controls.MaterialButton btnDeleteMovie;
        private MaterialSkin.Controls.MaterialButton btnAddData;
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
        private BindingSource filterModelBindingSource;
        private BindingSource sortModelBindingSource;
        private DataGridViewTextBoxColumn NameCinema;
        private DataGridViewTextBoxColumn NumberCinema;
        private DataGridViewTextBoxColumn WatchedCinema;
        private DataGridViewTextBoxColumn DataWatchedCinema;
        private DataGridViewTextBoxColumn GradeCinema;
        private DataGridViewTextBoxColumn IdCinema;
        private DataGridViewTextBoxColumn Cinema;
        private TableLayoutPanel tlPanelActionsWithElements;
        private TableLayoutPanel tlPanelPage;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
