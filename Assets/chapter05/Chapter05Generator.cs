using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chapter05Generator : MonoBehaviour
{
    public GameObject prefab;
    public Image img;
    bool sw;

    void Start()
    {
        sw = false;
        img.fillAmount = 0f;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            sw = true;
        }

        if(sw)
        {
            img.fillAmount += Time.deltaTime;
            if(img.fillAmount >= 1f)
            {
                sw = false;
                SceneManager.LoadScene(0);
            }
        }


    }
}
