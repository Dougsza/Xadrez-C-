using tabuleiro;

namespace xadrez {
    class Rei : Peca_Tabuleiro {

        public Rei(Cor cor, Tabuleiro_Classe tab) : base(cor, tab) {
           

        }
        private bool _PodeMover(Posicao pos) {
            Peca_Tabuleiro p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[tabuleiro.linhas,tabuleiro.colunas];
            Posicao pos = new Posicao(0,0);     
            
            //Acima
            pos.DefinirValores(posicao.linha - 1,posicao.coluna);
            if(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
            }

            //NS
            pos.DefinirValores(posicao.linha - 1,posicao.coluna + 1);
            if(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
            }

            //Direita
            pos.DefinirValores(posicao.linha,posicao.coluna + 1);
            if(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
            }

            //SO
            pos.DefinirValores(posicao.linha + 1,posicao.coluna - 1);
            if(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
            }

            //Abaixo
            pos.DefinirValores(posicao.linha + 1,posicao.coluna);
            if(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
            }

            //NO
            pos.DefinirValores(posicao.linha - 1,posicao.coluna - 1);
            if(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
            }

            //Esquerda
            pos.DefinirValores(posicao.linha,posicao.coluna - 1);
            if(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
            }

            //SE
            pos.DefinirValores(posicao.linha + 1,posicao.coluna + 1);
            if(tabuleiro.PosicaoValida(pos) && _PodeMover(pos)) {
                matriz[pos.linha,pos.coluna] = true;
            }
            return matriz;
        }
        public override string ToString() {
            return "R";
        }

    }
}
