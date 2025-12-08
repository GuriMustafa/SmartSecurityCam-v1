namespace SmartSecurityCam_v1
{
    partial class Form1
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
            this.listLog = new System.Windows.Forms.ListBox();
            this.pictureBoxFeed = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.Location = new System.Drawing.Point(12, 485);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(776, 186);
            this.listLog.TabIndex = 0;
            // 
            // pictureBoxFeed
            // 
            this.pictureBoxFeed.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxFeed.Name = "pictureBoxFeed";
            this.pictureBoxFeed.Size = new System.Drawing.Size(776, 391);
            this.pictureBoxFeed.TabIndex = 1;
            this.pictureBoxFeed.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(12, 409);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(190, 70);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Camera";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(217, 409);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(190, 70);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop Camera";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 681);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBoxFeed);
            this.Controls.Add(this.listLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.PictureBox pictureBoxFeed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
    }
}

