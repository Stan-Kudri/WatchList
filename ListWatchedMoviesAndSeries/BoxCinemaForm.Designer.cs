
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
            this.IdMove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSeriesPage = new System.Windows.Forms.TabPage();
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.SeriesTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberSeason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchedSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAllCinemaPage = new System.Windows.Forms.TabPage();
            this.dgvCinema = new System.Windows.Forms.DataGridView();
            this.NameCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WatchedCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataWatchedCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCinema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cinemaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnEditCinema = new System.Windows.Forms.Button();
            this.btnPullingFile = new System.Windows.Forms.Button();
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
            this.btnFormMovie.Size = new System.Drawing.Size(80, 30);
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
            this.btnDeliteMovie.Location = new System.Drawing.Point(295, 300);
            this.btnDeliteMovie.Name = "btnDeliteMovie";
            this.btnDeliteMovie.Size = new System.Drawing.Size(80, 30);
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
            this.btnFormSeries.Location = new System.Drawing.Point(105, 300);
            this.btnFormSeries.Name = "btnFormSeries";
            this.btnFormSeries.Size = new System.Drawing.Size(80, 30);
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
            this.BoxName.Tag = "Cinema";
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
            this.GradeMove,
            this.IdMove,
            this.Type});
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
            this.MoveWatched.HeaderText = "The Watched Cinema";
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
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Visible = false;
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
            this.dataGridViewTextBoxColumn1});
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
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
            this.GradeCinema,
            this.IdCinema,
            this.dataGridViewTextBoxColumn2});
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
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // btnEditCinema
            // 
            this.btnEditCinema.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEditCinema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCinema.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditCinema.Location = new System.Drawing.Point(200, 300);
            this.btnEditCinema.Name = "btnEditCinema";
            this.btnEditCinema.Size = new System.Drawing.Size(80, 30);
            this.btnEditCinema.TabIndex = 11;
            this.btnEditCinema.Text = "Edit";
            this.btnEditCinema.UseVisualStyleBackColor = false;
            this.btnEditCinema.Click += new System.EventHandler(this.btnEditRow_Click);
            // 
            // btnPullingFile
            // 
            this.btnPullingFile.BackColor = System.Drawing.Color.Azure;
            this.btnPullingFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPullingFile.Location = new System.Drawing.Point(390, 300);
            this.btnPullingFile.Name = "btnPullingFile";
            this.btnPullingFile.Size = new System.Drawing.Size(175, 30);
            this.btnPullingFile.TabIndex = 13;
            this.btnPullingFile.Text = "Load File";
            this.btnPullingFile.UseVisualStyleBackColor = false;
            this.btnPullingFile.Click += new System.EventHandler(this.btnPullingFile_Click);
            // 
            // BoxCinemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(574, 341);
            this.Controls.Add(this.btnPullingFile);
            this.Controls.Add(this.btnEditCinema);
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
        private Button btnEditCinema;
        private Button btnPullingFile;
        private DataGridViewTextBoxColumn MoveTitle;
        private DataGridViewTextBoxColumn MovePart;
        private DataGridViewTextBoxColumn MoveWatched;
        private DataGridViewTextBoxColumn DataWatchedMove;
        private DataGridViewTextBoxColumn GradeMove;
        private DataGridViewTextBoxColumn IdMove;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn SeriesTitle;
        private DataGridViewTextBoxColumn NumberSeason;
        private DataGridViewTextBoxColumn WatchedSeries;
        private DataGridViewTextBoxColumn DataWatchedSeries;
        private DataGridViewTextBoxColumn GradeSeries;
        private DataGridViewTextBoxColumn IdSeries;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn NameCinema;
        private DataGridViewTextBoxColumn NumberCinema;
        private DataGridViewTextBoxColumn WatchedCinema;
        private DataGridViewTextBoxColumn DataWatchedCinema;
        private DataGridViewTextBoxColumn GradeCinema;
        private DataGridViewTextBoxColumn IdCinema;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
