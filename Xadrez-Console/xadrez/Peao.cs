using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class Peao : Peca_Tabuleiro {
        
        public Peao(Cor cor, Tabuleiro_Classe tab) : base(cor , tab) {

        }
        
        private bool _PodeMover(Posicao pos) {
            Peca_Tabuleiro p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] MovimentosPossiveis() {
            // Matriz com o tamanho do tabuleiro 
             bool[,] matriz = new bool[tabuleiro.linhas,tabuleiro.colunas]; 
            Posicao pos = new Posicao(0,0);
            //Define os valores da matriz aonde essa peça pode ir e verifica 

            //NO
            pos.DefinirValores(posicao.linha - 1,posicao.coluna - 1);
            while(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
            }

            pos.DefinirValores(posicao.linha - 1,posicao.linha + 1);
            while(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
            }
            pos.DefinirValores(posicao.linha +1,posicao.linha + 1);
            while(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
            }
            pos.DefinirValores(posicao.linha +1,posicao.linha - 1);
            while(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
                if(tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
            }
            return matriz;
        }
        public override string ToString() {
            return "P";
        }
        //Parei aqui - Douglas
        private bool _ExisteInimigo(Posicao pos) {
            Peca_Tabuleiro p = tabuleiro.peca(pos);
            return p != null && p.cor != cor;
        }
        private bool _Livre(Posicao pos) {
            return tabuleiro.peca(pos) == null;
        }
    }
}
