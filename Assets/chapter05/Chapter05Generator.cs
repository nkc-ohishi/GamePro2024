//----------------------------------------------------------------------------
// �ȖځF�Q�[���v���O���~���O�P�N
// ���e�F�T�� ���K���
// �S���FKen.D.Ohishi 2024.05.30
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chapter05Generator : MonoBehaviour
{
    public GameObject prefab;   // �v���n�u��Unity�ŃZ�b�g
    public Image img;           // UI-Legacy-Image�I�u�W�F�N�g��Unity�ŃZ�b�g
    bool sw;                    // �X�C�b�`

    void Start()
    {
        sw = false;             // �X�C�b�`OFF
        img.fillAmount = 0f;    // �h��Ԃ��W���O�i��\���j
    }

    void Update()
    {
        // ���N���b�N���ꂽ��Q�[���I�u�W�F�N�g�𐶐�
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab);
        }

        // �G���^�[�L�[�ŃX�C�b�`ON
        if(Input.GetKeyDown(KeyCode.Return))
        {
            sw = true;
        }

        // �X�C�b�`ON�̎�
        if(sw)
        {
            // �h��Ԃ��W���𑝂₵��UI-Image�摜��\��
            img.fillAmount += Time.deltaTime;

            // �摜���S���\�����ꂽ��X�C�b�`OFF�ɂ��ăV�[���������[�h
            if(img.fillAmount >= 1f)
            {
                sw = false;
                SceneManager.LoadScene(0);
            }
        }
    }
}
