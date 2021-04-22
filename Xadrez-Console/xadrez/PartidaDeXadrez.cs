using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        //Variáveis
        public Tabuleiro_Classe tab { get; private set; }
        public bool partidaTerminada { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        private HashSet<Peca_Tabuleiro> _pecas;
        private HashSet<Peca_Tabuleiro> _capturadas;

        public PartidaDeXadrez() {
            tab = new Tabuleiro_Classe(8,8);
            partidaTerminada = false;
            turno = 1;
            jogadorAtual = Cor.Branca;

            /*HashSets:
              Importante inicializar eles antes do método _ColocarPecas()*/        
            _pecas = new HashSet<Peca_Tabuleiro>();
            _capturadas = new HashSet<Peca_Tabuleiro>();

            _ColocarPecas();
        }
        //Pega a origem e destino do jogador e envia para o método de executar movimento
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
            //Verifica a cor do jogador atual e troca de cor
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

            if(pecaCapturada != null) {
                _capturadas.Add(pecaCapturada);
            }
        }
        //Método que mostra quantas peças ainda estão no jogo com a cor informada
        public HashSet<Peca_Tabuleiro> PecasEmJogo(Cor cor) {
            HashSet<Peca_Tabuleiro> aux = new HashSet<Peca_Tabuleiro>();
            foreach(Peca_Tabuleiro pecas in _pecas) {
                if(pecas.cor == cor) {
                    aux.Add(pecas);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        //Método para separar as peças de cada cor
        public HashSet<Peca_Tabuleiro> PecasCapturadas(Cor cor) {
            HashSet<Peca_Tabuleiro> aux = new HashSet<Peca_Tabuleiro>();
            foreach(Peca_Tabuleiro pecas in _capturadas) {
                if(pecas.cor == cor) {
                    aux.Add(pecas);
                }
            }
            return aux;
        }
        //Método auxiliar para colocar pecas
        public void ColocarNovaPeca(char coluna, int linha, Peca_Tabuleiro peca) {
            tab.ColocarPeca(peca,new PosicaoXadrez(coluna,linha).ToPosicao());
            _pecas.Add(peca);
        }
        private void _ColocarPecas() {
            //Colocando as peças brancas no tabuleiro
            ColocarNovaPeca('c',1,new Torre(Cor.Branca,tab));
            ColocarNovaPeca('c',2,new Torre(Cor.Branca,tab));
            ColocarNovaPeca('d',1,new Rei(Cor.Branca,tab));
            ColocarNovaPeca('d',2,new Torre(Cor.Branca,tab));
            ColocarNovaPeca('e',1,new Torre(Cor.Branca,tab));
            ColocarNovaPeca('e',2,new Torre(Cor.Branca,tab));
            
            //Colocando as peças pretas no tabuleiro
            ColocarNovaPeca('c',8,new Torre(Cor.Preta,tab));           
            ColocarNovaPeca('c',7,new Torre(Cor.Preta,tab));           
            ColocarNovaPeca('d',8,new Rei(Cor.Preta,tab));           
            ColocarNovaPeca('d',7,new Torre(Cor.Preta,tab));           
            ColocarNovaPeca('e',8,new Torre(Cor.Preta,tab));           
            ColocarNovaPeca('e',7,new Torre(Cor.Preta,tab));           

        }        
    }
}
