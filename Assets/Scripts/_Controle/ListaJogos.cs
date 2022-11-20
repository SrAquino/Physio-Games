using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ListaJogos : MonoBehaviour
{

    public string nomeJogo;
    public GameObject msgErro;

    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();
        dropdown.options.Clear();

        List<string> jogos = new List<string>();
        jogos.Add("Selecione um jogo");
        jogos.Add("Tennis Physio");
        jogos.Add("Galaxy Shooter");
        

        foreach(var jogo in jogos){
            dropdown.options.Add(new Dropdown.OptionData(){text = jogo});
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});

    }

    void DropdownItemSelected(Dropdown dropdown){
        int index = dropdown.value;
        nomeJogo = dropdown.options[index].text;
    }


}
