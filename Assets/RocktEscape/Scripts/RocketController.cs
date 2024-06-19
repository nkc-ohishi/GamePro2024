using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    float speed = 10;            // �ړ����x��ۑ�����ϐ�
    Vector3 dir = Vector3.zero; // �ړ�������ۑ�����ϐ�

    Vector2 lb;         // ��ʍ����̃��[���h���W��ۑ�
    Vector2 ru;         // ��ʉE��̃��[���h���W��ۑ�
    Vector2 screenSize; // ��ʂ̕��ƍ�����ۑ�

    void Start()
    {
        // ��ʂ̕��ƍ���
        screenSize = new Vector2(Screen.width, Screen.height);
        // ��ʂ̍����̃��[���h���W
        lb = Camera.main.ScreenToWorldPoint(Vector2.zero);
        // ��ʉE��̃��[���h���W
        ru = Camera.main.ScreenToWorldPoint(screenSize);
    }

    void Update()
    {
        if (GameDirectorRocket.playState > 0) return;

        // �㉺���E�ړ�
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");

        transform.position += dir.normalized * speed * Time.deltaTime;

        // �ړ�����
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, lb.x, ru.x);
        pos.y = Mathf.Clamp(pos.y, lb.y, ru.y);
        transform.position = pos;
    }
}
