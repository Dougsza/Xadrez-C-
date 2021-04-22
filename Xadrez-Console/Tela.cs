using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace Xadrez_Console {
    class Tela {

        //Imprime a Partida
        public static void ImprimirPartida(PartidaDeXadrez partida) {
            ImprimeTabuleiro(partida.tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("Turno " + partida.turno);
            Console.WriteLine("Aguardando pela peça "+ partida.jogadorAtual);
            if(partida.xeque) {
                Console.WriteLine("XEQUE");
            }
            Console.WriteLine();
        }

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

        //Imprime o caminho aonde a peça pode ir
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

        //Imprime todas as peças capturadas de cada cor
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        //Esse método pega as peças de
        public static void ImprimirConjunto(HashSet<Peca_Tabuleiro> conjunto) {
            Console.Write("[ ");
            foreach(Peca_Tabuleiro peca in conjunto) {
                Console.Write(peca+" ");
            }
            Console.Write("]");
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
            }
            else if(peca.cor == Cor.Branca) {
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
