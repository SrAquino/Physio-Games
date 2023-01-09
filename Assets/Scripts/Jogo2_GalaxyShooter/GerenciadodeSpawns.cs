using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadodeSpawns : MonoBehaviour
{
    [SerializeField]
    private GameObject naveInimiga;

    [SerializeField]
    private GameObject[] powerUps;

    public static float tempoNovoInimigo; 
    public static float tempoNovoPower; 

    void Start()
    {
        tempoNovoInimigo = 5.5f;
        tempoNovoPower = 5.5f;
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerUpSpawn());
        
    }

   IEnumerator EnemySpawn(){

        while(true){
            Instantiate(naveInimiga, new Vector3(Random.Range(-7f, 7f),7,0), Quaternion.identity);
            yield return new WaitForSeconds(tempoNovoInimigo);
        }
   }

   IEnumerator PowerUpSpawn(){

        while(true){
            int randomPower = Random.Range(0,3);//  Gera um número aleatório para gerar um poder
            Instantiate(powerUps[randomPower],new Vector3(Random.Range(-7,7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(tempoNovoPower);
        }
   }
}
