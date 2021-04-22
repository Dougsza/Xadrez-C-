using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {

            try {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.partidaTerminada) {
                    try {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);                      
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                        //Valida a posição Origem
                        partida.ValidaPosicaoOrigem(origem);

                        //Matriz booleana que pega os movimentos possiveis e envia para imprimir eles na Tela
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimeTabuleiro(partida.tab,posicoesPossiveis);
                        Console.WriteLine("\n");
                        Console.WriteLine("Turno: {0}\nVez da peça: {1}",partida.turno,partida.jogadorAtual);
                        Console.WriteLine("\n");
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                        //Valida a posição Destino
                        partida.ValidarPosicaoDestino(origem,destino);
                        partida.RealizaJogada(origem,destino);

                    }catch(TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                 }

                /*PosicaoXadrez xadrez = new PosicaoXadrez('c',2);
                Console.WriteLine(xadrez); 
                Console.WriteLine(xadrez.ToPosicao());             
               */
                }catch(TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
