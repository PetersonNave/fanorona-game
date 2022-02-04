using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CJD_GAME
{
    public partial class Form1 : Form
    {
        private SoundPlayer select;
        private SoundPlayer xiadoBlack;
        private SoundPlayer xiadoCollor;
        public Form1()
        {
            select = new SoundPlayer("Audios/selectButton.wav");
            xiadoBlack = new SoundPlayer("Audios/blackAndWhite.wav");
            xiadoCollor = new SoundPlayer("Audios/color.wav");
            InitializeComponent();
            axWindowsMediaPlayer1.URL = ("Audios/Sweet_Home_Analoga.mp3");
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

       

        private void Quit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
           
        }

        //BOTÃO JOGAR
        private void Button1_MouseHover(object sender, EventArgs e)
        {
            select.Play();
            button1.Size = new System.Drawing.Size(223, 62);
            button1.Location = new Point(75,269);
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new System.Drawing.Size(200, 54);
            button1.Location = new Point(86, 278);
        }

        // BOTÃO CRÉDITOS
        private void Btn_creditos_MouseHover(object sender, EventArgs e)
        {
            select.Play();
            btn_creditos.Size = new System.Drawing.Size(223, 56);
            btn_creditos.Location = new Point(76, 347);

        }

        private void Btn_creditos_MouseLeave(object sender, EventArgs e)
        {
            btn_creditos.Size = new System.Drawing.Size(200, 48);
            btn_creditos.Location = new Point(86, 347);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TelaJogo inicio = new TelaJogo();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            inicio.Show();
            this.Hide();
        }
        private void PictureBox2_MouseHover(object sender, EventArgs e)
        {
            xiadoCollor.Play();
       }

        private void Xiado_black_MouseHover(object sender, EventArgs e)
        {
            xiadoBlack.Play();
        }
        private void Quit_button_MouseHover(object sender, EventArgs e)
        {
            quit_button.Size = new System.Drawing.Size(224, 56);
            quit_button.Location = new Point(74, 410);
            select.Play();
        }
        private void Quit_button_MouseLeave(object sender, EventArgs e)
        {
            quit_button.Size = new System.Drawing.Size(201, 48);
            quit_button.Location = new Point(86, 410);
        }
        private void Btn_creditos_Click(object sender, EventArgs e)
        {
            Creditos creditos = new Creditos();
            creditos.Show();
            this.Hide();
        }
    }

}