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
using System.Threading;

namespace CJD_GAME
{
    public partial class TelaJogo : Form
    {
        public TelaJogo()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = ("Audios/Drone_in_D.mp3");
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        PretoGanhou abaGanhador = new PretoGanhou();

        //DECLARAÇÃO DE VARIAVEIS /////////////////////////////////////////////////////////////////////////

        public bool comeuNaPrimeiraJogada = false;
        public bool movimentoVert = true;
        public bool movimentoHor = true;
        public bool movimentoDia = true;
        public bool jogada = false;
        public bool aproxOuAfast;
        public bool mute = false;
        public bool turno = true;
        public bool primeiraJogada = false;

        public int auxiliar = 0;
        public int quantidadePecaBranca = 0;
        public int quantidadePecaPreta = 0;
        public int contador = 1;

        public TableLayoutPanelCellPosition posicao;
        public TableLayoutPanelCellPosition posicaoFinal;
        public TableLayoutPanelCellPosition[] jaPassouCollor = new TableLayoutPanelCellPosition[50];

        PictureBox botaoEmSi = null;
        //////////////////////////////////////////////////////////////////////////////////////////////////

        public void MudarCanal()
        {         
            SoundPlayer trocarCanal;
            Random number = new Random();
            int numero = number.Next(1, 4);
            if (numero == 1)
            {
                trocarCanal = new SoundPlayer("Audios/MudarEf1.wav");
                trocarCanal.Play();
            }
            else if (numero == 2)
            {
                trocarCanal = new SoundPlayer("Audios/MudarEf2.wav");
                trocarCanal.Play();
            }
            else
            {
                trocarCanal = new SoundPlayer("Audios/MudarEf3.wav");
                trocarCanal.Play();
            }

        }
        
        private void TableLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            bool trocaDeTurno = true;
            PictureBox botao = (PictureBox)e.Data.GetData(typeof(PictureBox));
            e.Effect = DragDropEffects.Copy;
            Point loc = tableEntrada.PointToClient(new Point(e.X, e.Y));

            //determina a localização da célula
            int ColumnIndex = -1;
            int RowIndex = -1;
            int x = 0;
            int y = 0;
            while (ColumnIndex <= tableEntrada.ColumnCount)
            {
                if (loc.X < x)
                {
                    break;
                }

                ColumnIndex++;
                x += tableEntrada.GetColumnWidths()[ColumnIndex];
            }
            while (RowIndex <= tableEntrada.RowCount)
            {

                if (loc.Y < y)
                {
                    break;
                }

                RowIndex++;
                y += tableEntrada.GetRowHeights()[RowIndex];
            }         
            //VERIFICAR SE JÁ TEM PEÇA

            PictureBox existeBotao = tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex) as PictureBox;
            botaoEmSi = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex);
            PictureBox pecaMovida = (PictureBox)tableEntrada.GetControlFromPosition(posicao.Column, posicao.Row);
            if (posicao.Column != ColumnIndex || posicao.Row != RowIndex)
            {
                if (primeiraJogada == false)
                {
                    jaPassouCollor[0].Column = posicao.Column;
                    jaPassouCollor[0].Row = posicao.Row;
                    primeiraJogada = true;
                }
            }
            bool podeJogar = true;
            for (int i = 0; i < 50; i++)
            {
                if (ColumnIndex == jaPassouCollor[i].Column && jaPassouCollor[i].Row == RowIndex)
                {
                    MessageBox.Show("Você já passou por aqui");
                    podeJogar = false;
                    jogada = false;
                    botaoEmSi = pecaMovida;
                }
                else
                {
                    podeJogar = true;
                    jogada = true;
                }
            }
            if (podeJogar == true)
            {
                if (botaoEmSi.Image == null)
                {
                    TableLayoutPanelCellPosition posicaoFinal2 = tableEntrada.GetPositionFromControl(botao);
                    int colunaFinal = posicaoFinal2.Column - ColumnIndex;
                    int linhaFinal = posicaoFinal2.Row - RowIndex;

                    if (linhaFinal > -2 && linhaFinal < 2 && colunaFinal > -2 && colunaFinal < 2)
                    {
                        SoundPlayer Select = new SoundPlayer("Audios/selectButton.wav");
                        if (linhaFinal != 0 && colunaFinal != 0)
                        {
                            if (ColumnIndex == 1 || ColumnIndex == 3 || ColumnIndex == 5 || ColumnIndex == 7)
                            {
                                if (RowIndex == 1 || RowIndex == 3 && movimentoDia == true)
                                {
                                    if (movimentoDia == true)
                                    {
                                        jogada = true;
                                        if (turno == true)
                                        {
                                            movimentoDia = false;
                                            movimentoVert = true;
                                            movimentoHor = true;
                                            botaoEmSi.Image = Properties.Resources.peça_colorida;
                                            pecaMovida.Image = null;
                                            botaoEmSi.Tag = "selecionada";
                                            pecaMovida.Tag = "";
                                            jaPassouCollor[contador].Row = RowIndex;
                                            jaPassouCollor[contador].Column = ColumnIndex;
                                            contador++;
                                            Select.Play();
                                        }
                                        else
                                        {
                                            movimentoDia = false;
                                            movimentoVert = true;
                                            movimentoHor = true;
                                            botaoEmSi.Image = Properties.Resources.peça_preta_e_branca_1;
                                            pecaMovida.Image = null;
                                            botaoEmSi.Tag = "selecionada";
                                            pecaMovida.Tag = "";
                                            jaPassouCollor[contador].Row = RowIndex;
                                            jaPassouCollor[contador].Column = ColumnIndex;
                                            contador++;
                                            Select.Play();
                                        }
                                    }
                                    else { jogada = false; }
                                }
                                else
                                {
                                    jogada = false;
                                }
                            }
                            else if (ColumnIndex == 0 || ColumnIndex == 2 || ColumnIndex == 4 || ColumnIndex == 6 || ColumnIndex == 8)
                            {
                                if (RowIndex == 0 || RowIndex == 2 || RowIndex == 4 && movimentoDia == true)
                                {
                                    if (movimentoDia == true)
                                    {
                                        jogada = true;
                                        if (turno == true)
                                        {
                                            movimentoDia = false;
                                            movimentoVert = true;
                                            movimentoHor = true;
                                            botaoEmSi.Image = Properties.Resources.peça_colorida;
                                            pecaMovida.Image = null;
                                            botaoEmSi.Tag = "selecionada";
                                            pecaMovida.Tag = "";
                                            jaPassouCollor[contador].Row = RowIndex;
                                            jaPassouCollor[contador].Column = ColumnIndex;
                                            contador++;
                                            Select.Play();
                                        }
                                        else
                                        {
                                            movimentoDia = false;
                                            movimentoVert = true;
                                            movimentoHor = true;
                                            botaoEmSi.Image = Properties.Resources.peça_preta_e_branca_1;
                                            pecaMovida.Image = null;
                                            botaoEmSi.Tag = "selecionada";
                                            pecaMovida.Tag = "";
                                            jaPassouCollor[contador].Row = RowIndex;
                                            jaPassouCollor[contador].Column = ColumnIndex;
                                            contador++;
                                            Select.Play();
                                        }
                                    }
                                    else { jogada = false; }
                                }
                                else
                                {
                                    jogada = false;
                                }
                            }
                        }
                        else if (linhaFinal != 0 && colunaFinal == 0 && movimentoVert == true)
                        {
                            jogada = true;
                            if (turno == true)
                            {
                                movimentoDia = true;
                                movimentoVert = false;
                                movimentoHor = true;
                                botaoEmSi.Image = Properties.Resources.peça_colorida;
                                pecaMovida.Image = null;
                                botaoEmSi.Tag = "selecionada";
                                pecaMovida.Tag = "";
                                jaPassouCollor[contador].Row = RowIndex;
                                jaPassouCollor[contador].Column = ColumnIndex;
                                contador++;
                                Select.Play();
                            }
                            else
                            {
                                movimentoDia = true;
                                movimentoVert = false;
                                movimentoHor = true;
                                botaoEmSi.Image = Properties.Resources.peça_preta_e_branca_1;
                                pecaMovida.Image = null;
                                botaoEmSi.Tag = "selecionada";
                                pecaMovida.Tag = "";
                                jaPassouCollor[contador].Row = RowIndex;
                                jaPassouCollor[contador].Column = ColumnIndex;
                                contador++;
                                Select.Play();
                            }
                        }
                        else if (linhaFinal == 0 && colunaFinal != 0 && movimentoHor == true)
                        {
                            jogada = true;
                            if (turno == true)
                            {
                                movimentoDia = true;
                                movimentoVert = true;
                                movimentoHor = false;
                                botaoEmSi.Image = Properties.Resources.peça_colorida;
                                pecaMovida.Image = null;
                                botaoEmSi.Tag = "selecionada";
                                pecaMovida.Tag = "";
                                jaPassouCollor[contador].Row = RowIndex;
                                jaPassouCollor[contador].Column = ColumnIndex;
                                contador++;
                                Select.Play();
                            }
                            else
                            {
                                movimentoDia = true;
                                movimentoVert = true;
                                movimentoHor = false;
                                botaoEmSi.Image = Properties.Resources.peça_preta_e_branca_1;
                                pecaMovida.Image = null;
                                botaoEmSi.Tag = "selecionada";
                                pecaMovida.Tag = "";
                                jaPassouCollor[contador].Row = RowIndex;
                                jaPassouCollor[contador].Column = ColumnIndex;
                                contador++;
                                Select.Play();

                            }
                        }
                    }
                    else
                    {
                        jogada = false;
                    }
                }
                else
                {
                    MessageBox.Show("Já existe uma peça nesta posição", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    jogada = false;
                    trocaDeTurno = false;
                }
            }

            comeuNaPrimeiraJogada = false;
            posicaoFinal = tableEntrada.GetPositionFromControl(botao);

            int coluna = posicao.Column - ColumnIndex;
            int linha = posicao.Row - RowIndex;
            string tag = "";

            if (jogada == true)
            {
                if (turno == false)
                {
                    tag = "collor";
                }
                else
                {
                    tag = "black";
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //MOVIMENTOS VERTICAIS//
                if (coluna == 0 && linha != 0)
                {
                    PictureBox verificarBotao = null;
                    if (RowIndex - (linha) >= 0)
                    {
                        verificarBotao = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (linha));
                    }
                    PictureBox pecaTras = null;
                    if (RowIndex + (linha) + (linha) >= 0)
                    {
                        pecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex + (linha) + (linha));
                    }
                    /// CASO SEJA POSSIVEL 2 MOVIMENTOS NA MESMA JOGADA //////////////////////////////////
                    if (verificarBotao != null && pecaTras != null)
                    {
                        if (verificarBotao.Tag.ToString() == tag && pecaTras.Tag.ToString() == tag)
                        {
                            //JANELA MODAL
                            DialogResult resultado = AproxOrAfast.Mostrar();
                            if (resultado == DialogResult.No)
                            {
                                pecaTras = null;
                            }
                            else
                            {
                                verificarBotao = null;
                            }
                        }
                    }        
                    if (verificarBotao != null && verificarBotao.Tag.ToString() == tag)
                    {
                        PictureBox verificarAdiante = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (linha));
                        for (int i = 1; verificarAdiante != null; i++)
                        {
                            if (RowIndex - (linha * i) >= 0)
                            {
                                verificarAdiante = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex - (linha * i));
                            }
                            else { verificarAdiante = null; }
                            if (verificarAdiante != null)
                            {
                                if (verificarAdiante.Tag.ToString() == tag)
                                {
                                    comeuNaPrimeiraJogada = true;
                                    auxiliar++;
                                    verificarAdiante.Image = null;
                                    verificarAdiante.Tag = "";
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    // DA PRA PEGAR PEÇA EM BAIXO
                    if (pecaTras != null && pecaTras.Tag.ToString() == tag)
                    {
                        PictureBox pecaTrasSegunda = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex + (linha) + (linha));
                        for (int i = 2; pecaTrasSegunda != null; i++)
                        {
                            if (RowIndex + (linha * i) >= 0)
                            {
                                pecaTrasSegunda = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex, RowIndex + (linha * i));
                            }
                            else { pecaTrasSegunda = null; }

                            if (pecaTrasSegunda != null)
                            {
                                if (pecaTrasSegunda.Tag.ToString() == tag)
                                {
                                    comeuNaPrimeiraJogada = true;
                                    auxiliar++;
                                    pecaTrasSegunda.Image = null;
                                    pecaTrasSegunda.Tag = "";
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                //MOVIMENTOS DIAGONAIS ////////////////////////////////////////////////////////////////
                else if (coluna != 0 && linha != 0)
                {
                    PictureBox verificarBotao = null;
                    if (ColumnIndex - (coluna) >= 0 && RowIndex - (linha) >= 0)
                    {
                        verificarBotao = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (coluna), RowIndex - (linha));
                    }
                    PictureBox pecaTras = null;
                    if (ColumnIndex + (coluna) + (coluna) >= 0 && RowIndex + (linha) + (linha) >= 0)
                    {
                        pecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (coluna) + (coluna), RowIndex + (linha) + (linha));
                    }
                    /// CASO SEJA POSSIVEL 2 MOVIMENTOS NA MESMA JOGADA //////////////////////////////////
                    if (verificarBotao != null && pecaTras != null)
                    {
                        if (verificarBotao.Tag.ToString() == tag && pecaTras.Tag.ToString() == tag)
                        {
                            //JANELA MODAL
                            DialogResult resultado = AproxOrAfast.Mostrar();
                            if (resultado == DialogResult.No)
                            {
                                pecaTras = null;
                            }
                            else
                            {
                                verificarBotao = null;
                            }
                        }
                    }
                    if (verificarBotao != null && verificarBotao.Tag.ToString() == tag)
                    {
                        PictureBox verificarAdiante = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (coluna), RowIndex - (linha));
                        for (int i = 1; verificarAdiante != null; i++)
                        {
                            if (ColumnIndex - (coluna * i) >= 0 && RowIndex - (linha * i) >= 0)
                            {
                                verificarAdiante = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (coluna * i), RowIndex - (linha * i));
                            }
                            else { verificarAdiante = null; }
                            if (verificarAdiante != null)
                            {
                                if (verificarAdiante.Tag.ToString() == tag)
                                {
                                    comeuNaPrimeiraJogada = true;
                                    auxiliar++;
                                    verificarAdiante.Image = null;
                                    verificarAdiante.Tag = "";
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (pecaTras != null && pecaTras.Tag.ToString() == tag)
                    {
                        PictureBox pecaTrasSegunda = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (coluna) + (coluna), RowIndex + (linha) + (linha));
                        for (int i = 2; pecaTrasSegunda != null; i++)
                        {
                            if (ColumnIndex + (coluna * i) >= 0 && RowIndex + (linha * i) >= 0)
                            {
                                pecaTrasSegunda = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (coluna * i), RowIndex + (linha * i));
                            }
                            else { pecaTrasSegunda = null; }
                            if (pecaTrasSegunda != null)
                            {
                                if (pecaTrasSegunda.Tag.ToString() == tag)
                                {
                                    comeuNaPrimeiraJogada = true;
                                    auxiliar++;
                                    pecaTrasSegunda.Image = null;
                                    pecaTrasSegunda.Tag = "";
                                }
                                else { break; }
                            }
                        }
                    }
                }
                // MOVIMENTOS HORIZONTAIS/////////////////////////////////////////////
                else if (coluna != 0 && linha == 0)
                {
                    PictureBox verificarBotao = null;
                    if (ColumnIndex - (coluna) >= 0)
                    {
                        verificarBotao = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (coluna), RowIndex);
                    }
                    PictureBox pecaTras = null;
                    if (ColumnIndex + (coluna) + (coluna) >= 0)
                    {
                        pecaTras = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (coluna) + (coluna), RowIndex);
                    }
                    /// CASO SEJA POSSIVEL 2 MOVIMENTOS NA MESMA JOGADA //////////////////////////////////
                    if (verificarBotao != null && pecaTras != null)
                    {
                        if (verificarBotao.Tag.ToString() == tag && pecaTras.Tag.ToString() == tag)
                        {
                            //JANELA MODAL
                            DialogResult resultado = AproxOrAfast.Mostrar();
                            if (resultado == DialogResult.No)
                            {
                                pecaTras = null;
                            }
                            else
                            {
                                verificarBotao = null;
                            }
                        }
                    }
                    if (verificarBotao != null && verificarBotao.Tag.ToString() == tag)
                    {
                        PictureBox verificarAdiante = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (coluna), RowIndex);
                        for (int i = 1; verificarAdiante != null; i++)
                        {
                            if (ColumnIndex - (coluna * i) >= 0)
                            {
                                verificarAdiante = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex - (coluna * i), RowIndex);
                            }
                            else { verificarAdiante = null; }
                            if (verificarAdiante != null)
                            {
                                if (verificarAdiante.Tag.ToString() == tag)
                                {
                                    comeuNaPrimeiraJogada = true;
                                    auxiliar++;
                                    verificarAdiante.Image = null;
                                    verificarAdiante.Tag = "";
                                }
                                else { break; }
                            }
                        }
                    }
                    if (pecaTras != null && pecaTras.Tag.ToString() == tag)
                    {
                        PictureBox pecaTrasSegunda = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (coluna) + (coluna), RowIndex + (linha) + (linha));
                        for (int i = 2; pecaTrasSegunda != null; i++)
                        {
                            if (ColumnIndex + (coluna * i) >= 0)
                            {
                                pecaTrasSegunda = (PictureBox)tableEntrada.GetControlFromPosition(ColumnIndex + (coluna * i), RowIndex);
                            }
                            else { pecaTrasSegunda = null; }
                            if (pecaTrasSegunda != null)
                            {
                                if (pecaTrasSegunda.Tag.ToString() == tag)
                                {
                                    comeuNaPrimeiraJogada = true;
                                    auxiliar++;
                                    pecaTrasSegunda.Image = null;
                                    pecaTrasSegunda.Tag = "";
                                }
                                else { break; }
                            }
                        }
                    }
                }          
            }
            if(turno == false)
            {
                quantidadePecaPreta += auxiliar;
            }
            else
            {
                quantidadePecaBranca += auxiliar;
            }
            auxiliar = 0;

            //////////////////////// SIMULAR TODAS AS JOGADAS POSSIVEIS COM A MESMA PEÇA PARA VERIFICAR SE AINDÁ HÁ POSSIBILIDADES DE ELIMINAR MAIS PEÇAS ADVERSARIAS, CASO CONTRÁRIO TROCA O TURNO //////////////////

            TableLayoutPanelCellPosition possibilidades = tableEntrada.GetPositionFromControl(botaoEmSi);          
            if (comeuNaPrimeiraJogada == true)
            {
                // HORIZONTAL
                if (movimentoHor == true)
                {
                    if (possibilidades.Column + 1 <= 8)
                    {
                        PictureBox proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column + 1, possibilidades.Row);
                        for (int i = 0; i < jaPassouCollor.Length; i++)
                        {
                            if (jaPassouCollor[i].Row == possibilidades.Row && jaPassouCollor[i].Column == possibilidades.Column + 1)
                            {
                                proxPeca = null;
                                break;
                            }
                            else { continue; }
                        }
                        if (proxPeca != null)
                        {
                            if (proxPeca.Image == null)
                            {
                                if (possibilidades.Column + 2 <= 8)
                                {
                                    proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column + 2, possibilidades.Row);
                                    if (turno == true && proxPeca.Tag.ToString() == "black")
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor")
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                            else
                            {
                                if (possibilidades.Column - 1 >= 0)
                                {
                                    PictureBox proxPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column - 1, possibilidades.Row);
                                    for (int i = 0; i < jaPassouCollor.Length; i++)
                                    {
                                        if (jaPassouCollor[i].Row == possibilidades.Row && jaPassouCollor[i].Column == possibilidades.Column - 1)
                                        {
                                            proxPecaTras = null;
                                            break;
                                        }
                                        else { continue; }
                                    }
                                    if (proxPecaTras != null)
                                    {
                                        if (turno == true && proxPeca.Tag.ToString() == "black" && proxPecaTras.Image == null)
                                        {
                                            trocaDeTurno = false;
                                        }
                                        else if (turno == false && proxPeca.Tag.ToString() == "collor" && proxPecaTras.Image == null)
                                        {
                                            trocaDeTurno = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (possibilidades.Column - 1 >= 0)
                    {
                        PictureBox proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column - 1, possibilidades.Row);
                        for (int i = 0; i < jaPassouCollor.Length; i++)
                        {
                            if (jaPassouCollor[i].Row == possibilidades.Row && jaPassouCollor[i].Column == possibilidades.Column - 1)
                            {
                                proxPeca = null;
                                break;
                            }
                            else { continue; }
                        }
                        if (proxPeca != null)
                        {
                            if (proxPeca.Image == null)
                            {
                                if (possibilidades.Column - 2 >= 0)
                                {
                                    proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column - 2, possibilidades.Row);
                                    if (turno == true && proxPeca.Tag.ToString() == "black")
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor")
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                            else
                            {
                                if (possibilidades.Column + 1 >= 0)
                                {
                                    PictureBox proxPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column + 1, possibilidades.Row);
                                    for (int i = 0; i < jaPassouCollor.Length; i++)
                                    {
                                        if (jaPassouCollor[i].Row == possibilidades.Row && jaPassouCollor[i].Column == possibilidades.Column + 1)
                                        {
                                            proxPecaTras = null;
                                            break;
                                        }
                                        else { continue; }
                                    }
                                    if (proxPecaTras != null)
                                    {
                                        if (turno == true && proxPeca.Tag.ToString() == "black" && proxPecaTras.Image == null)
                                        {
                                            trocaDeTurno = false;
                                        }
                                        else if (turno == false && proxPeca.Tag.ToString() == "collor" && proxPecaTras.Image == null)
                                        {
                                            trocaDeTurno = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                /// VERTICAL /////////////////
                if (movimentoVert == true)
                {
                    if (possibilidades.Row + 1 <= 4)
                    {
                        PictureBox proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column, possibilidades.Row + 1);
                        for (int i = 0; i < jaPassouCollor.Length; i++)
                        {
                            if (jaPassouCollor[i].Row == possibilidades.Row + 1 && jaPassouCollor[i].Column == possibilidades.Column)
                            {
                                proxPeca = null;
                                break;
                            }
                            else { continue; }
                        }
                        if (proxPeca != null)
                        {
                            if (proxPeca.Image == null)
                            {
                                if (possibilidades.Row + 2 <= 4)
                                {
                                    proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column, possibilidades.Row + 2);
                                    if (turno == true && proxPeca.Tag.ToString() == "black")
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor")
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                            else
                            {
                                if (possibilidades.Row - 1 >= 0)
                                {
                                    PictureBox proxPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column, possibilidades.Row - 1);
                                    for (int i = 0; i < jaPassouCollor.Length; i++)
                                    {
                                        if (jaPassouCollor[i].Row == possibilidades.Row - 1 && jaPassouCollor[i].Column == possibilidades.Column)
                                        {
                                            proxPecaTras = null;
                                            break;
                                        }
                                        else { continue; }
                                    }
                                    if (proxPecaTras != null)
                                    {
                                        if (turno == true && proxPeca.Tag.ToString() == "black" && proxPecaTras.Image == null)
                                        {
                                            trocaDeTurno = false;
                                        }
                                        else if (turno == false && proxPeca.Tag.ToString() == "collor" && proxPecaTras.Image == null)
                                        {
                                            trocaDeTurno = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (possibilidades.Row - 1 >= 0)
                    {
                        PictureBox proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column, possibilidades.Row - 1);
                        for (int i = 0; i < jaPassouCollor.Length; i++)
                        {
                            if (jaPassouCollor[i].Row == possibilidades.Row - 1 && jaPassouCollor[i].Column == possibilidades.Column)
                            {
                                proxPeca = null;
                                break;
                            }
                            else { continue; }
                        }
                        if (proxPeca != null)
                        {
                            if (proxPeca.Image == null)
                            {
                                if (possibilidades.Row - 2 >= 0)
                                {
                                    proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column, possibilidades.Row - 2);
                                    if (turno == true && proxPeca.Tag.ToString() == "black")
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor")
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                            else
                            {
                                PictureBox proxPecaTras = null;
                                if (possibilidades.Row + 1 < 5)
                                {
                                    proxPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column, possibilidades.Row + 1);
                                }
                                if(proxPecaTras != null)
                                {
                                    if (turno == true && proxPeca.Tag.ToString() == "black" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                }                                                               
                            }
                        }
                    }
                }
                // DIAGONAIS /////////////////////////
                if (ColumnIndex == 1 || ColumnIndex == 3 || ColumnIndex == 5 || ColumnIndex == 7)
                {
                    if (RowIndex == 1 || RowIndex == 3)
                    { }
                    else
                    {
                        movimentoDia = false;
                    }
                }
                else if (ColumnIndex == 0 || ColumnIndex == 2 || ColumnIndex == 4 || ColumnIndex == 6 || ColumnIndex == 8)
                {
                    if (RowIndex == 0 || RowIndex == 2 || RowIndex == 4)
                    { }
                    else
                    {
                        movimentoDia = false;
                    }
                }
                if (movimentoDia == true)
                {
                    if (possibilidades.Row + 1 <= 4 && possibilidades.Column + 1 <= 8)
                    {
                        PictureBox proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column + 1, possibilidades.Row + 1);
                        for (int i = 0; i < jaPassouCollor.Length; i++)
                        {
                            if (jaPassouCollor[i].Row == possibilidades.Row + 1 && jaPassouCollor[i].Column == possibilidades.Column + 1)
                            {
                                proxPeca = null;
                                break;
                            }
                            else { continue; }
                        }
                        if (proxPeca != null)
                        {
                            if (proxPeca.Image == null)
                            {
                                if (possibilidades.Row + 2 <= 4 && possibilidades.Column + 2 <= 8)
                                {
                                    proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column + 2, possibilidades.Row + 2);
                                    if (turno == true && proxPeca.Tag.ToString() == "black")
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor")
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                            else
                            {
                                PictureBox proxPecaTras = null;
                                if (possibilidades.Column - 1 >= 0 && possibilidades.Row - 1 >= 0)
                                {
                                    proxPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column - 1, possibilidades.Row - 1);
                                    for (int i = 0; i < jaPassouCollor.Length; i++)
                                    {
                                        if (jaPassouCollor[i].Row == possibilidades.Row - 1 && jaPassouCollor[i].Column == possibilidades.Column - 1)
                                        {
                                            proxPecaTras = null;
                                            break;
                                        }
                                        else { continue; }
                                    }
                                }
                                if (proxPecaTras != null)
                                {
                                    if (turno == true && proxPeca.Tag.ToString() == "black" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                        }
                    }
                    if (possibilidades.Row - 1 >= 0 && possibilidades.Column - 1 >= 0)
                    {
                        PictureBox proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column - 1, possibilidades.Row - 1);
                        for (int i = 0; i < jaPassouCollor.Length; i++)
                        {
                            if (jaPassouCollor[i].Row == possibilidades.Row - 1 && jaPassouCollor[i].Column == possibilidades.Column - 1)
                            {
                                proxPeca = null;
                                break;
                            }
                            else { continue; }
                        }
                        if (proxPeca != null)
                        {
                            if (proxPeca.Image == null)
                            {
                                if (possibilidades.Column - 2 >= 0 && possibilidades.Row - 2 >= 0)
                                {
                                    proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column - 2, possibilidades.Row - 2);
                                    if (turno == true && proxPeca.Tag.ToString() == "black")
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor")
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                            else
                            {
                                PictureBox proxPecaTras = null;
                                if (possibilidades.Column + 1 <= 8 && possibilidades.Row + 1 <5)
                                {
                                    proxPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column + 1, possibilidades.Row + 1);
                                    for (int i = 0; i < jaPassouCollor.Length; i++)
                                    {
                                        if (jaPassouCollor[i].Row == possibilidades.Row + 1 && jaPassouCollor[i].Column == possibilidades.Column + 1)
                                        {
                                            proxPecaTras = null;
                                            break;
                                        }
                                        else { continue; }
                                    }
                                }
                                if (proxPecaTras != null)
                                {
                                    if (turno == true && proxPeca.Tag.ToString() == "black" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                        }
                    }
                    if (possibilidades.Row + 1 <5 && possibilidades.Column - 1 >= 0)
                    {
                        PictureBox proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column - 1, possibilidades.Row + 1);
                        for (int i = 0; i < jaPassouCollor.Length; i++)
                        {
                            if (jaPassouCollor[i].Row == possibilidades.Row + 1 && jaPassouCollor[i].Column == possibilidades.Column - 1)
                            {
                                proxPeca = null;
                                break;
                            }
                            else { continue; }
                        }
                        if (proxPeca != null)
                        {
                            if (proxPeca.Image == null)
                            {
                                if (possibilidades.Row + 2 < 5 && possibilidades.Column - 2 >= 0)
                                {
                                    proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column - 2, possibilidades.Row + 2);
                                    if (turno == true && proxPeca.Tag.ToString() == "black")
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor")
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                            else
                            {
                                PictureBox proxPecaTras = null;
                                if (possibilidades.Column + 1 <= 8 && possibilidades.Row - 1 >= 0)
                                {
                                    proxPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column + 1, possibilidades.Row - 1);
                                    for (int i = 0; i < jaPassouCollor.Length; i++)
                                    {
                                        if (jaPassouCollor[i].Row == possibilidades.Row - 1 && jaPassouCollor[i].Column == possibilidades.Column + 1)
                                        {
                                            proxPecaTras = null;
                                            break;
                                        }
                                        else { continue; }
                                    }
                                }
                                if (proxPecaTras != null)
                                {
                                    if (turno == true && proxPeca.Tag.ToString() == "black" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                        }
                    }
                    if (possibilidades.Row - 1 >= 0 && possibilidades.Column + 1 <= 8)
                    {
                        PictureBox proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column + 1, possibilidades.Row - 1);
                        for (int i = 0; i < jaPassouCollor.Length; i++)
                        {
                            if (jaPassouCollor[i].Row == possibilidades.Row - 1 && jaPassouCollor[i].Column == possibilidades.Column + 1)
                            {
                                proxPeca = null;
                                break;
                            }
                            else { continue; }
                        }
                        if (proxPeca != null)
                        {
                            if (proxPeca.Image == null)
                            {
                                if (possibilidades.Column + 2 <= 8 && possibilidades.Row - 2 >= 0)
                                {
                                    proxPeca = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column + 2, possibilidades.Row - 2);
                                    if (turno == true && proxPeca.Tag.ToString() == "black")
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor")
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                            else
                            {
                                PictureBox proxPecaTras = null;
                                if (possibilidades.Column - 1 >= 0 && possibilidades.Row + 1 <5)
                                {
                                    proxPecaTras = (PictureBox)tableEntrada.GetControlFromPosition(possibilidades.Column - 1, possibilidades.Row + 1);
                                    for (int i = 0; i < jaPassouCollor.Length; i++)
                                    {
                                        if (jaPassouCollor[i].Row == possibilidades.Row + 1 && jaPassouCollor[i].Column == possibilidades.Column - 1)
                                        {
                                            proxPecaTras = null;
                                            break;
                                        }
                                        else { continue; }
                                    }
                                }
                                if (proxPecaTras != null)
                                {
                                    if (turno == true && proxPeca.Tag.ToString() == "black" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                    else if (turno == false && proxPeca.Tag.ToString() == "collor" && proxPecaTras.Image == null)
                                    {
                                        trocaDeTurno = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //VERIFICAR SE TROCA OU NÃO O TURNO ///////////
            if (trocaDeTurno == true)
            {
                ChamarTrocaDeTurnoAutomatica();
            }
            if (quantidadePecaPreta == 22)
            {
                abaGanhador.vencedor = "black";
                abaGanhador.Show();
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                this.Hide();
            }
            else if (quantidadePecaBranca == 22)
            {
                abaGanhador.vencedor = "collor";
                abaGanhador.Show();
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                this.Hide();
            }

            //CHAMAR PROCEDIMENTO PARA TROCAR O FUNDO DA TELA DO JOGO ///////////
            FundoDeTela(quantidadePecaPreta - quantidadePecaBranca);

        }

        public void FundoDeTela(int resultado)
        {
            //PROCEDIMENTO DE TROCA DE FUNDO////
            if (resultado <= 3 && resultado >= -3)
            {
                this.BackgroundImage = CJD_GAME.Properties.Resources._50and50;
            }
            else if (resultado >= 4 && resultado < 7)
            {
                this.BackgroundImage = CJD_GAME.Properties.Resources._60Black;
            }
            else if (resultado >= 7 && resultado < 10)
            {
                this.BackgroundImage = CJD_GAME.Properties.Resources._80Black;
            }
            else if (resultado >= 10)
            {
                this.BackgroundImage = CJD_GAME.Properties.Resources._100Black;
            }
            else if (resultado <= -4 && resultado > -7)
            {
                this.BackgroundImage = CJD_GAME.Properties.Resources._60Collor;
            }
            else if (resultado <= -7 && resultado > -10)
            {
                this.BackgroundImage = CJD_GAME.Properties.Resources._80Collor;
            }
            else if (resultado <= -10)
            {
                this.BackgroundImage = CJD_GAME.Properties.Resources._100Collor;
            }
        }
        private void Tabuleiro_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void leave_mouse(object sender, EventArgs e)
        {
            PictureBox todasPecas = (PictureBox)sender; todasPecas.Size = new Size(34, 34);
        }
        // DECISÕES A PARTIR DO TURNO
        private void PictureBox3_Click(object sender, EventArgs e)
        {
            //botão troca de turno //

            ChamarTrocaDeTurnoAutomatica();
        }

        public void ChamarTrocaDeTurnoAutomatica()
        {
            if(primeiraJogada == true)
            {
                MudarCanal();
                if (turno == true)
                {
                    for (int i = 0; i < jaPassouCollor.Length; i++)
                    {
                        jaPassouCollor[i].Row = -1;
                        jaPassouCollor[i].Column = -1;
                    }
                    botaoEmSi.Tag = "collor";
                    jogada = true;
                    primeiraJogada = false;
                    contador = 1;
                    turno = false;
                    trocarTurno.Image = Properties.Resources.brotaPretoPng;
                    turnoBlack.Size = new Size(40, 40);
                    turnoBlack.Location = new Point(651, 73);
                    turnoCollor.Size = new Size(30, 30);
                    turnoCollor.Location = new Point(736, 83);
                    movimentoDia = true;
                    movimentoHor = true;
                    movimentoVert = true;
                }
                else
                {
                    for (int i = 0; i < jaPassouCollor.Length; i++)
                    {
                        jaPassouCollor[i].Row = -1;
                        jaPassouCollor[i].Column = -1;
                    }
                    botaoEmSi.Tag = "black";
                    jogada = true;
                    primeiraJogada = false;
                    contador = 1;
                    turno = true;
                    trocarTurno.Image = Properties.Resources.botão_trocar_png;
                    turnoBlack.Size = new Size(30, 30);
                    turnoBlack.Location = new Point(659, 83);
                    turnoCollor.Size = new Size(40, 40);
                    turnoCollor.Location = new Point(732, 73);
                    movimentoDia = true;
                    movimentoHor = true;
                    movimentoVert = true;
                }
            }
          
        }


        private void mouseCima(object sender, EventArgs e)
        {
            PictureBox peca = (PictureBox)sender;
            if (turno == false)
            {
                if (peca.Tag.ToString() == "black")
                {
                    peca.Size = new Size(40, 40);
                }
                else { }
            }
            else
            {
                if (peca.Tag.ToString() == "collor")
                {
                    peca.Size = new Size(40, 40);
                }
                else { }
            }
        }
        private void TodasPecasMouseDown(object sender, MouseEventArgs e)
        {
            PictureBox botao = (PictureBox)sender;
            posicao = tableEntrada.GetPositionFromControl(botao);
            if (primeiraJogada == false)
            {
                if (turno == false)
                {
                    if (botao.Tag.ToString() == "black")
                    {
                        botao.DoDragDrop(botao, DragDropEffects.Copy);
                    }
                    else { }
                }
                else
                {
                    if (botao.Tag.ToString() == "collor")
                    {
                        botao.DoDragDrop(botao, DragDropEffects.Copy);
                    }
                    else { }
                }
            }
            else
            {
                if (botao.Tag.ToString() == "selecionada")
                {
                    botao.DoDragDrop(botao, DragDropEffects.Copy);
                }
                else { }
            }
        }
        private void BotaoMute_Click(object sender, EventArgs e)
        {
            if (mute == false)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                botaoMute.BackgroundImage = CJD_GAME.Properties.Resources.mutado;
                mute = true;
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                botaoMute.BackgroundImage = CJD_GAME.Properties.Resources.desmutado;
                mute = false;
            }
        }
        private void TelaJogo_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void BtnPower_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
