using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class listaFisioterapeutas : MonoBehaviour
{

    // public Text TextBox;

    string nomeFisioterapeuta;

    public GameObject msgErro;

    void Start()
    {
        dadosJogo.Leitura();
        var dropdown = transform.GetComponent<Dropdown>();
        
        (dadosJogo.fisioterapeutas).Sort();

        foreach(var item in dadosJogo.fisioterapeutas){
            dropdown.options.Add(new Dropdown.OptionData(){text = item});
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});

    }

    void DropdownItemSelected(Dropdown dropdown){
        int index = dropdown.value;
        // Debug.Log(dropdown.options[index].text);
        nomeFisioterapeuta = dropdown.options[index].text;
        if(nomeFisioterapeuta == "Selecione o seu nome"){
            // Debug.Log("Aguardando seleção para login");
        }else{
            
            // Debug.Log("Fisioterapeuta selecionado é: " + nomeFisioterapeuta);
            msgErro.SetActive(false);
        }

    //     TextBox.text = dropdown.options[index].text;
    }

    public void SalvarFisioterapeuta(){
        // dadosJogo.nomeFisioterapeuta = nomeFisioterapeuta.GetComponent<Text>().text;
        if(nomeFisioterapeuta != "Selecione o seu nome"){
            string escrita = "$\n" + System.DateTime.Now + "\n";
            escrita = escrita + nomeFisioterapeuta;
            dadosJogo.Salvar(escrita);
            UnityEngine.SceneManagement.SceneManager.LoadScene("sceneLoginPaciente");
        }else{
            msgErro.SetActive(true);
        }
    }


}
