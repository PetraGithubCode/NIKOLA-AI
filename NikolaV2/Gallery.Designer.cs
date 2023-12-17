namespace NikolaV2
{
    partial class Gallery
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
            this.cardImg = new System.Windows.Forms.PictureBox();
            this.Explanation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cardImg)).BeginInit();
            this.SuspendLayout();
            // 
            // cardImg
            // 
            this.cardImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cardImg.Location = new System.Drawing.Point(91, 32);
            this.cardImg.Name = "cardImg";
            this.cardImg.Size = new System.Drawing.Size(141, 200);
            this.cardImg.TabIndex = 0;
            this.cardImg.TabStop = false;
            this.cardImg.Click += new System.EventHandler(this.cardImg_Click);
            // 
            // Explanation
            // 
            this.Explanation.AutoSize = true;
            this.Explanation.Location = new System.Drawing.Point(91, 283);
            this.Explanation.Name = "Explanation";
            this.Explanation.Size = new System.Drawing.Size(35, 13);
            this.Explanation.TabIndex = 1;
            this.Explanation.Text = "label1";
            // 
            // Gallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 450);
            this.Controls.Add(this.Explanation);
            this.Controls.Add(this.cardImg);
            this.Name = "Gallery";
            this.Text = "Gallery";
            ((System.ComponentModel.ISupportInitialize)(this.cardImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Explanation;
        public System.Windows.Forms.PictureBox cardImg;
    }
}