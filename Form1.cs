using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Form1 : Form
    {
        int nLinhas = 3;
        int nColunas = 3;
        Button[,] tabuleiro;
        int[,] bombas;
        int largura = 200;
        int altura = 200;
        bool primeira_vez = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabuleiro = new Button[nLinhas, nColunas];
            bombas = new int[nLinhas, nColunas];

            for (int linha = 0; linha < nLinhas; linha++)
            {
                for (int coluna = 0; coluna < nColunas; coluna++)
                {
                    tabuleiro[linha, coluna] = new Button();
                    tabuleiro[linha, coluna].Width = largura;
                    tabuleiro[linha, coluna].Height = altura;
                    tabuleiro[linha, coluna].Top = linha * altura;
                    tabuleiro[linha, coluna].Left = coluna * largura;

                    tabuleiro[linha, coluna].Name = linha + ":" + coluna;

                    tabuleiro[linha, coluna].Click += new EventHandler(Tabuleiro_Click);

                    Controls.Add(tabuleiro[linha, coluna]);
                }
            }

        }

        private void Tabuleiro_Click(object sender, EventArgs e)
        {
            Button tabuleiro_clicado = (Button)sender;

            // A partir do nome do tabuleiro_clicado consigo saber o X e Y clicados

            if (primeira_vez)
            {
                primeira_vez = false;
                geraBombas(linha_clicada, coluna_clicada);
                //geraBombas(linha_clicada, coluna_clicada);
            }
            else
            {

            }
            
        }

        public void geraBombas()
        {
            int totalBombas = 5;

            int bombasColocadas = 0;
               
            Random fabricaBombas = new Random();

            while (bombasColocadas < totalBombas)
            {
                int bombaLinha = fabricaBombas.Next(0, nLinhas);
                int bombaColuna = fabricaBombas.Next(0, nColunas);

                if (bombas[bombaLinha, bombaColuna] == 0)
                {
                    bombas[bombaLinha, bombaColuna] = 1;
                    bombasColocadas++;
                    tabuleiro[bombaLinha, bombaColuna].Text = "B";
                }
            }

        }
    }
}
