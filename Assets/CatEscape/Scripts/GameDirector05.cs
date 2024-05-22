using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector05 : MonoBehaviour
{
    Image hpGauge;

    // Start is called before the first frame update
    void Start()
    {
        hpGauge = GameObject.Find("hpGauge").GetComponent<Image>();
    }

    public void DecreaseHp()
    {
        hpGauge.fillAmount -= 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
