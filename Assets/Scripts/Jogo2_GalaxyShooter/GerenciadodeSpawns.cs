using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadodeSpawns : MonoBehaviour
{
    [SerializeField]
    private GameObject naveInimiga;

    [SerializeField]
    private GameObject[] powerUps;

    void Start()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(PowerUpSpawn());
    }

   IEnumerator EnemySpawn(){

        while(true){
            Instantiate(naveInimiga, new Vector3(Random.Range(-7f, 7f),7,0), Quaternion.identity);
            yield return new WaitForSeconds(5.5f);
        }
   }

   IEnumerator PowerUpSpawn(){

        while(true){
            int randomPower = Random.Range(0,3);//  Gera um número aleatório para gerar um poder
            Instantiate(powerUps[randomPower],new Vector3(Random.Range(-7,7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.5f);
        }
   }
}
