namespace WatchList.WinForms.ChildForms.MessageBoxForm
{
    partial class DataReplaceMessageForm
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
            btnYes = new Button();
            btnAllYes = new Button();
            btnNo = new Button();
            btnAllNo = new Button();
            labelQuestion = new Label();
            labelTitleItem = new Label();
            labelTitleInfo = new Label();
            SuspendLayout();
            // 
            // btnYes
            // 
            btnYes.Location = new Point(10, 75);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(75, 25);
            btnYes.TabIndex = 0;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += BtnYes_Click;
            // 
            // btnAllYes
            // 
            btnAllYes.Location = new Point(105, 75);
            btnAllYes.Name = "btnAllYes";
            btnAllYes.Size = new Size(75, 25);
            btnAllYes.TabIndex = 1;
            btnAllYes.Text = "Yes, for all";
            btnAllYes.UseVisualStyleBackColor = true;
            btnAllYes.Click += BtnAllYes_Click;
            // 
            // btnNo
            // 
            btnNo.Location = new Point(300, 75);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(75, 25);
            btnNo.TabIndex = 2;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += BtnNo_Click;
            // 
            // btnAllNo
            // 
            btnAllNo.Location = new Point(205, 75);
            btnAllNo.Name = "btnAllNo";
            btnAllNo.Size = new Size(75, 25);
            btnAllNo.TabIndex = 3;
            btnAllNo.Text = "No, for all";
            btnAllNo.UseVisualStyleBackColor = true;
            btnAllNo.Click += BtnAllNo_Click;
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelQuestion.Location = new Point(40, 20);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(307, 19);
            labelQuestion.TabIndex = 4;
            labelQuestion.Text = "The append item is a duplicate. Replace element?";
            // 
            // labelTitleItem
            // 
            labelTitleItem.AutoSize = true;
            labelTitleItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitleItem.Location = new Point(75, 40);
            labelTitleItem.Name = "labelTitleItem";
            labelTitleItem.Size = new Size(37, 19);
            labelTitleItem.TabIndex = 5;
            labelTitleItem.Text = "Item";
            // 
            // labelTitleInfo
            // 
            labelTitleInfo.AutoSize = true;
            labelTitleInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitleInfo.Location = new Point(40, 40);
            labelTitleInfo.Name = "labelTitleInfo";
            labelTitleInfo.Size = new Size(37, 19);
            labelTitleInfo.TabIndex = 6;
            labelTitleInfo.Text = "Title:";
            // 
            // DataReplaceMessageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 111);
            Controls.Add(labelTitleInfo);
            Controls.Add(labelTitleItem);
            Controls.Add(labelQuestion);
            Controls.Add(btnAllNo);
            Controls.Add(btnNo);
            Controls.Add(btnAllYes);
            Controls.Add(btnYes);
            Name = "DataReplaceMessageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Question";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnYes;
        private Button btnAllYes;
        private Button btnNo;
        private Button btnAllNo;
        private Label labelQuestion;
        private Label labelTitleItem;
        private Label labelTitleInfo;
    }
}
