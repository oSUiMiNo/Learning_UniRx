using Ono.MVP.Model;
using Ono.MVP.View;
using UniRx;
using UnityEngine;

namespace Ono.MVP.Presenter
{
    /// <summary>
    /// View��Model���q��Presenter
    /// </summary>
    public class CubeRotationPresenter : MonoBehaviour
    {
        [SerializeField] private SliderView _sliderView;

        void Start()
        {
            var cubeRotationLogic = CubeRotationModel.Instance;

            // ================================
            // Slider�̒l�̍X�V���Ď�
            // ================================

            _sliderView.SliderValueRP_X
                .Subscribe(value => { cubeRotationLogic.SetRotationX(value); }).AddTo(this);

            _sliderView.SliderValueRP_Y
                .Subscribe(value => { cubeRotationLogic.SetRotationY(value); }).AddTo(this);

            _sliderView.SliderValueRP_Z
                .Subscribe(value => { cubeRotationLogic.SetRotationZ(value); }).AddTo(this);
        }
    }
}