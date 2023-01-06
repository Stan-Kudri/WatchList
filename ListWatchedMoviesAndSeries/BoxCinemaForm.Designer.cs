
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
            this.mrbFormMovie = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnFormSeries = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnFormAnime = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnFormCartoon = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnEditCinema = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDeliteMovie = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnReplaceData = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnUseFilter = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCancleFilter = new MaterialSkin.Controls.MaterialRaisedButton();
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
            this.dgvCinema.MaximumSize = new System.Drawing.Size(620, 270);
            this.dgvCinema.MinimumSize = new System.Drawing.Size(620, 270);
            this.dgvCinema.Name = "dgvCinema";
            this.dgvCinema.ReadOnly = true;
            this.dgvCinema.RowTemplate.Height = 25;
            this.dgvCinema.Size = new System.Drawing.Size(620, 270);
            this.dgvCinema.TabIndex = 16;
            this.dgvCinema.Tag = "Cinema";
            // 
            // NameCinema
            // 
            this.NameCinema.FillWeight = 150F;
            this.NameCinema.HeaderText = "Title";
            this.NameCinema.Name = "NameCinema";
            this.NameCinema.ReadOnly = true;
            this.NameCinema.Width = 150;
            // 
            // NumberCinema
            // 
            this.NumberCinema.HeaderText = "Season/Part";
            this.NumberCinema.Name = "NumberCinema";
            this.NumberCinema.ReadOnly = true;
            // 
            // WatchedCinema
            // 
            this.WatchedCinema.FillWeight = 126F;
            this.WatchedCinema.HeaderText = "The Watched Cinema";
            this.WatchedCinema.Name = "WatchedCinema";
            this.WatchedCinema.ReadOnly = true;
            this.WatchedCinema.Width = 126;
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
            this.cmbFilterType.Location = new System.Drawing.Point(8, 416);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(206, 23);
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
            this.cmbFilterWatch.Location = new System.Drawing.Point(220, 416);
            this.cmbFilterWatch.Name = "cmbFilterWatch";
            this.cmbFilterWatch.Size = new System.Drawing.Size(206, 23);
            this.cmbFilterWatch.TabIndex = 18;
            // 
            // mrbFormMovie
            // 
            this.mrbFormMovie.Depth = 0;
            this.mrbFormMovie.Font = new System.Drawing.Font("Segoe UI", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mrbFormMovie.Location = new System.Drawing.Point(8, 352);
            this.mrbFormMovie.MouseState = MaterialSkin.MouseState.HOVER;
            this.mrbFormMovie.Name = "mrbFormMovie";
            this.mrbFormMovie.Primary = true;
            this.mrbFormMovie.Size = new System.Drawing.Size(100, 25);
            this.mrbFormMovie.TabIndex = 23;
            this.mrbFormMovie.Text = "Add Movie";
            this.mrbFormMovie.UseVisualStyleBackColor = true;
            this.mrbFormMovie.Click += new System.EventHandler(this.BtnFormMovie_Click);
            // 
            // btnFormSeries
            // 
            this.btnFormSeries.Depth = 0;
            this.btnFormSeries.Location = new System.Drawing.Point(114, 352);
            this.btnFormSeries.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormSeries.Name = "btnFormSeries";
            this.btnFormSeries.Primary = true;
            this.btnFormSeries.Size = new System.Drawing.Size(100, 25);
            this.btnFormSeries.TabIndex = 24;
            this.btnFormSeries.Text = "Add Series";
            this.btnFormSeries.UseVisualStyleBackColor = true;
            this.btnFormSeries.Click += new System.EventHandler(this.BtnFormSeries_Click);
            // 
            // btnFormAnime
            // 
            this.btnFormAnime.Depth = 0;
            this.btnFormAnime.Location = new System.Drawing.Point(220, 352);
            this.btnFormAnime.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormAnime.Name = "btnFormAnime";
            this.btnFormAnime.Primary = true;
            this.btnFormAnime.Size = new System.Drawing.Size(100, 25);
            this.btnFormAnime.TabIndex = 25;
            this.btnFormAnime.Text = "Add Anime";
            this.btnFormAnime.UseVisualStyleBackColor = true;
            this.btnFormAnime.Click += new System.EventHandler(this.BtnFormAnime_Click);
            // 
            // btnFormCartoon
            // 
            this.btnFormCartoon.Depth = 0;
            this.btnFormCartoon.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormCartoon.Location = new System.Drawing.Point(326, 352);
            this.btnFormCartoon.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFormCartoon.Name = "btnFormCartoon";
            this.btnFormCartoon.Primary = true;
            this.btnFormCartoon.Size = new System.Drawing.Size(100, 25);
            this.btnFormCartoon.TabIndex = 26;
            this.btnFormCartoon.Text = "Add Cartoon";
            this.btnFormCartoon.UseVisualStyleBackColor = true;
            this.btnFormCartoon.Click += new System.EventHandler(this.BtnFormCartoon_Click);
            // 
            // btnEditCinema
            // 
            this.btnEditCinema.Depth = 0;
            this.btnEditCinema.Location = new System.Drawing.Point(8, 382);
            this.btnEditCinema.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEditCinema.Name = "btnEditCinema";
            this.btnEditCinema.Primary = true;
            this.btnEditCinema.Size = new System.Drawing.Size(206, 25);
            this.btnEditCinema.TabIndex = 27;
            this.btnEditCinema.Text = "Edit";
            this.btnEditCinema.UseVisualStyleBackColor = true;
            this.btnEditCinema.Click += new System.EventHandler(this.BtnEditRow_Click);
            // 
            // btnDeliteMovie
            // 
            this.btnDeliteMovie.Depth = 0;
            this.btnDeliteMovie.Location = new System.Drawing.Point(220, 383);
            this.btnDeliteMovie.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDeliteMovie.Name = "btnDeliteMovie";
            this.btnDeliteMovie.Primary = true;
            this.btnDeliteMovie.Size = new System.Drawing.Size(206, 24);
            this.btnDeliteMovie.TabIndex = 28;
            this.btnDeliteMovie.Text = "Delite";
            this.btnDeliteMovie.UseVisualStyleBackColor = true;
            this.btnDeliteMovie.Click += new System.EventHandler(this.BtnDeliteMovie_Click);
            // 
            // btnReplaceData
            // 
            this.btnReplaceData.Depth = 0;
            this.btnReplaceData.Location = new System.Drawing.Point(430, 352);
            this.btnReplaceData.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReplaceData.Name = "btnReplaceData";
            this.btnReplaceData.Primary = true;
            this.btnReplaceData.Size = new System.Drawing.Size(195, 55);
            this.btnReplaceData.TabIndex = 29;
            this.btnReplaceData.Text = "Replace data from file ";
            this.btnReplaceData.UseVisualStyleBackColor = true;
            this.btnReplaceData.Click += new System.EventHandler(this.BtnReplaceFile_Click);
            // 
            // btnUseFilter
            // 
            this.btnUseFilter.Depth = 0;
            this.btnUseFilter.Location = new System.Drawing.Point(430, 414);
            this.btnUseFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUseFilter.Name = "btnUseFilter";
            this.btnUseFilter.Primary = true;
            this.btnUseFilter.Size = new System.Drawing.Size(80, 25);
            this.btnUseFilter.TabIndex = 30;
            this.btnUseFilter.Text = "Use Filter";
            this.btnUseFilter.UseVisualStyleBackColor = true;
            this.btnUseFilter.Click += new System.EventHandler(this.BtnUseFilter_Click);
            // 
            // btnCancleFilter
            // 
            this.btnCancleFilter.Depth = 0;
            this.btnCancleFilter.Location = new System.Drawing.Point(515, 414);
            this.btnCancleFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancleFilter.Name = "btnCancleFilter";
            this.btnCancleFilter.Primary = true;
            this.btnCancleFilter.Size = new System.Drawing.Size(110, 25);
            this.btnCancleFilter.TabIndex = 31;
            this.btnCancleFilter.Text = "Cancle Filter";
            this.btnCancleFilter.UseVisualStyleBackColor = true;
            this.btnCancleFilter.Click += new System.EventHandler(this.BtnCancleFilter_Click);
            // 
            // BoxCinemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(630, 450);
            this.Controls.Add(this.btnCancleFilter);
            this.Controls.Add(this.btnUseFilter);
            this.Controls.Add(this.btnReplaceData);
            this.Controls.Add(this.btnDeliteMovie);
            this.Controls.Add(this.btnEditCinema);
            this.Controls.Add(this.btnFormCartoon);
            this.Controls.Add(this.btnFormAnime);
            this.Controls.Add(this.btnFormSeries);
            this.Controls.Add(this.mrbFormMovie);
            this.Controls.Add(this.cmbFilterWatch);
            this.Controls.Add(this.cmbFilterType);
            this.Controls.Add(this.dgvCinema);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(630, 450);
            this.MinimumSize = new System.Drawing.Size(630, 450);
            this.Name = "BoxCinemaForm";
            this.Text = "BoxCinema";
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BindingSource cinemaBindingSource;
        private OpenFileDialog openFileDialog;
        private DataGridView dgvCinema;
        private ComboBox cmbFilterType;
        private ComboBox cmbFilterWatch;
        private BindingSource filterModelBindingSource;
        private MaterialSkin.Controls.MaterialRaisedButton mrbFormMovie;
        private MaterialSkin.Controls.MaterialRaisedButton btnFormSeries;
        private MaterialSkin.Controls.MaterialRaisedButton btnFormAnime;
        private MaterialSkin.Controls.MaterialRaisedButton btnFormCartoon;
        private DataGridViewTextBoxColumn NameCinema;
        private DataGridViewTextBoxColumn NumberCinema;
        private DataGridViewTextBoxColumn WatchedCinema;
        private DataGridViewTextBoxColumn DataWatchedCinema;
        private DataGridViewTextBoxColumn GradeCinema;
        private DataGridViewTextBoxColumn IdCinema;
        private DataGridViewTextBoxColumn Cinema;
        private MaterialSkin.Controls.MaterialRaisedButton btnEditCinema;
        private MaterialSkin.Controls.MaterialRaisedButton btnDeliteMovie;
        private MaterialSkin.Controls.MaterialRaisedButton btnReplaceData;
        private MaterialSkin.Controls.MaterialRaisedButton btnUseFilter;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancleFilter;
    }
}
