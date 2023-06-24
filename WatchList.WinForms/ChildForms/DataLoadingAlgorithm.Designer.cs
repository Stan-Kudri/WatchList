namespace WatchList.WinForms.ChildForms
{
    partial class DataLoadingAlgorithm
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
            cbExistGrade = new MaterialSkin.Controls.MaterialCheckbox();
            btnOk = new MaterialSkin.Controls.MaterialButton();
            btnCancel = new MaterialSkin.Controls.MaterialButton();
            btnClear = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // cbExistGrade
            // 
            cbExistGrade.AutoSize = true;
            cbExistGrade.Depth = 0;
            cbExistGrade.Location = new Point(10, 80);
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
            btnOk.Location = new Point(10, 120);
            btnOk.Margin = new Padding(4, 6, 4, 6);
            btnOk.MouseState = MaterialSkin.MouseState.HOVER;
            btnOk.Name = "btnOk";
            btnOk.NoAccentTextColor = Color.Empty;
            btnOk.Size = new Size(64, 36);
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
            btnCancel.Location = new Point(320, 120);
            btnCancel.Margin = new Padding(4, 6, 4, 6);
            btnCancel.MaximumSize = new Size(500, 400);
            btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            btnCancel.Name = "btnCancel";
            btnCancel.NoAccentTextColor = Color.Empty;
            btnCancel.Size = new Size(77, 36);
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
            btnClear.Location = new Point(165, 120);
            btnClear.Margin = new Padding(4, 6, 4, 6);
            btnClear.MouseState = MaterialSkin.MouseState.HOVER;
            btnClear.Name = "btnClear";
            btnClear.NoAccentTextColor = Color.Empty;
            btnClear.Size = new Size(66, 36);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnClear.UseAccentColor = false;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // DataLoadingAlgorithm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(420, 170);
            Controls.Add(btnClear);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cbExistGrade);
            MaximumSize = new Size(420, 170);
            MinimumSize = new Size(420, 170);
            Name = "DataLoadingAlgorithm";
            Text = "Loading data";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox cbExistGrade;
        private MaterialSkin.Controls.MaterialButton btnOk;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialButton btnClear;
    }
}