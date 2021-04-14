using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {

        public Tabuleiro_Classe tab { get; private set; }
        public bool partidaTerminada { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }

        public PartidaDeXadrez() {
            tab = new Tabuleiro_Classe(8,8);
            partidaTerminada = false;
            turno = 1;
            jogadorAtual = Cor.Branca;
            _ColocarPecas();
        }
        public void RealizaJogada(Posicao origem, Posicao destino) {
            ExecutaMovimento(origem,destino);
            turno++;
            _MudaJogador();
        }
        //Valida a Posição de origem ao usuário escolher sua posição
        public void ValidaPosicaoOrigem(Posicao pos) {
            if(tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça nessa posição de origem");                
            }
            if(jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("Não é a vez dessa peça!");                
            }
            if(!tab.peca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não existe movimentos possiveis para a peça escolhida  ");               
            }
        }
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino) {
            if(!tab.peca(origem).PodeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino invalida!");
            }
        }
        private void _MudaJogador() {
            if(jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else
                jogadorAtual = Cor.Branca;
        }
        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca_Tabuleiro p = tab.RetirarPeca(origem);
            p.IcrementaMovimento();
            Peca_Tabuleiro pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p,destino);           

        }
        //Método auxiliar para colocar pecas
        private void _ColocarPecas() {

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
