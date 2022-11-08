
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
            this.btnFormMovie = new System.Windows.Forms.Button();
            this.btnDeliteMovie = new System.Windows.Forms.Button();
            this.btnFormSeries = new System.Windows.Forms.Button();
            this.cinemaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnEditCinema = new System.Windows.Forms.Button();
            this.btnPullingFile = new System.Windows.Forms.Button();
            this.btnFormAnime = new System.Windows.Forms.Button();
            this.btnFormCartoon = new System.Windows.Forms.Button();
            this.tabAllCinemaPage = new System.Windows.Forms.TabPage();
            this.dgvCinema = new System.Windows.Forms.DataGridView();
            this.NameCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchedCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSeriesPage = new System.Windows.Forms.TabPage();
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.SeriesTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberSeason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchedSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Series = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMoviePage = new System.Windows.Forms.TabPage();
            this.dgvMove = new System.Windows.Forms.DataGridView();
            this.MoveTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovePart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveWatched = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedMove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeMove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Box = new System.Windows.Forms.TabControl();
            this.tabAnimePage = new System.Windows.Forms.TabPage();
            this.dgvAnime = new System.Windows.Forms.DataGridView();
            this.AnimeTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberSeasonAnime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchedAnime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedAnime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeAnime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdAnime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeAnime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCartoonPage = new System.Windows.Forms.TabPage();
            this.dgvCartoon = new System.Windows.Forms.DataGridView();
            this.CartoonTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartoonPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchedCartoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedCartoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeCartoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCartoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cartoon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).BeginInit();
            this.tabAllCinemaPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinema)).BeginInit();
            this.tabSeriesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
            this.tabMoviePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMove)).BeginInit();
            this.Box.SuspendLayout();
            this.tabAnimePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnime)).BeginInit();
            this.tabCartoonPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartoon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFormMovie
            // 
            this.btnFormMovie.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFormMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormMovie.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormMovie.Location = new System.Drawing.Point(10, 300);
            this.btnFormMovie.Name = "btnFormMovie";
            this.btnFormMovie.Size = new System.Drawing.Size(85, 30);
            this.btnFormMovie.TabIndex = 1;
            this.btnFormMovie.Text = "Add Movie";
            this.btnFormMovie.UseVisualStyleBackColor = false;
            this.btnFormMovie.Click += new System.EventHandler(this.btnFormMovie_Click);
            // 
            // btnDeliteMovie
            // 
            this.btnDeliteMovie.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeliteMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeliteMovie.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeliteMovie.Location = new System.Drawing.Point(195, 340);
            this.btnDeliteMovie.Name = "btnDeliteMovie";
            this.btnDeliteMovie.Size = new System.Drawing.Size(170, 30);
            this.btnDeliteMovie.TabIndex = 2;
            this.btnDeliteMovie.Text = "Delite";
            this.btnDeliteMovie.UseVisualStyleBackColor = false;
            this.btnDeliteMovie.Click += new System.EventHandler(this.btnDeliteMovie_Click);
            // 
            // btnFormSeries
            // 
            this.btnFormSeries.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFormSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormSeries.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormSeries.Location = new System.Drawing.Point(100, 300);
            this.btnFormSeries.Name = "btnFormSeries";
            this.btnFormSeries.Size = new System.Drawing.Size(85, 30);
            this.btnFormSeries.TabIndex = 9;
            this.btnFormSeries.Text = "Add Series";
            this.btnFormSeries.UseVisualStyleBackColor = false;
            this.btnFormSeries.Click += new System.EventHandler(this.btnFormSeries_Click);
            // 
            // btnEditCinema
            // 
            this.btnEditCinema.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnEditCinema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCinema.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditCinema.Location = new System.Drawing.Point(10, 340);
            this.btnEditCinema.Name = "btnEditCinema";
            this.btnEditCinema.Size = new System.Drawing.Size(170, 30);
            this.btnEditCinema.TabIndex = 11;
            this.btnEditCinema.Text = "Edit";
            this.btnEditCinema.UseVisualStyleBackColor = false;
            this.btnEditCinema.Click += new System.EventHandler(this.btnEditRow_Click);
            // 
            // btnPullingFile
            // 
            this.btnPullingFile.BackColor = System.Drawing.Color.Azure;
            this.btnPullingFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPullingFile.Location = new System.Drawing.Point(385, 300);
            this.btnPullingFile.Name = "btnPullingFile";
            this.btnPullingFile.Size = new System.Drawing.Size(180, 70);
            this.btnPullingFile.TabIndex = 13;
            this.btnPullingFile.Text = "Load File";
            this.btnPullingFile.UseVisualStyleBackColor = false;
            this.btnPullingFile.Click += new System.EventHandler(this.btnPullingFile_Click);
            // 
            // btnFormAnime
            // 
            this.btnFormAnime.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFormAnime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormAnime.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormAnime.Location = new System.Drawing.Point(190, 300);
            this.btnFormAnime.Name = "btnFormAnime";
            this.btnFormAnime.Size = new System.Drawing.Size(85, 30);
            this.btnFormAnime.TabIndex = 14;
            this.btnFormAnime.Text = "Add Anime";
            this.btnFormAnime.UseVisualStyleBackColor = false;
            this.btnFormAnime.Click += new System.EventHandler(this.btnFormAnime_Click);
            // 
            // btnFormCartoon
            // 
            this.btnFormCartoon.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFormCartoon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormCartoon.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormCartoon.Location = new System.Drawing.Point(280, 300);
            this.btnFormCartoon.Name = "btnFormCartoon";
            this.btnFormCartoon.Size = new System.Drawing.Size(85, 30);
            this.btnFormCartoon.TabIndex = 15;
            this.btnFormCartoon.Text = "Add Cartoon";
            this.btnFormCartoon.UseVisualStyleBackColor = false;
            this.btnFormCartoon.Click += new System.EventHandler(this.btnFormCartoon_Click);
            // 
            // tabAllCinemaPage
            // 
            this.tabAllCinemaPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabAllCinemaPage.Controls.Add(this.dgvCinema);
            this.tabAllCinemaPage.Location = new System.Drawing.Point(4, 24);
            this.tabAllCinemaPage.Name = "tabAllCinemaPage";
            this.tabAllCinemaPage.Size = new System.Drawing.Size(547, 252);
            this.tabAllCinemaPage.TabIndex = 5;
            this.tabAllCinemaPage.Text = "All Cinema";
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
            this.dgvCinema.Location = new System.Drawing.Point(3, 0);
            this.dgvCinema.MaximumSize = new System.Drawing.Size(543, 250);
            this.dgvCinema.MinimumSize = new System.Drawing.Size(543, 250);
            this.dgvCinema.Name = "dgvCinema";
            this.dgvCinema.ReadOnly = true;
            this.dgvCinema.RowTemplate.Height = 25;
            this.dgvCinema.Size = new System.Drawing.Size(543, 250);
            this.dgvCinema.TabIndex = 12;
            this.dgvCinema.Tag = "Cinema";
            // 
            // NameCinema
            // 
            this.NameCinema.HeaderText = "Title";
            this.NameCinema.Name = "NameCinema";
            this.NameCinema.ReadOnly = true;
            // 
            // NumberCinema
            // 
            this.NumberCinema.HeaderText = "Season/Part";
            this.NumberCinema.Name = "NumberCinema";
            this.NumberCinema.ReadOnly = true;
            // 
            // WatchedCinema
            // 
            this.WatchedCinema.HeaderText = "The Watched Cinema";
            this.WatchedCinema.Name = "WatchedCinema";
            this.WatchedCinema.ReadOnly = true;
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
            // tabSeriesPage
            // 
            this.tabSeriesPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabSeriesPage.Controls.Add(this.dgvSeries);
            this.tabSeriesPage.Location = new System.Drawing.Point(4, 24);
            this.tabSeriesPage.Name = "tabSeriesPage";
            this.tabSeriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeriesPage.Size = new System.Drawing.Size(547, 252);
            this.tabSeriesPage.TabIndex = 1;
            this.tabSeriesPage.Text = "Series";
            // 
            // dgvSeries
            // 
            this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeriesTitle,
            this.NumberSeason,
            this.WatchedSeries,
            this.DataWatchedSeries,
            this.GradeSeries,
            this.IdSeries,
            this.Series});
            this.dgvSeries.Location = new System.Drawing.Point(3, 0);
            this.dgvSeries.MaximumSize = new System.Drawing.Size(543, 250);
            this.dgvSeries.MinimumSize = new System.Drawing.Size(543, 250);
            this.dgvSeries.Name = "dgvSeries";
            this.dgvSeries.ReadOnly = true;
            this.dgvSeries.RowTemplate.Height = 25;
            this.dgvSeries.Size = new System.Drawing.Size(543, 250);
            this.dgvSeries.TabIndex = 12;
            this.dgvSeries.Tag = "Series";
            // 
            // SeriesTitle
            // 
            this.SeriesTitle.HeaderText = "Title";
            this.SeriesTitle.Name = "SeriesTitle";
            this.SeriesTitle.ReadOnly = true;
            // 
            // NumberSeason
            // 
            this.NumberSeason.HeaderText = "Season";
            this.NumberSeason.Name = "NumberSeason";
            this.NumberSeason.ReadOnly = true;
            // 
            // WatchedSeries
            // 
            this.WatchedSeries.HeaderText = "The Watched Cinema";
            this.WatchedSeries.Name = "WatchedSeries";
            this.WatchedSeries.ReadOnly = true;
            // 
            // DataWatchedSeries
            // 
            this.DataWatchedSeries.HeaderText = "Data";
            this.DataWatchedSeries.Name = "DataWatchedSeries";
            this.DataWatchedSeries.ReadOnly = true;
            // 
            // GradeSeries
            // 
            this.GradeSeries.HeaderText = "Grade";
            this.GradeSeries.Name = "GradeSeries";
            this.GradeSeries.ReadOnly = true;
            // 
            // IdSeries
            // 
            this.IdSeries.HeaderText = "ID";
            this.IdSeries.Name = "IdSeries";
            this.IdSeries.ReadOnly = true;
            this.IdSeries.Visible = false;
            // 
            // Series
            // 
            this.Series.HeaderText = "Type";
            this.Series.Name = "Series";
            this.Series.ReadOnly = true;
            this.Series.Visible = false;
            // 
            // tabMovePage
            // 
            this.tabMoviePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabMoviePage.Controls.Add(this.dgvMove);
            this.tabMoviePage.Location = new System.Drawing.Point(4, 24);
            this.tabMoviePage.Name = "tabMovePage";
            this.tabMoviePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMoviePage.Size = new System.Drawing.Size(547, 252);
            this.tabMoviePage.TabIndex = 0;
            this.tabMoviePage.Text = "Move";
            // 
            // dgvMove
            // 
            this.dgvMove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MoveTitle,
            this.MovePart,
            this.MoveWatched,
            this.DataWatchedMove,
            this.GradeMove,
            this.IdMove,
            this.Movie});
            this.dgvMove.Location = new System.Drawing.Point(3, 0);
            this.dgvMove.MaximumSize = new System.Drawing.Size(543, 250);
            this.dgvMove.MinimumSize = new System.Drawing.Size(543, 250);
            this.dgvMove.Name = "dgvMove";
            this.dgvMove.ReadOnly = true;
            this.dgvMove.RowTemplate.Height = 25;
            this.dgvMove.Size = new System.Drawing.Size(543, 250);
            this.dgvMove.TabIndex = 11;
            this.dgvMove.Tag = "Move";
            // 
            // MoveTitle
            // 
            this.MoveTitle.HeaderText = "Title";
            this.MoveTitle.Name = "MoveTitle";
            this.MoveTitle.ReadOnly = true;
            // 
            // MovePart
            // 
            this.MovePart.HeaderText = "Part";
            this.MovePart.Name = "MovePart";
            this.MovePart.ReadOnly = true;
            // 
            // MoveWatched
            // 
            this.MoveWatched.HeaderText = "The Watched Move";
            this.MoveWatched.Name = "MoveWatched";
            this.MoveWatched.ReadOnly = true;
            // 
            // DataWatchedMove
            // 
            this.DataWatchedMove.HeaderText = "Data";
            this.DataWatchedMove.Name = "DataWatchedMove";
            this.DataWatchedMove.ReadOnly = true;
            // 
            // GradeMove
            // 
            this.GradeMove.HeaderText = "Grade";
            this.GradeMove.Name = "GradeMove";
            this.GradeMove.ReadOnly = true;
            // 
            // IdMove
            // 
            this.IdMove.HeaderText = "ID";
            this.IdMove.Name = "IdMove";
            this.IdMove.ReadOnly = true;
            this.IdMove.Visible = false;
            // 
            // Movie
            // 
            this.Movie.HeaderText = "Type";
            this.Movie.Name = "Movie";
            this.Movie.ReadOnly = true;
            this.Movie.Visible = false;
            // 
            // Box
            // 
            this.Box.Controls.Add(this.tabMoviePage);
            this.Box.Controls.Add(this.tabSeriesPage);
            this.Box.Controls.Add(this.tabAnimePage);
            this.Box.Controls.Add(this.tabCartoonPage);
            this.Box.Controls.Add(this.tabAllCinemaPage);
            this.Box.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Box.ItemSize = new System.Drawing.Size(50, 20);
            this.Box.Location = new System.Drawing.Point(10, 12);
            this.Box.Name = "Box";
            this.Box.SelectedIndex = 0;
            this.Box.Size = new System.Drawing.Size(555, 280);
            this.Box.TabIndex = 10;
            this.Box.Tag = "Cinema";
            // 
            // tabAnimePage
            // 
            this.tabAnimePage.Controls.Add(this.dgvAnime);
            this.tabAnimePage.Location = new System.Drawing.Point(4, 24);
            this.tabAnimePage.Name = "tabAnimePage";
            this.tabAnimePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnimePage.Size = new System.Drawing.Size(547, 252);
            this.tabAnimePage.TabIndex = 3;
            this.tabAnimePage.Text = "Anime";
            this.tabAnimePage.UseVisualStyleBackColor = true;
            // 
            // dgvAnime
            // 
            this.dgvAnime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnimeTitle,
            this.NumberSeasonAnime,
            this.WatchedAnime,
            this.DataWatchedAnime,
            this.GradeAnime,
            this.IdAnime,
            this.TypeAnime});
            this.dgvAnime.Location = new System.Drawing.Point(3, 0);
            this.dgvAnime.MaximumSize = new System.Drawing.Size(543, 250);
            this.dgvAnime.MinimumSize = new System.Drawing.Size(543, 250);
            this.dgvAnime.Name = "dgvAnime";
            this.dgvAnime.ReadOnly = true;
            this.dgvAnime.RowTemplate.Height = 25;
            this.dgvAnime.Size = new System.Drawing.Size(543, 250);
            this.dgvAnime.TabIndex = 14;
            this.dgvAnime.Tag = "Series";
            // 
            // AnimeTitle
            // 
            this.AnimeTitle.HeaderText = "Title";
            this.AnimeTitle.Name = "AnimeTitle";
            this.AnimeTitle.ReadOnly = true;
            // 
            // NumberSeasonAnime
            // 
            this.NumberSeasonAnime.HeaderText = "Season";
            this.NumberSeasonAnime.Name = "NumberSeasonAnime";
            this.NumberSeasonAnime.ReadOnly = true;
            // 
            // WatchedAnime
            // 
            this.WatchedAnime.HeaderText = "The Watched Anime";
            this.WatchedAnime.Name = "WatchedAnime";
            this.WatchedAnime.ReadOnly = true;
            // 
            // DataWatchedAnime
            // 
            this.DataWatchedAnime.HeaderText = "Data";
            this.DataWatchedAnime.Name = "DataWatchedAnime";
            this.DataWatchedAnime.ReadOnly = true;
            // 
            // GradeAnime
            // 
            this.GradeAnime.HeaderText = "Grade";
            this.GradeAnime.Name = "GradeAnime";
            this.GradeAnime.ReadOnly = true;
            // 
            // IdAnime
            // 
            this.IdAnime.HeaderText = "ID";
            this.IdAnime.Name = "IdAnime";
            this.IdAnime.ReadOnly = true;
            this.IdAnime.Visible = false;
            // 
            // TypeAnime
            // 
            this.TypeAnime.HeaderText = "Type";
            this.TypeAnime.Name = "TypeAnime";
            this.TypeAnime.ReadOnly = true;
            this.TypeAnime.Visible = false;
            // 
            // tabCartoonPage
            // 
            this.tabCartoonPage.Controls.Add(this.dgvCartoon);
            this.tabCartoonPage.Location = new System.Drawing.Point(4, 24);
            this.tabCartoonPage.Name = "tabCartoonPage";
            this.tabCartoonPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabCartoonPage.Size = new System.Drawing.Size(547, 252);
            this.tabCartoonPage.TabIndex = 4;
            this.tabCartoonPage.Text = "Cartoon";
            this.tabCartoonPage.UseVisualStyleBackColor = true;
            // 
            // dgvCartoon
            // 
            this.dgvCartoon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartoon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CartoonTitle,
            this.CartoonPart,
            this.WatchedCartoon,
            this.DataWatchedCartoon,
            this.GradeCartoon,
            this.IdCartoon,
            this.Cartoon});
            this.dgvCartoon.Location = new System.Drawing.Point(3, 0);
            this.dgvCartoon.MaximumSize = new System.Drawing.Size(543, 250);
            this.dgvCartoon.MinimumSize = new System.Drawing.Size(543, 250);
            this.dgvCartoon.Name = "dgvCartoon";
            this.dgvCartoon.ReadOnly = true;
            this.dgvCartoon.RowTemplate.Height = 25;
            this.dgvCartoon.Size = new System.Drawing.Size(543, 250);
            this.dgvCartoon.TabIndex = 12;
            this.dgvCartoon.Tag = "Move";
            // 
            // CartoonTitle
            // 
            this.CartoonTitle.HeaderText = "Title";
            this.CartoonTitle.Name = "CartoonTitle";
            this.CartoonTitle.ReadOnly = true;
            // 
            // CartoonPart
            // 
            this.CartoonPart.HeaderText = "Part";
            this.CartoonPart.Name = "CartoonPart";
            this.CartoonPart.ReadOnly = true;
            // 
            // WatchedCartoon
            // 
            this.WatchedCartoon.HeaderText = "The Watched Cartoon";
            this.WatchedCartoon.Name = "WatchedCartoon";
            this.WatchedCartoon.ReadOnly = true;
            // 
            // DataWatchedCartoon
            // 
            this.DataWatchedCartoon.HeaderText = "Data";
            this.DataWatchedCartoon.Name = "DataWatchedCartoon";
            this.DataWatchedCartoon.ReadOnly = true;
            // 
            // GradeCartoon
            // 
            this.GradeCartoon.HeaderText = "Grade";
            this.GradeCartoon.Name = "GradeCartoon";
            this.GradeCartoon.ReadOnly = true;
            // 
            // IdCartoon
            // 
            this.IdCartoon.HeaderText = "ID";
            this.IdCartoon.Name = "IdCartoon";
            this.IdCartoon.ReadOnly = true;
            this.IdCartoon.Visible = false;
            // 
            // Cartoon
            // 
            this.Cartoon.HeaderText = "Type";
            this.Cartoon.Name = "Cartoon";
            this.Cartoon.ReadOnly = true;
            this.Cartoon.Visible = false;
            // 
            // BoxCinemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(574, 381);
            this.Controls.Add(this.Box);
            this.Controls.Add(this.btnFormCartoon);
            this.Controls.Add(this.btnFormAnime);
            this.Controls.Add(this.btnPullingFile);
            this.Controls.Add(this.btnEditCinema);
            this.Controls.Add(this.btnFormSeries);
            this.Controls.Add(this.btnDeliteMovie);
            this.Controls.Add(this.btnFormMovie);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(590, 420);
            this.MinimumSize = new System.Drawing.Size(590, 420);
            this.Name = "BoxCinemaForm";
            this.Text = "BoxCinema";
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).EndInit();
            this.tabAllCinemaPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinema)).EndInit();
            this.tabSeriesPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
            this.tabMoviePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMove)).EndInit();
            this.Box.ResumeLayout(false);
            this.tabAnimePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnime)).EndInit();
            this.tabCartoonPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartoon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnFormMovie;
        private Button btnDeliteMovie;
        private Button btnFormSeries;
        private BindingSource cinemaBindingSource;
        private Button btnEditCinema;
        private Button btnPullingFile;
        private Button btnFormAnime;
        private Button btnFormCartoon;
        private TabPage tabAllCinemaPage;
        private DataGridView dgvCinema;
        private TabPage tabSeriesPage;
        private DataGridView dgvSeries;
        private TabPage tabMoviePage;
        private DataGridView dgvMove;
        private TabControl Box;
        private TabPage tabAnimePage;
        private DataGridView dgvAnime;
        private TabPage tabCartoonPage;
        private DataGridView dgvCartoon;
        private DataGridViewTextBoxColumn SeriesTitle;
        private DataGridViewTextBoxColumn NumberSeason;
        private DataGridViewTextBoxColumn WatchedSeries;
        private DataGridViewTextBoxColumn DataWatchedSeries;
        private DataGridViewTextBoxColumn GradeSeries;
        private DataGridViewTextBoxColumn IdSeries;
        private DataGridViewTextBoxColumn Series;
        private DataGridViewTextBoxColumn CartoonTitle;
        private DataGridViewTextBoxColumn CartoonPart;
        private DataGridViewTextBoxColumn WatchedCartoon;
        private DataGridViewTextBoxColumn DataWatchedCartoon;
        private DataGridViewTextBoxColumn GradeCartoon;
        private DataGridViewTextBoxColumn IdCartoon;
        private DataGridViewTextBoxColumn Cartoon;
        private DataGridViewTextBoxColumn MoveTitle;
        private DataGridViewTextBoxColumn MovePart;
        private DataGridViewTextBoxColumn MoveWatched;
        private DataGridViewTextBoxColumn DataWatchedMove;
        private DataGridViewTextBoxColumn GradeMove;
        private DataGridViewTextBoxColumn IdMove;
        private DataGridViewTextBoxColumn Movie;
        private DataGridViewTextBoxColumn AnimeTitle;
        private DataGridViewTextBoxColumn NumberSeasonAnime;
        private DataGridViewTextBoxColumn WatchedAnime;
        private DataGridViewTextBoxColumn DataWatchedAnime;
        private DataGridViewTextBoxColumn GradeAnime;
        private DataGridViewTextBoxColumn IdAnime;
        private DataGridViewTextBoxColumn TypeAnime;
        private DataGridViewTextBoxColumn NameCinema;
        private DataGridViewTextBoxColumn NumberCinema;
        private DataGridViewTextBoxColumn WatchedCinema;
        private DataGridViewTextBoxColumn DataWatchedCinema;
        private DataGridViewTextBoxColumn GradeCinema;
        private DataGridViewTextBoxColumn IdCinema;
        private DataGridViewTextBoxColumn Cinema;
    }
}
