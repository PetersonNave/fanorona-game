using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CJD_GAME
{
    public partial class PretoGanhou : Form
    {
      
        public PretoGanhou()
        {
            InitializeComponent();
       
        }
        public string vencedor { get; set; }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PretoGanhou_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = ("Audios/Falling_Rain.mp3");
            axWindowsMediaPlayer1.Ctlcontrols.play();
            if (vencedor == "collor")
            {
                this.BackgroundImage = CJD_GAME.Properties.Resources.derrotaPreto;
            }
            else
            {

                this.BackgroundImage = CJD_GAME.Properties.Resources.derrotaColorido;
            }
        }
    }
}
