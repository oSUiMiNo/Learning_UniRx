using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Ono.MVP.View
{
    /// <summary>
    /// Slider��View��S���N���X
    /// </summary>
    public class SliderView : MonoBehaviour
    {
        [SerializeField] private Slider _sliderX, _sliderY, _sliderZ;
        [SerializeField] private TextMeshProUGUI _textX, _textY, _textZ;

        /// <summary>
        /// X�������Slider
        /// �w�ǋ@�\�̂݊O���Ɍ��J
        /// </summary>
        public IReadOnlyReactiveProperty<float> SliderValueRP_X => _floatReactivePropertyX;
        private readonly FloatReactiveProperty _floatReactivePropertyX = new FloatReactiveProperty();

        /// <summary>
        /// Y�������Slider
        /// �w�ǋ@�\�̂݊O���Ɍ��J
        /// </summary>
        public IReadOnlyReactiveProperty<float> SliderValueRP_Y => _floatReactivePropertyY;
        private readonly FloatReactiveProperty _floatReactivePropertyY = new FloatReactiveProperty();

        /// <summary>
        /// Z�������Slider
        /// �w�ǋ@�\�̂݊O���Ɍ��J
        /// </summary>
        public IReadOnlyReactiveProperty<float> SliderValueRP_Z => _floatReactivePropertyZ;
        private readonly FloatReactiveProperty _floatReactivePropertyZ = new FloatReactiveProperty();

        void Start()
        {
            //X������pSlider�̒l�̕ύX���Ď�
            _sliderX.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyX, _textX); })
                .AddTo(this);

            //Y������pSlider�̒l�̕ύX���Ď�
            _sliderY.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyY, _textY); })
                .AddTo(this);

            //Z������pSlider�̒l�̕ύX���Ď�
            _sliderZ.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyZ, _textZ); })
                .AddTo(this);
        }

        /// <summary>
        /// Slider�̒l�ύX���̏���
        /// </summary>
        /// <param name="value">Slider�̒l</param>
        /// <param name="floatReactiveProperty">�l���X�V��������RP</param>
        /// <param name="valueText">�X�V����e�L�X�g</param>
        private void OnValueChange(float value, FloatReactiveProperty floatReactiveProperty, TextMeshProUGUI valueText)
        {
            //�l�̐��`
            var arrangeValue = Mathf.Floor((value - 0.5f) * 100) / 100 * 360;
            //�l�̍X�V
            floatReactiveProperty.Value = arrangeValue;
            //�e�L�X�g�ɒl�𔽉f
            valueText.text = arrangeValue.ToString();
        }
    }
}