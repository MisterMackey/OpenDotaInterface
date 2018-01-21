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
            this.TabAnalyze = new System.Windows.Forms.TabPage();
            this.labelMatchCount = new System.Windows.Forms.Label();
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
            this.TabManage.Controls.Add(this.labelMatchCount);
            this.TabManage.Location = new System.Drawing.Point(4, 22);
            this.TabManage.Name = "TabManage";
            this.TabManage.Padding = new System.Windows.Forms.Padding(3);
            this.TabManage.Size = new System.Drawing.Size(534, 444);
            this.TabManage.TabIndex = 1;
            this.TabManage.Text = "Manage";
            this.TabManage.UseVisualStyleBackColor = true;
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
            // labelMatchCount
            // 
            this.labelMatchCount.AutoSize = true;
            this.labelMatchCount.Location = new System.Drawing.Point(9, 7);
            this.labelMatchCount.Name = "labelMatchCount";
            this.labelMatchCount.Size = new System.Drawing.Size(109, 13);
            this.labelMatchCount.TabIndex = 0;
            this.labelMatchCount.Text = "Current match count: ";
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
    }
}