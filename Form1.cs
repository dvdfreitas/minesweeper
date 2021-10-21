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
        int nLinhas = 5;
        int nColunas = 5;
        Button[,] tabuleiro;
        int[,] bombas;
        int largura = 100;
        int altura = 100;
        bool primeira_vez = true;
        int pos_vazias = 0;
        int totalBombas = 1;
        int margem = 100;
        // Define a altura dos botões de controlo (não do tabuleiro)
        int altura_button = 50;
        TextBox larguraBox = new TextBox();
        TextBox alturaBox = new TextBox();
        
        
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Bisque;
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            larguraBox.Text = nColunas + "";
            alturaBox.Text = nLinhas + "";

            Button startButton = new Button();
            startButton.Left = nColunas * largura + margem;
            startButton.Text = "Start";
            startButton.Click += new EventHandler(inicia_jogo);
            Controls.Add(startButton);

            nLinhas = Int32.Parse(alturaBox.Text);
            //TextBox larguraBox = new TextBox();
            //TextBox alturaBox = new TextBox();
            alturaBox.Left = nColunas * largura + margem;
            larguraBox.Left = nColunas * largura + margem;
            larguraBox.Top = altura_button;
            alturaBox.Top = 2*altura_button;

            Controls.Add(larguraBox);
            Controls.Add(alturaBox);

           
        }

        private void inicia_jogo(object sender, EventArgs e)
        {
            nLinhas = Int32.Parse(alturaBox.Text);
            nColunas = Int32.Parse(larguraBox.Text);

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
            int padding = 300; // Deve ser dinâmic
            this.Size = new Size(nLinhas * altura + padding, nColunas * largura + padding);
        }



        private void Tabuleiro_Click(object sender, EventArgs e)
        {
            Button tabuleiro_clicado = (Button)sender;

            String nome_tabuleiro = tabuleiro_clicado.Name;
            int pos = nome_tabuleiro.IndexOf(':');
            int linha_clicada = Int32.Parse(nome_tabuleiro.Substring(0, pos));
            int coluna_clicada = Int32.Parse(nome_tabuleiro.Substring(pos+1));

            if (primeira_vez)
            {
                primeira_vez = false;
                geraBombas(linha_clicada, coluna_clicada);
            }

            int bombas_volta = 0;
            if (bombas[linha_clicada, coluna_clicada] == 1)
                MessageBox.Show("Game over");
            else
            {
                if (linha_clicada - 1 >=0 && coluna_clicada -1 >=0 && bombas[linha_clicada - 1, coluna_clicada - 1] == 1)
                        bombas_volta++;
                if (linha_clicada - 1 >= 0 && bombas[linha_clicada - 1, coluna_clicada] == 1)
                    bombas_volta++;
                if (linha_clicada - 1 >= 0 && coluna_clicada + 1 < nColunas && bombas[linha_clicada - 1, coluna_clicada + 1] == 1)
                    bombas_volta++;
                if (coluna_clicada - 1 >= 0 && bombas[linha_clicada, coluna_clicada - 1] == 1)
                    bombas_volta++;
                if (coluna_clicada + 1 < nColunas && bombas[linha_clicada, coluna_clicada + 1] == 1)
                    bombas_volta++;
                if (linha_clicada + 1 < nLinhas && coluna_clicada - 1 >= 0 && bombas[linha_clicada + 1, coluna_clicada - 1] == 1)
                    bombas_volta++;
                if (linha_clicada + 1 < nLinhas && bombas[linha_clicada + 1, coluna_clicada] == 1)
                    bombas_volta++;
                if (linha_clicada + 1 < nLinhas && coluna_clicada + 1 < nColunas && bombas[linha_clicada + 1, coluna_clicada + 1] == 1)
                    bombas_volta++;

                if (bombas_volta == 0)
                    MessageBox.Show("Zero");

                tabuleiro[linha_clicada, coluna_clicada].Text = bombas_volta + "";

            }
            pos_vazias++;

            if (pos_vazias == nLinhas * nColunas - totalBombas)
                MessageBox.Show("Ganhou");
        }

        // Esta função gera um número aleatório de bombas
        // (que coloca na variável global: bombas)
        // Mas nunca na posição X: linha_clicada e Y: coluna_clicada
        public void geraBombas(int linha_clicada, int coluna_clicada)
        {

            int bombasColocadas = 0;
               
            Random fabricaBombas = new Random();

            while (bombasColocadas < totalBombas)
            {
                int bombaLinha = fabricaBombas.Next(0, nLinhas);
                int bombaColuna = fabricaBombas.Next(0, nColunas);

                if (!(bombas[bombaLinha,bombaColuna]==1 || 
                       (linha_clicada == bombaLinha && 
                       coluna_clicada == bombaColuna)))
                {               
                    bombas[bombaLinha, bombaColuna] = 1;
                    bombasColocadas++;
                    //tabuleiro[bombaLinha, bombaColuna].Text = "B";
                }
            }

            for (int linha = 0; linha < nLinhas; linha++)
            {
                for (int coluna = 0; coluna < nColunas; coluna++)
                {
                    debug_bombas.Text += bombas[linha, coluna];
                }

                debug_bombas.Text += System.Environment.NewLine;
            }
        }

        
    }
}
