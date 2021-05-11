using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class Dama : Peca_Tabuleiro{
        public Dama(Cor cor, Tabuleiro_Classe tab) : base (cor, tab) {

        }
        private bool _PodeMover(Posicao pos) {
            Peca_Tabuleiro p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] MovimentosPossiveis() {
            throw new NotImplementedException();
        }
        public override string ToString() {
            return "D";
        }
    }
}
