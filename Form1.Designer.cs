namespace CJD_GAME
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.quit_button = new System.Windows.Forms.Button();
            this.xiado_black = new System.Windows.Forms.PictureBox();
            this.xiado_color = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_creditos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.xiado_black)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xiado_color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // quit_button
            // 
            this.quit_button.BackgroundImage = global::CJD_GAME.Properties.Resources.sair;
            this.quit_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.quit_button.FlatAppearance.BorderSize = 4;
            this.quit_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.quit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quit_button.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit_button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.quit_button.Location = new System.Drawing.Point(86, 410);
            this.quit_button.Name = "quit_button";
            this.quit_button.Size = new System.Drawing.Size(201, 48);
            this.quit_button.TabIndex = 1;
            this.quit_button.UseVisualStyleBackColor = true;
            this.quit_button.Click += new System.EventHandler(this.Quit_button_Click);
            this.quit_button.MouseLeave += new System.EventHandler(this.Quit_button_MouseLeave);
            this.quit_button.MouseHover += new System.EventHandler(this.Quit_button_MouseHover);
            // 
            // xiado_black
            // 
            this.xiado_black.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.xiado_black.Image = global::CJD_GAME.Properties.Resources.black;
            this.xiado_black.Location = new System.Drawing.Point(207, 111);
            this.xiado_black.Name = "xiado_black";
            this.xiado_black.Size = new System.Drawing.Size(37, 73);
            this.xiado_black.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.xiado_black.TabIndex = 5;
            this.xiado_black.TabStop = false;
            this.xiado_black.MouseHover += new System.EventHandler(this.Xiado_black_MouseHover);
            // 
            // xiado_color
            // 
            this.xiado_color.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.xiado_color.Image = global::CJD_GAME.Properties.Resources.color;
            this.xiado_color.Location = new System.Drawing.Point(155, 111);
            this.xiado_color.Name = "xiado_color";
            this.xiado_color.Size = new System.Drawing.Size(51, 73);
            this.xiado_color.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.xiado_color.TabIndex = 4;
            this.xiado_color.TabStop = false;
            this.xiado_color.MouseHover += new System.EventHandler(this.PictureBox2_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CJD_GAME.Properties.Resources.logo_fanorona_color_war_final;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 262);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click_1);
            // 
            // btn_creditos
            // 
            this.btn_creditos.BackgroundImage = global::CJD_GAME.Properties.Resources.Botao_Creditos;
            this.btn_creditos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_creditos.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_creditos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_creditos.FlatAppearance.BorderSize = 4;
            this.btn_creditos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btn_creditos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btn_creditos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_creditos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_creditos.ForeColor = System.Drawing.Color.Transparent;
            this.btn_creditos.Location = new System.Drawing.Point(86, 347);
            this.btn_creditos.Name = "btn_creditos";
            this.btn_creditos.Size = new System.Drawing.Size(200, 48);
            this.btn_creditos.TabIndex = 2;
            this.btn_creditos.UseVisualStyleBackColor = true;
            this.btn_creditos.Click += new System.EventHandler(this.Btn_creditos_Click);
            this.btn_creditos.MouseLeave += new System.EventHandler(this.Btn_creditos_MouseLeave);
            this.btn_creditos.MouseHover += new System.EventHandler(this.Btn_creditos_MouseHover);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::CJD_GAME.Properties.Resources.Botao_Jogar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 4;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(86, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 53);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.Button1_MouseLeave);
            this.button1.MouseHover += new System.EventHandler(this.Button1_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CJD_GAME.Properties.Resources.animação_menu;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 467);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CJD_GAME.Properties.Resources.animação_menu;
            this.pictureBox3.Location = new System.Drawing.Point(340, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 467);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(72, 46);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(30, 44);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 491);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.xiado_black);
            this.Controls.Add(this.xiado_color);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_creditos);
            this.Controls.Add(this.quit_button);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";

            ((System.ComponentModel.ISupportInitialize)(this.xiado_black)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xiado_color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button quit_button;
        private System.Windows.Forms.Button btn_creditos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox xiado_color;
        private System.Windows.Forms.PictureBox xiado_black;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

