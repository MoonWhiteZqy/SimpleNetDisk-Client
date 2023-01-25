namespace NetdiskClient
{
    partial class ManagerForm
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
            this.useridLabel = new System.Windows.Forms.Label();
            this.useridTextBox = new System.Windows.Forms.TextBox();
            this.queryUserButton = new System.Windows.Forms.Button();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.userListBox = new System.Windows.Forms.CheckedListBox();
            this.spaceInfoLabel = new System.Windows.Forms.Label();
            this.friendNumLabel = new System.Windows.Forms.Label();
            this.uploadFileNumLabel = new System.Windows.Forms.Label();
            this.lowerSpace = new System.Windows.Forms.TextBox();
            this.spaceUsedLabel = new System.Windows.Forms.Label();
            this.lowerFileNum = new System.Windows.Forms.TextBox();
            this.uploadCntLabel = new System.Windows.Forms.Label();
            this.higherSpace = new System.Windows.Forms.TextBox();
            this.higherFileNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // useridLabel
            // 
            this.useridLabel.AutoSize = true;
            this.useridLabel.Location = new System.Drawing.Point(17, 23);
            this.useridLabel.Name = "useridLabel";
            this.useridLabel.Size = new System.Drawing.Size(47, 12);
            this.useridLabel.TabIndex = 0;
            this.useridLabel.Text = "用户ID:";
            // 
            // useridTextBox
            // 
            this.useridTextBox.Location = new System.Drawing.Point(82, 20);
            this.useridTextBox.Name = "useridTextBox";
            this.useridTextBox.Size = new System.Drawing.Size(100, 21);
            this.useridTextBox.TabIndex = 1;
            // 
            // queryUserButton
            // 
            this.queryUserButton.Location = new System.Drawing.Point(19, 326);
            this.queryUserButton.Name = "queryUserButton";
            this.queryUserButton.Size = new System.Drawing.Size(75, 23);
            this.queryUserButton.TabIndex = 2;
            this.queryUserButton.Text = "查找";
            this.queryUserButton.UseVisualStyleBackColor = true;
            this.queryUserButton.Click += new System.EventHandler(this.queryUserButton_Click);
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Location = new System.Drawing.Point(236, 326);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(75, 23);
            this.deleteUserButton.TabIndex = 3;
            this.deleteUserButton.Text = "删除";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // userListBox
            // 
            this.userListBox.FormattingEnabled = true;
            this.userListBox.Items.AddRange(new object[] {
            "张三",
            "李四",
            "王五"});
            this.userListBox.Location = new System.Drawing.Point(183, 151);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(119, 132);
            this.userListBox.TabIndex = 4;
            this.userListBox.SelectedIndexChanged += new System.EventHandler(this.userListBox_SelectedIndexChanged);
            // 
            // spaceInfoLabel
            // 
            this.spaceInfoLabel.AutoSize = true;
            this.spaceInfoLabel.Location = new System.Drawing.Point(17, 151);
            this.spaceInfoLabel.Name = "spaceInfoLabel";
            this.spaceInfoLabel.Size = new System.Drawing.Size(59, 12);
            this.spaceInfoLabel.TabIndex = 5;
            this.spaceInfoLabel.Text = "使用空间:";
            // 
            // friendNumLabel
            // 
            this.friendNumLabel.AutoSize = true;
            this.friendNumLabel.Location = new System.Drawing.Point(17, 171);
            this.friendNumLabel.Name = "friendNumLabel";
            this.friendNumLabel.Size = new System.Drawing.Size(47, 12);
            this.friendNumLabel.TabIndex = 6;
            this.friendNumLabel.Text = "好友数:";
            // 
            // uploadFileNumLabel
            // 
            this.uploadFileNumLabel.AutoSize = true;
            this.uploadFileNumLabel.Location = new System.Drawing.Point(17, 191);
            this.uploadFileNumLabel.Name = "uploadFileNumLabel";
            this.uploadFileNumLabel.Size = new System.Drawing.Size(71, 12);
            this.uploadFileNumLabel.TabIndex = 7;
            this.uploadFileNumLabel.Text = "上传文件数:";
            // 
            // lowerSpace
            // 
            this.lowerSpace.Location = new System.Drawing.Point(82, 47);
            this.lowerSpace.Name = "lowerSpace";
            this.lowerSpace.Size = new System.Drawing.Size(100, 21);
            this.lowerSpace.TabIndex = 10;
            // 
            // spaceUsedLabel
            // 
            this.spaceUsedLabel.AutoSize = true;
            this.spaceUsedLabel.Location = new System.Drawing.Point(17, 50);
            this.spaceUsedLabel.Name = "spaceUsedLabel";
            this.spaceUsedLabel.Size = new System.Drawing.Size(59, 12);
            this.spaceUsedLabel.TabIndex = 9;
            this.spaceUsedLabel.Text = "空间大小:";
            // 
            // lowerFileNum
            // 
            this.lowerFileNum.Location = new System.Drawing.Point(82, 80);
            this.lowerFileNum.Name = "lowerFileNum";
            this.lowerFileNum.Size = new System.Drawing.Size(100, 21);
            this.lowerFileNum.TabIndex = 12;
            // 
            // uploadCntLabel
            // 
            this.uploadCntLabel.AutoSize = true;
            this.uploadCntLabel.Location = new System.Drawing.Point(17, 83);
            this.uploadCntLabel.Name = "uploadCntLabel";
            this.uploadCntLabel.Size = new System.Drawing.Size(59, 12);
            this.uploadCntLabel.TabIndex = 11;
            this.uploadCntLabel.Text = "上传文件:";
            // 
            // higherSpace
            // 
            this.higherSpace.Location = new System.Drawing.Point(211, 50);
            this.higherSpace.Name = "higherSpace";
            this.higherSpace.Size = new System.Drawing.Size(100, 21);
            this.higherSpace.TabIndex = 13;
            // 
            // higherFileNum
            // 
            this.higherFileNum.Location = new System.Drawing.Point(211, 80);
            this.higherFileNum.Name = "higherFileNum";
            this.higherFileNum.Size = new System.Drawing.Size(100, 21);
            this.higherFileNum.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "至";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "至";
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 381);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.higherFileNum);
            this.Controls.Add(this.higherSpace);
            this.Controls.Add(this.lowerFileNum);
            this.Controls.Add(this.uploadCntLabel);
            this.Controls.Add(this.lowerSpace);
            this.Controls.Add(this.spaceUsedLabel);
            this.Controls.Add(this.uploadFileNumLabel);
            this.Controls.Add(this.friendNumLabel);
            this.Controls.Add(this.spaceInfoLabel);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.deleteUserButton);
            this.Controls.Add(this.queryUserButton);
            this.Controls.Add(this.useridTextBox);
            this.Controls.Add(this.useridLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManagerForm";
            this.Text = "ManagerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label useridLabel;
        private System.Windows.Forms.TextBox useridTextBox;
        private System.Windows.Forms.Button queryUserButton;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.CheckedListBox userListBox;
        private System.Windows.Forms.Label spaceInfoLabel;
        private System.Windows.Forms.Label friendNumLabel;
        private System.Windows.Forms.Label uploadFileNumLabel;
        private System.Windows.Forms.TextBox lowerSpace;
        private System.Windows.Forms.Label spaceUsedLabel;
        private System.Windows.Forms.TextBox lowerFileNum;
        private System.Windows.Forms.Label uploadCntLabel;
        private System.Windows.Forms.TextBox higherSpace;
        private System.Windows.Forms.TextBox higherFileNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}