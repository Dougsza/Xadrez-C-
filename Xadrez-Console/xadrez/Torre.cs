using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class Torre : Peca_Tabuleiro {
        public Torre(Cor cor,Tabuleiro_Classe tab) : base(cor,tab) {

        }
        private bool _PodeMover(Posicao pos) {
            Peca_Tabuleiro p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] MovimentosPossiveis() {
            //Matriz com o tamanho do tabuleiro
            bool[,] matriz = new bool[tabuleiro.linhas,tabuleiro.colunas];

            Posicao pos = new Posicao(0,0);

            //Acima
            //Coloca na variavel pos os valores da posicao.linha
            pos.DefinirValores(posicao.linha - 1,posicao.coluna);
            while(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha - 1;
            }
            //Abaixo
            pos.DefinirValores(posicao.linha + 1,posicao.coluna);
            while(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha + 1;
            }      
            //Direita
            pos.DefinirValores(posicao.linha ,posicao.coluna +1);
            while(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }      
            //Esquerda
            pos.DefinirValores(posicao.linha ,posicao.coluna -1);
            while(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna - 1;                
            }
            return matriz;
        }
        public override string ToString() {
            return "T";
        }
    }
}

