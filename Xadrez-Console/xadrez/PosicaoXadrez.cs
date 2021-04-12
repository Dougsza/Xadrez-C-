using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;
// Essa classe converte letras em números na matriz do tabuleiro
namespace xadrez {
    class PosicaoXadrez {
        public char coluna;
        public int linha;

        public PosicaoXadrez(char coluna,int linha) {
            this.linha = linha;
            this.coluna = coluna;
        }

        //Converte  posição em letras e numeros ex(c ,7)
        public Posicao ToPosicao() {
            return new Posicao(8 - linha,coluna - 'a');
        }

        public override string ToString() {
            return "" + coluna + linha;
        }
    }
}
