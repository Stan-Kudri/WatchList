namespace WatchList.WinForms.ChildForms
{
    partial class MergeDatabaseForm
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
            components = new System.ComponentModel.Container();
            cbExistGrade = new MaterialSkin.Controls.MaterialCheckbox();
            btnOk = new MaterialSkin.Controls.MaterialButton();
            btnCancel = new MaterialSkin.Controls.MaterialButton();
            btnClear = new MaterialSkin.Controls.MaterialButton();
            cmbTypeCinema = new MaterialSkin.Controls.MaterialComboBox();
            typeUploadBindingSource = new BindingSource(components);
            labelTypeCinemaLoad = new MaterialSkin.Controls.MaterialLabel();
            moreGradeBindingSource = new BindingSource(components);
            cmbGrade = new MaterialSkin.Controls.MaterialComboBox();
            labelScoreMore = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)typeUploadBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)moreGradeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // cbExistGrade
            // 
            cbExistGrade.AutoSize = true;
            cbExistGrade.Depth = 0;
            cbExistGrade.Location = new Point(10, 70);
            cbExistGrade.Margin = new Padding(0);
            cbExistGrade.MouseLocation = new Point(-1, -1);
            cbExistGrade.MouseState = MaterialSkin.MouseState.HOVER;
            cbExistGrade.Name = "cbExistGrade";
            cbExistGrade.ReadOnly = false;
            cbExistGrade.Ripple = true;
            cbExistGrade.Size = new Size(391, 37);
            cbExistGrade.TabIndex = 0;
            cbExistGrade.Text = "Delete existing grade (Set Status \"Planned Watch\")";
            cbExistGrade.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOk.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOk.Depth = 0;
            btnOk.HighEmphasis = true;
            btnOk.Icon = null;
            btnOk.Location = new Point(10, 170);
            btnOk.Margin = new Padding(4, 6, 4, 6);
            btnOk.MaximumSize = new Size(100, 36);
            btnOk.MinimumSize = new Size(100, 36);
            btnOk.MouseState = MaterialSkin.MouseState.HOVER;
            btnOk.Name = "btnOk";
            btnOk.NoAccentTextColor = Color.Empty;
            btnOk.Size = new Size(100, 36);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOk.UseAccentColor = false;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCancel.Depth = 0;
            btnCancel.HighEmphasis = true;
            btnCancel.Icon = null;
            btnCancel.Location = new Point(330, 170);
            btnCancel.Margin = new Padding(4, 6, 4, 6);
            btnCancel.MaximumSize = new Size(100, 36);
            btnCancel.MinimumSize = new Size(100, 36);
            btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancel.Name = "btnCancel";
            btnCancel.NoAccentTextColor = Color.Empty;
            btnCancel.Size = new Size(100, 36);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCancel.UseAccentColor = false;
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnClear.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnClear.Depth = 0;
            btnClear.HighEmphasis = true;
            btnClear.Icon = null;
            btnClear.Location = new Point(170, 170);
            btnClear.Margin = new Padding(4, 6, 4, 6);
            btnClear.MaximumSize = new Size(100, 36);
            btnClear.MinimumSize = new Size(100, 36);
            btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            btnClear.Name = "btnClear";
            btnClear.NoAccentTextColor = Color.Empty;
            btnClear.Size = new Size(100, 36);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClear.UseAccentColor = false;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // cmbTypeCinema
            // 
            cmbTypeCinema.AutoResize = false;
            cmbTypeCinema.BackColor = Color.FromArgb(255, 255, 255);
            cmbTypeCinema.DataBindings.Add(new Binding("SelectedValue", typeUploadBindingSource, "SelectedValue", true));
            cmbTypeCinema.DataBindings.Add(new Binding("DataSource", typeUploadBindingSource, "Items", true));
            cmbTypeCinema.Depth = 0;
            cmbTypeCinema.DrawMode = DrawMode.OwnerDrawVariable;
            cmbTypeCinema.DropDownHeight = 174;
            cmbTypeCinema.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeCinema.DropDownWidth = 110;
            cmbTypeCinema.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            cmbTypeCinema.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTypeCinema.FormattingEnabled = true;
            cmbTypeCinema.IntegralHeight = false;
            cmbTypeCinema.ItemHeight = 43;
            cmbTypeCinema.Location = new Point(10, 110);
            cmbTypeCinema.MaxDropDownItems = 4;
            cmbTypeCinema.MaximumSize = new Size(120, 0);
            cmbTypeCinema.MinimumSize = new Size(120, 0);
            cmbTypeCinema.MouseState = MaterialSkin.MouseState.OUT;
            cmbTypeCinema.Name = "cmbTypeCinema";
            cmbTypeCinema.Size = new Size(120, 49);
            cmbTypeCinema.StartIndex = 0;
            cmbTypeCinema.TabIndex = 4;
            // 
            // typeUploadBindingSource
            // 
            typeUploadBindingSource.DataSource = typeof(BindingItem.ModelDataLoad.ModelTypeCinemaUpload);
            // 
            // labelTypeCinemaLoad
            // 
            labelTypeCinemaLoad.AutoSize = true;
            labelTypeCinemaLoad.Depth = 0;
            labelTypeCinemaLoad.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelTypeCinemaLoad.Location = new Point(135, 123);
            labelTypeCinemaLoad.MouseState = MaterialSkin.MouseState.HOVER;
            labelTypeCinemaLoad.Name = "labelTypeCinemaLoad";
            labelTypeCinemaLoad.Size = new Size(36, 19);
            labelTypeCinemaLoad.TabIndex = 5;
            labelTypeCinemaLoad.Text = "Type";
            // 
            // moreGradeBindingSource
            // 
            moreGradeBindingSource.DataSource = typeof(BindingItem.ModelDataLoad.ModelDownloadMoreGrade);
            // 
            // cmbGrade
            // 
            cmbGrade.AutoResize = false;
            cmbGrade.BackColor = Color.FromArgb(255, 255, 255);
            cmbGrade.DataBindings.Add(new Binding("SelectedValue", moreGradeBindingSource, "Value", true));
            cmbGrade.DataBindings.Add(new Binding("DataSource", moreGradeBindingSource, "Items", true));
            cmbGrade.Depth = 0;
            cmbGrade.DrawMode = DrawMode.OwnerDrawVariable;
            cmbGrade.DropDownHeight = 174;
            cmbGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrade.DropDownWidth = 121;
            cmbGrade.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbGrade.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbGrade.FormattingEnabled = true;
            cmbGrade.IntegralHeight = false;
            cmbGrade.ItemHeight = 43;
            cmbGrade.Location = new Point(175, 108);
            cmbGrade.MaxDropDownItems = 4;
            cmbGrade.MouseState = MaterialSkin.MouseState.OUT;
            cmbGrade.Name = "cmbGrade";
            cmbGrade.Size = new Size(172, 49);
            cmbGrade.StartIndex = 0;
            cmbGrade.TabIndex = 6;
            // 
            // labelScoreMore
            // 
            labelScoreMore.AutoSize = true;
            labelScoreMore.Depth = 0;
            labelScoreMore.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelScoreMore.Location = new Point(353, 123);
            labelScoreMore.MouseState = MaterialSkin.MouseState.HOVER;
            labelScoreMore.Name = "labelScoreMore";
            labelScoreMore.Size = new Size(81, 19);
            labelScoreMore.TabIndex = 7;
            labelScoreMore.Text = "Score more";
            // 
            // MergeDatabaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(440, 210);
            Controls.Add(labelScoreMore);
            Controls.Add(cmbGrade);
            Controls.Add(labelTypeCinemaLoad);
            Controls.Add(cmbTypeCinema);
            Controls.Add(btnClear);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cbExistGrade);
            MaximumSize = new Size(440, 210);
            MinimumSize = new Size(440, 210);
            Name = "MergeDatabaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading data";
            Load += DatabaseForm_Load;
            ((System.ComponentModel.ISupportInitialize)typeUploadBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)moreGradeBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox cbExistGrade;
        private MaterialSkin.Controls.MaterialButton btnOk;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnClear;
        private MaterialSkin.Controls.MaterialComboBox cmbTypeCinema;
        private BindingSource typeUploadBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelTypeCinemaLoad;
        private BindingSource moreGradeBindingSource;
        private MaterialSkin.Controls.MaterialComboBox cmbGrade;
        private MaterialSkin.Controls.MaterialLabel labelScoreMore;
    }
}
