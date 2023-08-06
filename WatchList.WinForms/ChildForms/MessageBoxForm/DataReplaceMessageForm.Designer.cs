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
            tlButtonPanel = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tlTitlePanel = new TableLayoutPanel();
            tlButtonPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tlTitlePanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnYes
            // 
            btnYes.Dock = DockStyle.Fill;
            btnYes.Location = new Point(3, 3);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(84, 24);
            btnYes.TabIndex = 0;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += BtnYes_Click;
            // 
            // btnAllYes
            // 
            btnAllYes.Dock = DockStyle.Fill;
            btnAllYes.Location = new Point(93, 3);
            btnAllYes.Name = "btnAllYes";
            btnAllYes.Size = new Size(84, 24);
            btnAllYes.TabIndex = 1;
            btnAllYes.Text = "Yes, for all";
            btnAllYes.UseVisualStyleBackColor = true;
            btnAllYes.Click += BtnAllYes_Click;
            // 
            // btnNo
            // 
            btnNo.Dock = DockStyle.Fill;
            btnNo.Location = new Point(273, 3);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(84, 24);
            btnNo.TabIndex = 2;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += BtnNo_Click;
            // 
            // btnAllNo
            // 
            btnAllNo.Dock = DockStyle.Fill;
            btnAllNo.Location = new Point(183, 3);
            btnAllNo.Name = "btnAllNo";
            btnAllNo.Size = new Size(84, 24);
            btnAllNo.TabIndex = 3;
            btnAllNo.Text = "No, for all";
            btnAllNo.UseVisualStyleBackColor = true;
            btnAllNo.Click += BtnAllNo_Click;
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Dock = DockStyle.Fill;
            labelQuestion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelQuestion.Location = new Point(23, 3);
            labelQuestion.Margin = new Padding(3);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(314, 19);
            labelQuestion.TabIndex = 4;
            labelQuestion.Text = "The append item is a duplicate. Replace element?";
            labelQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTitleItem
            // 
            labelTitleItem.AutoSize = true;
            labelTitleItem.Dock = DockStyle.Fill;
            labelTitleItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitleItem.Location = new Point(21, 3);
            labelTitleItem.Margin = new Padding(3);
            labelTitleItem.Name = "labelTitleItem";
            labelTitleItem.Size = new Size(318, 18);
            labelTitleItem.TabIndex = 5;
            labelTitleItem.Text = "Item";
            labelTitleItem.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tlButtonPanel
            // 
            tlButtonPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tlButtonPanel.ColumnCount = 4;
            tlButtonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlButtonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlButtonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlButtonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlButtonPanel.Controls.Add(btnYes, 0, 0);
            tlButtonPanel.Controls.Add(btnAllYes, 1, 0);
            tlButtonPanel.Controls.Add(btnAllNo, 2, 0);
            tlButtonPanel.Controls.Add(btnNo, 3, 0);
            tlButtonPanel.Location = new Point(10, 70);
            tlButtonPanel.Name = "tlButtonPanel";
            tlButtonPanel.RowCount = 1;
            tlButtonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlButtonPanel.Size = new Size(360, 30);
            tlButtonPanel.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(labelQuestion, 1, 0);
            tableLayoutPanel1.Location = new Point(10, 10);
            tableLayoutPanel1.MinimumSize = new Size(360, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(360, 25);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // tlTitlePanel
            // 
            tlTitlePanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlTitlePanel.ColumnCount = 3;
            tlTitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tlTitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tlTitlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tlTitlePanel.Controls.Add(labelTitleItem, 1, 0);
            tlTitlePanel.Location = new Point(10, 40);
            tlTitlePanel.Name = "tlTitlePanel";
            tlTitlePanel.RowCount = 1;
            tlTitlePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlTitlePanel.Size = new Size(360, 24);
            tlTitlePanel.TabIndex = 10;
            // 
            // DataReplaceMessageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 111);
            Controls.Add(tlTitlePanel);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tlButtonPanel);
            MinimumSize = new Size(400, 150);
            Name = "DataReplaceMessageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Question";
            FormClosing += Btn_FormClosing;
            tlButtonPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tlTitlePanel.ResumeLayout(false);
            tlTitlePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnYes;
        private Button btnAllYes;
        private Button btnNo;
        private Button btnAllNo;
        private Label labelQuestion;
        private Label labelTitleItem;
        private Label labelTitleInfo;
        private TableLayoutPanel tlButtonPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tlTitlePanel;
    }
}
