using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KoumoriController06 : MonoBehaviour
{
    float speed = -10;

    void Start()
    {
        Destroy(gameObject, 20f);        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        if(GameDirector06.gameState != 0)
        {
            Destroy(gameObject);
        }
    }
}
