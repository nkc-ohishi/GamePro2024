using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class chapter05Controller : MonoBehaviour
{
    Vector3 startPos = new Vector3(-12f, 0, 0);
    float speed = 5f;

    void Start()
    {
        startPos.x = -12f;
        startPos.y = Random.Range(-4.5f, 4.5f);
        transform.position = startPos;

        Destroy(gameObject, 10);
    }

    void Update()
    {
        // ‰æ–Ê‰E‚ÉÁ‚¦‚½‚ç¶‚©‚çÄ“oê‚³‚¹‚é
        if(transform.position.x > 12f)
        {
            startPos.y = Random.Range(-4.5f, 4.5f);
            transform.position = startPos;            
        }

        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
