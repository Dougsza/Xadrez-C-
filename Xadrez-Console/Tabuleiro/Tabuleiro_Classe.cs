using System;
using System.Collections.Generic;
using tabuleiro;

namespace tabuleiro {
    class Tabuleiro_Classe {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca_Tabuleiro[,] pecas;
        
        public Tabuleiro_Classe(int linhas,int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca_Tabuleiro[linhas,colunas];
        }

        public Peca_Tabuleiro peca(int linha,int coluna) {
            return pecas[linha,coluna];
        }
        public void ColocarPeca(Peca_Tabuleiro peca,Posicao posicao) {
            pecas[posicao.linha,posicao.coluna] = peca;
            peca.posicao = posicao;
        }   
    }    
}
