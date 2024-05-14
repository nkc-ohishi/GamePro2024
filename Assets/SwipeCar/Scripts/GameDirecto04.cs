//----------------------------------------------------------------------------
// �ȖځF�Q�[���v���O���~���O�P�N
// ���e�F�S�� SwipeCar GameDirector�X�N���v�g
// �S���FKen.D.Ohishi 2024.05.10
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//----------------------------------------------------------------------------
// �N���X���FGameDirector�N���X
// �@�\�@�@�F�Q�[���V�[�����ʂ̏���
//----------------------------------------------------------------------------
public class GameDirector04 : MonoBehaviour
{
    // �N���X�̃����o�ϐ�
    GameObject car;
    GameObject flag;
    GameObject distance;
    GameObject result;

    public static bool isPlaying;

    public AudioSource maruAudioSource;
    public AudioSource batuAudioSource;
    bool resultSeflg;

    //------------------------------------------------------------------------
    // ���\�b�h���FStart���\�b�h
    //------------------------------------------------------------------------
    void Start()
    {
        // �q�G�����L�[�E�B���h�E�̒����瓯�����O�̃I�u�W�F�N�g��������
        // �ϐ��ɕۑ�����B�����̓Q�[���I�u�W�F�N�g�̖��O�Ɗ��S��v���Ȃ���
        // �����邱�Ƃ��ł��Ȃ�
        car      = GameObject.Find("car_0");
        flag     = GameObject.Find("flag_0");
        distance = GameObject.Find("distance");
        result   = GameObject.Find("result");

        // �Q�[�������ǂ����̃X�C�b�`
        isPlaying = false;

        // ������ʉ��̍Đ��t���O
        resultSeflg = true;
    }

    //------------------------------------------------------------------------
    // ���\�b�h���FUpdate���\�b�h
    //------------------------------------------------------------------------
    void Update()
    {
        // �ԂƊ��̋���(length) = ���̂����W - �Ԃ̂����W
        float width = 1.63f;
        float length = flag.transform.position.x - car.transform.position.x - width;

        // TextMeshProUGUI�R���|�[�l���g�̏���textMeshPro�ϐ��ɕۑ�
        TextMeshProUGUI textMeshPro = distance.GetComponent<TextMeshProUGUI>();

        // Text�R���|�[�l���g�̏���text�ϐ��ɕۑ�
        Text text = result.GetComponent<Text>();

        if (length >= 0)
        {
            // �ԂƊ��̋������O�ȏ�i�Ԃ����̉E�ɂ���j�̎��̏���
            // TextMeshProUGUI�R���|�[�l���g��text�̕������X�V����
            textMeshPro.text = "Distance:" + length.ToString("F2") + "m";

        }
        else
        {
            // �ԂƊ��̋������O�����i�Ԃ����̍��ɂ���j�̎��̏���
            textMeshPro.text = "GameOver";
            text.text = "���s�I�I";
            if (resultSeflg)
            {
                batuAudioSource.Play();
                resultSeflg = false;
            }
        }

        // �v���C�t���O��ON���� �Ԃ̃X�s�[�h��0.01�����i�قڒ�~�j
        if (isPlaying && CarController04.speed < 0.0001f)
        {
            if (length >= 0 && length < 0.5f)
            {
                text.text = "�����I�I";
                if (resultSeflg)
                {
                    maruAudioSource.Play();
                    resultSeflg = false;
                }
            }
            else
            {
                text.text = "���s�I�I";
                if (resultSeflg)
                {
                    batuAudioSource.Play();
                    resultSeflg = false;
                }
            }
        }

        // Enter�L�[�ŃV�[�����ēǂݍ���
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }



    }
}
