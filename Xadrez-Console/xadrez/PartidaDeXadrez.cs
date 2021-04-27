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
        public bool xeque { get; private set; }
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

        public Peca_Tabuleiro ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca_Tabuleiro p = tab.RetirarPeca(origem);
            p.IcrementaMovimento();
            Peca_Tabuleiro pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p,destino);           

            if(pecaCapturada != null) {
                _capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca_Tabuleiro pecaCapturada) {
            Peca_Tabuleiro p = tab.RetirarPeca(destino);
            p.DecrenentaMovimento();
            if(pecaCapturada != null) {
                tab.ColocarPeca(pecaCapturada,destino);
                _capturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p,origem);
        }

        //Pega a origem e destino do jogador e envia para o método de executar movimento
        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca_Tabuleiro pecaCapturada = ExecutaMovimento(origem,destino);
            if(EstaEmXeque(jogadorAtual)) {
                DesfazMovimento(origem,destino,pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque");
            }
            if(EstaEmXeque(_Adversaria(jogadorAtual))) {
                xeque = true;
            }
            else {
                xeque = false;
            }
            if(TesteXequeMate(_Adversaria(jogadorAtual))) {
                partidaTerminada = true;
            }
            else {
                turno++;
                _MudaJogador();
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

        private Cor _Adversaria(Cor cor) {
            if(cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }
        
        //Verifica se existe um rei com a cor informada no metodo na partida
        private Peca_Tabuleiro _Rei(Cor cor) {
            foreach (Peca_Tabuleiro x in PecasEmJogo(cor)) {
                if(x is Rei) {
                    return x;
                }
            }
            return null;
        }

        //Verifica se a cor da pela informada está em xeque
        public bool EstaEmXeque(Cor cor) {
            Peca_Tabuleiro R = _Rei(cor);
            if(R == null) {
                throw new TabuleiroException("Não tem rei da cor "+ cor +" no tabuleiro!");
            }
            foreach(Peca_Tabuleiro x in PecasEmJogo(_Adversaria(cor))) {
                bool[,] mat = x.MovimentosPossiveis();
                if(mat[R.posicao.linha,R.posicao.coluna]) {
                    return true;
                }
            }
            return false;
        }
        public bool TesteXequeMate(Cor cor) {
            if(!EstaEmXeque(cor)) {
                return false;
            }
            foreach(Peca_Tabuleiro x in PecasEmJogo(cor)) {
                bool[,] mat = x.MovimentosPossiveis();
                for(int i=0; i < tab.linhas; i++) {
                    for(int j=0; j<tab.colunas; j++) {
                        Posicao origem = x.posicao;
                        Posicao destino = new Posicao(i,j);
                        Peca_Tabuleiro pecaCapturada = ExecutaMovimento(origem,destino);
                        bool testeXeque = EstaEmXeque(cor);
                        DesfazMovimento(origem,destino,pecaCapturada);
                        if(!testeXeque) {
                            return false;
                        }
                    }
                }
            }
            return true;
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
