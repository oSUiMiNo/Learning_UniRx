using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// View �� Model �� Presenter ���m��Ȃ��B


namespace MakuExample.MVP_Basic.View
{
    /// <summary>
    /// �K���ȃQ�[���I�u�W�F�N�g�ɃA�^�b�`
    /// �\���Ώۂ� Slider �� View ��S���B
    /// Slider �̒l�̕ύX���Ď����� View �̓��e���X�V����B
    /// </summary>
    public class EX_View : MonoBehaviour
    {
        /// <summary>
        /// Slider�̒l
        /// �w�ǋ@�\�̂݊O���Ɍ��J
        /// </summary>
        public IReadOnlyReactiveProperty<float> SliderValueRP => floatReactiveProperty;
        private readonly FloatReactiveProperty floatReactiveProperty = new FloatReactiveProperty();


        void Start()
        {
            Slider slider = GetComponent<Slider>();
            TextMeshProUGUI text = transform.Find("Text").GetComponent<TextMeshProUGUI>();


            // =======================================================================
            // �eSlider�̒l�̍X�V�C�x���g�Ƀ��A�N�e�B�u�v���p�e�B�̕ύX������o�^����
            // =======================================================================
            slider.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, floatReactiveProperty, text); })
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