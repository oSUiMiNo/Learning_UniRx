using UniRx;
using UnityEngine;

//Presenter �� Model �� View ��m���Ă���
using MakuExample.MVP_Basic.Model;
using MakuExample.MVP_Basic.View;


namespace MakuExample.MVP_Basic.Presenter
{
    /// <summary>
    /// �K���ȃQ�[���I�u�W�F�N�g�ɃA�^�b�`����B
    /// Model �� View ���q�� Presenter
    /// View �̍X�V���Ď����āAModel �̃f�[�^���X�V����B
    /// </summary>
    public class EX_Presenter : MonoBehaviour
    {
        void Start()
        {
            EX_View _VIEW_X = GameObject.Find("Slider_X").GetComponent<EX_View>();
            EX_View _VIEW_Y = GameObject.Find("Slider_Y").GetComponent<EX_View>();
            EX_View _VIEW_Z = GameObject.Find("Slider_Z").GetComponent<EX_View>();
            EX_Model _MODEL_ = EX_Model.Ins;

            // ===============================================================================
            // View ���A�N�e�B�u�v���p�e�B�X�V�C�x���g�ɁAModel �̃f�[�^���X�V������o�^����
            // ===============================================================================
            _VIEW_X.SliderValueRP
                .Subscribe(value => { _MODEL_.rotation = Vector3.right * value; }).AddTo(this);

            _VIEW_Y.SliderValueRP
                .Subscribe(value => { _MODEL_.rotation = Vector3.up * value; }).AddTo(this);

            _VIEW_Z.SliderValueRP
                .Subscribe(value => { _MODEL_.rotation = Vector3.forward * value ; }).AddTo(this);
        }
    }
}