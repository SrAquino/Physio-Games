using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class Bottun_IniciarPartida : MonoBehaviour
{

    public Button iniciar;
    public Dropdown jogos;



    void Start()
    {
        iniciar.onClick = new Button.ButtonClickedEvent();
        iniciar.onClick.AddListener(()=>IniciaPartida());
        
    }

    void IniciaPartida(){
        int index = jogos.value;
        string nome = jogos.options[index].text;

        configCalibragem.porta = new SerialPort(ListaPortas.nomePorta, 115200);

        Debug.Log("Abrir porta..");
        configCalibragem.porta.Open();
        Debug.Log("Porta aberta!");

        if( String.Equals(nome,"Tennis Physio") ){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Calibragem_Tennis");
        } else if (String.Equals(nome,"Galaxy Shooter")){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Calibragem_GalaxyShooter");
        }
        
    }
}
