//----------------------------------------------------------------------------
// 科目：ゲームプログラミング１年
// 内容：５章 練習問題
// 担当：Ken.D.Ohishi 2024.05.30
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chapter05Generator : MonoBehaviour
{
    public GameObject prefab;   // プレハブをUnityでセット
    public Image img;           // UI-Legacy-ImageオブジェクトをUnityでセット
    bool sw;                    // スイッチ

    void Start()
    {
        sw = false;             // スイッチOFF
        img.fillAmount = 0f;    // 塗りつぶし係数０（非表示）
    }

    void Update()
    {
        // 左クリックされたらゲームオブジェクトを生成
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab);
        }

        // エンターキーでスイッチON
        if(Input.GetKeyDown(KeyCode.Return))
        {
            sw = true;
        }

        // スイッチONの時
        if(sw)
        {
            // 塗りつぶし係数を増やしてUI-Image画像を表示
            img.fillAmount += Time.deltaTime;

            // 画像が全部表示されたらスイッチOFFにしてシーンをリロード
            if(img.fillAmount >= 1f)
            {
                sw = false;
                SceneManager.LoadScene(0);
            }
        }
    }
}
