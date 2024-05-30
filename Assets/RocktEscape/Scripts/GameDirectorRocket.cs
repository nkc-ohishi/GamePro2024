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
            // BGM�~�߂�
            GetComponent<AudioSource>().Stop();

            // �c�莞�Ԃ��O�ɂȂ�����AEnter�L�[���������ƁA�؂�ւ����o
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playState = 2;
            }
        }
        else if (playState == 2)
        {
            // �h��Ԃ��W���𑝂₵��UI-Image�摜��\��
            img.fillAmount += Time.deltaTime;

            // �摜���S���\�����ꂽ��X�C�b�`OFF�ɂ��ăV�[���������[�h
            if (img.fillAmount >= 1f)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

        // playState���P�ȏ�ł���Έȉ��̏������s��Ȃ�
        if (playState > 0) return;

        kyori += Time.deltaTime;
        kyoriLabel.text = kyori.ToString("000.00") + "km";

        // �������Ԃ����炷����
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 100f;

        // �������Ԃ��O��菬�����Ȃ����珈����UI�̍X�V���~�߂�
        if(lastTime < 0)
        {
            playState = 1;
        }

    }
}
