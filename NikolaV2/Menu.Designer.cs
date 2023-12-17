namespace NikolaV2
{
    partial class Menu1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu1));
            this.musicCheck = new System.Windows.Forms.CheckBox();
            this.playButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.helpButton = new System.Windows.Forms.Button();
            this.GalleryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // musicCheck
            // 
            this.musicCheck.AutoSize = true;
            this.musicCheck.Location = new System.Drawing.Point(220, 301);
            this.musicCheck.Name = "musicCheck";
            this.musicCheck.Size = new System.Drawing.Size(66, 17);
            this.musicCheck.TabIndex = 0;
            this.musicCheck.Text = "MUSIC?";
            this.musicCheck.UseVisualStyleBackColor = true;
            this.musicCheck.CheckedChanged += new System.EventHandler(this.musicCheck_CheckedChanged);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(220, 187);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(296, 46);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "PLAY";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(443, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "\"Fig Leaf Times Two\" Kevin MacLeod (incompetech.com)\r\nLicensed under Creative Com" +
    "mons: By Attribution 4.0 License\r\nhttp://creativecommons.org/licenses/by/4.0/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 65);
            this.label2.TabIndex = 3;
            this.label2.Text = "Coding, Sprites : Michal \"Nevada\" Vacho\r\nCards made using : Canva\r\nMusic source :" +
    " Incompetech\r\nTesters : \r\nCoded in C#";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(151, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 160);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(220, 239);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(145, 46);
            this.helpButton.TabIndex = 5;
            this.helpButton.Text = "HELP";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // GalleryButton
            // 
            this.GalleryButton.Location = new System.Drawing.Point(371, 239);
            this.GalleryButton.Name = "GalleryButton";
            this.GalleryButton.Size = new System.Drawing.Size(145, 46);
            this.GalleryButton.TabIndex = 6;
            this.GalleryButton.Text = "GALLERY";
            this.GalleryButton.UseVisualStyleBackColor = true;
            this.GalleryButton.Click += new System.EventHandler(this.GalleryButton_Click);
            // 
            // Menu1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(752, 441);
            this.Controls.Add(this.GalleryButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.musicCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu1";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox musicCheck;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button GalleryButton;
    }
}