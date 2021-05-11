using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class Bispo : Peca_Tabuleiro {

        public Bispo(Cor cor, Tabuleiro_Classe tab) : base (cor,tab) {

        }
        private bool _PodeMover(Posicao pos) {
            Peca_Tabuleiro p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] MovimentosPossiveis() {
            return null;
        }

        public override string ToString() {
            return "B";
        }
    }
}
