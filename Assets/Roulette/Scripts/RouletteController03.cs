//-------------------------------------------------------------------------------
// 内容　　　：ルーレットコントローラーを作ってみた
// ファイル名：RouletteController.cs
// 概要　　　：左クリックで回転をスタート、ストップさせる
//-------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

public class RouletteController03 : MonoBehaviour
{
    public Text judge;      // UnityエディタでText(Legacy)オブジェクトをセットする
    float rotSpeed = 0;     // 現在の回転速度
    float speed    = 10;    // 回転速度を保存する変数
    bool sw = false;        // 回転スイッチ
    int a;

    // シーンが再生されたとき、1回だけ実行されるメソッド
    void Start()
    {
        // Applicationクラスは、ゲームアプリ全体のパラメータ設定を行う
        // １秒間に60回Updateメソッドを実行する設定
        Application.targetFrameRate = 60;

        speed = 10;        // 初速度
    }

    // シーンが再生されている間繰り返して実行されるメソッド
    void Update()
    {
        // 左マウスが押されたら回転速度を設定する
        if(Input.GetMouseButtonDown(0))
        {
            // 左マウスがクリックされる毎にON　OFFを繰り返す
            if(sw == true)
            {
                sw = false;
            }
            else
            {
                sw = true;
            }
        }

        // スイッチがONの時回転加速、OFFで停止
        if(sw == true)
        {
            rotSpeed = speed;
            speed += 0.02f;
            speed = Mathf.Min(speed, 60f); // 回転速度の上限60度
        }
        else
        {
            rotSpeed = 0;
            speed = 10;
        }

        // Updateが1回実行あたり、rotSpeedだけZ軸回転させる
        // 左クリックされる前　０　左クリックされた後　１０(0.02ずつ増える)
        transform.Rotate(0, 0, rotSpeed);

        // Rouletteの回転角度によってText表示を変える
        float z = transform.localEulerAngles.z;
        if(z < 30f)
        {
            judge.text = "凶";       // 30度未満
        }
        else if(z < 90)
        {
            judge.text = "大吉";     // 30度以上 90度未満
        }
        else if (z < 150)
        {
            judge.text = "大凶";     // 90度以上 150度未満
        }
        else if (z < 210)
        {
            judge.text = "小吉";     // 150度以上 210度未満
        }
        else if (z < 270)
        {
            judge.text = "末吉";     // 210度以上 270度未満      
        }
        else if (z < 330)
        {
            judge.text = "中吉";     // 270度以上 330度未満
        }
        else
        {
            judge.text = "凶";       // 330度以上 360度未満
        }

        // エスケイプキーで終了
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
