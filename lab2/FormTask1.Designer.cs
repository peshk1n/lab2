namespace lab2
{
    partial class FormTask1
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
            this.photo = new System.Windows.Forms.PictureBox();
            this.p_gray1 = new System.Windows.Forms.PictureBox();
            this.histogram1 = new System.Windows.Forms.PictureBox();
            this.p_gray2 = new System.Windows.Forms.PictureBox();
            this.difference = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_gray1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_gray2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difference)).BeginInit();
            this.SuspendLayout();
            // 
            // photo
            // 
            this.photo.Location = new System.Drawing.Point(3, 12);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(299, 243);
            this.photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photo.TabIndex = 0;
            this.photo.TabStop = false;
            // 
            // p_gray1
            // 
            this.p_gray1.Location = new System.Drawing.Point(308, 12);
            this.p_gray1.Name = "p_gray1";
            this.p_gray1.Size = new System.Drawing.Size(299, 243);
            this.p_gray1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_gray1.TabIndex = 1;
            this.p_gray1.TabStop = false;
            // 
            // histogram1
            // 
            this.histogram1.Location = new System.Drawing.Point(3, 261);
            this.histogram1.Name = "histogram1";
            this.histogram1.Size = new System.Drawing.Size(1214, 374);
            this.histogram1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.histogram1.TabIndex = 2;
            this.histogram1.TabStop = false;
            // 
            // p_gray2
            // 
            this.p_gray2.Location = new System.Drawing.Point(613, 12);
            this.p_gray2.Name = "p_gray2";
            this.p_gray2.Size = new System.Drawing.Size(299, 243);
            this.p_gray2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_gray2.TabIndex = 3;
            this.p_gray2.TabStop = false;
            // 
            // difference
            // 
            this.difference.Location = new System.Drawing.Point(918, 12);
            this.difference.Name = "difference";
            this.difference.Size = new System.Drawing.Size(299, 243);
            this.difference.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.difference.TabIndex = 5;
            this.difference.TabStop = false;
            this.difference.SizeChanged += new System.EventHandler(this.dif_Resize);
            this.difference.Resize += new System.EventHandler(this.dif_Resize);
            // 
            // FormTask1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 647);
            this.Controls.Add(this.difference);
            this.Controls.Add(this.p_gray2);
            this.Controls.Add(this.histogram1);
            this.Controls.Add(this.p_gray1);
            this.Controls.Add(this.photo);
            this.Name = "FormTask1";
            this.Text = "FormTask1";
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_gray1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_gray2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difference)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox photo;
        private PictureBox p_gray1;
        private PictureBox histogram1;
        private PictureBox p_gray2;
        private PictureBox difference;
    }
}