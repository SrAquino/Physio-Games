using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{   

    [SerializeField]
    private GameObject enemyExplosioPrefab;

    private controllGame2 _gerenciadordeinterface;

    public static float speed = 5.0f;

    void Start()
    {
        //Debug.Log("Enemy: MUAHAHAHA I will kill you " + name);
        _gerenciadordeinterface = GameObject.Find("controllGame").GetComponent<controllGame2>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -7){//Volta o mesmo objeto pro topo caso não seja destruido pelo player
            transform.position = new Vector3(Random.Range(-7,7),5.5f,0);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Colidiu com: " + other.name);

        if(other.tag == "Laser"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);

            Instantiate(enemyExplosioPrefab, transform.position, Quaternion.identity);
            
            if(_gerenciadordeinterface != null){
                _gerenciadordeinterface.atualizaPlacar();
            }
        }

        if(other.tag == "Player"){
            Player_galaxy p1 = other.GetComponent<Player_galaxy>();
                if(p1 != null){
                    Debug.Log("Colidiu com: " + other.name);
                    p1.Damage();
                }
                    
                Destroy(this.gameObject);
                Instantiate(enemyExplosioPrefab, transform.position, Quaternion.identity);
        }
    
    }
}
