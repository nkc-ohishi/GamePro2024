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
