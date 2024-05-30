//----------------------------------------------------------------------------
// 科目：ゲームプログラミング１年
// 内容：５章 練習問題
// 担当：Ken.D.Ohishi 2024.05.30
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class chapter05Controller : MonoBehaviour
{
    Vector3 startPos;       // 生成時に表示される場所
    float speed = 5f;       // 移動速度
    
    void Start()
    {
        // 生成されたときに表示される場所を指定
        startPos.x = -12f;
        startPos.y = Random.Range(-4.5f, 4.5f);
        startPos.z = 0;
        transform.position = startPos;

        // このゲームオブジェクトは生成後10秒で消滅する
        Destroy(gameObject, 10);
    }

    void Update()
    {
        // 画面右に消えたら左から再登場させる
        if(transform.position.x > 12f)
        {
            startPos.y = Random.Range(-4.5f, 4.5f);
            transform.position = startPos;            
        }
        // 移動
        transform.position += Vector3.right * speed * Time.deltaTime;
        // transform.Translate(Vector3.right * speed * Time.deltaTime); 上に行ってしまう
    }
}
