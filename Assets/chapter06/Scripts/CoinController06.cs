using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController06 : MonoBehaviour
{
    Vector3 sePos;
    public AudioClip coinSe;
    Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        sePos = player.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log(sePos);
            GameDirector06.coinCnt++;
            AudioSource.PlayClipAtPoint(coinSe, sePos);
            Destroy(gameObject);
        }
    }
}
