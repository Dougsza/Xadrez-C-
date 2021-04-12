using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro_Classe tab { get; private set; }
        public bool partidaTerminada { get; private set; }
        private int _turno;
        private Cor _jogadorAtual;

        public PartidaDeXadrez() {
            tab = new Tabuleiro_Classe(8,8);
            partidaTerminada = false;
            _turno = 1;
            _jogadorAtual = Cor.Branca;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca_Tabuleiro p = tab.RetirarPeca(origem);
            p.icrementaMovimento();
            Peca_Tabuleiro pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p,destino);           

        }
        //Método auxiliar para colocar pecas
        private void ColocarPecas() {

            //Colocando as peças brancas no tabuleiro
            tab.ColocarPeca(new Torre(Cor.Branca,tab),new PosicaoXadrez('c',1).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Branca,tab),new PosicaoXadrez('c',2).ToPosicao());
            tab.ColocarPeca(new Rei(Cor.Branca,tab),new PosicaoXadrez('d',1).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Branca,tab),new PosicaoXadrez('d',2).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Branca,tab),new PosicaoXadrez('e',2).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Branca,tab),new PosicaoXadrez('e',1).ToPosicao());
            //Colocando as peças pretas no tabuleiro
            tab.ColocarPeca(new Torre(Cor.Preta,tab),new PosicaoXadrez('c',8).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Preta,tab),new PosicaoXadrez('c',7).ToPosicao());
            tab.ColocarPeca(new Rei(Cor.Preta,tab),new PosicaoXadrez('d',8).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Preta,tab),new PosicaoXadrez('d',7).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Preta,tab),new PosicaoXadrez('e',8).ToPosicao());
            tab.ColocarPeca(new Torre(Cor.Preta,tab),new PosicaoXadrez('e',7).ToPosicao());


        }

        
    }
}
