using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoGenerator : MonoBehaviour
{
    public GameObject meteoPre; // 覐΂̃v���n�u��ۑ�����ϐ�
    float span = 1;             // 覐΂��o���Ԋu�i�b�j
    float delta = 0;            // ���Ԍv�Z�p�ϐ�

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameDirectorRocket.playState > 0) return;

        delta += Time.deltaTime;

        // span�b���ɏ������s��
        if(delta > span)
        {
            delta = 0; // ���Ԍv�Z�p�ϐ����O�ɂ���

            // 覐΂̃v���n�u���q�G�����L�[�ɓo�ꂳ����
            GameObject go = Instantiate(meteoPre);
            int py = Random.Range(-6, 7);
            go.transform.position = new Vector3(10, py, 0);
        }

        
    }
}
