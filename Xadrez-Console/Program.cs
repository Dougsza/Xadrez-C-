using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {

            try {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.partidaTerminada) {
                    Console.Clear();
                    Tela.ImprimeTabuleiro(partida.tab);
                    Console.WriteLine("\n\n");
                    Console.Write("     Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimeTabuleiro(partida.tab,posicoesPossiveis);                

                    Console.WriteLine("\n\n");
                    Console.Write("     Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem,destino);                  

                }

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
