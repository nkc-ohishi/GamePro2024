using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController05 : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(3, 0, 0);
        }
    }

    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);
    }

    public void RButtonDown()
    {
        transform.Translate(3, 0, 0);
    }
}
