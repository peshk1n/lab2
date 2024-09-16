namespace lab2
{
    partial class FormTask3
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
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxRGB = new System.Windows.Forms.PictureBox();
            this.pictureBoxHSV = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHSV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сохранить изображение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(180, 62);
            this.trackBar1.Maximum = 360;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(145, 56);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickFrequency = 10;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(180, 124);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(145, 56);
            this.trackBar2.TabIndex = 2;
            this.trackBar2.TickFrequency = 10;
            this.trackBar2.Value = 100;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(180, 186);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(145, 56);
            this.trackBar3.TabIndex = 3;
            this.trackBar3.TickFrequency = 10;
            this.trackBar3.Value = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Тон";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Насыщенность";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Значение";
            // 
            // pictureBoxRGB
            // 
            this.pictureBoxRGB.Location = new System.Drawing.Point(352, 16);
            this.pictureBoxRGB.Name = "pictureBoxRGB";
            this.pictureBoxRGB.Size = new System.Drawing.Size(317, 214);
            this.pictureBoxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRGB.TabIndex = 7;
            this.pictureBoxRGB.TabStop = false;
            // 
            // pictureBoxHSV
            // 
            this.pictureBoxHSV.Location = new System.Drawing.Point(675, 16);
            this.pictureBoxHSV.Name = "pictureBoxHSV";
            this.pictureBoxHSV.Size = new System.Drawing.Size(317, 214);
            this.pictureBoxHSV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHSV.TabIndex = 8;
            this.pictureBoxHSV.TabStop = false;
            // 
            // FormTask3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 753);
            this.Controls.Add(this.pictureBoxHSV);
            this.Controls.Add(this.pictureBoxRGB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Name = "FormTask3";
            this.Text = "FormTask3";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBoxRGB;
        private PictureBox pictureBoxHSV;
    }
}