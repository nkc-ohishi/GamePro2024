//----------------------------------------------------------------------------
// �ȖځF�Q�[���v���O���~���O�P�N
// ���e�F�T�� ���K���
// �S���FKen.D.Ohishi 2024.05.30
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class chapter05Controller : MonoBehaviour
{
    Vector3 startPos;       // �������ɕ\�������ꏊ
    float speed = 5f;       // �ړ����x
    
    void Start()
    {
        // �������ꂽ�Ƃ��ɕ\�������ꏊ���w��
        startPos.x = -12f;
        startPos.y = Random.Range(-4.5f, 4.5f);
        startPos.z = 0;
        transform.position = startPos;

        // ���̃Q�[���I�u�W�F�N�g�͐�����10�b�ŏ��ł���
        Destroy(gameObject, 10);
    }

    void Update()
    {
        // ��ʉE�ɏ������獶����ēo�ꂳ����
        if(transform.position.x > 12f)
        {
            startPos.y = Random.Range(-4.5f, 4.5f);
            transform.position = startPos;            
        }
        // �ړ�
        transform.position += Vector3.right * speed * Time.deltaTime;
        // transform.Translate(Vector3.right * speed * Time.deltaTime); ��ɍs���Ă��܂�
    }
}
