namespace NetdiskClient
{
    partial class NetdiskForm
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
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.uploadButton = new System.Windows.Forms.Button();
            this.shareButton = new System.Windows.Forms.Button();
            this.friendListBox = new System.Windows.Forms.CheckedListBox();
            this.friendLabel = new System.Windows.Forms.Label();
            this.friendIdTextBox = new System.Windows.Forms.TextBox();
            this.addFriendButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.uploadedFileNumLabel = new System.Windows.Forms.Label();
            this.restspaceLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 12;
            this.fileListBox.Items.AddRange(new object[] {
            "文件1",
            "文件2",
            "文件3",
            "文件4"});
            this.fileListBox.Location = new System.Drawing.Point(10, 69);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(174, 244);
            this.fileListBox.TabIndex = 0;
            this.fileListBox.SelectedIndexChanged += new System.EventHandler(this.fileListBox_SelectedIndexChanged);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(4, 343);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 1;
            this.downloadButton.Text = "下载";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(80, 343);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 2;
            this.uploadButton.Text = "上传";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // shareButton
            // 
            this.shareButton.Location = new System.Drawing.Point(155, 343);
            this.shareButton.Name = "shareButton";
            this.shareButton.Size = new System.Drawing.Size(75, 23);
            this.shareButton.TabIndex = 3;
            this.shareButton.Text = "分享";
            this.shareButton.UseVisualStyleBackColor = true;
            this.shareButton.Click += new System.EventHandler(this.shareButton_Click);
            // 
            // friendListBox
            // 
            this.friendListBox.FormattingEnabled = true;
            this.friendListBox.Items.AddRange(new object[] {
            "张三",
            "李四",
            "王五"});
            this.friendListBox.Location = new System.Drawing.Point(200, 69);
            this.friendListBox.Name = "friendListBox";
            this.friendListBox.Size = new System.Drawing.Size(125, 244);
            this.friendListBox.TabIndex = 4;
            // 
            // friendLabel
            // 
            this.friendLabel.AutoSize = true;
            this.friendLabel.Location = new System.Drawing.Point(10, 9);
            this.friendLabel.Name = "friendLabel";
            this.friendLabel.Size = new System.Drawing.Size(59, 12);
            this.friendLabel.TabIndex = 5;
            this.friendLabel.Text = "新朋友ID:";
            // 
            // friendIdTextBox
            // 
            this.friendIdTextBox.Location = new System.Drawing.Point(86, 6);
            this.friendIdTextBox.Name = "friendIdTextBox";
            this.friendIdTextBox.Size = new System.Drawing.Size(100, 21);
            this.friendIdTextBox.TabIndex = 6;
            // 
            // addFriendButton
            // 
            this.addFriendButton.Location = new System.Drawing.Point(207, 6);
            this.addFriendButton.Name = "addFriendButton";
            this.addFriendButton.Size = new System.Drawing.Size(75, 23);
            this.addFriendButton.TabIndex = 7;
            this.addFriendButton.Text = "添加好友";
            this.addFriendButton.UseVisualStyleBackColor = true;
            this.addFriendButton.Click += new System.EventHandler(this.addFriendButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(229, 343);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 8;
            this.refreshButton.Text = "刷新";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // uploadedFileNumLabel
            // 
            this.uploadedFileNumLabel.AutoSize = true;
            this.uploadedFileNumLabel.Location = new System.Drawing.Point(10, 29);
            this.uploadedFileNumLabel.Name = "uploadedFileNumLabel";
            this.uploadedFileNumLabel.Size = new System.Drawing.Size(83, 12);
            this.uploadedFileNumLabel.TabIndex = 9;
            this.uploadedFileNumLabel.Text = "已上传文件数:";
            // 
            // restspaceLabel
            // 
            this.restspaceLabel.AutoSize = true;
            this.restspaceLabel.Location = new System.Drawing.Point(10, 49);
            this.restspaceLabel.Name = "restspaceLabel";
            this.restspaceLabel.Size = new System.Drawing.Size(59, 12);
            this.restspaceLabel.TabIndex = 10;
            this.restspaceLabel.Text = "空间使用:";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(305, 343);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "删除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // NetdiskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 374);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.restspaceLabel);
            this.Controls.Add(this.uploadedFileNumLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.addFriendButton);
            this.Controls.Add(this.friendIdTextBox);
            this.Controls.Add(this.friendLabel);
            this.Controls.Add(this.friendListBox);
            this.Controls.Add(this.shareButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.fileListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NetdiskForm";
            this.Text = "NetdiskForm";
            this.Load += new System.EventHandler(this.NetdiskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button shareButton;
        private System.Windows.Forms.CheckedListBox friendListBox;
        private System.Windows.Forms.Label friendLabel;
        private System.Windows.Forms.TextBox friendIdTextBox;
        private System.Windows.Forms.Button addFriendButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label uploadedFileNumLabel;
        private System.Windows.Forms.Label restspaceLabel;
        private System.Windows.Forms.Button deleteButton;
    }
}