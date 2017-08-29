namespace Nager.Date.Monitor
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
            this.dataGridViewPublicHoliday = new System.Windows.Forms.DataGridView();
            this.buttonGet = new System.Windows.Forms.Button();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublicHoliday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPublicHoliday
            // 
            this.dataGridViewPublicHoliday.AllowUserToAddRows = false;
            this.dataGridViewPublicHoliday.AllowUserToDeleteRows = false;
            this.dataGridViewPublicHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPublicHoliday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPublicHoliday.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPublicHoliday.Name = "dataGridViewPublicHoliday";
            this.dataGridViewPublicHoliday.ReadOnly = true;
            this.dataGridViewPublicHoliday.Size = new System.Drawing.Size(479, 379);
            this.dataGridViewPublicHoliday.TabIndex = 0;
            this.dataGridViewPublicHoliday.SelectionChanged += new System.EventHandler(this.dataGridViewPublicHoliday_SelectionChanged);
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(236, 13);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(75, 23);
            this.buttonGet.TabIndex = 2;
            this.buttonGet.Text = "Get";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Location = new System.Drawing.Point(3, 15);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCountry.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxYear);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxCountry);
            this.splitContainer1.Panel1.Controls.Add(this.buttonGet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(730, 433);
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewPublicHoliday);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridViewDetail);
            this.splitContainer2.Size = new System.Drawing.Size(730, 379);
            this.splitContainer2.SplitterDistance = 479;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.ReadOnly = true;
            this.dataGridViewDetail.Size = new System.Drawing.Size(247, 379);
            this.dataGridViewDetail.TabIndex = 1;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(130, 15);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(100, 20);
            this.textBoxYear.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 433);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Nager.Date.Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPublicHoliday)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPublicHoliday;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.TextBox textBoxYear;
    }
}

