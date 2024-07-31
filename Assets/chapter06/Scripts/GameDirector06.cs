using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector06 : MonoBehaviour
{
    public static float timeCount;  // �o�ߎ���
    public Text timeLabel;          // �o�ߎ��ԕ\���p   

    public static int coinCnt;      // �R�C���擾��
    public Text coinCntLabel;       // �R�C���擾���\��

    public static int gameState;    // �Q�[���̏��
    public Image backImg;           // �N���A���̔w�i
    public Text resultLabel;        // �N���A�\��

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
        // �G���^�[�L�[�Ń����[�h
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

        // �o�ߎ��ԍX�V����
        timeCount += Time.deltaTime;
        timeLabel.text = "Time�F" + timeCount.ToString("000.00");

        // �R�C���擾���\��
        coinCntLabel.text = "Coin�F" + coinCnt.ToString("D2") + " / 10";

    }
}
