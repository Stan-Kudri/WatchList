namespace ListWatchedMoviesAndSeries
{
    partial class Movie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAddMovie = new System.Windows.Forms.TextBox();
            this.labelNameMovie = new System.Windows.Forms.Label();
            this.btnBackFormMovie = new System.Windows.Forms.Button();
            this.btnClearTxtMovie = new System.Windows.Forms.Button();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAddMovie
            // 
            this.txtAddMovie.Location = new System.Drawing.Point(12, 12);
            this.txtAddMovie.Name = "txtAddMovie";
            this.txtAddMovie.Size = new System.Drawing.Size(320, 23);
            this.txtAddMovie.TabIndex = 2;
            // 
            // labelNameMovie
            // 
            this.labelNameMovie.AutoSize = true;
            this.labelNameMovie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelNameMovie.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNameMovie.Location = new System.Drawing.Point(350, 13);
            this.labelNameMovie.Name = "labelNameMovie";
            this.labelNameMovie.Size = new System.Drawing.Size(45, 19);
            this.labelNameMovie.TabIndex = 4;
            this.labelNameMovie.Text = "Name";
            // 
            // btnBackFormMovie
            // 
            this.btnBackFormMovie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBackFormMovie.Location = new System.Drawing.Point(290, 60);
            this.btnBackFormMovie.Name = "btnBackFormMovie";
            this.btnBackFormMovie.Size = new System.Drawing.Size(120, 40);
            this.btnBackFormMovie.TabIndex = 13;
            this.btnBackFormMovie.Text = "Close";
            this.btnBackFormMovie.UseVisualStyleBackColor = false;
            this.btnBackFormMovie.Click += new System.EventHandler(this.btnBackFormMovie_Click);
            // 
            // btnClearTxtMovie
            // 
            this.btnClearTxtMovie.BackColor = System.Drawing.Color.Yellow;
            this.btnClearTxtMovie.Location = new System.Drawing.Point(150, 60);
            this.btnClearTxtMovie.Name = "btnClearTxtMovie";
            this.btnClearTxtMovie.Size = new System.Drawing.Size(120, 40);
            this.btnClearTxtMovie.TabIndex = 12;
            this.btnClearTxtMovie.Text = "Clear";
            this.btnClearTxtMovie.UseVisualStyleBackColor = false;
            this.btnClearTxtMovie.Click += new System.EventHandler(this.btnClearTxtMovie_Click);
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAddMovie.Location = new System.Drawing.Point(10, 60);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(120, 40);
            this.btnAddMovie.TabIndex = 11;
            this.btnAddMovie.Text = "Add";
            this.btnAddMovie.UseVisualStyleBackColor = false;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // addMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(419, 111);
            this.Controls.Add(this.btnBackFormMovie);
            this.Controls.Add(this.btnClearTxtMovie);
            this.Controls.Add(this.btnAddMovie);
            this.Controls.Add(this.labelNameMovie);
            this.Controls.Add(this.txtAddMovie);
            this.MaximumSize = new System.Drawing.Size(435, 150);
            this.MinimumSize = new System.Drawing.Size(435, 150);
            this.Name = "addMovie";
            this.Text = "Movie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtAddMovie;
        private Label labelNameMovie;
        private Button btnBackFormMovie;
        private Button btnClearTxtMovie;
        private Button btnAddMovie;
    }
}