using System;
using System.Text;

namespace tabuleiro {
    class Posicao {

        public int linha { get; set; }
        public int coluna { get; set; }

       public  Posicao(int linha , int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("Linha {0} \n Coluna{1}", linha, coluna);

            return sb.ToString();
        }
    }
}
