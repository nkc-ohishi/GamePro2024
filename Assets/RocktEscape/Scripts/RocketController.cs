using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    float speed = 10;            // 移動速度を保存する変数
    Vector3 dir = Vector3.zero; // 移動方向を保存する変数

    Vector2 lb;         // 画面左下のワールド座標を保存
    Vector2 ru;         // 画面右上のワールド座標を保存
    Vector2 screenSize; // 画面の幅と高さを保存

    void Start()
    {
        // 画面の幅と高さ
        screenSize = new Vector2(Screen.width, Screen.height);
        // 画面の左下のワールド座標
        lb = Camera.main.ScreenToWorldPoint(Vector2.zero);
        // 画面右上のワールド座標
        ru = Camera.main.ScreenToWorldPoint(screenSize);
    }

    void Update()
    {
        if (GameDirectorRocket.playState > 0) return;

        // 上下左右移動
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;

        // 移動制限
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, lb.x, ru.x);
        pos.y = Mathf.Clamp(pos.y, lb.y, ru.y);
        transform.position = pos;
    }
}
