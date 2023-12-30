using UniRx;
using UnityEngine;

// Presenter �� Model �� View ��m���Ă���
using MakuExample.MVP_Practical.Model;
using MakuExample.MVP_Practical.View;


namespace MakuExample.MVP_Basic.Presenter_Practical
{
    /// <summary>
    /// �K���ȃQ�[���I�u�W�F�N�g�ɃA�^�b�`�B
    /// Model �� View ���q�� Presenter
    /// View �̍X�V���Ď����āAModel �̃f�[�^���X�V����B
    /// </summary>
    public class EX_Presenter : MonoBehaviour
    {
        void Start()
        {
            EX_View _VIEW_ = EX_View.Ins;
            EX_Model _MODEL_ = EX_Model.Ins;

            // ===============================================================================
            // View ���A�N�e�B�u�v���p�e�B�X�V�C�x���g�ɁAModel �̃f�[�^���X�V������o�^����
            // ===============================================================================
            _VIEW_.SliderValueRP_X
                .Subscribe(value => { _MODEL_.SetRotationX(value); }).AddTo(this);

            _VIEW_.SliderValueRP_Y
                .Subscribe(value => { _MODEL_.SetRotationY(value); }).AddTo(this);

            _VIEW_.SliderValueRP_Z
                .Subscribe(value => { _MODEL_.SetRotationZ(value); }).AddTo(this);
        }
    }
}