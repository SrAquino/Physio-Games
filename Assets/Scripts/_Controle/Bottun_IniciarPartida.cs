using System;
using UnityEngine;
using UnityEngine.UI;

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

        if( String.Equals(nome,"Tennis Physio") ){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Calibragem_Tennis");
        } else if (String.Equals(nome,"Galaxy Shooter")){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Calibragem_GalaxyShooter");
        }
        
    }
}
