//----------------------------------------------------------------------------
// 科目：ゲームプログラミング１年
// 内容：４章 SwipeCar GameDirectorスクリプト
// 担当：Ken.D.Ohishi 2024.05.10
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//----------------------------------------------------------------------------
// クラス名：GameDirectorクラス
// 機能　　：ゲームシーン共通の処理
//----------------------------------------------------------------------------
public class GameDirector04 : MonoBehaviour
{
    // クラスのメンバ変数
    GameObject car;
    GameObject flag;
    GameObject distance;
    GameObject result;

    public static bool isPlaying;

    public AudioSource maruAudioSource;
    public AudioSource batuAudioSource;
    bool resultSeflg;

    //------------------------------------------------------------------------
    // メソッド名：Startメソッド
    //------------------------------------------------------------------------
    void Start()
    {
        // ヒエラルキーウィンドウの中から同じ名前のオブジェクトを見つけて
        // 変数に保存する。引数はゲームオブジェクトの名前と完全一致しないと
        // 見つけることができない
        car      = GameObject.Find("car_0");
        flag     = GameObject.Find("flag_0");
        distance = GameObject.Find("distance");
        result   = GameObject.Find("result");

        // ゲーム中かどうかのスイッチ
        isPlaying = false;

        // 判定効果音の再生フラグ
        resultSeflg = true;
    }

    //------------------------------------------------------------------------
    // メソッド名：Updateメソッド
    //------------------------------------------------------------------------
    void Update()
    {
        // 車と旗の距離(length) = 旗のｘ座標 - 車のｘ座標
        float width = 1.63f;
        float length = flag.transform.position.x - car.transform.position.x - width;

        // TextMeshProUGUIコンポーネントの情報をtextMeshPro変数に保存
        TextMeshProUGUI textMeshPro = distance.GetComponent<TextMeshProUGUI>();

        // Textコンポーネントの情報をtext変数に保存
        Text text = result.GetComponent<Text>();

        if (length >= 0)
        {
            // 車と旗の距離が０以上（車が旗の右にいる）の時の処理
            // TextMeshProUGUIコンポーネントのtextの文字を更新する
            textMeshPro.text = "Distance:" + length.ToString("F2") + "m";

        }
        else
        {
            // 車と旗の距離が０未満（車が旗の左にいる）の時の処理
            textMeshPro.text = "GameOver";
            text.text = "失敗！！";
            if (resultSeflg)
            {
                batuAudioSource.Play();
                resultSeflg = false;
            }
        }

        // プレイフラグがONかつ 車のスピードが0.01未満（ほぼ停止）
        if (isPlaying && CarController04.speed < 0.0001f)
        {
            if (length >= 0 && length < 0.5f)
            {
                text.text = "成功！！";
                if (resultSeflg)
                {
                    maruAudioSource.Play();
                    resultSeflg = false;
                }
            }
            else
            {
                text.text = "失敗！！";
                if (resultSeflg)
                {
                    batuAudioSource.Play();
                    resultSeflg = false;
                }
            }
        }

        // Enterキーでシーンを再読み込み
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }



    }
}
