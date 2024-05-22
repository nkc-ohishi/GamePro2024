using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirectorRocket : MonoBehaviour
{
    public Text kyoriLabel;
    float kyori;

    public Image timeGauge;
    public static float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        kyori = 0;
        lastTime = 100;
    }

    // Update is called once per frame
    void Update()
    {
        kyori += Time.deltaTime;
        int k = (int)kyori;
        kyoriLabel.text = k.ToString("D6") + "km";

        // �������Ԃ����炷����
        lastTime -= Time.deltaTime;
        timeGauge.fillAmount = lastTime / 100f;

        // �������Ԃ��O��菬�����Ȃ����烊�X�^�[�g
        if(lastTime < 0)
        {
            SceneManager.LoadScene(0);
        }

    }
}
