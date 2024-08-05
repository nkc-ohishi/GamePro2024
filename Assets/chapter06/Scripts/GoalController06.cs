using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GoalController06 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(GameDirector06.coinCnt >= 10)
            {
                GameDirector06.gameState = 1;
            }
        }
    }

}
