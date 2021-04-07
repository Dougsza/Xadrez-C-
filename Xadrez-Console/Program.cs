using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {
            Tabuleiro_Classe tab = new Tabuleiro_Classe(8,8);
          
            tab.ColocarPeca(new Rei(Cor.Branca,tab), new Posicao(0,1));

            Tela.ImprimeTabileiro(tab);

        }
    }
}
