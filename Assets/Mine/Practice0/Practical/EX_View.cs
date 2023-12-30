using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// View �� Model �� Presenter ���m��Ȃ�


namespace MakuExample.MVP_Practical.View
{
    /// <summary>
    /// �K���ȃQ�[���I�u�W�F�N�g�ɃA�^�b�`
    /// �\���Ώۂ� Slider �� View ��S���B
    /// Slider �̒l�̕ύX���Ď����� View �̓��e���X�V����B
    /// </summary>
    public class EX_View : MonoBehaviour
    {
        public static EX_View Ins;
        void Awake() { Ins = this; }

        
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
            Slider sliderX = GameObject.Find("Slider_X").GetComponent<Slider>();
            Slider sliderY = GameObject.Find("Slider_Y").GetComponent<Slider>();
            Slider sliderZ = GameObject.Find("Slider_Z").GetComponent<Slider>();
            TextMeshProUGUI textX = sliderX.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI textY = sliderY.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI textZ = sliderZ.transform.Find("Text").GetComponent<TextMeshProUGUI>();

            // =======================================================================
            // �eSlider�̒l�̍X�V�C�x���g�Ƀ��A�N�e�B�u�v���p�e�B�̕ύX������o�^����
            // =======================================================================
            //X������p
            sliderX.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyX, textX); })
                .AddTo(this);
            //Y������p
            sliderY.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyY, textY); })
                .AddTo(this);
            //Z������p
            sliderZ.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyZ, textZ); })
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
            //���A�N�e�B�u�v���p�e�B�̍X�V
            floatReactiveProperty.Value = arrangeValue;
            //�e�L�X�g�ɒl�𔽉f
            valueText.text = arrangeValue.ToString();
        }
    }
}