namespace FS_REST
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertPenjualanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPenjualanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dcPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationToolStripMenuItem,
            this.tableToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertEventToolStripMenuItem,
            this.searchEventToolStripMenuItem,
            this.insertPenjualanToolStripMenuItem,
            this.searchPenjualanToolStripMenuItem});
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.operationToolStripMenuItem.Text = "Event";
            // 
            // insertEventToolStripMenuItem
            // 
            this.insertEventToolStripMenuItem.Name = "insertEventToolStripMenuItem";
            this.insertEventToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.insertEventToolStripMenuItem.Text = "Insert Event";
            this.insertEventToolStripMenuItem.Click += new System.EventHandler(this.insertEventToolStripMenuItem_Click);
            // 
            // searchEventToolStripMenuItem
            // 
            this.searchEventToolStripMenuItem.Name = "searchEventToolStripMenuItem";
            this.searchEventToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.searchEventToolStripMenuItem.Text = "Search Event";
            this.searchEventToolStripMenuItem.Click += new System.EventHandler(this.searchEventToolStripMenuItem_Click);
            // 
            // insertPenjualanToolStripMenuItem
            // 
            this.insertPenjualanToolStripMenuItem.Name = "insertPenjualanToolStripMenuItem";
            this.insertPenjualanToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.insertPenjualanToolStripMenuItem.Text = "Insert Penjualan";
            this.insertPenjualanToolStripMenuItem.Click += new System.EventHandler(this.insertPenjualanToolStripMenuItem_Click);
            // 
            // searchPenjualanToolStripMenuItem
            // 
            this.searchPenjualanToolStripMenuItem.Name = "searchPenjualanToolStripMenuItem";
            this.searchPenjualanToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.searchPenjualanToolStripMenuItem.Text = "Search Penjualan";
            this.searchPenjualanToolStripMenuItem.Click += new System.EventHandler(this.searchPenjualanToolStripMenuItem_Click);
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTableToolStripMenuItem,
            this.detailTableToolStripMenuItem});
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // newTableToolStripMenuItem
            // 
            this.newTableToolStripMenuItem.Name = "newTableToolStripMenuItem";
            this.newTableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newTableToolStripMenuItem.Text = "New Table";
            this.newTableToolStripMenuItem.Click += new System.EventHandler(this.newTableToolStripMenuItem_Click);
            // 
            // detailTableToolStripMenuItem
            // 
            this.detailTableToolStripMenuItem.Name = "detailTableToolStripMenuItem";
            this.detailTableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.detailTableToolStripMenuItem.Text = "Detail Table";
            this.detailTableToolStripMenuItem.Click += new System.EventHandler(this.detailTableToolStripMenuItem_Click);
            // 
            // dcPanel
            // 
            this.dcPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dcPanel.Location = new System.Drawing.Point(0, 24);
            this.dcPanel.Name = "dcPanel";
            this.dcPanel.Size = new System.Drawing.Size(684, 438);
            this.dcPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.dcPanel);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FSRESTAURANT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertEventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchEventToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dcPanel;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertPenjualanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchPenjualanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailTableToolStripMenuItem;
    }
}

