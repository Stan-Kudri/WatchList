using ListWatchedMoviesAndSeries.BindingItem.Model;

namespace ListWatchedMoviesAndSeries
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
            this.components = new System.ComponentModel.Container();
            this.cinemaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dgvCinema = new System.Windows.Forms.DataGridView();
            this.NameCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchedCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFormMovie = new MaterialSkin.Controls.MaterialButton();
            this.btnFormSeries = new MaterialSkin.Controls.MaterialButton();
            this.btnFormAnime = new MaterialSkin.Controls.MaterialButton();
            this.btnFormCartoon = new MaterialSkin.Controls.MaterialButton();
            this.btnEditCinema = new MaterialSkin.Controls.MaterialButton();
            this.btnDeliteMovie = new MaterialSkin.Controls.MaterialButton();
            this.btnReplaceData = new MaterialSkin.Controls.MaterialButton();
            this.btnUseFilter = new MaterialSkin.Controls.MaterialButton();
            this.btnCancleFilter = new MaterialSkin.Controls.MaterialButton();
            this.cmbFilterType = new MaterialSkin.Controls.MaterialComboBox();
            this.filterModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbFilterWatch = new MaterialSkin.Controls.MaterialComboBox();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.pageModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBackPage = new MaterialSkin.Controls.MaterialButton();
            this.btnNextPage = new MaterialSkin.Controls.MaterialButton();
            this.btnStartPage = new MaterialSkin.Controls.MaterialButton();
            this.btnEndPage = new MaterialSkin.Controls.MaterialButton();
            this.tbPage = new System.Windows.Forms.TextBox();
            this.labelTotalPage = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "ReplaceDataFromFile ";
            // 
            // dgvCinema
            // 
            this.dgvCinema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCinema.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCinema,
            this.NumberCinema,
            this.WatchedCinema,
            this.DataWatchedCinema,
            this.GradeCinema,
            this.IdCinema,
            this.Cinema});
            this.dgvCinema.Location = new System.Drawing.Point(5, 120);
            this.dgvCinema.MaximumSize = new System.Drawing.Size(640, 240);
            this.dgvCinema.MinimumSize = new System.Drawing.Size(640, 240);
            this.dgvCinema.Name = "dgvCinema";
            this.dgvCinema.ReadOnly = true;
            this.dgvCinema.RowTemplate.Height = 25;
            this.dgvCinema.Size = new System.Drawing.Size(640, 240);
            this.dgvCinema.TabIndex = 16;
            this.dgvCinema.Tag = "Cinema";
            // 
            // NameCinema
            // 
            this.NameCinema.FillWeight = 160F;
            this.NameCinema.HeaderText = "Title";
            this.NameCinema.Name = "NameCinema";
            this.NameCinema.ReadOnly = true;
            this.NameCinema.Width = 160;
            // 
            // NumberCinema
            // 
            this.NumberCinema.HeaderText = "Season/Part";
            this.NumberCinema.Name = "NumberCinema";
            this.NumberCinema.ReadOnly = true;
            // 
            // WatchedCinema
            // 
            this.WatchedCinema.FillWeight = 136F;
            this.WatchedCinema.HeaderText = "The Watched Cinema";
            this.WatchedCinema.Name = "WatchedCinema";
            this.WatchedCinema.ReadOnly = true;
            this.WatchedCinema.Width = 136;
            // 
            // DataWatchedCinema
            // 
            this.DataWatchedCinema.HeaderText = "Data";
            this.DataWatchedCinema.Name = "DataWatchedCinema";
            this.DataWatchedCinema.ReadOnly = true;
            // 
            // GradeCinema
            // 
            this.GradeCinema.HeaderText = "Grade";
            this.GradeCinema.Name = "GradeCinema";
            this.GradeCinema.ReadOnly = true;
            // 
            // IdCinema
            // 
            this.IdCinema.HeaderText = "ID";
            this.IdCinema.Name = "IdCinema";
            this.IdCinema.ReadOnly = true;
            this.IdCinema.Visible = false;
            // 
            // Cinema
            // 
            this.Cinema.HeaderText = "Type";
            this.Cinema.Name = "Cinema";
            this.Cinema.ReadOnly = true;
            this.Cinema.Visible = false;
            // 
            // btnFormMovie
            // 
            this.btnFormMovie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFormMovie.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFormMovie.Depth = 0;
            this.btnFormMovie.HighEmphasis = true;
            this.btnFormMovie.Icon = null;
            this.btnFormMovie.Location = new System.Drawing.Point(5, 395);
            this.btnFormMovie.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFormMovie.MaximumSize = new System.Drawing.Size(155, 20);
            this.btnFormMovie.MinimumSize = new System.Drawing.Size(155, 20);
            this.btnFormMovie.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormMovie.Name = "btnFormMovie";
            this.btnFormMovie.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFormMovie.Size = new System.Drawing.Size(155, 20);
            this.btnFormMovie.TabIndex = 32;
            this.btnFormMovie.Text = "Add Movie";
            this.btnFormMovie.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnFormMovie.UseAccentColor = false;
            this.btnFormMovie.UseVisualStyleBackColor = true;
            this.btnFormMovie.Click += new System.EventHandler(this.BtnFormMovie_Click);
            // 
            // btnFormSeries
            // 
            this.btnFormSeries.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFormSeries.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFormSeries.Depth = 0;
            this.btnFormSeries.HighEmphasis = true;
            this.btnFormSeries.Icon = null;
            this.btnFormSeries.Location = new System.Drawing.Point(166, 395);
            this.btnFormSeries.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFormSeries.MaximumSize = new System.Drawing.Size(155, 20);
            this.btnFormSeries.MinimumSize = new System.Drawing.Size(155, 20);
            this.btnFormSeries.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormSeries.Name = "btnFormSeries";
            this.btnFormSeries.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFormSeries.Size = new System.Drawing.Size(155, 20);
            this.btnFormSeries.TabIndex = 33;
            this.btnFormSeries.Text = "Add Series";
            this.btnFormSeries.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnFormSeries.UseAccentColor = false;
            this.btnFormSeries.UseVisualStyleBackColor = true;
            this.btnFormSeries.Click += new System.EventHandler(this.BtnFormSeries_Click);
            // 
            // btnFormAnime
            // 
            this.btnFormAnime.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFormAnime.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFormAnime.Depth = 0;
            this.btnFormAnime.HighEmphasis = true;
            this.btnFormAnime.Icon = null;
            this.btnFormAnime.Location = new System.Drawing.Point(328, 395);
            this.btnFormAnime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFormAnime.MaximumSize = new System.Drawing.Size(155, 20);
            this.btnFormAnime.MinimumSize = new System.Drawing.Size(155, 20);
            this.btnFormAnime.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormAnime.Name = "btnFormAnime";
            this.btnFormAnime.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFormAnime.Size = new System.Drawing.Size(155, 20);
            this.btnFormAnime.TabIndex = 34;
            this.btnFormAnime.Text = "Add Anime";
            this.btnFormAnime.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnFormAnime.UseAccentColor = false;
            this.btnFormAnime.UseVisualStyleBackColor = true;
            this.btnFormAnime.Click += new System.EventHandler(this.BtnFormAnime_Click);
            // 
            // btnFormCartoon
            // 
            this.btnFormCartoon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFormCartoon.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFormCartoon.Depth = 0;
            this.btnFormCartoon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormCartoon.HighEmphasis = true;
            this.btnFormCartoon.Icon = null;
            this.btnFormCartoon.Location = new System.Drawing.Point(490, 395);
            this.btnFormCartoon.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFormCartoon.MaximumSize = new System.Drawing.Size(155, 20);
            this.btnFormCartoon.MinimumSize = new System.Drawing.Size(155, 20);
            this.btnFormCartoon.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormCartoon.Name = "btnFormCartoon";
            this.btnFormCartoon.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFormCartoon.Size = new System.Drawing.Size(155, 20);
            this.btnFormCartoon.TabIndex = 35;
            this.btnFormCartoon.Text = "Add Cartoon";
            this.btnFormCartoon.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnFormCartoon.UseAccentColor = false;
            this.btnFormCartoon.UseVisualStyleBackColor = true;
            this.btnFormCartoon.Click += new System.EventHandler(this.BtnFormCartoon_Click);
            // 
            // btnEditCinema
            // 
            this.btnEditCinema.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEditCinema.Depth = 0;
            this.btnEditCinema.HighEmphasis = true;
            this.btnEditCinema.Icon = null;
            this.btnEditCinema.Location = new System.Drawing.Point(5, 420);
            this.btnEditCinema.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditCinema.MaximumSize = new System.Drawing.Size(210, 20);
            this.btnEditCinema.MinimumSize = new System.Drawing.Size(210, 20);
            this.btnEditCinema.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditCinema.Name = "btnEditCinema";
            this.btnEditCinema.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEditCinema.Size = new System.Drawing.Size(210, 20);
            this.btnEditCinema.TabIndex = 36;
            this.btnEditCinema.Text = "Edit";
            this.btnEditCinema.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEditCinema.UseAccentColor = false;
            this.btnEditCinema.UseVisualStyleBackColor = true;
            this.btnEditCinema.Click += new System.EventHandler(this.BtnEditRow_Click);
            // 
            // btnDeliteMovie
            // 
            this.btnDeliteMovie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeliteMovie.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDeliteMovie.Depth = 0;
            this.btnDeliteMovie.HighEmphasis = true;
            this.btnDeliteMovie.Icon = null;
            this.btnDeliteMovie.Location = new System.Drawing.Point(220, 420);
            this.btnDeliteMovie.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeliteMovie.MaximumSize = new System.Drawing.Size(210, 20);
            this.btnDeliteMovie.MinimumSize = new System.Drawing.Size(210, 20);
            this.btnDeliteMovie.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeliteMovie.Name = "btnDeliteMovie";
            this.btnDeliteMovie.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDeliteMovie.Size = new System.Drawing.Size(210, 20);
            this.btnDeliteMovie.TabIndex = 37;
            this.btnDeliteMovie.Text = "Delite";
            this.btnDeliteMovie.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDeliteMovie.UseAccentColor = false;
            this.btnDeliteMovie.UseVisualStyleBackColor = true;
            this.btnDeliteMovie.Click += new System.EventHandler(this.BtnDeliteMovie_Click);
            // 
            // btnReplaceData
            // 
            this.btnReplaceData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReplaceData.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReplaceData.Depth = 0;
            this.btnReplaceData.HighEmphasis = true;
            this.btnReplaceData.Icon = null;
            this.btnReplaceData.Location = new System.Drawing.Point(435, 420);
            this.btnReplaceData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReplaceData.MaximumSize = new System.Drawing.Size(210, 20);
            this.btnReplaceData.MinimumSize = new System.Drawing.Size(210, 20);
            this.btnReplaceData.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReplaceData.Name = "btnReplaceData";
            this.btnReplaceData.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReplaceData.Size = new System.Drawing.Size(210, 20);
            this.btnReplaceData.TabIndex = 38;
            this.btnReplaceData.Text = "Replace data from file ";
            this.btnReplaceData.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReplaceData.UseAccentColor = false;
            this.btnReplaceData.UseVisualStyleBackColor = true;
            this.btnReplaceData.Click += new System.EventHandler(this.BtnReplaceFile_Click);
            // 
            // btnUseFilter
            // 
            this.btnUseFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUseFilter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUseFilter.Depth = 0;
            this.btnUseFilter.HighEmphasis = true;
            this.btnUseFilter.Icon = null;
            this.btnUseFilter.Location = new System.Drawing.Point(495, 95);
            this.btnUseFilter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUseFilter.MaximumSize = new System.Drawing.Size(150, 20);
            this.btnUseFilter.MinimumSize = new System.Drawing.Size(150, 20);
            this.btnUseFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUseFilter.Name = "btnUseFilter";
            this.btnUseFilter.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUseFilter.Size = new System.Drawing.Size(150, 20);
            this.btnUseFilter.TabIndex = 39;
            this.btnUseFilter.Text = "Use Filter";
            this.btnUseFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUseFilter.UseAccentColor = false;
            this.btnUseFilter.UseVisualStyleBackColor = true;
            this.btnUseFilter.Click += new System.EventHandler(this.BtnUseFilter_Click);
            // 
            // btnCancleFilter
            // 
            this.btnCancleFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancleFilter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancleFilter.Depth = 0;
            this.btnCancleFilter.HighEmphasis = true;
            this.btnCancleFilter.Icon = null;
            this.btnCancleFilter.Location = new System.Drawing.Point(495, 70);
            this.btnCancleFilter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancleFilter.MaximumSize = new System.Drawing.Size(150, 20);
            this.btnCancleFilter.MinimumSize = new System.Drawing.Size(150, 20);
            this.btnCancleFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancleFilter.Name = "btnCancleFilter";
            this.btnCancleFilter.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancleFilter.Size = new System.Drawing.Size(150, 20);
            this.btnCancleFilter.TabIndex = 40;
            this.btnCancleFilter.Text = "Cancle Filter";
            this.btnCancleFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancleFilter.UseAccentColor = false;
            this.btnCancleFilter.UseVisualStyleBackColor = true;
            this.btnCancleFilter.Click += new System.EventHandler(this.BtnCancleFilter_Click);
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.AutoResize = false;
            this.cmbFilterType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbFilterType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.filterModelBindingSource, "Type", true));
            this.cmbFilterType.Depth = 0;
            this.cmbFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbFilterType.DropDownHeight = 174;
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.DropDownWidth = 121;
            this.cmbFilterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbFilterType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.IntegralHeight = false;
            this.cmbFilterType.ItemHeight = 43;
            this.cmbFilterType.Location = new System.Drawing.Point(5, 70);
            this.cmbFilterType.MaxDropDownItems = 4;
            this.cmbFilterType.MaximumSize = new System.Drawing.Size(235, 0);
            this.cmbFilterType.MinimumSize = new System.Drawing.Size(235, 0);
            this.cmbFilterType.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(235, 49);
            this.cmbFilterType.StartIndex = 0;
            this.cmbFilterType.TabIndex = 41;
            // 
            // filterModelBindingSource
            // 
            this.filterModelBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.BindingItem.Model.FilterModel);
            // 
            // cmbFilterWatch
            // 
            this.cmbFilterWatch.AutoResize = false;
            this.cmbFilterWatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbFilterWatch.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.filterModelBindingSource, "Watch", true));
            this.cmbFilterWatch.Depth = 0;
            this.cmbFilterWatch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbFilterWatch.DropDownHeight = 174;
            this.cmbFilterWatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterWatch.DropDownWidth = 121;
            this.cmbFilterWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbFilterWatch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbFilterWatch.IntegralHeight = false;
            this.cmbFilterWatch.ItemHeight = 43;
            this.cmbFilterWatch.Location = new System.Drawing.Point(250, 70);
            this.cmbFilterWatch.MaxDropDownItems = 4;
            this.cmbFilterWatch.MaximumSize = new System.Drawing.Size(235, 0);
            this.cmbFilterWatch.MinimumSize = new System.Drawing.Size(235, 0);
            this.cmbFilterWatch.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbFilterWatch.Name = "cmbFilterWatch";
            this.cmbFilterWatch.Size = new System.Drawing.Size(235, 49);
            this.cmbFilterWatch.StartIndex = 0;
            this.cmbFilterWatch.TabIndex = 42;
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.pageModelBindingSource, "Size", true));
            this.cmbPageSize.FormattingEnabled = true;
            this.cmbPageSize.Location = new System.Drawing.Point(5, 365);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(120, 23);
            this.cmbPageSize.TabIndex = 43;
            this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.СmbPageSize_SelectedIndexChanged);
            // 
            // pageModelBindingSource
            // 
            this.pageModelBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.BindingItem.Model.PageModel);
            // 
            // btnBackPage
            // 
            this.btnBackPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBackPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBackPage.Depth = 0;
            this.btnBackPage.HighEmphasis = true;
            this.btnBackPage.Icon = null;
            this.btnBackPage.Location = new System.Drawing.Point(270, 365);
            this.btnBackPage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBackPage.MaximumSize = new System.Drawing.Size(20, 20);
            this.btnBackPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnBackPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBackPage.Name = "btnBackPage";
            this.btnBackPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBackPage.Size = new System.Drawing.Size(20, 20);
            this.btnBackPage.TabIndex = 44;
            this.btnBackPage.Text = "<";
            this.btnBackPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnBackPage.UseAccentColor = false;
            this.btnBackPage.UseVisualStyleBackColor = true;
            this.btnBackPage.Click += new System.EventHandler(this.BtnBackPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNextPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNextPage.Depth = 0;
            this.btnNextPage.HighEmphasis = true;
            this.btnNextPage.Icon = null;
            this.btnNextPage.Location = new System.Drawing.Point(370, 365);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNextPage.MaximumSize = new System.Drawing.Size(20, 20);
            this.btnNextPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnNextPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNextPage.Size = new System.Drawing.Size(20, 20);
            this.btnNextPage.TabIndex = 45;
            this.btnNextPage.Text = ">";
            this.btnNextPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNextPage.UseAccentColor = false;
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // btnStartPage
            // 
            this.btnStartPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStartPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStartPage.Depth = 0;
            this.btnStartPage.HighEmphasis = true;
            this.btnStartPage.Icon = null;
            this.btnStartPage.Location = new System.Drawing.Point(245, 365);
            this.btnStartPage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStartPage.MaximumSize = new System.Drawing.Size(20, 20);
            this.btnStartPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnStartPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStartPage.Name = "btnStartPage";
            this.btnStartPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStartPage.Size = new System.Drawing.Size(20, 20);
            this.btnStartPage.TabIndex = 49;
            this.btnStartPage.Text = "<<";
            this.btnStartPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnStartPage.UseAccentColor = false;
            this.btnStartPage.UseVisualStyleBackColor = true;
            this.btnStartPage.Click += new System.EventHandler(this.BtnStartPage_Click);
            // 
            // btnEndPage
            // 
            this.btnEndPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEndPage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEndPage.Depth = 0;
            this.btnEndPage.HighEmphasis = true;
            this.btnEndPage.Icon = null;
            this.btnEndPage.Location = new System.Drawing.Point(395, 365);
            this.btnEndPage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEndPage.MaximumSize = new System.Drawing.Size(20, 20);
            this.btnEndPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnEndPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEndPage.Size = new System.Drawing.Size(20, 20);
            this.btnEndPage.TabIndex = 50;
            this.btnEndPage.Text = ">>";
            this.btnEndPage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEndPage.UseAccentColor = false;
            this.btnEndPage.UseVisualStyleBackColor = true;
            this.btnEndPage.Click += new System.EventHandler(this.BtnEndPage_Click);
            // 
            // tbPage
            // 
            this.tbPage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pageModelBindingSource, "Number", true));
            this.tbPage.Location = new System.Drawing.Point(295, 365);
            this.tbPage.MaximumSize = new System.Drawing.Size(40, 20);
            this.tbPage.MinimumSize = new System.Drawing.Size(40, 20);
            this.tbPage.Name = "tbPage";
            this.tbPage.Size = new System.Drawing.Size(40, 20);
            this.tbPage.TabIndex = 51;
            this.tbPage.TextChanged += new System.EventHandler(this.TbPage_TextChanged);
            // 
            // labelTotalPage
            // 
            this.labelTotalPage.AutoSize = true;
            this.labelTotalPage.Depth = 0;
            this.labelTotalPage.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelTotalPage.Location = new System.Drawing.Point(341, 366);
            this.labelTotalPage.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelTotalPage.Name = "labelTotalPage";
            this.labelTotalPage.Size = new System.Drawing.Size(17, 19);
            this.labelTotalPage.TabIndex = 52;
            this.labelTotalPage.Text = "/1";
            // 
            // BoxCinemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(650, 445);
            this.Controls.Add(this.labelTotalPage);
            this.Controls.Add(this.tbPage);
            this.Controls.Add(this.btnEndPage);
            this.Controls.Add(this.btnStartPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnBackPage);
            this.Controls.Add(this.cmbPageSize);
            this.Controls.Add(this.cmbFilterWatch);
            this.Controls.Add(this.cmbFilterType);
            this.Controls.Add(this.btnCancleFilter);
            this.Controls.Add(this.btnUseFilter);
            this.Controls.Add(this.btnReplaceData);
            this.Controls.Add(this.btnDeliteMovie);
            this.Controls.Add(this.btnEditCinema);
            this.Controls.Add(this.btnFormCartoon);
            this.Controls.Add(this.btnFormAnime);
            this.Controls.Add(this.btnFormSeries);
            this.Controls.Add(this.btnFormMovie);
            this.Controls.Add(this.dgvCinema);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(650, 445);
            this.MinimumSize = new System.Drawing.Size(650, 445);
            this.Name = "BoxCinemaForm";
            this.Text = "BoxCinema";
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BindingSource cinemaBindingSource;
        private OpenFileDialog openFileDialog;
        private DataGridView dgvCinema;
        private MaterialSkin.Controls.MaterialButton btnFormMovie;
        private MaterialSkin.Controls.MaterialButton btnFormSeries;
        private MaterialSkin.Controls.MaterialButton btnFormAnime;
        private MaterialSkin.Controls.MaterialButton btnFormCartoon;
        private MaterialSkin.Controls.MaterialButton btnEditCinema;
        private MaterialSkin.Controls.MaterialButton btnDeliteMovie;
        private DataGridViewTextBoxColumn NameCinema;
        private DataGridViewTextBoxColumn NumberCinema;
        private DataGridViewTextBoxColumn WatchedCinema;
        private DataGridViewTextBoxColumn DataWatchedCinema;
        private DataGridViewTextBoxColumn GradeCinema;
        private DataGridViewTextBoxColumn IdCinema;
        private DataGridViewTextBoxColumn Cinema;
        private MaterialSkin.Controls.MaterialButton btnReplaceData;
        private MaterialSkin.Controls.MaterialButton btnUseFilter;
        private MaterialSkin.Controls.MaterialButton btnCancleFilter;
        private MaterialSkin.Controls.MaterialComboBox cmbFilterType;
        private MaterialSkin.Controls.MaterialComboBox cmbFilterWatch;
        private ComboBox cmbPageSize;
        private MaterialSkin.Controls.MaterialButton btnBackPage;
        private MaterialSkin.Controls.MaterialButton btnNextPage;
        private MaterialSkin.Controls.MaterialButton btnStartPage;
        private MaterialSkin.Controls.MaterialButton btnEndPage;
        private TextBox tbPage;
        private BindingSource filterModelBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelTotalPage;
        private BindingSource pageModelBindingSource;
    }
}
