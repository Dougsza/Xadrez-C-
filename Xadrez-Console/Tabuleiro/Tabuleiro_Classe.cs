using System;
using System.Collections.Generic;
using tabuleiro;

namespace tabuleiro {
    class Tabuleiro_Classe {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca_Tabuleiro[,] pecas;
        
        public Tabuleiro_Classe(int linhas,int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca_Tabuleiro[linhas,colunas];
        }

        //Este método ajuda a verificar se dentro da matriz Peca_Tabuleiro esta vazia (null)
        public Peca_Tabuleiro peca(int linha,int coluna) {
            return pecas[linha,coluna];
        }     

        public Peca_Tabuleiro peca(Posicao pos) {
            return pecas[pos.linha,pos.coluna];
        }   

        //Coloca a peça em uma posição do Tabuleiro
        public void ColocarPeca(Peca_Tabuleiro peca,Posicao posicao) {
            if(ExistePeca(posicao)) {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            pecas[posicao.linha,posicao.coluna] = peca;
            peca.posicao = posicao;
        }   

        public bool ExistePeca(Posicao pos) {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        //Verifica se a posição é valida
        public bool PosicaoValida(Posicao pos) {
            if(pos.linha <0 || pos.linha >=linhas || pos.coluna <0 || pos.coluna >=colunas) {
                return false;
            }
            return true;
        }
        /*Verifica o resultado que retornou do método PosicaoValida e caso o retorno do
         método for falso ele envia uma Exception personalizada para a classe TabuleiroExpection*/
        public void ValidarPosicao(Posicao pos) {
            if(!PosicaoValida(pos)) {
                throw new TabuleiroException("Posição invalida!");
            }
        }
    }    
}
