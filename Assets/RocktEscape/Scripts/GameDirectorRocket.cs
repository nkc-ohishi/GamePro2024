using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirectorRocket : MonoBehaviour
{
    public Image img;
    public Text kyoriLabel;
    public Text resultLabel;
    float kyori;

    public Image timeGauge;
    public static float lastTime;
    public static int playState;

    // Start is called before the first frame update
    void Start()
    {
        kyori     = 0;
        lastTime  = 100;
        playState = 0;

        img.fillAmount = 0;
        resultLabel.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (playState == 1)
        {
            resultLabel.text = "Game Over !!";
            // BGM止める
            GetComponent<AudioSource>().Stop();

            // 残り時間が０になった後、Enterキーが押されると、切り替え演出
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playState = 2;
            }
        }
        else if (playState == 2)
        {
            // 塗りつぶし係数を増やしてUI-Image画像を表示
            img.fillAmount += Time.deltaTime;

            // 画像が全部表示されたらスイッチOFFにしてシーンをリロード
            if (img.fillAmount >= 1f)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

        // playStateが１以上であれば以下の処理を行わない
        if (playState > 0) return;

        kyori += Time.deltaTime;
        kyoriLabel.text = kyori.ToString("000.00") + "km";

        // 制限時間を減らす処理
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 100f;

        // 制限時間が０より小さくなったら処理をUIの更新を止める
        if(lastTime < 0)
        {
            playState = 1;
        }

    }
}
