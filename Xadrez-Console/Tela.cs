using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console {
    class Tela {

        //Imprime o tabuleiro
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
            Console.WriteLine();
            
        }

        //Lê a posição em que o usuário quer que a peça se movimente
        public static PosicaoXadrez LerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna,linha);
        }

        //Imprime a peça do tabuleiro 
        public static void ImprimirPeca(Peca_Tabuleiro peca) {
            if(peca.cor == Cor.Branca) {
                Console.Write(peca+" ");
            }
            else {
                //Transforma as peças que não são brancas em amarelas
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca+ " ");
                Console.ForegroundColor = aux;
            }
        }
    }
}
