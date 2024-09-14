namespace lab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.task1 = new System.Windows.Forms.Button();
            this.task2 = new System.Windows.Forms.Button();
            this.task3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Загрузить изображение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // task1
            // 
            this.task1.Enabled = false;
            this.task1.Location = new System.Drawing.Point(6, 47);
            this.task1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.task1.Name = "task1";
            this.task1.Size = new System.Drawing.Size(88, 28);
            this.task1.TabIndex = 1;
            this.task1.Text = "Задание 1";
            this.task1.UseVisualStyleBackColor = true;
            // 
            // task2
            // 
            this.task2.Enabled = false;
            this.task2.Location = new System.Drawing.Point(97, 47);
            this.task2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.task2.Name = "task2";
            this.task2.Size = new System.Drawing.Size(88, 28);
            this.task2.TabIndex = 2;
            this.task2.Text = "Задание 2";
            this.task2.UseVisualStyleBackColor = true;
            this.task2.Click += new System.EventHandler(this.task2_Click);
            // 
            // task3
            // 
            this.task3.Enabled = false;
            this.task3.Location = new System.Drawing.Point(188, 47);
            this.task3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.task3.Name = "task3";
            this.task3.Size = new System.Drawing.Size(88, 28);
            this.task3.TabIndex = 3;
            this.task3.Text = "Задание 3";
            this.task3.UseVisualStyleBackColor = true;
            this.task3.Click += new System.EventHandler(this.task3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(282, 90);
            this.Controls.Add(this.task3);
            this.Controls.Add(this.task2);
            this.Controls.Add(this.task1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button task1;
        private Button task2;
        private Button task3;
    }
}