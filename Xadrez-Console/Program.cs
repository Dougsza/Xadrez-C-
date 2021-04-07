using System;
using tabuleiro;
using xadrez;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {

            try {
                PosicaoXadrez xadrez = new PosicaoXadrez('c',2);
                Console.WriteLine(xadrez); 
                Console.WriteLine(xadrez.ToPosicao());             
               
                }catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
