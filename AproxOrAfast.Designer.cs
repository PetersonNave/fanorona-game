namespace CJD_GAME
{
    partial class AproxOrAfast
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
            this.btnNao = new System.Windows.Forms.Button();
            this.btnSim = new System.Windows.Forms.Button();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNao
            // 
            this.btnNao.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnNao.FlatAppearance.BorderSize = 2;
            this.btnNao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnNao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnNao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNao.Location = new System.Drawing.Point(47, 47);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(264, 57);
            this.btnNao.TabIndex = 0;
            this.btnNao.Text = "aproximação";
            this.btnNao.UseVisualStyleBackColor = true;
            this.btnNao.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnSim
            // 
            this.btnSim.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSim.FlatAppearance.BorderSize = 2;
            this.btnSim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnSim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSim.Location = new System.Drawing.Point(46, 119);
            this.btnSim.Name = "btnSim";
            this.btnSim.Size = new System.Drawing.Size(264, 57);
            this.btnSim.TabIndex = 0;
            this.btnSim.Text = "afastamento";
            this.btnSim.UseVisualStyleBackColor = true;
            this.btnSim.Click += new System.EventHandler(this.Button2_Click);
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.BackColor = System.Drawing.Color.Transparent;
            this.lblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.Location = new System.Drawing.Point(55, 10);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(247, 24);
            this.lblMensagem.TabIndex = 1;
            this.lblMensagem.Text = "Selecione um movimento";
            // 
            // AproxOrAfast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CJD_GAME.Properties.Resources.fundo_tabuleiro__colorido_1;
            this.ClientSize = new System.Drawing.Size(363, 188);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.btnSim);
            this.Controls.Add(this.btnNao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AproxOrAfast";
            this.Text = "AproxOrAfast";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNao;
        private System.Windows.Forms.Button btnSim;
        private System.Windows.Forms.Label lblMensagem;
    }
}