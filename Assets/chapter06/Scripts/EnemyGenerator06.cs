using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator06 : MonoBehaviour
{
    public GameObject enemyPre;
    public Transform player;
    Vector3 pos;
    int enemyType;

    void Start()
    {
        enemyType = 0;
        InvokeRepeating("EnemyCreate", 5f, 7f);
    }

    void Update()
    {
        if(GameDirector06.gameState >= 1)
        {
            CancelInvoke("EnemyCreate");
        }
    }

    void EnemyCreate()
    {
        Quaternion q;
        enemyType = (enemyType == 0) ? 1 : 0;

        pos = player.position;

        if (enemyType == 0)
        {
            pos.x = 20f;
            q = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            pos.x = -20f;
            q = Quaternion.Euler(0, 180, 0);
        }


        Instantiate(enemyPre, pos, q);
    }
}
