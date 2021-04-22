using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro {
   abstract class Peca_Tabuleiro {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro_Classe tabuleiro { get; protected set; }

        public Peca_Tabuleiro(Cor cor, Tabuleiro_Classe tabuleiro) {
            this.posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            this.qtdMovimentos = 0;

        }
        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();
            for(int i =0; i<tabuleiro.linhas; i++) {
                for(int j = 0; j<tabuleiro.colunas; j++) {
                    if(mat[i,j] == true) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos) {
            return MovimentosPossiveis()[pos.linha,pos.coluna];
        }

        public abstract bool[,] MovimentosPossiveis();  
        
        public void IcrementaMovimento() {
            qtdMovimentos += 1;
        } 
        
        public void DecrenentaMovimento() {
            qtdMovimentos -= 1;
        }
     
    }
}
