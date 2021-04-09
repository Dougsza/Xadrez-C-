using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {

            try {

                Tabuleiro_Classe tab = new Tabuleiro_Classe(8,8);
                tab.ColocarPeca(new Rei(Cor.Preta,tab),new Posicao(5,7));
                tab.ColocarPeca(new Rei(Cor.Preta,tab),new Posicao(0,2));
                tab.ColocarPeca(new Torre(Cor.Branca,tab),new Posicao(3,2));
                Tela.ImprimeTabuleiro(tab);

                /*PosicaoXadrez xadrez = new PosicaoXadrez('c',2);
                Console.WriteLine(xadrez); 
                Console.WriteLine(xadrez.ToPosicao());             
               */
                }catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
