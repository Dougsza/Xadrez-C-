using System;
using Tabuleiro;

namespace Tabuleiro {
    class Tabuleiro_Classe {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca_Tabuleiro[,] Pecas;

        public Tabuleiro_Classe(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            Pecas = new Peca_Tabuleiro[linhas,colunas];
        }
        public Peca_Tabuleiro peca(int linha,int coluna) {
            return Pecas[linha, coluna];
        }
    }
}
