//----------------------------------------------------------------------------
// 科目：ゲームプログラミング１年
// 内容：４章 SwipeCar CarControllerスクリプト
// 担当：Ken.D.Ohishi 2024.05.10
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------------
// クラス名：CarControllerクラス
// 機能　　：車オブジェクトの制御を行う
//----------------------------------------------------------------------------
public class CarController04 : MonoBehaviour
{
    // クラスのメンバ変数（クラス内に定義されたメソッドすべてで利用できる変数）
    float speed = 0;    
    Vector2 startPos;
    AudioSource carSe;

    //------------------------------------------------------------------------
    // メソッド名：Startメソッド
    // 動作　　　：シーンが再生されたときに１度だけ自動で実行されるメソッド
    // 用途　　　：変数の初期値をセットするのに使われる
    //------------------------------------------------------------------------
    void Start()
    {
        // Updateメソッドを1秒間に60回実行させる指定
        Application.targetFrameRate = 60;

        // AudioSourceコンポーネントの情報をcarSe変数に保存
        carSe = GetComponent<AudioSource>();
    }

    //------------------------------------------------------------------------
    // メソッド名：Updateメソッド
    // 動作　　　：シーンが再生されている間、繰り返し自動で実行されるメソッド
    // 用途　　　：ゲームオブジェクトのパラメータを更新するのに使われる
    //------------------------------------------------------------------------
    void Update()
    {
        // マウスの左ボタンが１回押されたときの処理
        if(Input.GetMouseButtonDown(0))
        {
            // speed = 0.2f;

            // マウスをクリックした座標をstartPos変数に保存
            startPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            // マウスを離した座標をendPos変数に保存
            Vector2 endPos = Input.mousePosition;

            // マウスをクリックした位置から離した位置までの距離を計算して保存
            float swipeLength = endPos.x - startPos.x;

            // ドラッグした距離に比例してスピードを早くする
            speed = swipeLength / 500f;

            // 効果音の再生
            carSe.Play();

            // ゲームプレイフラグをONにする
            GameDirector04.isPlaying = true;
        }

        // Ｘ軸方向に、speedの値だけ移動させる
        transform.Translate(speed, 0, 0);

        // speedの変数の値を徐々に減らしていく
        speed *= 0.98f;
    }

}
