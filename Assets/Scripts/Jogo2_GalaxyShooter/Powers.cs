using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    private float speed = 2.5f;
    [SerializeField]
    private int powerID;// 0 = triple; 1 = speed; 2 = shield

    void Start()
    {
        
    }
    void Update()
    {
       transform.Translate(Vector3.down * speed * Time.deltaTime);

       if (transform.position.y < -5){
            Destroy(this.gameObject);
        }
    }

     private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Colidiu com: " + other.name);

        if (other.name == "Player"){
            Player_galaxy p1 = other.GetComponent<Player_galaxy>();

            switch(powerID){
                case 0:
                    p1.powerUpOn("triple");
                break;

                case 1:
                    p1.powerUpOn("speed");
                break;

                case 2:
                    p1.powerUpOn("shield");
                break;
            }
        
            
        Destroy(this.gameObject);
        }
        
        
     }
}
