using ListWatchedMoviesAndSeries.Models.View;

namespace ListWatchedMoviesAndSeries
{
    partial class TVSeriesForm
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
            this.txtAddSeries = new System.Windows.Forms.TextBox();
            this.seriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelNameSeries = new System.Windows.Forms.Label();
            this.labelNumberSeason = new System.Windows.Forms.Label();
            this.btnAddSeries = new System.Windows.Forms.Button();
            this.btnClearTxtSeries = new System.Windows.Forms.Button();
            this.btnBackFormSeries = new System.Windows.Forms.Button();
            this.numericSeason = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerSeries = new System.Windows.Forms.DateTimePicker();
            this.watchDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericGradeSeries = new System.Windows.Forms.NumericUpDown();
            this.labelGradeSeries = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.seriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGradeSeries)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddSeries
            // 
            this.txtAddSeries.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.seriesBindingSource, "Name", true));
            this.txtAddSeries.Location = new System.Drawing.Point(10, 10);
            this.txtAddSeries.Name = "txtAddSeries";
            this.txtAddSeries.Size = new System.Drawing.Size(352, 23);
            this.txtAddSeries.TabIndex = 1;
            // 
            // seriesBindingSource
            // 
            this.seriesBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.Models.View.Series);
            // 
            // labelNameSeries
            // 
            this.labelNameSeries.AutoSize = true;
            this.labelNameSeries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelNameSeries.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNameSeries.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNameSeries.Location = new System.Drawing.Point(365, 10);
            this.labelNameSeries.Name = "labelNameSeries";
            this.labelNameSeries.Size = new System.Drawing.Size(45, 19);
            this.labelNameSeries.TabIndex = 5;
            this.labelNameSeries.Text = "Name";
            // 
            // labelNumberSeason
            // 
            this.labelNumberSeason.AutoSize = true;
            this.labelNumberSeason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelNumberSeason.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNumberSeason.Location = new System.Drawing.Point(365, 40);
            this.labelNumberSeason.Name = "labelNumberSeason";
            this.labelNumberSeason.Size = new System.Drawing.Size(52, 19);
            this.labelNumberSeason.TabIndex = 6;
            this.labelNumberSeason.Text = "Season";
            // 
            // btnAddSeries
            // 
            this.btnAddSeries.AutoEllipsis = true;
            this.btnAddSeries.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSeries.Location = new System.Drawing.Point(215, 70);
            this.btnAddSeries.Name = "btnAddSeries";
            this.btnAddSeries.Size = new System.Drawing.Size(60, 30);
            this.btnAddSeries.TabIndex = 8;
            this.btnAddSeries.Text = "Add";
            this.btnAddSeries.UseVisualStyleBackColor = false;
            this.btnAddSeries.Click += new System.EventHandler(this.BtnAddSeries_Click);
            // 
            // btnClearTxtSeries
            // 
            this.btnClearTxtSeries.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClearTxtSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTxtSeries.Location = new System.Drawing.Point(285, 70);
            this.btnClearTxtSeries.Name = "btnClearTxtSeries";
            this.btnClearTxtSeries.Size = new System.Drawing.Size(60, 30);
            this.btnClearTxtSeries.TabIndex = 9;
            this.btnClearTxtSeries.Text = "Clear";
            this.btnClearTxtSeries.UseVisualStyleBackColor = false;
            this.btnClearTxtSeries.Click += new System.EventHandler(this.BtnClearTxtSeries_Click);
            // 
            // btnBackFormSeries
            // 
            this.btnBackFormSeries.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBackFormSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackFormSeries.Location = new System.Drawing.Point(355, 70);
            this.btnBackFormSeries.Name = "btnBackFormSeries";
            this.btnBackFormSeries.Size = new System.Drawing.Size(60, 30);
            this.btnBackFormSeries.TabIndex = 10;
            this.btnBackFormSeries.Text = "Close";
            this.btnBackFormSeries.UseVisualStyleBackColor = false;
            this.btnBackFormSeries.Click += new System.EventHandler(this.BtnBackFormSeries_Click);
            // 
            // numericSeason
            // 
            this.numericSeason.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.seriesBindingSource, "Season", true));
            this.numericSeason.Location = new System.Drawing.Point(215, 40);
            this.numericSeason.Name = "numericSeason";
            this.numericSeason.Size = new System.Drawing.Size(145, 23);
            this.numericSeason.TabIndex = 11;
            this.numericSeason.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateTimePickerSeries
            // 
            this.dateTimePickerSeries.CustomFormat = "\"dd.MM.yyyy\"";
            this.dateTimePickerSeries.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.watchDetailBindingSource, "DateWatch", true));
            this.dateTimePickerSeries.Location = new System.Drawing.Point(9, 70);
            this.dateTimePickerSeries.MaxDate = new System.DateTime(2022, 8, 7, 0, 0, 0, 0);
            this.dateTimePickerSeries.MinDate = new System.DateTime(1949, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerSeries.Name = "dateTimePickerSeries";
            this.dateTimePickerSeries.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerSeries.TabIndex = 13;
            this.dateTimePickerSeries.Value = new System.DateTime(2022, 8, 7, 0, 0, 0, 0);
            this.dateTimePickerSeries.ValueChanged += new System.EventHandler(this.DateTimePickerSeries_ValueChanged);
            // 
            // watchDetailBindingSource
            // 
            this.watchDetailBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.Models.Item.WatchDetail);
            // 
            // numericGradeSeries
            // 
            this.numericGradeSeries.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.watchDetailBindingSource, "Grade", true));
            this.numericGradeSeries.InterceptArrowKeys = false;
            this.numericGradeSeries.Location = new System.Drawing.Point(9, 40);
            this.numericGradeSeries.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericGradeSeries.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericGradeSeries.Name = "numericGradeSeries";
            this.numericGradeSeries.ReadOnly = true;
            this.numericGradeSeries.Size = new System.Drawing.Size(101, 23);
            this.numericGradeSeries.TabIndex = 17;
            this.numericGradeSeries.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelGradeSeries
            // 
            this.labelGradeSeries.AutoSize = true;
            this.labelGradeSeries.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGradeSeries.Location = new System.Drawing.Point(115, 40);
            this.labelGradeSeries.Name = "labelGradeSeries";
            this.labelGradeSeries.Size = new System.Drawing.Size(85, 19);
            this.labelGradeSeries.TabIndex = 18;
            this.labelGradeSeries.Text = "Grade Series";
            // 
            // TVSeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(419, 111);
            this.Controls.Add(this.labelGradeSeries);
            this.Controls.Add(this.numericGradeSeries);
            this.Controls.Add(this.dateTimePickerSeries);
            this.Controls.Add(this.numericSeason);
            this.Controls.Add(this.btnBackFormSeries);
            this.Controls.Add(this.btnClearTxtSeries);
            this.Controls.Add(this.btnAddSeries);
            this.Controls.Add(this.labelNumberSeason);
            this.Controls.Add(this.labelNameSeries);
            this.Controls.Add(this.txtAddSeries);
            this.MaximumSize = new System.Drawing.Size(435, 150);
            this.MinimumSize = new System.Drawing.Size(435, 150);
            this.Name = "TVSeriesForm";
            this.Text = "Series";
            ((System.ComponentModel.ISupportInitialize)(this.seriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGradeSeries)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelNameSeries;
        private Label labelNumberSeason;
        private Button btnClearTxtSeries;
        private Button btnBackFormSeries;
        private Button btnAddSeries;
        private TextBox txtAddSeries;
        private NumericUpDown numericSeason;
        private DateTimePicker dateTimePickerSeries;
        private NumericUpDown numericGradeSeries;
        private Label labelGradeSeries;
        private BindingSource watchDetailBindingSource;
        private BindingSource seriesBindingSource;
    }
}