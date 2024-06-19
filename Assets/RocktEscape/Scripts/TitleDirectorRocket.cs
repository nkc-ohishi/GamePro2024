//----------------------------------------------------------------------------
// 科目：ゲームプログラミング１年
// 内容：課題 RocketEscape 解答例
// 担当：Ken.D.Ohishi 2024.06.17
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleDirectorRocket : MonoBehaviour
{
    public Image img;
    bool sw = false;

    void Start()
    {
        img.fillAmount = 0;
        sw = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            sw = true;
        }

        if(sw)
        {
            img.fillAmount += Time.deltaTime;
            if (img.fillAmount >= 1f)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
