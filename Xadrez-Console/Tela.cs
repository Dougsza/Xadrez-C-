using System;
using tabuleiro;

namespace Xadrez_Console {
    class Tela {

        public static void ImprimeTabuleiro(Tabuleiro_Classe tabuleiro) {

            for(int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i +" ");
                for(int j = 0; j < tabuleiro.colunas; j++) {
                     if(tabuleiro.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        ImprimirPeca(tabuleiro.peca(i,j));
                    }                

                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca_Tabuleiro peca) {
            if(peca.cor == Cor.Branca) {
                Console.Write(peca+" ");
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca+ " ");
                Console.ForegroundColor = aux;
            }
        }
    }
}
