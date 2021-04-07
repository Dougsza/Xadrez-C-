using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class PosicaoXadrez {
        public char coluna;
        public int linha;

        public PosicaoXadrez(char coluna,int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 - linha,coluna - 'a');
        }

        public override string ToString() {
            return "" + coluna + linha;
        }
    }
}
