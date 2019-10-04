namespace btserver
{
    partial class mainForm
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
            this.changeLocation = new System.Windows.Forms.Button();
            this.buttonListener = new System.Windows.Forms.Button();
            this.fileLocationLabel = new System.Windows.Forms.Label();
            this.ListenerStatusInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeLocation
            // 
            this.changeLocation.Enabled = false;
            this.changeLocation.Location = new System.Drawing.Point(133, 140);
            this.changeLocation.Name = "changeLocation";
            this.changeLocation.Size = new System.Drawing.Size(169, 43);
            this.changeLocation.TabIndex = 0;
            this.changeLocation.Text = "文件存放位置:";
            this.changeLocation.UseVisualStyleBackColor = true;
            this.changeLocation.Click += new System.EventHandler(this.ChangeLocation_Click);
            // 
            // buttonListener
            // 
            this.buttonListener.Location = new System.Drawing.Point(133, 249);
            this.buttonListener.Name = "buttonListener";
            this.buttonListener.Size = new System.Drawing.Size(169, 42);
            this.buttonListener.TabIndex = 1;
            this.buttonListener.Text = "开始/停止监听";
            this.buttonListener.UseVisualStyleBackColor = true;
            this.buttonListener.Click += new System.EventHandler(this.Button2_Click);
            // 
            // fileLocationLabel
            // 
            this.fileLocationLabel.AutoSize = true;
            this.fileLocationLabel.Location = new System.Drawing.Point(372, 152);
            this.fileLocationLabel.Name = "fileLocationLabel";
            this.fileLocationLabel.Size = new System.Drawing.Size(35, 17);
            this.fileLocationLabel.TabIndex = 2;
            this.fileLocationLabel.Text = "c:\\bt";
            // 
            // ListenerStatusInfo
            // 
            this.ListenerStatusInfo.AutoSize = true;
            this.ListenerStatusInfo.Location = new System.Drawing.Point(372, 262);
            this.ListenerStatusInfo.Name = "ListenerStatusInfo";
            this.ListenerStatusInfo.Size = new System.Drawing.Size(64, 17);
            this.ListenerStatusInfo.TabIndex = 3;
            this.ListenerStatusInfo.Text = "监听状态";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListenerStatusInfo);
            this.Controls.Add(this.fileLocationLabel);
            this.Controls.Add(this.buttonListener);
            this.Controls.Add(this.changeLocation);
            this.Name = "mainForm";
            this.Text = "蓝牙同步主机版";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeLocation;
        private System.Windows.Forms.Button buttonListener;
        private System.Windows.Forms.Label fileLocationLabel;
        private System.Windows.Forms.Label ListenerStatusInfo;
        private bool isBlueToothAble = false;

        public bool IsBlueToothAble
        {
            get
            {
                return isBlueToothAble;
            }
        }
    }
}

