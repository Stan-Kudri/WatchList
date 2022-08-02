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
            this.btnFormMovie = new System.Windows.Forms.Button();
            this.btnDeliteMovie = new System.Windows.Forms.Button();
            this.listAllBoxName = new System.Windows.Forms.ListBox();
            this.btnFormSeries = new System.Windows.Forms.Button();
            this.BoxName = new System.Windows.Forms.TabControl();
            this.tabMovePage = new System.Windows.Forms.TabPage();
            this.listCinemaBoxName = new System.Windows.Forms.ListBox();
            this.tabSeriesPage = new System.Windows.Forms.TabPage();
            this.listSeriesBoxName = new System.Windows.Forms.ListBox();
            this.tabAllCinemaPage = new System.Windows.Forms.TabPage();
            this.BoxName.SuspendLayout();
            this.tabMovePage.SuspendLayout();
            this.tabSeriesPage.SuspendLayout();
            this.tabAllCinemaPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFormMovie
            // 
            this.btnFormMovie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnFormMovie.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormMovie.Location = new System.Drawing.Point(10, 320);
            this.btnFormMovie.Name = "btnFormMovie";
            this.btnFormMovie.Size = new System.Drawing.Size(100, 50);
            this.btnFormMovie.TabIndex = 1;
            this.btnFormMovie.Text = "Add Movie";
            this.btnFormMovie.UseVisualStyleBackColor = false;
            this.btnFormMovie.Click += new System.EventHandler(this.btnFormMovie_Click);
            // 
            // btnDeliteMovie
            // 
            this.btnDeliteMovie.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeliteMovie.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeliteMovie.Location = new System.Drawing.Point(250, 320);
            this.btnDeliteMovie.Name = "btnDeliteMovie";
            this.btnDeliteMovie.Size = new System.Drawing.Size(100, 50);
            this.btnDeliteMovie.TabIndex = 2;
            this.btnDeliteMovie.Text = "Delite Cinema";
            this.btnDeliteMovie.UseVisualStyleBackColor = false;
            this.btnDeliteMovie.Click += new System.EventHandler(this.btnDeliteMovie_Click);
            // 
            // listAllBoxName
            // 
            this.listAllBoxName.FormattingEnabled = true;
            this.listAllBoxName.Location = new System.Drawing.Point(5, 5);
            this.listAllBoxName.Name = "listAllBoxName";
            this.listAllBoxName.Size = new System.Drawing.Size(322, 251);
            this.listAllBoxName.TabIndex = 4;
            // 
            // btnFormSeries
            // 
            this.btnFormSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnFormSeries.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFormSeries.Location = new System.Drawing.Point(130, 320);
            this.btnFormSeries.Name = "btnFormSeries";
            this.btnFormSeries.Size = new System.Drawing.Size(100, 50);
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
            this.BoxName.Size = new System.Drawing.Size(340, 300);
            this.BoxName.TabIndex = 10;
            // 
            // tabMovePage
            // 
            this.tabMovePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabMovePage.Controls.Add(this.listCinemaBoxName);
            this.tabMovePage.Location = new System.Drawing.Point(4, 24);
            this.tabMovePage.Name = "tabMovePage";
            this.tabMovePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabMovePage.Size = new System.Drawing.Size(332, 272);
            this.tabMovePage.TabIndex = 0;
            this.tabMovePage.Text = "Move/Cartoon";
            // 
            // listCinemaBoxName
            // 
            this.listCinemaBoxName.FormattingEnabled = true;
            this.listCinemaBoxName.Location = new System.Drawing.Point(5, 5);
            this.listCinemaBoxName.Name = "listCinemaBoxName";
            this.listCinemaBoxName.Size = new System.Drawing.Size(322, 251);
            this.listCinemaBoxName.TabIndex = 5;
            // 
            // tabSeriesPage
            // 
            this.tabSeriesPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabSeriesPage.Controls.Add(this.listSeriesBoxName);
            this.tabSeriesPage.Location = new System.Drawing.Point(4, 24);
            this.tabSeriesPage.Name = "tabSeriesPage";
            this.tabSeriesPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeriesPage.Size = new System.Drawing.Size(332, 272);
            this.tabSeriesPage.TabIndex = 1;
            this.tabSeriesPage.Text = "Series";
            // 
            // listSeriesBoxName
            // 
            this.listSeriesBoxName.FormattingEnabled = true;
            this.listSeriesBoxName.Location = new System.Drawing.Point(5, 5);
            this.listSeriesBoxName.Name = "listSeriesBoxName";
            this.listSeriesBoxName.Size = new System.Drawing.Size(322, 251);
            this.listSeriesBoxName.TabIndex = 5;
            // 
            // tabAllCinemaPage
            // 
            this.tabAllCinemaPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabAllCinemaPage.Controls.Add(this.listAllBoxName);
            this.tabAllCinemaPage.Location = new System.Drawing.Point(4, 24);
            this.tabAllCinemaPage.Name = "tabAllCinemaPage";
            this.tabAllCinemaPage.Size = new System.Drawing.Size(332, 272);
            this.tabAllCinemaPage.TabIndex = 2;
            this.tabAllCinemaPage.Text = "All Cinema";
            // 
            // BoxCinema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(359, 381);
            this.Controls.Add(this.BoxName);
            this.Controls.Add(this.btnFormSeries);
            this.Controls.Add(this.btnDeliteMovie);
            this.Controls.Add(this.btnFormMovie);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(375, 420);
            this.MinimumSize = new System.Drawing.Size(375, 420);
            this.Name = "BoxCinema";
            this.Text = "BoxCinema";
            this.BoxName.ResumeLayout(false);
            this.tabMovePage.ResumeLayout(false);
            this.tabSeriesPage.ResumeLayout(false);
            this.tabAllCinemaPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnFormMovie;
        private Button btnDeliteMovie;
        public ListBox listAllBoxName;
        private Button btnFormSeries;
        private TabControl BoxName;
        private TabPage tabMovePage;
        private TabPage tabSeriesPage;
        public ListBox listCinemaBoxName;
        public ListBox listSeriesBoxName;
        private TabPage tabAllCinemaPage;
    }
}