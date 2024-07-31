using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleLogoController06 : MonoBehaviour
{
    const float START_SPEED = 3f;   // 通常速度
    const float SPEEDUP_TIME = 4f;  // スピードアップ時間

    Image image;                    // オブジェクト保存用
    float speed;                    // フェード速度
    float time;                     // 時間計測用変数
    bool speedUpFlg;                // スピードアップフラグ

    void Start()
    {
        image = gameObject.GetComponent<Image>(); //　Textコンポーネントを取得
        speed = START_SPEED;                    // スピードの初期値設定
        speedUpFlg = false;                     // スピードアップフラグOFF
    }

    void Update()
    {
        //オブジェクトのAlpha値を更新
        image.color = GetAlphaColor(image.color);

        // エンターキーが押された後は点滅速度を赤い彗星にする
        if (Input.GetKeyDown(KeyCode.Return))
        {
            speedUpFlg = true;
            speed *= 5f;
            time = 0f;
        }

        // エンターキーが押されてからSPEEDUP_TIME秒たったら点滅速度を戻す
        if (speedUpFlg && (time / speed) >= SPEEDUP_TIME)
        {
            speedUpFlg = false;
            speed = 5f;
            time = 0f;
            SceneManager.LoadScene(1);
        }
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * speed;
        // アルファ値を 0.0～1.0の範囲で循環させる
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;
    }

}