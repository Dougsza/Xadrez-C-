using System;
using System.Collections.Generic;
using tabuleiro;

namespace tabuleiro {
    class Tabuleiro_Classe {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca_Tabuleiro[,] _pecas;
        
        public Tabuleiro_Classe(int linhas,int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            _pecas = new Peca_Tabuleiro[linhas,colunas];
        }
        //Este método ajuda a verificar se dentro da matriz Peca_Tabuleiro esta vazia (null) no For da classe Tela
        public Peca_Tabuleiro peca(int linha,int coluna) {
            return _pecas[linha,coluna];
        }     
        //Sobrecarda de peca
        public Peca_Tabuleiro peca(Posicao pos) {
            return _pecas[pos.linha,pos.coluna];
        }   
        //Coloca a peça em uma posição do Tabuleiro
        public void ColocarPeca(Peca_Tabuleiro peca,Posicao pos) {
            if(ExistePeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            _pecas[pos.linha,pos.coluna] = peca;
            peca.posicao = pos;
        }          
        //Retira as peças do Tabuleiro
        public Peca_Tabuleiro RetirarPeca(Posicao pos) {
            if(peca(pos) == null) {
                return null;
            }
            //Variável do tipo auxiliar que pega a peça na posição do parâmetro do metodo que deixa a posição da peça nula
            Peca_Tabuleiro aux = peca(pos);
            aux.posicao = null;
            _pecas[pos.linha,pos.coluna] = null;
            return aux;
        }
        //Verifica se existe uma peça na posição que entra no método
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
