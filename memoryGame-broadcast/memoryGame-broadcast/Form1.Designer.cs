namespace memoryGame_broadcast
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.imgListGame1 = new System.Windows.Forms.ImageList(this.components);
            this.imgListApp = new System.Windows.Forms.ImageList(this.components);
            this.imgListNone = new System.Windows.Forms.ImageList(this.components);
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtPlayers = new System.Windows.Forms.TextBox();
            this.imgListGame2 = new System.Windows.Forms.ImageList(this.components);
            this.btnOcultarImages = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // imgListGame1
            // 
            this.imgListGame1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListGame1.ImageStream")));
            this.imgListGame1.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListGame1.Images.SetKeyName(0, "acrobat.png");
            this.imgListGame1.Images.SetKeyName(1, "android.png");
            this.imgListGame1.Images.SetKeyName(2, "apple.png");
            this.imgListGame1.Images.SetKeyName(3, "css.png");
            this.imgListGame1.Images.SetKeyName(4, "excel.png");
            this.imgListGame1.Images.SetKeyName(5, "facebook.png");
            this.imgListGame1.Images.SetKeyName(6, "github.png");
            this.imgListGame1.Images.SetKeyName(7, "google.png");
            this.imgListGame1.Images.SetKeyName(8, "html.png");
            this.imgListGame1.Images.SetKeyName(9, "linkedin.png");
            this.imgListGame1.Images.SetKeyName(10, "linux.png");
            this.imgListGame1.Images.SetKeyName(11, "pc.png");
            this.imgListGame1.Images.SetKeyName(12, "twitter.png");
            this.imgListGame1.Images.SetKeyName(13, "whatsap.png");
            this.imgListGame1.Images.SetKeyName(14, "windows.png");
            this.imgListGame1.Images.SetKeyName(15, "word.png");
            this.imgListGame1.Images.SetKeyName(16, "wordpress.png");
            this.imgListGame1.Images.SetKeyName(17, "youtube.png");
            // 
            // imgListApp
            // 
            this.imgListApp.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListApp.ImageStream")));
            this.imgListApp.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListApp.Images.SetKeyName(0, "cerrar.png");
            this.imgListApp.Images.SetKeyName(1, "puzzle.png");
            // 
            // imgListNone
            // 
            this.imgListNone.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListNone.ImageStream")));
            this.imgListNone.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListNone.Images.SetKeyName(0, "humano.png");
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.White;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnStartGame.Image = ((System.Drawing.Image)(resources.GetObject("btnStartGame.Image")));
            this.btnStartGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartGame.Location = new System.Drawing.Point(12, 12);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(211, 40);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.Text = "StartGame Enviar Invitación";
            this.btnStartGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            this.btnStartGame.DragLeave += new System.EventHandler(this.btnStartGame_DragLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(483, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(81, 40);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtPlayers
            // 
            this.txtPlayers.Location = new System.Drawing.Point(570, 58);
            this.txtPlayers.Multiline = true;
            this.txtPlayers.Name = "txtPlayers";
            this.txtPlayers.Size = new System.Drawing.Size(191, 164);
            this.txtPlayers.TabIndex = 3;
            // 
            // imgListGame2
            // 
            this.imgListGame2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListGame2.ImageStream")));
            this.imgListGame2.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListGame2.Images.SetKeyName(0, "acrobat.png");
            this.imgListGame2.Images.SetKeyName(1, "android.png");
            this.imgListGame2.Images.SetKeyName(2, "apple.png");
            this.imgListGame2.Images.SetKeyName(3, "css.png");
            this.imgListGame2.Images.SetKeyName(4, "excel.png");
            this.imgListGame2.Images.SetKeyName(5, "facebook.png");
            this.imgListGame2.Images.SetKeyName(6, "github.png");
            this.imgListGame2.Images.SetKeyName(7, "google.png");
            this.imgListGame2.Images.SetKeyName(8, "html.png");
            this.imgListGame2.Images.SetKeyName(9, "linkedin.png");
            this.imgListGame2.Images.SetKeyName(10, "linux.png");
            this.imgListGame2.Images.SetKeyName(11, "pc.png");
            this.imgListGame2.Images.SetKeyName(12, "twitter.png");
            this.imgListGame2.Images.SetKeyName(13, "whatsap.png");
            this.imgListGame2.Images.SetKeyName(14, "windows.png");
            this.imgListGame2.Images.SetKeyName(15, "word.png");
            this.imgListGame2.Images.SetKeyName(16, "wordpress.png");
            this.imgListGame2.Images.SetKeyName(17, "youtube.png");
            // 
            // btnOcultarImages
            // 
            this.btnOcultarImages.BackColor = System.Drawing.Color.White;
            this.btnOcultarImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOcultarImages.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOcultarImages.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnOcultarImages.Image = ((System.Drawing.Image)(resources.GetObject("btnOcultarImages.Image")));
            this.btnOcultarImages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOcultarImages.Location = new System.Drawing.Point(238, 12);
            this.btnOcultarImages.Name = "btnOcultarImages";
            this.btnOcultarImages.Size = new System.Drawing.Size(150, 40);
            this.btnOcultarImages.TabIndex = 1;
            this.btnOcultarImages.Text = "Ocultar Imagenes";
            this.btnOcultarImages.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOcultarImages.UseVisualStyleBackColor = false;
            this.btnOcultarImages.Click += new System.EventHandler(this.btnOcultarImages_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 551);
            this.panel1.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 621);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPlayers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOcultarImages);
            this.Controls.Add(this.btnStartGame);
            this.Name = "frmMain";
            this.Text = "MemoryGame Broadcast";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imgListGame1;
        private System.Windows.Forms.ImageList imgListApp;
        private System.Windows.Forms.ImageList imgListNone;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtPlayers;
        private System.Windows.Forms.ImageList imgListGame2;
        private System.Windows.Forms.Button btnOcultarImages;
        private System.Windows.Forms.Panel panel1;
    }
}

