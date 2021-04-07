using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {

            try {
                Tabuleiro_Classe tab = new Tabuleiro_Classe(8,8);

                tab.ColocarPeca(new Rei(Cor.Branca,tab),new Posicao(0,1));
                tab.ColocarPeca(new Torre(Cor.Amarela,tab),new Posicao(0,8));
                Tela.ImprimeTabileiro(tab);
            }catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
