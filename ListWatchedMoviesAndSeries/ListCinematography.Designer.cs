using ListWatchedMoviesAndSeries.Models.View;

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
            this.BoxName = new System.Windows.Forms.TabControl();
            this.tabMovePage = new System.Windows.Forms.TabPage();
            this.dgvMove = new System.Windows.Forms.DataGridView();
            this.MoveTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovePart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoveWatched = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedMove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeMove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSeriesPage = new System.Windows.Forms.TabPage();
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.SeriesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberSeason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchedSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAllCinemaPage = new System.Windows.Forms.TabPage();
            this.dgvCinema = new System.Windows.Forms.DataGridView();
            this.NameCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchedCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cinemaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BoxName.SuspendLayout();
            this.tabMovePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMove)).BeginInit();
            this.tabSeriesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
            this.tabAllCinemaPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFormMovie
            // 
            this.btnFormMovie.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFormMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormMovie.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormMovie.Location = new System.Drawing.Point(10, 300);
            this.btnFormMovie.Name = "btnFormMovie";
            this.btnFormMovie.Size = new System.Drawing.Size(120, 30);
            this.btnFormMovie.TabIndex = 1;
            this.btnFormMovie.Text = "Add Movie";
            this.btnFormMovie.UseVisualStyleBackColor = false;
            this.btnFormMovie.Click += new System.EventHandler(this.btnFormMovie_Click);
            // 
            // btnDeliteMovie
            // 
            this.btnDeliteMovie.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDeliteMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeliteMovie.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeliteMovie.Location = new System.Drawing.Point(445, 300);
            this.btnDeliteMovie.Name = "btnDeliteMovie";
            this.btnDeliteMovie.Size = new System.Drawing.Size(120, 30);
            this.btnDeliteMovie.TabIndex = 2;
            this.btnDeliteMovie.Text = "Delite Cinema";
            this.btnDeliteMovie.UseVisualStyleBackColor = false;
            this.btnDeliteMovie.Click += new System.EventHandler(this.btnDeliteMovie_Click);
            // 
            // btnFormSeries
            // 
            this.btnFormSeries.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFormSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormSeries.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormSeries.Location = new System.Drawing.Point(228, 300);
            this.btnFormSeries.Name = "btnFormSeries";
            this.btnFormSeries.Size = new System.Drawing.Size(120, 30);
            this.btnFormSeries.TabIndex = 9;
            this.btnFormSeries.Text = "Add Series";
            this.btnFormSeries.UseVisualStyleBackColor = false;
            this.btnFormSeries.Click += new System.EventHandler(this.btnFormSeries_Click);
            // 
            // BoxName
            // 
            this.BoxName.Controls.Add(this.tabMovePage);
            this.BoxName.Controls.Add(this.tabSeriesPage);
            this.BoxName.Controls.Add(this.tabAllCinemaPage);
            this.BoxName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BoxName.ItemSize = new System.Drawing.Size(50, 20);
            this.BoxName.Location = new System.Drawing.Point(10, 12);
            this.BoxName.Name = "BoxName";
            this.BoxName.SelectedIndex = 0;
            this.BoxName.Size = new System.Drawing.Size(555, 280);
            this.BoxName.TabIndex = 10;
            // 
            // tabMovePage
            // 
            this.tabMovePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabMovePage.Controls.Add(this.dgvMove);
            this.tabMovePage.Location = new System.Drawing.Point(4, 24);
            this.tabMovePage.Name = "tabMovePage";
            this.tabMovePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMovePage.Size = new System.Drawing.Size(547, 252);
            this.tabMovePage.TabIndex = 0;
            this.tabMovePage.Text = "Move/Cartoon";
            // 
            // dgvMove
            // 
            this.dgvMove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMove.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MoveTitle,
            this.MovePart,
            this.MoveWatched,
            this.DataWatchedMove,
            this.GradeMove});
            this.dgvMove.Location = new System.Drawing.Point(3, 0);
            this.dgvMove.MaximumSize = new System.Drawing.Size(543, 250);
            this.dgvMove.MinimumSize = new System.Drawing.Size(543, 250);
            this.dgvMove.Name = "dgvMove";
            this.dgvMove.RowTemplate.Height = 25;
            this.dgvMove.Size = new System.Drawing.Size(543, 250);
            this.dgvMove.TabIndex = 11;
            // 
            // MoveTitle
            // 
            this.MoveTitle.HeaderText = "Title";
            this.MoveTitle.Name = "MoveTitle";
            // 
            // MovePart
            // 
            this.MovePart.HeaderText = "Part";
            this.MovePart.Name = "MovePart";
            // 
            // MoveWatched
            // 
            this.MoveWatched.HeaderText = "The Watched Cinema";
            this.MoveWatched.Name = "MoveWatched";
            // 
            // DataWatchedMove
            // 
            this.DataWatchedMove.HeaderText = "Data";
            this.DataWatchedMove.Name = "DataWatchedMove";
            // 
            // GradeMove
            // 
            this.GradeMove.HeaderText = "Grade";
            this.GradeMove.Name = "GradeMove";
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
            this.SeriesName,
            this.NumberSeason,
            this.WatchedSeries,
            this.DataWatchedSeries,
            this.GradeSeries});
            this.dgvSeries.Location = new System.Drawing.Point(3, 0);
            this.dgvSeries.MaximumSize = new System.Drawing.Size(543, 250);
            this.dgvSeries.MinimumSize = new System.Drawing.Size(543, 250);
            this.dgvSeries.Name = "dgvSeries";
            this.dgvSeries.RowTemplate.Height = 25;
            this.dgvSeries.Size = new System.Drawing.Size(543, 250);
            this.dgvSeries.TabIndex = 12;
            // 
            // SeriesName
            // 
            this.SeriesName.HeaderText = "Title";
            this.SeriesName.Name = "SeriesName";
            // 
            // NumberSeason
            // 
            this.NumberSeason.HeaderText = "Season";
            this.NumberSeason.Name = "NumberSeason";
            // 
            // WatchedSeries
            // 
            this.WatchedSeries.HeaderText = "The Watched Cinema";
            this.WatchedSeries.Name = "WatchedSeries";
            // 
            // DataWatchedSeries
            // 
            this.DataWatchedSeries.HeaderText = "Data";
            this.DataWatchedSeries.Name = "DataWatchedSeries";
            // 
            // GradeSeries
            // 
            this.GradeSeries.HeaderText = "Grade";
            this.GradeSeries.Name = "GradeSeries";
            // 
            // tabAllCinemaPage
            // 
            this.tabAllCinemaPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabAllCinemaPage.Controls.Add(this.dgvCinema);
            this.tabAllCinemaPage.Location = new System.Drawing.Point(4, 24);
            this.tabAllCinemaPage.Name = "tabAllCinemaPage";
            this.tabAllCinemaPage.Size = new System.Drawing.Size(547, 252);
            this.tabAllCinemaPage.TabIndex = 2;
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
            this.GradeCinema});
            this.dgvCinema.Location = new System.Drawing.Point(3, 0);
            this.dgvCinema.MaximumSize = new System.Drawing.Size(543, 250);
            this.dgvCinema.MinimumSize = new System.Drawing.Size(543, 250);
            this.dgvCinema.Name = "dgvCinema";
            this.dgvCinema.RowTemplate.Height = 25;
            this.dgvCinema.Size = new System.Drawing.Size(543, 250);
            this.dgvCinema.TabIndex = 12;
            // 
            // NameCinema
            // 
            this.NameCinema.HeaderText = "Title";
            this.NameCinema.Name = "NameCinema";
            // 
            // NumberCinema
            // 
            this.NumberCinema.HeaderText = "Season/Part";
            this.NumberCinema.Name = "NumberCinema";
            // 
            // WatchedCinema
            // 
            this.WatchedCinema.HeaderText = "The Watched Cinema";
            this.WatchedCinema.Name = "WatchedCinema";
            // 
            // DataWatchedCinema
            // 
            this.DataWatchedCinema.HeaderText = "Data";
            this.DataWatchedCinema.Name = "DataWatchedCinema";
            // 
            // GradeCinema
            // 
            this.GradeCinema.HeaderText = "Grade";
            this.GradeCinema.Name = "GradeCinema";
            // 
            // BoxCinemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(574, 341);
            this.Controls.Add(this.BoxName);
            this.Controls.Add(this.btnFormSeries);
            this.Controls.Add(this.btnDeliteMovie);
            this.Controls.Add(this.btnFormMovie);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(590, 380);
            this.MinimumSize = new System.Drawing.Size(590, 380);
            this.Name = "BoxCinemaForm";
            this.Text = "BoxCinema";
            this.BoxName.ResumeLayout(false);
            this.tabMovePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMove)).EndInit();
            this.tabSeriesPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
            this.tabAllCinemaPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnFormMovie;
        private Button btnDeliteMovie;
        private Button btnFormSeries;
        private TabControl BoxName;
        private TabPage tabMovePage;
        private TabPage tabSeriesPage;
        private TabPage tabAllCinemaPage;
        private DataGridView dgvMove;
        private BindingSource cinemaBindingSource;
        private DataGridView dgvSeries;
        private DataGridView dgvCinema;
        private DataGridViewTextBoxColumn MoveTitle;
        private DataGridViewTextBoxColumn MovePart;
        private DataGridViewTextBoxColumn MoveWatched;
        private DataGridViewTextBoxColumn DataWatchedMove;
        private DataGridViewTextBoxColumn GradeMove;
        private DataGridViewTextBoxColumn SeriesName;
        private DataGridViewTextBoxColumn NumberSeason;
        private DataGridViewTextBoxColumn WatchedSeries;
        private DataGridViewTextBoxColumn DataWatchedSeries;
        private DataGridViewTextBoxColumn GradeSeries;
        private DataGridViewTextBoxColumn NameCinema;
        private DataGridViewTextBoxColumn NumberCinema;
        private DataGridViewTextBoxColumn WatchedCinema;
        private DataGridViewTextBoxColumn DataWatchedCinema;
        private DataGridViewTextBoxColumn GradeCinema;
    }
}