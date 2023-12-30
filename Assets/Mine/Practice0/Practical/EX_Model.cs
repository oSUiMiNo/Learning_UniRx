using UnityEngine;
// Model �� View �� Presenter ���m��Ȃ�


namespace MakuExample.MVP_Practical.Model
{
    /// <summary>
    /// �L���[�u�ɃA�^�b�`����B
    /// �f�[�^�O������n�����f�[�^�ɂ���ăL���[�u����]�����郍�W�b�N�������f���N���X�B
    /// �L���[�u�� View �̂悤�Ɍ����邪�AView �� UI�̌����ڂł���X���C�_�[�B
    /// Model�̃f�[�^���X�V����Ă���̂�������₷���悤�ɃL���[�u�Ńr�W���A���C�Y���Ă��邾���ŁA
    /// �d�v�Ȃ͓̂�Model�N���X�̐��l�i�f�[�^�j�Ȃ̂����A�f�[�^��ۑ�����ϐ��������̂ōX�ɕ�����ɂ���
    /// �f�[�^�̓L���[�u Transform �̃v���p�e�B�Ɋi�[�����`�ɂȂ��Ă��邩��B
    /// �Ȃ̂Ō����ɂ͍���� Transform �� Model �ƌ����Ă����B
    /// </summary>
    public class EX_Model : MonoBehaviour
    {
        public static EX_Model Ins;
        void Awake() { Ins = this; }


        /// <summary>
        /// �^����ꂽ�p�����[�^�ɉ�����X�������ɃL���[�u����]
        /// </summary>
        /// <param name="x">X����]</param>
        public void SetRotationX(float x)
        {
            var rot = Quaternion.AngleAxis(x, Vector3.right);
            transform.rotation = rot;
        }

        /// <summary>
        /// �^����ꂽ�p�����[�^�ɉ�����Y�������ɃL���[�u����]
        /// </summary>
        /// <param name="y">X����]</param>
        public void SetRotationY(float y)
        {
            var rot = Quaternion.AngleAxis(y, Vector3.up);
            transform.rotation = rot;
        }

        /// <summary>
        /// �^����ꂽ�p�����[�^�ɉ�����Z�������ɃL���[�u����]
        /// </summary>
        /// <param name="z">Z����]</param>
        public void SetRotationZ(float z)
        {
            var rot = Quaternion.AngleAxis(z, Vector3.forward);
            transform.rotation = rot;
        }
    }
}