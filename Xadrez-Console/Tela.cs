using System;
using tabuleiro;

namespace Xadrez_Console {
    class Tela {

        public static void ImprimeTabileiro(Tabuleiro_Classe tabuleiro) {

            for(int i = 0; i < tabuleiro.linhas; i++) {               
                for(int j = 0; j < tabuleiro.colunas; j++) {
                     if(tabuleiro.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(tabuleiro.peca(i, j) + " ");
                    }                

                }
                Console.WriteLine();
            }
        }
    }
}
