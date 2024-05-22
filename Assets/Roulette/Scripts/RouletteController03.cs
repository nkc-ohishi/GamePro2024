//-------------------------------------------------------------------------------
// ���e�@�@�@�F���[���b�g�R���g���[���[������Ă݂�
// �t�@�C�����FRouletteController.cs
// �T�v�@�@�@�F���N���b�N�ŉ�]���X�^�[�g�A�X�g�b�v������
//-------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

public class RouletteController03 : MonoBehaviour
{
    public Text judge;      // Unity�G�f�B�^��Text(Legacy)�I�u�W�F�N�g���Z�b�g����
    float rotSpeed = 0;     // ���݂̉�]���x
    float speed    = 10;    // ��]���x��ۑ�����ϐ�
    bool sw = false;        // ��]�X�C�b�`
    int a;

    // �V�[�����Đ����ꂽ�Ƃ��A1�񂾂����s����郁�\�b�h
    void Start()
    {
        // Application�N���X�́A�Q�[���A�v���S�̂̃p�����[�^�ݒ���s��
        // �P�b�Ԃ�60��Update���\�b�h�����s����ݒ�
        Application.targetFrameRate = 60;

        speed = 10;        // �����x
    }

    // �V�[�����Đ�����Ă���ԌJ��Ԃ��Ď��s����郁�\�b�h
    void Update()
    {
        // ���}�E�X�������ꂽ���]���x��ݒ肷��
        if(Input.GetMouseButtonDown(0))
        {
            // ���}�E�X���N���b�N����閈��ON�@OFF���J��Ԃ�
            if(sw == true)
            {
                sw = false;
            }
            else
            {
                sw = true;
            }
        }

        // �X�C�b�`��ON�̎���]�����AOFF�Œ�~
        if(sw == true)
        {
            rotSpeed = speed;
            speed += 0.02f;
            speed = Mathf.Min(speed, 60f); // ��]���x�̏��60�x
        }
        else
        {
            rotSpeed = 0;
            speed = 10;
        }

        // Update��1����s������ArotSpeed����Z����]������
        // ���N���b�N�����O�@�O�@���N���b�N���ꂽ��@�P�O(0.02��������)
        transform.Rotate(0, 0, rotSpeed);

        // Roulette�̉�]�p�x�ɂ����Text�\����ς���
        float z = transform.localEulerAngles.z;
        if(z < 30f)
        {
            judge.text = "��";       // 30�x����
        }
        else if(z < 90)
        {
            judge.text = "��g";     // 30�x�ȏ� 90�x����
        }
        else if (z < 150)
        {
            judge.text = "�勥";     // 90�x�ȏ� 150�x����
        }
        else if (z < 210)
        {
            judge.text = "���g";     // 150�x�ȏ� 210�x����
        }
        else if (z < 270)
        {
            judge.text = "���g";     // 210�x�ȏ� 270�x����      
        }
        else if (z < 330)
        {
            judge.text = "���g";     // 270�x�ȏ� 330�x����
        }
        else
        {
            judge.text = "��";       // 330�x�ȏ� 360�x����
        }

        // �G�X�P�C�v�L�[�ŏI��
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
