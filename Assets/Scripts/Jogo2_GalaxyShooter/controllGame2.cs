using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controle do jogo
public class controllGame2 : MonoBehaviour
{
    //Variavel de config. do modo do jogo: 1 - tempo, 2 - fácil, 3- médio, 4-difícil 
    public static int modalidadeJogo; 
    
    //Flag para controle do início do jogo
    public static int startGame;
    
    //Calculando o tempo decorrido total da partida
    public static float tempoTotalPartida;
    
    //variavel responsavel pela coleta do tempo da partida configurado pelo fisioterapeuta
    int tempoPartida;
    
    //variavel que realiza o calculo da partida durante a execução da configuração de partida por tempo
    public static float tempoDecorrido;
    
    //Guarda as imagens das vidas
    public Sprite[] Vida;
    public Image VidaExibida;

    public int score;
    public Text scoreText;

    void Update()
    {
        //Configuração dos modos de jogo
        //Debug.Log("CONFIGURAÇÃO DOS MODOS DE JOGO");
        if(startGame == 1){
            //Debug.Log("GAME STARTED");
            tempoTotalPartida += Time.deltaTime;
            //Debug.Log("tempoPartida: " + tempoPartida);
            switch(modalidadeJogo){
                case 1://Tempo
                    //Debug.Log("Jogo por TEMPO! : " + configPartida_jogo2.tempo);
                    tempoPartida = configPartida_jogo2.tempo;     //lê tempo necessario
                    tempoPartida = tempoPartida * 60;       //converte tempo em segundos
                    tempoDecorrido += Time.deltaTime; 
                    Player_galaxy.flagDificuldade = false;  //config. partida para ser fácil

                    if(tempoDecorrido >= tempoPartida || Player_galaxy.Life == 0){
                        UnityEngine.SceneManagement.SceneManager.LoadScene("sceneFimPartida");
                    }
                break;
                
                /*
                case 2: //fácil 
                    
                break;
                case 3: //médio
                   
                break;
                case 4: //difícil
                   
                break;*/
            }
        }
    }

    //Muda a imagem da quantdade de vida do player
    public void atualizaVida(int vidaAtual){
        VidaExibida.sprite = Vida[vidaAtual];
    }

    public void atualizaPlacar(){
        score += 100;
        scoreText.text = "Pontuação: "+score;
    } 
}
