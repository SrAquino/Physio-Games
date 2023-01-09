using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System.Globalization;
using System.IO;
using System;

public class ListaPortas : MonoBehaviour
{

    public static string nomePorta;
    public GameObject msgErro;

    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();

        string [] portasDisponiveis = SerialPort.GetPortNames(); //coleta porta serial disponivel
        //Debug.Log(portasDisponiveis[1]); //seleciona a primeira que é a que está conectado c/ comun serial c/ arduino
        //Cria porta e abre 
        //porta = new SerialPort("/dev/ttyACM1", 115200);
        
        List<string> portas = new List<string>();

        foreach(var porta in portasDisponiveis){
            portas.Add(porta);
        }
        foreach(var porta in portas){
            dropdown.options.Add(new Dropdown.OptionData(){text = porta});
        }

        DropdownItemSelected(dropdown);
        dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});

    }

    void DropdownItemSelected(Dropdown dropdown){
        int index = dropdown.value;
        nomePorta = dropdown.options[index].text;
    }


}
