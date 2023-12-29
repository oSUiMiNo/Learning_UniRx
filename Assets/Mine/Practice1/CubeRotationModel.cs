
using UnityEngine;

namespace Ono.MVP.Model
{
    /// <summary>
    /// �r�W�l�X���W�b�N�������f���N���X
    /// �L���[�u����]������
    /// �L���[�u�ɃA�^�b�`
    /// </summary>
    public class CubeRotationModel : MonoBehaviour
    {
        /// <summary>
        /// �C���X�^���X
        /// </summary>
        public static CubeRotationModel Instance;

        private void Awake()
        {
            Instance = this;
        }

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