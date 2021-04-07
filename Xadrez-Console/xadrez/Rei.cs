using tabuleiro;

namespace xadrez {
    class Rei :Peca_Tabuleiro {

        public Rei(Cor cor, Tabuleiro_Classe tab) : base(cor, tab) {

        }
        public override string ToString() {
            return "R";
        }
    }
}
