using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    public AudioClip se;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        // �J�����I�u�W�F�N�g�̃g�����X�t�H�[���R���|�[�l���g���擾
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;            // �ړ����x��ۑ�����ϐ�
        Vector3 dir = Vector3.left;  // �ړ�������ۑ�����ϐ�

        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    // �����蔻�菈��
    void OnTriggerEnter2D(Collider2D other)
    {
        // �������Ԃ��P�O�b���炷
        GameDirectorRocket.lastTime -= 10;

        // ���ʉ���炷�i�I�[�f�B�I���X�i�[���J�����̈ʒu�ōĐ��j
        AudioSource.PlayClipAtPoint(se, cam.position);

        // 覐΂ɉ����̃I�u�W�F�N�g���d�Ȃ�����A覐΂��폜
        Destroy(gameObject);
    }

}