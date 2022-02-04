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
    public partial class Creditos : Form
    {
        public Creditos()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = CJD_GAME.Properties.Resources.creditos_programacao;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = CJD_GAME.Properties.Resources.creditos_multimidia;
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
