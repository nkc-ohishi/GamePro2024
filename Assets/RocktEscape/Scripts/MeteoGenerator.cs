using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoGenerator : MonoBehaviour
{
    public GameObject meteoPre; // 隕石のプレハブを保存する変数
    float span = 1;             // 隕石を出す間隔（秒）
    float delta = 0;            // 時間計算用変数

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameDirectorRocket.playState > 0) return;

        delta += Time.deltaTime;

        // span秒毎に処理を行う
        if(delta > span)
        {
            delta = 0; // 時間計算用変数を０にする

            // 隕石のプレハブをヒエラルキーに登場させる
            GameObject go = Instantiate(meteoPre);
            int py = Random.Range(-6, 7);
            go.transform.position = new Vector3(10, py, 0);
        }

        
    }
}
