using System.IO;
using System;


class Program
{
    static void Main()
    {
        Mar jogo = new Mar();
        // View tela = new View();
        jogo.limpaTela();

        
        jogo.menu();
        jogo.inseriCoordenada();
        // jogo.mostraMarDisplay();
        jogo.testaTiro();
    }
}
