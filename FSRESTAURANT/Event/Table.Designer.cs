namespace FS_REST.Event
{
    partial class Table
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
            this.nmCapacity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // nmCapacity
            // 
            this.nmCapacity.Location = new System.Drawing.Point(96, 21);
            this.nmCapacity.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmCapacity.Name = "nmCapacity";
            this.nmCapacity.Size = new System.Drawing.Size(120, 20);
            this.nmCapacity.TabIndex = 0;
            this.nmCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Capacity :";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(58, 68);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(158, 36);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 131);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmCapacity);
            this.Name = "Table";
            this.Text = "Table";
            ((System.ComponentModel.ISupportInitialize)(this.nmCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmCapacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsert;
    }
}