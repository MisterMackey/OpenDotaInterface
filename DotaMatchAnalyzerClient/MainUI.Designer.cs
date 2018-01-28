namespace DotaMatchAnalyzerClient
{
    partial class MainUI
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabExplore = new System.Windows.Forms.TabPage();
            this.TabManage = new System.Windows.Forms.TabPage();
            this.txtDownloadRange = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.labelMatchCount = new System.Windows.Forms.Label();
            this.TabAnalyze = new System.Windows.Forms.TabPage();
            this.lblHighestMatchId = new System.Windows.Forms.Label();
            this.lblLowestMatchId = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.TabManage.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabExplore);
            this.TabControl.Controls.Add(this.TabManage);
            this.TabControl.Controls.Add(this.TabAnalyze);
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(542, 470);
            this.TabControl.TabIndex = 0;
            // 
            // TabExplore
            // 
            this.TabExplore.Location = new System.Drawing.Point(4, 22);
            this.TabExplore.Name = "TabExplore";
            this.TabExplore.Padding = new System.Windows.Forms.Padding(3);
            this.TabExplore.Size = new System.Drawing.Size(534, 444);
            this.TabExplore.TabIndex = 0;
            this.TabExplore.Text = "Explore";
            this.TabExplore.UseVisualStyleBackColor = true;
            // 
            // TabManage
            // 
            this.TabManage.Controls.Add(this.lblTimer);
            this.TabManage.Controls.Add(this.lblLowestMatchId);
            this.TabManage.Controls.Add(this.lblHighestMatchId);
            this.TabManage.Controls.Add(this.txtDownloadRange);
            this.TabManage.Controls.Add(this.btnDownload);
            this.TabManage.Controls.Add(this.btnDelete);
            this.TabManage.Controls.Add(this.labelMatchCount);
            this.TabManage.Location = new System.Drawing.Point(4, 22);
            this.TabManage.Name = "TabManage";
            this.TabManage.Padding = new System.Windows.Forms.Padding(3);
            this.TabManage.Size = new System.Drawing.Size(534, 444);
            this.TabManage.TabIndex = 1;
            this.TabManage.Text = "Manage";
            this.TabManage.UseVisualStyleBackColor = true;
            // 
            // txtDownloadRange
            // 
            this.txtDownloadRange.Location = new System.Drawing.Point(124, 68);
            this.txtDownloadRange.Name = "txtDownloadRange";
            this.txtDownloadRange.Size = new System.Drawing.Size(100, 20);
            this.txtDownloadRange.TabIndex = 3;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(12, 65);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(106, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download Match";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 35);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete Matches";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // labelMatchCount
            // 
            this.labelMatchCount.AutoSize = true;
            this.labelMatchCount.Location = new System.Drawing.Point(9, 7);
            this.labelMatchCount.Name = "labelMatchCount";
            this.labelMatchCount.Size = new System.Drawing.Size(109, 13);
            this.labelMatchCount.TabIndex = 0;
            this.labelMatchCount.Text = "Current match count: ";
            // 
            // TabAnalyze
            // 
            this.TabAnalyze.Location = new System.Drawing.Point(4, 22);
            this.TabAnalyze.Name = "TabAnalyze";
            this.TabAnalyze.Padding = new System.Windows.Forms.Padding(3);
            this.TabAnalyze.Size = new System.Drawing.Size(534, 444);
            this.TabAnalyze.TabIndex = 2;
            this.TabAnalyze.Text = "Analyze";
            this.TabAnalyze.UseVisualStyleBackColor = true;
            // 
            // lblHighestMatchId
            // 
            this.lblHighestMatchId.AutoSize = true;
            this.lblHighestMatchId.Location = new System.Drawing.Point(192, 7);
            this.lblHighestMatchId.Name = "lblHighestMatchId";
            this.lblHighestMatchId.Size = new System.Drawing.Size(90, 13);
            this.lblHighestMatchId.TabIndex = 4;
            this.lblHighestMatchId.Text = "Highest Match_id";
            // 
            // lblLowestMatchId
            // 
            this.lblLowestMatchId.AutoSize = true;
            this.lblLowestMatchId.Location = new System.Drawing.Point(351, 7);
            this.lblLowestMatchId.Name = "lblLowestMatchId";
            this.lblLowestMatchId.Size = new System.Drawing.Size(88, 13);
            this.lblLowestMatchId.TabIndex = 5;
            this.lblLowestMatchId.Text = "Lowest Match_id";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(263, 75);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(35, 13);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "label1";
            this.lblTimer.Visible = false;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 471);
            this.Controls.Add(this.TabControl);
            this.Name = "MainUI";
            this.Text = "DotaMatchAnalyzer";
            this.TabControl.ResumeLayout(false);
            this.TabManage.ResumeLayout(false);
            this.TabManage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabExplore;
        private System.Windows.Forms.TabPage TabManage;
        private System.Windows.Forms.TabPage TabAnalyze;
        private System.Windows.Forms.Label labelMatchCount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtDownloadRange;
        private System.Windows.Forms.Label lblLowestMatchId;
        private System.Windows.Forms.Label lblHighestMatchId;
        private System.Windows.Forms.Label lblTimer;
    }
}