namespace Saturland
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel_headerHome = new System.Windows.Forms.Panel();
            this.pictureBox_Leftback = new System.Windows.Forms.PictureBox();
            this.pictureBox_Minimize = new System.Windows.Forms.PictureBox();
            this.pictureBox_Exit = new System.Windows.Forms.PictureBox();
            this.pictureBox_Amazement = new System.Windows.Forms.PictureBox();
            this.pictureBox_Waterpark = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_headerHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Leftback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Amazement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Waterpark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel_headerHome
            // 
            this.panel_headerHome.BackColor = System.Drawing.Color.Transparent;
            this.panel_headerHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_headerHome.BackgroundImage")));
            this.panel_headerHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_headerHome.Controls.Add(this.pictureBox_Leftback);
            this.panel_headerHome.Controls.Add(this.pictureBox_Minimize);
            this.panel_headerHome.Controls.Add(this.pictureBox_Exit);
            this.panel_headerHome.Location = new System.Drawing.Point(2, 2);
            this.panel_headerHome.Name = "panel_headerHome";
            this.panel_headerHome.Size = new System.Drawing.Size(1280, 720);
            this.panel_headerHome.TabIndex = 0;
            this.panel_headerHome.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_headerHome_Paint);
            // 
            // pictureBox_Leftback
            // 
            this.pictureBox_Leftback.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Leftback.BackgroundImage")));
            this.pictureBox_Leftback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Leftback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Leftback.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Leftback.Name = "pictureBox_Leftback";
            this.pictureBox_Leftback.Size = new System.Drawing.Size(70, 70);
            this.pictureBox_Leftback.TabIndex = 5;
            this.pictureBox_Leftback.TabStop = false;
            this.pictureBox_Leftback.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox_Minimize
            // 
            this.pictureBox_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Minimize.BackgroundImage")));
            this.pictureBox_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Minimize.Location = new System.Drawing.Point(1171, -2);
            this.pictureBox_Minimize.Name = "pictureBox_Minimize";
            this.pictureBox_Minimize.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_Minimize.TabIndex = 4;
            this.pictureBox_Minimize.TabStop = false;
            this.pictureBox_Minimize.Click += new System.EventHandler(this.pictureBox_Minimize_Click);
            // 
            // pictureBox_Exit
            // 
            this.pictureBox_Exit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Exit.BackgroundImage")));
            this.pictureBox_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Exit.Location = new System.Drawing.Point(1227, 0);
            this.pictureBox_Exit.Name = "pictureBox_Exit";
            this.pictureBox_Exit.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_Exit.TabIndex = 3;
            this.pictureBox_Exit.TabStop = false;
            this.pictureBox_Exit.Click += new System.EventHandler(this.pictureBox_Exit_Click);
            // 
            // pictureBox_Amazement
            // 
            this.pictureBox_Amazement.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Amazement.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Amazement.BackgroundImage")));
            this.pictureBox_Amazement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Amazement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Amazement.Location = new System.Drawing.Point(56, 280);
            this.pictureBox_Amazement.Name = "pictureBox_Amazement";
            this.pictureBox_Amazement.Size = new System.Drawing.Size(350, 375);
            this.pictureBox_Amazement.TabIndex = 3;
            this.pictureBox_Amazement.TabStop = false;
            this.pictureBox_Amazement.Click += new System.EventHandler(this.pictureBox_Amazement_Click);
            // 
            // pictureBox_Waterpark
            // 
            this.pictureBox_Waterpark.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Waterpark.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Waterpark.BackgroundImage")));
            this.pictureBox_Waterpark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Waterpark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_Waterpark.Location = new System.Drawing.Point(468, 280);
            this.pictureBox_Waterpark.Name = "pictureBox_Waterpark";
            this.pictureBox_Waterpark.Size = new System.Drawing.Size(350, 375);
            this.pictureBox_Waterpark.TabIndex = 4;
            this.pictureBox_Waterpark.TabStop = false;
            this.pictureBox_Waterpark.Click += new System.EventHandler(this.pictureBox_Waterpark_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox1.Location = new System.Drawing.Point(870, 280);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 375);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox_Waterpark);
            this.Controls.Add(this.pictureBox_Amazement);
            this.Controls.Add(this.panel_headerHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.panel_headerHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Leftback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Amazement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Waterpark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel_headerHome;
        private System.Windows.Forms.PictureBox pictureBox_Amazement;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox_Waterpark;
        private System.Windows.Forms.PictureBox pictureBox_Minimize;
        private System.Windows.Forms.PictureBox pictureBox_Exit;
        private System.Windows.Forms.PictureBox pictureBox_Leftback;
    }
}