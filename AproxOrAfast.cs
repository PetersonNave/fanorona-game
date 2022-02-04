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
    public partial class AproxOrAfast : Form
    {
        public AproxOrAfast()
        {
            InitializeComponent();
        }
        public DialogResult Resultado { get; private set; }

        public static DialogResult Mostrar()
        {
            var msgBox = new AproxOrAfast();
            msgBox.lblMensagem.Text = "Selecione um movimento";
            msgBox.btnSim.Text = "Aproximação";
            msgBox.btnNao.Text = "Afastamento";
            msgBox.ShowDialog();
            return msgBox.Resultado;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Resultado = DialogResult.Yes;
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Resultado = DialogResult.No;
            Close();
        }
      

     
     
    }
}
