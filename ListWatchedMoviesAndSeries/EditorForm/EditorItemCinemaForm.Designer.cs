namespace ListWatchedMoviesAndSeries.EditorForm
{
    partial class EditorItemCinemaForm
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
            this.numericEditGradeCinema = new System.Windows.Forms.NumericUpDown();
            this.watchDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateTPCinema = new System.Windows.Forms.DateTimePicker();
            this.numericEditSequel = new System.Windows.Forms.NumericUpDown();
            this.cinemaModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.labelNameCinema = new MaterialSkin.Controls.MaterialLabel();
            this.labelNumberSequel = new MaterialSkin.Controls.MaterialLabel();
            this.labelGradeCinema = new MaterialSkin.Controls.MaterialLabel();
            this.btnSaveEdit = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnReturnDataCinema = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCloseEdit = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericEditGradeCinema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEditSequel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // numericEditGradeCinema
            // 
            this.numericEditGradeCinema.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.watchDetailBindingSource, "Grade", true));
            this.numericEditGradeCinema.Enabled = false;
            this.numericEditGradeCinema.InterceptArrowKeys = false;
            this.numericEditGradeCinema.Location = new System.Drawing.Point(10, 100);
            this.numericEditGradeCinema.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericEditGradeCinema.Name = "numericEditGradeCinema";
            this.numericEditGradeCinema.ReadOnly = true;
            this.numericEditGradeCinema.Size = new System.Drawing.Size(101, 23);
            this.numericEditGradeCinema.TabIndex = 27;
            // 
            // watchDetailBindingSource
            // 
            this.watchDetailBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.Models.Item.WatchDetail);
            // 
            // dateTPCinema
            // 
            this.dateTPCinema.CustomFormat = "\"dd.MM.yyyy\"";
            this.dateTPCinema.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.watchDetailBindingSource, "DateWatch", true));
            this.dateTPCinema.Location = new System.Drawing.Point(10, 135);
            this.dateTPCinema.MaxDate = new System.DateTime(2022, 8, 29, 0, 0, 0, 0);
            this.dateTPCinema.MinDate = new System.DateTime(1949, 12, 31, 0, 0, 0, 0);
            this.dateTPCinema.Name = "dateTPCinema";
            this.dateTPCinema.Size = new System.Drawing.Size(158, 23);
            this.dateTPCinema.TabIndex = 26;
            this.dateTPCinema.Value = new System.DateTime(2022, 8, 7, 0, 0, 0, 0);
            this.dateTPCinema.ValueChanged += new System.EventHandler(this.DateTimePickerCinema_ValueChanged);
            // 
            // numericEditSequel
            // 
            this.numericEditSequel.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cinemaModelBindingSource, "NumberSequel", true));
            this.numericEditSequel.Location = new System.Drawing.Point(175, 100);
            this.numericEditSequel.Name = "numericEditSequel";
            this.numericEditSequel.Size = new System.Drawing.Size(146, 23);
            this.numericEditSequel.TabIndex = 25;
            // 
            // cinemaModelBindingSource
            // 
            this.cinemaModelBindingSource.DataSource = typeof(ListWatchedMoviesAndSeries.Models.CinemaModel);
            // 
            // txtEditName
            // 
            this.txtEditName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cinemaModelBindingSource, "Name", true));
            this.txtEditName.Location = new System.Drawing.Point(10, 70);
            this.txtEditName.Multiline = true;
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(311, 23);
            this.txtEditName.TabIndex = 19;
            // 
            // labelNameCinema
            // 
            this.labelNameCinema.AutoSize = true;
            this.labelNameCinema.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNameCinema.Depth = 0;
            this.labelNameCinema.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNameCinema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNameCinema.Location = new System.Drawing.Point(330, 70);
            this.labelNameCinema.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelNameCinema.Name = "labelNameCinema";
            this.labelNameCinema.Size = new System.Drawing.Size(49, 19);
            this.labelNameCinema.TabIndex = 29;
            this.labelNameCinema.Text = "Name";
            // 
            // labelNumberSequel
            // 
            this.labelNumberSequel.AutoSize = true;
            this.labelNumberSequel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNumberSequel.Depth = 0;
            this.labelNumberSequel.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNumberSequel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNumberSequel.Location = new System.Drawing.Point(330, 100);
            this.labelNumberSequel.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelNumberSequel.Name = "labelNumberSequel";
            this.labelNumberSequel.Size = new System.Drawing.Size(55, 19);
            this.labelNumberSequel.TabIndex = 30;
            this.labelNumberSequel.Text = "Sequel";
            // 
            // labelGradeCinema
            // 
            this.labelGradeCinema.AutoSize = true;
            this.labelGradeCinema.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelGradeCinema.Depth = 0;
            this.labelGradeCinema.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGradeCinema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelGradeCinema.Location = new System.Drawing.Point(120, 100);
            this.labelGradeCinema.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelGradeCinema.Name = "labelGradeCinema";
            this.labelGradeCinema.Size = new System.Drawing.Size(48, 19);
            this.labelGradeCinema.TabIndex = 31;
            this.labelGradeCinema.Text = "Grade";
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Depth = 0;
            this.btnSaveEdit.Location = new System.Drawing.Point(175, 135);
            this.btnSaveEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Primary = true;
            this.btnSaveEdit.Size = new System.Drawing.Size(70, 25);
            this.btnSaveEdit.TabIndex = 32;
            this.btnSaveEdit.Text = "Save";
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Click += new System.EventHandler(this.BtnSaveEdit_Click);
            // 
            // btnReturnDataCinema
            // 
            this.btnReturnDataCinema.Depth = 0;
            this.btnReturnDataCinema.Location = new System.Drawing.Point(250, 135);
            this.btnReturnDataCinema.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReturnDataCinema.Name = "btnReturnDataCinema";
            this.btnReturnDataCinema.Primary = true;
            this.btnReturnDataCinema.Size = new System.Drawing.Size(70, 25);
            this.btnReturnDataCinema.TabIndex = 33;
            this.btnReturnDataCinema.Text = "Return";
            this.btnReturnDataCinema.UseVisualStyleBackColor = true;
            this.btnReturnDataCinema.Click += new System.EventHandler(this.BtnReturnDataCinema_Click);
            // 
            // btnCloseEdit
            // 
            this.btnCloseEdit.Depth = 0;
            this.btnCloseEdit.Location = new System.Drawing.Point(330, 125);
            this.btnCloseEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCloseEdit.Name = "btnCloseEdit";
            this.btnCloseEdit.Primary = true;
            this.btnCloseEdit.Size = new System.Drawing.Size(60, 35);
            this.btnCloseEdit.TabIndex = 34;
            this.btnCloseEdit.Text = "Close";
            this.btnCloseEdit.UseVisualStyleBackColor = true;
            this.btnCloseEdit.Click += new System.EventHandler(this.BtnCloseEdit_Click);
            // 
            // EditorItemCinemaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(400, 170);
            this.Controls.Add(this.btnCloseEdit);
            this.Controls.Add(this.btnReturnDataCinema);
            this.Controls.Add(this.btnSaveEdit);
            this.Controls.Add(this.labelGradeCinema);
            this.Controls.Add(this.labelNumberSequel);
            this.Controls.Add(this.labelNameCinema);
            this.Controls.Add(this.numericEditGradeCinema);
            this.Controls.Add(this.dateTPCinema);
            this.Controls.Add(this.numericEditSequel);
            this.Controls.Add(this.txtEditName);
            this.Location = new System.Drawing.Point(400, 170);
            this.MaximumSize = new System.Drawing.Size(400, 170);
            this.Name = "EditorItemCinemaForm";
            this.Text = "EditorItemCinemaForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericEditGradeCinema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.watchDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEditSequel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cinemaModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtEditName;
        protected NumericUpDown numericEditGradeCinema;
        protected DateTimePicker dateTPCinema;
        protected NumericUpDown numericEditSequel;
        private BindingSource watchDetailBindingSource;
        private BindingSource cinemaModelBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelNameCinema;
        private MaterialSkin.Controls.MaterialLabel labelNumberSequel;
        private MaterialSkin.Controls.MaterialLabel labelGradeCinema;
        private MaterialSkin.Controls.MaterialRaisedButton btnSaveEdit;
        private MaterialSkin.Controls.MaterialRaisedButton btnReturnDataCinema;
        private MaterialSkin.Controls.MaterialRaisedButton btnCloseEdit;
    }
}