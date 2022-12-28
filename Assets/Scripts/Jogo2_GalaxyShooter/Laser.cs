using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5.0f;


    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > 5.5f){//Destrói o objeto caso saia da tela
            Destroy(this.gameObject);
        }
        
    }
}
