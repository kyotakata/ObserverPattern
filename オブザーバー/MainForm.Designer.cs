namespace オブザーバー
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.components = new System.ComponentModel.Container();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.SubButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // WarningLabel
            // 
            this.WarningLabel.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WarningLabel.Location = new System.Drawing.Point(35, 33);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(246, 108);
            this.WarningLabel.TabIndex = 0;
            this.WarningLabel.Text = "label1";
            this.WarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubButton
            // 
            this.SubButton.Location = new System.Drawing.Point(37, 164);
            this.SubButton.Name = "SubButton";
            this.SubButton.Size = new System.Drawing.Size(105, 30);
            this.SubButton.TabIndex = 1;
            this.SubButton.Text = "Sub";
            this.SubButton.UseVisualStyleBackColor = true;
            this.SubButton.Click += new System.EventHandler(this.SubButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SubButton);
            this.Controls.Add(this.WarningLabel);
            this.Name = "MainForm";
            this.Text = "メイン";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.Button SubButton;
        private System.Windows.Forms.Timer timer1;
    }
}

