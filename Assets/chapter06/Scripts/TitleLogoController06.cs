using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleLogoController06 : MonoBehaviour
{
    const float START_SPEED = 3f;   // �ʏ푬�x
    const float SPEEDUP_TIME = 4f;  // �X�s�[�h�A�b�v����

    Image image;                    // �I�u�W�F�N�g�ۑ��p
    float speed;                    // �t�F�[�h���x
    float time;                     // ���Ԍv���p�ϐ�
    bool speedUpFlg;                // �X�s�[�h�A�b�v�t���O

    void Start()
    {
        image = gameObject.GetComponent<Image>();   //�@Text�R���|�[�l���g���擾
        speed = START_SPEED;                        // �X�s�[�h�̏����l�ݒ�
        speedUpFlg = false;                         // �X�s�[�h�A�b�v�t���OOFF
    }

    void Update()
    {
        //�I�u�W�F�N�g��Alpha�l���X�V
        image.color = GetAlphaColor(image.color);

        // �G���^�[�L�[�������ꂽ��̓t�F�[�h���x�𑁂�����
        if (Input.GetKeyDown(KeyCode.Return))
        {
            speedUpFlg = true;
            speed *= 5f;
            time = 0f;
        }

        // �G���^�[�L�[��������Ă���SPEEDUP_TIME�b��������V�[���J��
        if (speedUpFlg && (time / speed) >= SPEEDUP_TIME)
        {
            SceneManager.LoadScene(1);
        }
    }

    //Alpha�l���X�V����Color��Ԃ�
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * speed;
        // �A���t�@�l�� 0.0�`1.0�͈̔͂ŏz������
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

}