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
        public abstract bool[,] movimentosPossiveis();

      
        public void icrementaMovimento() {
            qtdMovimentos += 1;
        }
     
    }
}
