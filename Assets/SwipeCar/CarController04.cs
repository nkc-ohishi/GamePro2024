//----------------------------------------------------------------------------
// �ȖځF�Q�[���v���O���~���O�P�N
// ���e�F�S�� SwipeCar CarController�X�N���v�g
// �S���FKen.D.Ohishi 2024.05.10
//----------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------------------------------------
// �N���X���FCarController�N���X
// �@�\�@�@�F�ԃI�u�W�F�N�g�̐�����s��
//----------------------------------------------------------------------------
public class CarController04 : MonoBehaviour
{
    // �N���X�̃����o�ϐ��i�N���X���ɒ�`���ꂽ���\�b�h���ׂĂŗ��p�ł���ϐ��j
    float speed = 0;    
    Vector2 startPos;
    AudioSource carSe;

    //------------------------------------------------------------------------
    // ���\�b�h���FStart���\�b�h
    // ����@�@�@�F�V�[�����Đ����ꂽ�Ƃ��ɂP�x���������Ŏ��s����郁�\�b�h
    // �p�r�@�@�@�F�ϐ��̏����l���Z�b�g����̂Ɏg����
    //------------------------------------------------------------------------
    void Start()
    {
        // Update���\�b�h��1�b�Ԃ�60����s������w��
        Application.targetFrameRate = 60;

        // AudioSource�R���|�[�l���g�̏���carSe�ϐ��ɕۑ�
        carSe = GetComponent<AudioSource>();
    }

    //------------------------------------------------------------------------
    // ���\�b�h���FUpdate���\�b�h
    // ����@�@�@�F�V�[�����Đ�����Ă���ԁA�J��Ԃ������Ŏ��s����郁�\�b�h
    // �p�r�@�@�@�F�Q�[���I�u�W�F�N�g�̃p�����[�^���X�V����̂Ɏg����
    //------------------------------------------------------------------------
    void Update()
    {
        // �}�E�X�̍��{�^�����P�񉟂��ꂽ�Ƃ��̏���
        if(Input.GetMouseButtonDown(0))
        {
            // speed = 0.2f;

            // �}�E�X���N���b�N�������W��startPos�ϐ��ɕۑ�
            startPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            // �}�E�X�𗣂������W��endPos�ϐ��ɕۑ�
            Vector2 endPos = Input.mousePosition;

            // �}�E�X���N���b�N�����ʒu���痣�����ʒu�܂ł̋������v�Z���ĕۑ�
            float swipeLength = endPos.x - startPos.x;

            // �h���b�O���������ɔ�Ⴕ�ăX�s�[�h�𑁂�����
            speed = swipeLength / 500f;

            // ���ʉ��̍Đ�
            carSe.Play();

            // �Q�[���v���C�t���O��ON�ɂ���
            GameDirector04.isPlaying = true;
        }

        // �w�������ɁAspeed�̒l�����ړ�������
        transform.Translate(speed, 0, 0);

        // speed�̕ϐ��̒l�����X�Ɍ��炵�Ă���
        speed *= 0.98f;
    }

}
