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
                     ImprimirPeca(tabuleiro.peca(i,j));                             
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            
            
        }      
        public static void ImprimeTabuleiro(Tabuleiro_Classe tabuleiro, bool[,] posicoesPossiveis) {
            //Essa variável pega a cor do fundo original do console
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            //Essa variável pega a cor Ciano e mostra o caminho que a peça pode se mover
            ConsoleColor fundoAlterado = ConsoleColor.DarkCyan;

            for(int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i +" ");
                for(int j = 0; j < tabuleiro.colunas; j++) {      
                    if(posicoesPossiveis[i,j]) {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                     ImprimirPeca(tabuleiro.peca(i,j));                             
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
            
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
            if(peca == null) {
                Console.Write("- ");
            }else if(peca.cor == Cor.Branca) {
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
