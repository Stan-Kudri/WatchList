using ListWatchedMoviesAndSeries.Models.View;

namespace ListWatchedMoviesAndSeries
{
    partial class MovieForm
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
            this.components = new System.ComponentModel.Container();
            this.txtAddMovie = new System.Windows.Forms.TextBox();
            this.labelNameMovie = new System.Windows.Forms.Label();
            this.btnBackFormMovie = new System.Windows.Forms.Button();
            this.btnClearTxtMovie = new System.Windows.Forms.Button();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.dateTimePickerMovie = new System.Windows.Forms.DateTimePicker();
            this.watchDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericGradeMovie = new System.Windows.Forms.NumericUpDown();
            this.labelGradeMovie = new System.Windows.Forms.Label();
            this.movieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.watchDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGradeMovie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddMovie
            // 
            this.txtAddMovie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.movieBindingSource, "Name", true));
            this.txtAddMovie.Location = new System.Drawing.Point(10, 12);
            this.txtAddMovie.Name = "txtAddMovie";
            this.txtAddMovie.Size = new System.Drawing.Size(350, 23);
            this.txtAddMovie.TabIndex = 2;
            // 
            // labelNameMovie
            // 
            this.labelNameMovie.AutoSize = true;
            this.labelNameMovie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelNameMovie.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNameMovie.Location = new System.Drawing.Point(365, 12);
            this.labelNameMovie.Name = "labelNameMovie";
            this.labelNameMovie.Size = new System.Drawing.Size(45, 19);
            this.labelNameMovie.TabIndex = 4;
            this.labelNameMovie.Text = "Name";
            // 
            // btnBackFormMovie
            // 
            this.btnBackFormMovie.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBackFormMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackFormMovie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBackFormMovie.Location = new System.Drawing.Point(355, 65);
            this.btnBackFormMovie.Name = "btnBackFormMovie";
            this.btnBackFormMovie.Size = new System.Drawing.Size(60, 30);
            this.btnBackFormMovie.TabIndex = 13;
            this.btnBackFormMovie.Text = "Close";
            this.btnBackFormMovie.UseVisualStyleBackColor = false;
            this.btnBackFormMovie.Click += new System.EventHandler(this.BtnBackFormMovie_Click);
            // 
            // btnClearTxtMovie
            // 
            this.btnClearTxtMovie.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClearTxtMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTxtMovie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearTxtMovie.Location = new System.Drawing.Point(285, 65);
            this.btnClearTxtMovie.Name = "btnClearTxtMovie";
            this.btnClearTxtMovie.Size = new System.Drawing.Size(60, 30);
            this.btnClearTxtMovie.TabIndex = 12;
            this.btnClearTxtMovie.Text = "Clear";
            this.btnClearTxtMovie.UseVisualStyleBackColor = false;
            this.btnClearTxtMovie.Click += new System.EventHandler(this.BtnClearTxtMovie_Click);
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMovie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddMovie.Location = new System.Drawing.Point(215, 65);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(60, 30);
            this.btnAddMovie.TabIndex = 11;
            this.btnAddMovie.Text = "Add";
            this.btnAddMovie.UseVisualStyleBackColor = false;
            this.btnAddMovie.Click += new System.EventHandler(this.BtnAddMovie_Click);
            // 
            // dateTimePickerMovie
            // 
            this.dateTimePickerMovie.CustomFormat = "\"dd.MM.yyyy\"";
            this.dateTimePickerMovie.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.watchDetailBindingSource, "DateWatch", true));
            this.dateTimePickerMovie.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMovie.Location = new System.Drawing.Point(10, 65);
            this.dateTimePickerMovie.MaxDate = new System.DateTime(2022, 8, 7, 0, 0, 0, 0);
            this.dateTimePickerMovie.MinDate = new System.DateTime(1949, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerMovie.Name = "dateTimePickerMovie";
            this.dateTimePickerMovie.Size = new System.Drawing.Size(195, 23);
            this.dateTimePickerMovie.TabIndex = 15;
            this.dateTimePickerMovie.Value = new System.DateTime(2022, 8, 7, 0, 0, 0, 0);
            this.dateTimePickerMovie.ValueChanged += new System.EventHandler(this.DateTimePickerMovie_ValueChanged);
            // 
            // watchDetailBindingSource
            // 
            this.watchDetailBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.Models.Item.WatchDetail);
            // 
            // numericGradeMovie
            // 
            this.numericGradeMovie.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.watchDetailBindingSource, "Grade", true));
            this.numericGradeMovie.Location = new System.Drawing.Point(10, 37);
            this.numericGradeMovie.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericGradeMovie.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericGradeMovie.Name = "numericGradeMovie";
            this.numericGradeMovie.ReadOnly = true;
            this.numericGradeMovie.Size = new System.Drawing.Size(101, 23);
            this.numericGradeMovie.TabIndex = 16;
            this.numericGradeMovie.ThousandsSeparator = true;
            this.numericGradeMovie.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelGradeMovie
            // 
            this.labelGradeMovie.AutoSize = true;
            this.labelGradeMovie.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGradeMovie.Location = new System.Drawing.Point(117, 37);
            this.labelGradeMovie.Name = "labelGradeMovie";
            this.labelGradeMovie.Size = new System.Drawing.Size(88, 19);
            this.labelGradeMovie.TabIndex = 17;
            this.labelGradeMovie.Text = "Grade Movie";
            // 
            // movieBindingSource
            // 
            this.movieBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.Models.View.Movie);
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(419, 101);
            this.Controls.Add(this.labelGradeMovie);
            this.Controls.Add(this.numericGradeMovie);
            this.Controls.Add(this.dateTimePickerMovie);
            this.Controls.Add(this.btnBackFormMovie);
            this.Controls.Add(this.btnClearTxtMovie);
            this.Controls.Add(this.btnAddMovie);
            this.Controls.Add(this.labelNameMovie);
            this.Controls.Add(this.txtAddMovie);
            this.MaximumSize = new System.Drawing.Size(435, 140);
            this.MinimumSize = new System.Drawing.Size(435, 140);
            this.Name = "MovieForm";
            this.Text = "Movie";
            ((System.ComponentModel.ISupportInitialize)(this.watchDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGradeMovie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtAddMovie;
        private Label labelNameMovie;
        private Button btnBackFormMovie;
        private Button btnClearTxtMovie;
        private Button btnAddMovie;
        private DateTimePicker dateTimePickerMovie;
        private NumericUpDown numericGradeMovie;
        private Label labelGradeMovie;
        private BindingSource watchDetailBindingSource;
        private BindingSource movieBindingSource;
    }
}