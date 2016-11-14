namespace Form_Event
{
    partial class InsertEvent
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbNama = new System.Windows.Forms.TextBox();
            this.nmCapacity = new System.Windows.Forms.NumericUpDown();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtStop = new System.Windows.Forms.DateTimePicker();
            this.lbMenu = new System.Windows.Forms.ListBox();
            this.btnRight2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnLeft2 = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tbDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gpHeader = new System.Windows.Forms.GroupBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gpHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Maximum Capacity";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date Time Start :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tbNama
            // 
            this.tbNama.Location = new System.Drawing.Point(115, 26);
            this.tbNama.Name = "tbNama";
            this.tbNama.Size = new System.Drawing.Size(200, 20);
            this.tbNama.TabIndex = 7;
            // 
            // nmCapacity
            // 
            this.nmCapacity.Location = new System.Drawing.Point(115, 104);
            this.nmCapacity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmCapacity.Name = "nmCapacity";
            this.nmCapacity.Size = new System.Drawing.Size(63, 20);
            this.nmCapacity.TabIndex = 11;
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(115, 52);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 20);
            this.dtStart.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(161, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 37);
            this.label7.TabIndex = 15;
            this.label7.Text = "New Event";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(17, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "Date Time Stop :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtStop
            // 
            this.dtStop.CustomFormat = "dd/MM/yyyy hh:mm:ss";
            this.dtStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStop.Location = new System.Drawing.Point(115, 78);
            this.dtStop.Name = "dtStop";
            this.dtStop.Size = new System.Drawing.Size(200, 20);
            this.dtStop.TabIndex = 17;
            // 
            // lbMenu
            // 
            this.lbMenu.FormattingEnabled = true;
            this.lbMenu.Location = new System.Drawing.Point(10, 238);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(197, 238);
            this.lbMenu.TabIndex = 18;
            // 
            // btnRight2
            // 
            this.btnRight2.Location = new System.Drawing.Point(213, 210);
            this.btnRight2.Name = "btnRight2";
            this.btnRight2.Size = new System.Drawing.Size(45, 48);
            this.btnRight2.TabIndex = 19;
            this.btnRight2.Text = ">>";
            this.btnRight2.UseVisualStyleBackColor = true;
            this.btnRight2.Click += new System.EventHandler(this.btnRight2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(264, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(238, 266);
            this.dataGridView1.TabIndex = 20;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(213, 264);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(45, 48);
            this.btnRight.TabIndex = 21;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(213, 318);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(45, 48);
            this.btnLeft.TabIndex = 22;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnLeft2
            // 
            this.btnLeft2.Location = new System.Drawing.Point(213, 372);
            this.btnLeft2.Name = "btnLeft2";
            this.btnLeft2.Size = new System.Drawing.Size(45, 48);
            this.btnLeft2.TabIndex = 23;
            this.btnLeft2.Text = "<<";
            this.btnLeft2.UseVisualStyleBackColor = true;
            this.btnLeft2.Click += new System.EventHandler(this.btnLeft2_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(111, 482);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(253, 28);
            this.btnInsert.TabIndex = 24;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(321, 36);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(170, 100);
            this.tbDescription.TabIndex = 25;
            this.tbDescription.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(318, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Description :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gpHeader
            // 
            this.gpHeader.Controls.Add(this.tbDescription);
            this.gpHeader.Controls.Add(this.label3);
            this.gpHeader.Controls.Add(this.label1);
            this.gpHeader.Controls.Add(this.label2);
            this.gpHeader.Controls.Add(this.label4);
            this.gpHeader.Controls.Add(this.tbNama);
            this.gpHeader.Controls.Add(this.nmCapacity);
            this.gpHeader.Controls.Add(this.dtStart);
            this.gpHeader.Controls.Add(this.label8);
            this.gpHeader.Controls.Add(this.dtStop);
            this.gpHeader.Location = new System.Drawing.Point(1, 53);
            this.gpHeader.Name = "gpHeader";
            this.gpHeader.Size = new System.Drawing.Size(501, 145);
            this.gpHeader.TabIndex = 27;
            this.gpHeader.TabStop = false;
            this.gpHeader.Text = "Header";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(7, 210);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(200, 20);
            this.tbSearch.TabIndex = 27;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // InsertEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 526);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.gpHeader);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnLeft2);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRight2);
            this.Controls.Add(this.lbMenu);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "InsertEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "insertEvent";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gpHeader.ResumeLayout(false);
            this.gpHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.NumericUpDown nmCapacity;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnLeft2;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRight2;
        private System.Windows.Forms.ListBox lbMenu;
        private System.Windows.Forms.DateTimePicker dtStop;
        private System.Windows.Forms.GroupBox gpHeader;
        private System.Windows.Forms.RichTextBox tbDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSearch;
    }
}