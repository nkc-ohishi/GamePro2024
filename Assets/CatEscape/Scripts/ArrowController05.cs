using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController05 : MonoBehaviour
{
    GameObject player;
    GameDirector05 director;

    void Start()
    {
        player = GameObject.Find("player_0");
        director = GameObject.Find("GameDirector").GetComponent<GameDirector05>();
    }

    void Update()
    {
        transform.Translate(0, -0.1f, 0);
        
        if(transform.position.y < -5f)
        {
            Destroy(gameObject);
        }

        Vector2 p1  = transform.position;
        Vector2 p2  = player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if(d < r1 + r2)
        {
            director.DecreaseHp();
            Destroy(gameObject);
        }


    }
}
