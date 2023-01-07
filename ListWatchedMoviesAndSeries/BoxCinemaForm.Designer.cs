
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
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.filterModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbFilterWatch = new System.Windows.Forms.ComboBox();
            this.btnFormMovie = new MaterialSkin.Controls.MaterialButton();
            this.btnFormSeries = new MaterialSkin.Controls.MaterialButton();
            this.btnFormAnime = new MaterialSkin.Controls.MaterialButton();
            this.btnFormCartoon = new MaterialSkin.Controls.MaterialButton();
            this.btnEditCinema = new MaterialSkin.Controls.MaterialButton();
            this.btnDeliteMovie = new MaterialSkin.Controls.MaterialButton();
            this.btnReplaceData = new MaterialSkin.Controls.MaterialButton();
            this.btnUseFilter = new MaterialSkin.Controls.MaterialButton();
            this.btnCancleFilter = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterModelBindingSource)).BeginInit();
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
            this.dgvCinema.Location = new System.Drawing.Point(5, 70);
            this.dgvCinema.MaximumSize = new System.Drawing.Size(640, 270);
            this.dgvCinema.MinimumSize = new System.Drawing.Size(640, 270);
            this.dgvCinema.Name = "dgvCinema";
            this.dgvCinema.ReadOnly = true;
            this.dgvCinema.RowTemplate.Height = 25;
            this.dgvCinema.Size = new System.Drawing.Size(640, 270);
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
            // cmbFilterType
            // 
            this.cmbFilterType.BackColor = System.Drawing.Color.PowderBlue;
            this.cmbFilterType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.filterModelBindingSource, "Type", true));
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Location = new System.Drawing.Point(5, 420);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(210, 23);
            this.cmbFilterType.TabIndex = 17;
            // 
            // filterModelBindingSource
            // 
            this.filterModelBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.Model.FilterModel);
            // 
            // cmbFilterWatch
            // 
            this.cmbFilterWatch.BackColor = System.Drawing.Color.PowderBlue;
            this.cmbFilterWatch.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.filterModelBindingSource, "Watch", true));
            this.cmbFilterWatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterWatch.FormattingEnabled = true;
            this.cmbFilterWatch.Location = new System.Drawing.Point(225, 420);
            this.cmbFilterWatch.Name = "cmbFilterWatch";
            this.cmbFilterWatch.Size = new System.Drawing.Size(210, 23);
            this.cmbFilterWatch.TabIndex = 18;
            // 
            // btnFormMovie
            // 
            this.btnFormMovie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFormMovie.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFormMovie.Depth = 0;
            this.btnFormMovie.HighEmphasis = true;
            this.btnFormMovie.Icon = null;
            this.btnFormMovie.Location = new System.Drawing.Point(5, 345);
            this.btnFormMovie.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFormMovie.MaximumSize = new System.Drawing.Size(100, 30);
            this.btnFormMovie.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnFormMovie.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormMovie.Name = "btnFormMovie";
            this.btnFormMovie.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFormMovie.Size = new System.Drawing.Size(100, 30);
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
            this.btnFormSeries.Location = new System.Drawing.Point(115, 345);
            this.btnFormSeries.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFormSeries.MaximumSize = new System.Drawing.Size(100, 30);
            this.btnFormSeries.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnFormSeries.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormSeries.Name = "btnFormSeries";
            this.btnFormSeries.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFormSeries.Size = new System.Drawing.Size(100, 30);
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
            this.btnFormAnime.Location = new System.Drawing.Point(225, 345);
            this.btnFormAnime.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFormAnime.MaximumSize = new System.Drawing.Size(100, 30);
            this.btnFormAnime.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnFormAnime.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormAnime.Name = "btnFormAnime";
            this.btnFormAnime.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFormAnime.Size = new System.Drawing.Size(100, 30);
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
            this.btnFormCartoon.Location = new System.Drawing.Point(335, 345);
            this.btnFormCartoon.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFormCartoon.MaximumSize = new System.Drawing.Size(100, 30);
            this.btnFormCartoon.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnFormCartoon.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormCartoon.Name = "btnFormCartoon";
            this.btnFormCartoon.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFormCartoon.Size = new System.Drawing.Size(100, 30);
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
            this.btnEditCinema.Location = new System.Drawing.Point(5, 380);
            this.btnEditCinema.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEditCinema.MaximumSize = new System.Drawing.Size(210, 30);
            this.btnEditCinema.MinimumSize = new System.Drawing.Size(210, 30);
            this.btnEditCinema.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditCinema.Name = "btnEditCinema";
            this.btnEditCinema.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEditCinema.Size = new System.Drawing.Size(210, 30);
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
            this.btnDeliteMovie.Location = new System.Drawing.Point(225, 380);
            this.btnDeliteMovie.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDeliteMovie.MaximumSize = new System.Drawing.Size(210, 30);
            this.btnDeliteMovie.MinimumSize = new System.Drawing.Size(210, 30);
            this.btnDeliteMovie.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeliteMovie.Name = "btnDeliteMovie";
            this.btnDeliteMovie.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDeliteMovie.Size = new System.Drawing.Size(210, 30);
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
            this.btnReplaceData.Location = new System.Drawing.Point(445, 345);
            this.btnReplaceData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReplaceData.MaximumSize = new System.Drawing.Size(200, 60);
            this.btnReplaceData.MinimumSize = new System.Drawing.Size(200, 60);
            this.btnReplaceData.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReplaceData.Name = "btnReplaceData";
            this.btnReplaceData.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReplaceData.Size = new System.Drawing.Size(200, 60);
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
            this.btnUseFilter.Location = new System.Drawing.Point(445, 410);
            this.btnUseFilter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUseFilter.MaximumSize = new System.Drawing.Size(80, 30);
            this.btnUseFilter.MinimumSize = new System.Drawing.Size(80, 30);
            this.btnUseFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUseFilter.Name = "btnUseFilter";
            this.btnUseFilter.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUseFilter.Size = new System.Drawing.Size(80, 30);
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
            this.btnCancleFilter.Location = new System.Drawing.Point(528, 410);
            this.btnCancleFilter.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancleFilter.MaximumSize = new System.Drawing.Size(115, 30);
            this.btnCancleFilter.MinimumSize = new System.Drawing.Size(115, 30);
            this.btnCancleFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancleFilter.Name = "btnCancleFilter";
            this.btnCancleFilter.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancleFilter.Size = new System.Drawing.Size(115, 30);
            this.btnCancleFilter.TabIndex = 40;
            this.btnCancleFilter.Text = "Cancle Filter";
            this.btnCancleFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancleFilter.UseAccentColor = false;
            this.btnCancleFilter.UseVisualStyleBackColor = true;
            this.btnCancleFilter.Click += new System.EventHandler(this.BtnCancleFilter_Click);
            // 
            // BoxCinemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.btnCancleFilter);
            this.Controls.Add(this.btnUseFilter);
            this.Controls.Add(this.btnReplaceData);
            this.Controls.Add(this.btnDeliteMovie);
            this.Controls.Add(this.btnEditCinema);
            this.Controls.Add(this.btnFormCartoon);
            this.Controls.Add(this.btnFormAnime);
            this.Controls.Add(this.btnFormSeries);
            this.Controls.Add(this.btnFormMovie);
            this.Controls.Add(this.cmbFilterWatch);
            this.Controls.Add(this.cmbFilterType);
            this.Controls.Add(this.dgvCinema);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(650, 450);
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "BoxCinemaForm";
            this.Text = "BoxCinema";
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BindingSource cinemaBindingSource;
        private OpenFileDialog openFileDialog;
        private DataGridView dgvCinema;
        private ComboBox cmbFilterType;
        private ComboBox cmbFilterWatch;
        private BindingSource filterModelBindingSource;
        private MaterialSkin.Controls.MaterialButton materialButton1asddasdasdasdddddddddddddddd;
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
    }
}
