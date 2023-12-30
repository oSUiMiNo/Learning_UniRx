using UnityEngine;
// Model �� View �� Presenter ���m��Ȃ�


namespace MakuExample.MVP_Basic.Model
{
    /// <summary>
    /// �L���[�u�ɃA�^�b�`����B
    /// �O������n�����( V �� P �� M )�f�[�^�ɂ���ăL���[�u����]�����郍�W�b�N������ Model�N���X�B
    /// �L���[�u�� View �̂悤�Ɍ����邪�AView �� UI�̌����ڂł���X���C�_�[�B
    /// Model�̃f�[�^���X�V����Ă���̂�������₷���悤�ɃL���[�u�Ńr�W���A���C�Y���Ă��邾���B
    /// </summary>
    public class EX_Model : MonoBehaviour
    {
        public static EX_Model Ins;
        private void Awake() { Ins = this; }


        // ===========================================================================
        // ������ Model �̃f�[�^�{�́BPresenter �ɂ���� View �ɍ��킹�čX�V�����
        // ===========================================================================
        public Vector3 rotation;


        // �r�W���A���C�Y
        void Update() { transform.rotation = Quaternion.Euler(rotation); }
    }
}