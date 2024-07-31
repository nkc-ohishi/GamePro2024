using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector06 : MonoBehaviour
{
    public static float timeCount;  // 経過時間
    public Text timeLabel;          // 経過時間表示用   

    public static int coinCnt;      // コイン取得数
    public Text coinCntLabel;       // コイン取得数表示

    public static int gameState;    // ゲームの状態
    public Image backImg;           // クリア時の背景
    public Text resultLabel;        // クリア表示

    public AudioSource normalBgm;
    public AudioSource gameOverBgm;
    public AudioSource gameClearBgm;
    int bgmChange;

    void Start()
    {
        timeCount = 0;
        coinCnt = 0;
        gameState = 0;
        resultLabel.text = "";
        backImg.gameObject.SetActive(false);

        bgmChange = 0;
        normalBgm.Play();
    }

    void Update()
    {
        // エンターキーでリロード
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (gameState == 1)
            {
                SceneManager.LoadScene(0);
            }
            else if(gameState == 2)
            {
                SceneManager.LoadScene(1);
            }
        }

        if (gameState == 1)
        {
            backImg.gameObject.SetActive(true);
            resultLabel.text = "Congratulations !!\nClear Time\n" + timeCount.ToString("000.00") + " sec";
            if (bgmChange++ == 0)
            {
                normalBgm.Stop();
                gameClearBgm.Play();
            }
        }
        else if (gameState == 2)
        {
            if(bgmChange++ == 0)
            {
                normalBgm.Stop();
                gameOverBgm.Play();
            }

            backImg.gameObject.SetActive(true);
            resultLabel.text = "GameOver !!\nPush Enter Retry";
        }

        if (gameState >= 1) return;

        // 経過時間更新処理
        timeCount += Time.deltaTime;
        timeLabel.text = "Time：" + timeCount.ToString("000.00");

        // コイン取得数表示
        coinCntLabel.text = "Coin：" + coinCnt.ToString("D2") + " / 10";

    }
}
