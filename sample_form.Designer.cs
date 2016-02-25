namespace ftpRemote
{
    partial class sample_form
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReadfile = new System.Windows.Forms.Button();
            this.ServerDirList = new System.Windows.Forms.ListBox();
            this.btnFileStream = new System.Windows.Forms.Button();
            this.txtCsvDetail = new System.Windows.Forms.TextBox();
            this.txtServerDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnReadfile
            // 
            this.btnReadfile.Location = new System.Drawing.Point(12, 43);
            this.btnReadfile.Name = "btnReadfile";
            this.btnReadfile.Size = new System.Drawing.Size(120, 30);
            this.btnReadfile.TabIndex = 0;
            this.btnReadfile.Text = "サーバ読み込み";
            this.btnReadfile.UseVisualStyleBackColor = true;
            this.btnReadfile.Click += new System.EventHandler(this.btnReadfile_Click);
            // 
            // ServerDirList
            // 
            this.ServerDirList.FormattingEnabled = true;
            this.ServerDirList.ItemHeight = 12;
            this.ServerDirList.Location = new System.Drawing.Point(13, 79);
            this.ServerDirList.Name = "ServerDirList";
            this.ServerDirList.Size = new System.Drawing.Size(649, 88);
            this.ServerDirList.TabIndex = 2;
            // 
            // btnFileStream
            // 
            this.btnFileStream.Location = new System.Drawing.Point(12, 173);
            this.btnFileStream.Name = "btnFileStream";
            this.btnFileStream.Size = new System.Drawing.Size(120, 30);
            this.btnFileStream.TabIndex = 0;
            this.btnFileStream.Text = "ファイルストリーミング";
            this.btnFileStream.UseVisualStyleBackColor = true;
            this.btnFileStream.Click += new System.EventHandler(this.btnFileStream_Click);
            // 
            // txtCsvDetail
            // 
            this.txtCsvDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCsvDetail.Location = new System.Drawing.Point(13, 210);
            this.txtCsvDetail.Multiline = true;
            this.txtCsvDetail.Name = "txtCsvDetail";
            this.txtCsvDetail.Size = new System.Drawing.Size(648, 157);
            this.txtCsvDetail.TabIndex = 3;
            // 
            // txtServerDirectory
            // 
            this.txtServerDirectory.Location = new System.Drawing.Point(75, 12);
            this.txtServerDirectory.Name = "txtServerDirectory";
            this.txtServerDirectory.Size = new System.Drawing.Size(200, 19);
            this.txtServerDirectory.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "サーバURL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "ユーザー";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(353, 12);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(90, 19);
            this.txtUser.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "パスワード";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(515, 12);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(90, 19);
            this.txtPass.TabIndex = 8;
            // 
            // sample_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 379);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerDirectory);
            this.Controls.Add(this.txtCsvDetail);
            this.Controls.Add(this.ServerDirList);
            this.Controls.Add(this.btnFileStream);
            this.Controls.Add(this.btnReadfile);
            this.Name = "sample_form";
            this.Text = "サンプルアプリ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadfile;
        private System.Windows.Forms.ListBox ServerDirList;
        private System.Windows.Forms.Button btnFileStream;
        private System.Windows.Forms.TextBox txtCsvDetail;
        private System.Windows.Forms.TextBox txtServerDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPass;
    }
}

