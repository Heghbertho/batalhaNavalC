using System;
using System.IO;

class Mar {
    int[,] array = new int[8, 8];
    
    public int acertou;
    public int jogador = 1;
    public string text_j1;
    public string text_j2;
    
    public void limpaTela()
    {
        Console.Clear();
    }
    
    public void inseriCoordenada()
    {
        Console.Write("      Batalha Iniciada\n");
        Console.Write("____________________________________________________\n");
        Console.Write("Jogador 1\n");
        text_j1 = Console.ReadLine();
        Console.Write("Enter com suas coordenadas, voce tem direito a 3 navios \n");
        Console.Write("Use números entre 0 e 7\n");
        
        for (int i = 1; i <= 3; i++)
        {
            Console.Write("Localização " + i + " \n");
            
            Console.Write("Longitude  : ");
            int locX = Convert.ToInt32( Console.ReadLine() );
           
            Console.Write("Latitude   : ");
            int locY = Convert.ToInt32( Console.ReadLine() );
           
            if ( verTamanhoXY(locX,locY) ){   
                
                if ( localizaNavio(1,locX,locY) ){
                    // Console.Write("Coordenada OK \n");
                } else {
                    Console.Write("Erro Coordenada, tente outra coordenada \n");
                    i -= 1 ;
                }
            } else {
                 Console.Write("Ei mané !! Coordenada maior que o tamanho do Mar, tente outra coordenada \n");
                 i -= 1 ;
            }
            // limpaTela();
        }
        
        limpaTela();
        Console.Write("      Batalha Iniciada\n");
        Console.Write("____________________________________________________\n");
        Console.Write("Jogador 2\n");
        text_j2 = Console.ReadLine();
        Console.Write("Enter com suas coordenadas, voce tem direito a 3 navios \n");
        Console.Write("Use números entre 0 e 7\n");
        
        for (int i = 1; i <= 3; i++)
        {
            Console.Write("Localização " + i + " \n");
            
            Console.Write("Longitude  : ");
            int locX = Convert.ToInt32( Console.ReadLine() );
           
            Console.Write("Latitude   : ");
            int locY = Convert.ToInt32( Console.ReadLine() );
           
            if ( verTamanhoXY(locX,locY) ){   
                
                if ( localizaNavio(2,locX,locY) ){
                    // Console.Write("Coordenada OK \n");
                } else {
                    Console.Write("Erro Coordenada, tente outra coordenada \n");
                    i -= 1 ;
                }
            } else {
                 Console.Write("Ei mané !! Coordenada maior que o tamanho do Mar, tente outra coordenada \n");
                 i -= 1 ;
            }
            // limpaTela();
        }
        
       
        
       
    }
    
    public bool verTamanhoXY(int locX, int locY)
    {
        if ( locX > 7 || locY > 7 ){
            return false;
        }
        
        return true;
    
    }
    
    public bool localizaNavio(int j,int locX,int locY)
    {
        if ( verLocal(locX,locY ) ) {
            // Console.Write("vazio \n");
            array[locX,locY] = j;
            return true;
        } else {
            Console.Write("ocupado \n");
            return false;
        }
            
    }
    
    public void mostraMar()
    {
     
     for (int i = 0; i < 8 ; i++){
        for (int e = 0; e < 8 ; e++){
            Console.Write(array[i,e] );
        }
         Console.Write("\n");
     }
     
    }

   public void mostraMarDisplay()
    {
        Console.Write("      Batalha Iniciada\n");
        Console.Write("┌───────────────────────────────┐\n");
        for (int i = 0; i < 8 ; i++){
            for (int e = 0; e < 8 ; e++){
                  Console.Write("│");
                if(array[i,e] == 0 || array[i,e] == 1 || array[i,e] == 2 ){
                    Console.Write(" ▓ ");
                } else {
                    Console.Write(" X ");
                }
            }
            Console.Write("│");
            Console.Write("\n");
        }
        Console.Write("└───────────────────────────────┘");
        Console.Write("\n");
    }
    
    
    
    public bool verLocal(int locX,int locY){
        
        if ( array[locX,locY] == 0 || array[locX,locY] == 9){
            return true;    
        } else {
            return false;    
        }
        
    }
    
    public void testaTiro()
    {
        acertou = 3;
        int j1 = 3;
        int j2 = 3;
        string msg;
        string jogadorVez = text_j1;
        limpaTela();
        
        
        while ( j1 > 0 && j2 > 0){
            // mostraMar();
            mostraMarDisplay();
            Console.Write("Tiros de "+ jogadorVez +"\n");
           
            
            Console.Write("Latitude:\n");
            
            int lat =  Convert.ToInt32( Console.ReadLine() ); 
            Console.Write("Longitude:\n");
            int lon =  Convert.ToInt32( Console.ReadLine() );
            limpaTela();
            
            if ( verLocal(lat,lon) ) {
                array[lat,lon] = 9;
                // mostraMar();
                // mostraMarDisplay();
                
                
            } else {
                // limpaTela();
                
                if ( array[lat,lon] == 1 ){
                    array[lat,lon] = 0;
                    j1 -= 1;
                    if(  jogadorVez == text_j1 ){
                        Console.Write("Putz! Você se matou " + text_j1 +"\n");
                    } else {
                        Console.Write("Parabens "+ text_j2 +" você acertou o navio de " + text_j1 +"\n");
                    }
                }
                
                if ( array[lat,lon] == 2 ){
                    array[lat,lon] = 0;
                    j2 -= 1;
                    if(  jogadorVez == text_j2 ){
                        Console.Write("Ô " + text_j2 +" tu atirou em tu mesmo doidão !!\n");
                    } else {
                        Console.Write("Parabens "+ text_j1 +" você acertou o navio de " + text_j2 +"\n");
                    }
                }
                
                
                // acertou = acertou -1;
            }
            if ( jogadorVez == text_j1){
                    jogadorVez = text_j2;
                } else {
                    jogadorVez = text_j1;
            }
             Console.Write("      Placar "+j1+" x "+j2+"\n");
        }
        
        Console.Write("Fim de jogo...\n");
        
        
    }
    
    public void inseriInf(){
        Console.Write("Instruções:\n");
        Console.Write("02 Jogadores, tem direito a 3 navios, usando coordenadas\n");
        Console.Write("em matriz de 8x8, cada usuário alocará seus navios usando\n");
        Console.Write("eixos de latitude e longitude com numeração de 0 a 7\n");
        Console.Write("após a alocação dos navios, os jogadores começam a jogar\n");
        Console.Write("suas minas, com tiros alternados entre jogadores, até a \n");
        Console.Write("destruição do primeiro oponente, finalizando com o \n");
        Console.Write("Vencedor o que permanecer com navio.\n");
    }
    
    public void sobre(){
        Console.Write("Versão 0.0001:\n");
        Console.Write("Tarefa de classe - Fametro\n");
        Console.Write("Professor: Leonardo\n");
        Console.Write("Curso ADS-2017\n");
        Console.Write("Aluno: Heghbertho Costa\n");
        Console.Write("Pontuação: 1 ponto\n");
       
    }
    
    public void menu(){
        Console.Write("╔═════════════════════════════════════════════════════════╗\n");
        Console.Write("║ Bem vindo a Batalha naval - ver 0.00001                 ║\n");
        Console.Write("╚═════════════════════════════════════════════════════════╝\n");
        Console.Write("╔═════════════════════════════════════════════════════════╗\n");
        Console.Write("║ Menu                                                    ║\n");
        Console.Write("╠═════════════════════════════════════════════════════════╣\n");
        Console.Write("║ (1) Instruções do Jogo                                  ║\n");
        Console.Write("║ (2) Jogar                                               ║\n");
        Console.Write("║ (3) Sobre                                               ║\n");
        Console.Write("╚═════════════════════════════════════════════════════════╝\n");
        String text_op = Console.ReadLine();
        
        switch (text_op)
        {

          case "1":
          limpaTela();
          inseriInf();
          menu();
          break;
          
          case "2":
          limpaTela();
          break;
          
          case "3":
          limpaTela();
          sobre();
          menu();
          break;
        
          default:
            limpaTela(); 
            menu();
            
          break;
        }
    
    }
}