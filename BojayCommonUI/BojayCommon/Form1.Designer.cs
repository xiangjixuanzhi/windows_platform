namespace BojayCommon

{
    partial class BojayClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BojayClass));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel_table = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button_start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Files = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_project = new System.Windows.Forms.TextBox();
            this.textBox_times = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_mode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.richTextBox_ShowErrorMessage = new System.Windows.Forms.RichTextBox();
            this.label_show = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel_table.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_table
            // 
            this.panel_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_table.BackColor = System.Drawing.SystemColors.Control;
            this.panel_table.Controls.Add(this.listView1);
            this.panel_table.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_table.Location = new System.Drawing.Point(13, 67);
            this.panel_table.Name = "panel_table";
            this.panel_table.Size = new System.Drawing.Size(1657, 575);
            this.panel_table.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1657, 575);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button_start.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_start.Location = new System.Drawing.Point(1467, 729);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(203, 64);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.Start_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1461, 663);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 47);
            this.label1.TabIndex = 3;
            this.label1.Text = "Files：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.UseMnemonic = false;
            // 
            // textBox_Files
            // 
            this.textBox_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Files.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_Files.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Files.Location = new System.Drawing.Point(1555, 666);
            this.textBox_Files.Name = "textBox_Files";
            this.textBox_Files.ReadOnly = true;
            this.textBox_Files.Size = new System.Drawing.Size(115, 42);
            this.textBox_Files.TabIndex = 4;
            this.textBox_Files.Text = "0";
            this.textBox_Files.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 47);
            this.label2.TabIndex = 5;
            this.label2.Text = "Project";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_project
            // 
            this.textBox_project.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_project.Location = new System.Drawing.Point(109, 14);
            this.textBox_project.Name = "textBox_project";
            this.textBox_project.ReadOnly = true;
            this.textBox_project.Size = new System.Drawing.Size(223, 42);
            this.textBox_project.TabIndex = 6;
            this.textBox_project.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_times
            // 
            this.textBox_times.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_times.Location = new System.Drawing.Point(455, 14);
            this.textBox_times.Name = "textBox_times";
            this.textBox_times.ReadOnly = true;
            this.textBox_times.Size = new System.Drawing.Size(146, 42);
            this.textBox_times.TabIndex = 8;
            this.textBox_times.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(364, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 47);
            this.label3.TabIndex = 7;
            this.label3.Text = "Times";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_mode
            // 
            this.textBox_mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_mode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_mode.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_mode.Location = new System.Drawing.Point(1467, 14);
            this.textBox_mode.Name = "textBox_mode";
            this.textBox_mode.ReadOnly = true;
            this.textBox_mode.Size = new System.Drawing.Size(203, 42);
            this.textBox_mode.TabIndex = 10;
            this.textBox_mode.Text = "LOCAL";
            this.textBox_mode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1376, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 47);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mode";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox_ShowErrorMessage
            // 
            this.richTextBox_ShowErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_ShowErrorMessage.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_ShowErrorMessage.Location = new System.Drawing.Point(12, 650);
            this.richTextBox_ShowErrorMessage.Name = "richTextBox_ShowErrorMessage";
            this.richTextBox_ShowErrorMessage.Size = new System.Drawing.Size(1443, 143);
            this.richTextBox_ShowErrorMessage.TabIndex = 1;
            this.richTextBox_ShowErrorMessage.Text = "";
            // 
            // label_show
            // 
            this.label_show.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_show.BackColor = System.Drawing.SystemColors.Window;
            this.label_show.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_show.Location = new System.Drawing.Point(653, 682);
            this.label_show.Name = "label_show";
            this.label_show.Size = new System.Drawing.Size(214, 78);
            this.label_show.TabIndex = 11;
            this.label_show.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BojayClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 803);
            this.Controls.Add(this.label_show);
            this.Controls.Add(this.textBox_mode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_times);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_project);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Files);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.richTextBox_ShowErrorMessage);
            this.Controls.Add(this.panel_table);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1700, 850);
            this.Name = "BojayClass";
            this.Text = "***MainWindows***";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel_table.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel_table;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Files;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_project;
        private System.Windows.Forms.TextBox textBox_times;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_mode;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.RichTextBox richTextBox_ShowErrorMessage;
        private System.Windows.Forms.Label label_show;
    }
}

