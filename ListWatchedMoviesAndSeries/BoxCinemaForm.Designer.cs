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
            btnFormMovie = new MaterialSkin.Controls.MaterialButton();
            btnFormSeries = new MaterialSkin.Controls.MaterialButton();
            btnFormAnime = new MaterialSkin.Controls.MaterialButton();
            btnFormCartoon = new MaterialSkin.Controls.MaterialButton();
            btnEditCinema = new MaterialSkin.Controls.MaterialButton();
            btnDeleteMovie = new MaterialSkin.Controls.MaterialButton();
            btnReplaceData = new MaterialSkin.Controls.MaterialButton();
            btnUseFilter = new MaterialSkin.Controls.MaterialButton();
            btnCancelFilter = new MaterialSkin.Controls.MaterialButton();
            cmbFilterType = new MaterialSkin.Controls.MaterialComboBox();
            filterModelBindingSource = new BindingSource(components);
            cmbFilterWatch = new MaterialSkin.Controls.MaterialComboBox();
            cmbPageSize = new ComboBox();
            pageModelBindingSource = new BindingSource(components);
            btnBackPage = new MaterialSkin.Controls.MaterialButton();
            btnNextPage = new MaterialSkin.Controls.MaterialButton();
            btnStartPage = new MaterialSkin.Controls.MaterialButton();
            btnEndPage = new MaterialSkin.Controls.MaterialButton();
            textBoxPage = new TextBox();
            labelTotalPage = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)cinemaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCinema).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filterModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pageModelBindingSource).BeginInit();
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
            dgvCinema.MaximumSize = new Size(640, 240);
            dgvCinema.MinimumSize = new Size(640, 240);
            dgvCinema.Name = "dgvCinema";
            dgvCinema.ReadOnly = true;
            dgvCinema.RowTemplate.Height = 25;
            dgvCinema.Size = new Size(640, 240);
            dgvCinema.TabIndex = 16;
            dgvCinema.Tag = "Cinema";
            // 
            // NameCinema
            // 
            NameCinema.FillWeight = 160F;
            NameCinema.HeaderText = "Title";
            NameCinema.Name = "NameCinema";
            NameCinema.ReadOnly = true;
            NameCinema.Width = 160;
            // 
            // NumberCinema
            // 
            NumberCinema.HeaderText = "Season/Part";
            NumberCinema.Name = "NumberCinema";
            NumberCinema.ReadOnly = true;
            // 
            // WatchedCinema
            // 
            WatchedCinema.FillWeight = 136F;
            WatchedCinema.HeaderText = "The Watched Cinema";
            WatchedCinema.Name = "WatchedCinema";
            WatchedCinema.ReadOnly = true;
            WatchedCinema.Width = 136;
            // 
            // DataWatchedCinema
            // 
            DataWatchedCinema.HeaderText = "Data";
            DataWatchedCinema.Name = "DataWatchedCinema";
            DataWatchedCinema.ReadOnly = true;
            // 
            // GradeCinema
            // 
            GradeCinema.HeaderText = "Grade";
            GradeCinema.Name = "GradeCinema";
            GradeCinema.ReadOnly = true;
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
            Cinema.Visible = false;
            // 
            // btnFormMovie
            // 
            btnFormMovie.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFormMovie.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFormMovie.Depth = 0;
            btnFormMovie.HighEmphasis = true;
            btnFormMovie.Icon = null;
            btnFormMovie.Location = new Point(5, 395);
            btnFormMovie.Margin = new Padding(4, 6, 4, 6);
            btnFormMovie.MaximumSize = new Size(155, 20);
            btnFormMovie.MinimumSize = new Size(155, 20);
            btnFormMovie.MouseState = MaterialSkin.MouseState.HOVER;
            btnFormMovie.Name = "btnFormMovie";
            btnFormMovie.NoAccentTextColor = Color.Empty;
            btnFormMovie.Size = new Size(155, 20);
            btnFormMovie.TabIndex = 32;
            btnFormMovie.Text = "Add Movie";
            btnFormMovie.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFormMovie.UseAccentColor = false;
            btnFormMovie.UseVisualStyleBackColor = true;
            btnFormMovie.Click += BtnFormMovie_Click;
            // 
            // btnFormSeries
            // 
            btnFormSeries.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFormSeries.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFormSeries.Depth = 0;
            btnFormSeries.HighEmphasis = true;
            btnFormSeries.Icon = null;
            btnFormSeries.Location = new Point(166, 395);
            btnFormSeries.Margin = new Padding(4, 6, 4, 6);
            btnFormSeries.MaximumSize = new Size(155, 20);
            btnFormSeries.MinimumSize = new Size(155, 20);
            btnFormSeries.MouseState = MaterialSkin.MouseState.HOVER;
            btnFormSeries.Name = "btnFormSeries";
            btnFormSeries.NoAccentTextColor = Color.Empty;
            btnFormSeries.Size = new Size(155, 20);
            btnFormSeries.TabIndex = 33;
            btnFormSeries.Text = "Add Series";
            btnFormSeries.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFormSeries.UseAccentColor = false;
            btnFormSeries.UseVisualStyleBackColor = true;
            btnFormSeries.Click += BtnFormSeries_Click;
            // 
            // btnFormAnime
            // 
            btnFormAnime.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFormAnime.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFormAnime.Depth = 0;
            btnFormAnime.HighEmphasis = true;
            btnFormAnime.Icon = null;
            btnFormAnime.Location = new Point(328, 395);
            btnFormAnime.Margin = new Padding(4, 6, 4, 6);
            btnFormAnime.MaximumSize = new Size(155, 20);
            btnFormAnime.MinimumSize = new Size(155, 20);
            btnFormAnime.MouseState = MaterialSkin.MouseState.HOVER;
            btnFormAnime.Name = "btnFormAnime";
            btnFormAnime.NoAccentTextColor = Color.Empty;
            btnFormAnime.Size = new Size(155, 20);
            btnFormAnime.TabIndex = 34;
            btnFormAnime.Text = "Add Anime";
            btnFormAnime.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFormAnime.UseAccentColor = false;
            btnFormAnime.UseVisualStyleBackColor = true;
            btnFormAnime.Click += BtnFormAnime_Click;
            // 
            // btnFormCartoon
            // 
            btnFormCartoon.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFormCartoon.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFormCartoon.Depth = 0;
            btnFormCartoon.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnFormCartoon.HighEmphasis = true;
            btnFormCartoon.Icon = null;
            btnFormCartoon.Location = new Point(490, 395);
            btnFormCartoon.Margin = new Padding(4, 6, 4, 6);
            btnFormCartoon.MaximumSize = new Size(155, 20);
            btnFormCartoon.MinimumSize = new Size(155, 20);
            btnFormCartoon.MouseState = MaterialSkin.MouseState.HOVER;
            btnFormCartoon.Name = "btnFormCartoon";
            btnFormCartoon.NoAccentTextColor = Color.Empty;
            btnFormCartoon.Size = new Size(155, 20);
            btnFormCartoon.TabIndex = 35;
            btnFormCartoon.Text = "Add Cartoon";
            btnFormCartoon.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFormCartoon.UseAccentColor = false;
            btnFormCartoon.UseVisualStyleBackColor = true;
            btnFormCartoon.Click += BtnFormCartoon_Click;
            // 
            // btnEditCinema
            // 
            btnEditCinema.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEditCinema.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnEditCinema.Depth = 0;
            btnEditCinema.HighEmphasis = true;
            btnEditCinema.Icon = null;
            btnEditCinema.Location = new Point(5, 420);
            btnEditCinema.Margin = new Padding(4, 6, 4, 6);
            btnEditCinema.MaximumSize = new Size(210, 20);
            btnEditCinema.MinimumSize = new Size(210, 20);
            btnEditCinema.MouseState = MaterialSkin.MouseState.HOVER;
            btnEditCinema.Name = "btnEditCinema";
            btnEditCinema.NoAccentTextColor = Color.Empty;
            btnEditCinema.Size = new Size(210, 20);
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
            btnDeleteMovie.Location = new Point(220, 420);
            btnDeleteMovie.Margin = new Padding(4, 6, 4, 6);
            btnDeleteMovie.MaximumSize = new Size(210, 20);
            btnDeleteMovie.MinimumSize = new Size(210, 20);
            btnDeleteMovie.MouseState = MaterialSkin.MouseState.HOVER;
            btnDeleteMovie.Name = "btnDeleteMovie";
            btnDeleteMovie.NoAccentTextColor = Color.Empty;
            btnDeleteMovie.Size = new Size(210, 20);
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
            btnReplaceData.Location = new Point(435, 420);
            btnReplaceData.Margin = new Padding(4, 6, 4, 6);
            btnReplaceData.MaximumSize = new Size(210, 20);
            btnReplaceData.MinimumSize = new Size(210, 20);
            btnReplaceData.MouseState = MaterialSkin.MouseState.HOVER;
            btnReplaceData.Name = "btnReplaceData";
            btnReplaceData.NoAccentTextColor = Color.Empty;
            btnReplaceData.Size = new Size(210, 20);
            btnReplaceData.TabIndex = 38;
            btnReplaceData.Text = "Replace data from file ";
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
            btnUseFilter.MaximumSize = new Size(150, 20);
            btnUseFilter.MinimumSize = new Size(150, 20);
            btnUseFilter.MouseState = MaterialSkin.MouseState.HOVER;
            btnUseFilter.Name = "btnUseFilter";
            btnUseFilter.NoAccentTextColor = Color.Empty;
            btnUseFilter.Size = new Size(150, 20);
            btnUseFilter.TabIndex = 39;
            btnUseFilter.Text = "Use Filter";
            btnUseFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnUseFilter.UseAccentColor = false;
            btnUseFilter.UseVisualStyleBackColor = true;
            btnUseFilter.Click += BtnUseFilter_Click;
            // 
            // btnCancelFilter
            // 
            btnCancelFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancelFilter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancelFilter.Depth = 0;
            btnCancelFilter.HighEmphasis = true;
            btnCancelFilter.Icon = null;
            btnCancelFilter.Location = new Point(495, 70);
            btnCancelFilter.Margin = new Padding(4, 6, 4, 6);
            btnCancelFilter.MaximumSize = new Size(150, 20);
            btnCancelFilter.MinimumSize = new Size(150, 20);
            btnCancelFilter.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancelFilter.Name = "btnCancelFilter";
            btnCancelFilter.NoAccentTextColor = Color.Empty;
            btnCancelFilter.Size = new Size(150, 20);
            btnCancelFilter.TabIndex = 40;
            btnCancelFilter.Text = "Cancel Filter";
            btnCancelFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancelFilter.UseAccentColor = false;
            btnCancelFilter.UseVisualStyleBackColor = true;
            btnCancelFilter.Click += BtnCancelFilter_Click;
            // 
            // cmbFilterType
            // 
            cmbFilterType.AutoResize = false;
            cmbFilterType.BackColor = Color.FromArgb(255, 255, 255);
            cmbFilterType.DataBindings.Add(new Binding("SelectedValue", filterModelBindingSource, "Type", true));
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
            // cmbFilterWatch
            // 
            cmbFilterWatch.AutoResize = false;
            cmbFilterWatch.BackColor = Color.FromArgb(255, 255, 255);
            cmbFilterWatch.DataBindings.Add(new Binding("SelectedValue", filterModelBindingSource, "Watch", true));
            cmbFilterWatch.Depth = 0;
            cmbFilterWatch.DrawMode = DrawMode.OwnerDrawVariable;
            cmbFilterWatch.DropDownHeight = 174;
            cmbFilterWatch.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterWatch.DropDownWidth = 121;
            cmbFilterWatch.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cmbFilterWatch.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbFilterWatch.IntegralHeight = false;
            cmbFilterWatch.ItemHeight = 43;
            cmbFilterWatch.Location = new Point(250, 70);
            cmbFilterWatch.MaxDropDownItems = 4;
            cmbFilterWatch.MaximumSize = new Size(235, 0);
            cmbFilterWatch.MinimumSize = new Size(235, 0);
            cmbFilterWatch.MouseState = MaterialSkin.MouseState.OUT;
            cmbFilterWatch.Name = "cmbFilterWatch";
            cmbFilterWatch.Size = new Size(235, 49);
            cmbFilterWatch.StartIndex = 0;
            cmbFilterWatch.TabIndex = 42;
            // 
            // cmbPageSize
            // 
            cmbPageSize.DataBindings.Add(new Binding("SelectedValue", pageModelBindingSource, "Size", true));
            cmbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPageSize.FormattingEnabled = true;
            cmbPageSize.Location = new Point(5, 365);
            cmbPageSize.Name = "cmbPageSize";
            cmbPageSize.Size = new Size(120, 23);
            cmbPageSize.TabIndex = 43;
            cmbPageSize.SelectedIndexChanged += СmbPageSize_Changed;
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
            btnBackPage.Location = new Point(270, 365);
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
            btnNextPage.Location = new Point(370, 365);
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
            btnStartPage.Location = new Point(245, 365);
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
            btnEndPage.Location = new Point(395, 365);
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
            textBoxPage.Location = new Point(295, 365);
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
            // BoxCinemaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(650, 445);
            Controls.Add(labelTotalPage);
            Controls.Add(textBoxPage);
            Controls.Add(btnEndPage);
            Controls.Add(btnStartPage);
            Controls.Add(btnNextPage);
            Controls.Add(btnBackPage);
            Controls.Add(cmbPageSize);
            Controls.Add(cmbFilterWatch);
            Controls.Add(cmbFilterType);
            Controls.Add(btnCancelFilter);
            Controls.Add(btnUseFilter);
            Controls.Add(btnReplaceData);
            Controls.Add(btnDeleteMovie);
            Controls.Add(btnEditCinema);
            Controls.Add(btnFormCartoon);
            Controls.Add(btnFormAnime);
            Controls.Add(btnFormSeries);
            Controls.Add(btnFormMovie);
            Controls.Add(dgvCinema);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(650, 445);
            MinimumSize = new Size(650, 445);
            Name = "BoxCinemaForm";
            Text = "BoxCinema";
            ((System.ComponentModel.ISupportInitialize)cinemaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCinema).EndInit();
            ((System.ComponentModel.ISupportInitialize)filterModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pageModelBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private MaterialSkin.Controls.MaterialButton btnDeleteMovie;
        private DataGridViewTextBoxColumn NameCinema;
        private DataGridViewTextBoxColumn NumberCinema;
        private DataGridViewTextBoxColumn WatchedCinema;
        private DataGridViewTextBoxColumn DataWatchedCinema;
        private DataGridViewTextBoxColumn GradeCinema;
        private DataGridViewTextBoxColumn IdCinema;
        private DataGridViewTextBoxColumn Cinema;
        private MaterialSkin.Controls.MaterialButton btnReplaceData;
        private MaterialSkin.Controls.MaterialButton btnUseFilter;
        private MaterialSkin.Controls.MaterialButton btnCancelFilter;
        private MaterialSkin.Controls.MaterialComboBox cmbFilterType;
        private MaterialSkin.Controls.MaterialComboBox cmbFilterWatch;
        private ComboBox cmbPageSize;
        private MaterialSkin.Controls.MaterialButton btnBackPage;
        private MaterialSkin.Controls.MaterialButton btnNextPage;
        private MaterialSkin.Controls.MaterialButton btnStartPage;
        private MaterialSkin.Controls.MaterialButton btnEndPage;
        private TextBox textBoxPage;
        private BindingSource filterModelBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelTotalPage;
        private BindingSource pageModelBindingSource;
    }
}
