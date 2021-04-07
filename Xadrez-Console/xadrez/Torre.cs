using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class Torre : Peca_Tabuleiro {
        public Torre(Cor cor,Tabuleiro_Classe tab) : base(cor,tab) {

        }
        public override string ToString() {
            return "T";
        }
    }
}

