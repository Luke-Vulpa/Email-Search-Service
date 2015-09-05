namespace EmailSearchSerice
{
    partial class EmailFinder
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
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailSearchHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.exportAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(284, 51);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(193, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(27, 52);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(236, 22);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(27, 99);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(450, 302);
            this.resultTextBox.TabIndex = 3;
            this.resultTextBox.TextChanged += new System.EventHandler(this.resultTextBox_TextChanged);
            this.resultTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resultTextBox_KeyDown);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(284, 474);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(193, 27);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Export as...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(504, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailSearchHelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // emailSearchHelpToolStripMenuItem
            // 
            this.emailSearchHelpToolStripMenuItem.Name = "emailSearchHelpToolStripMenuItem";
            this.emailSearchHelpToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.emailSearchHelpToolStripMenuItem.Text = "Email Search Help...";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(24, 434);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(63, 17);
            this.resultLabel.TabIndex = 5;
            this.resultLabel.Text = "Results: ";
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(284, 428);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 6;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(402, 428);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // exportAsToolStripMenuItem
            // 
            this.exportAsToolStripMenuItem.Name = "exportAsToolStripMenuItem";
            this.exportAsToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.exportAsToolStripMenuItem.Text = "Export As...";
            this.exportAsToolStripMenuItem.Click += new System.EventHandler(this.exportAsToolStripMenuItem_Click);
            // 
            // EmailFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 531);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EmailFinder";
            this.Text = "Email Search ";
            this.Load += new System.EventHandler(this.EmailFinder_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailSearchHelpToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStripMenuItem exportAsToolStripMenuItem;
    }
}

