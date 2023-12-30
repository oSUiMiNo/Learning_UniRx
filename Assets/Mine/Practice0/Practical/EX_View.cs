using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// View は Model も Presenter も知らない


namespace MakuExample.MVP_Practical.View
{
    /// <summary>
    /// 適当なゲームオブジェクトにアタッチ
    /// 表現対象の Slider の View を担う。
    /// Slider の値の変更を監視して View の内容を更新する。
    /// </summary>
    public class EX_View : MonoBehaviour
    {
        public static EX_View Ins;
        void Awake() { Ins = this; }

        
        /// <summary>
        /// X軸操作のSlider
        /// 購読機能のみ外部に公開
        /// </summary>
        public IReadOnlyReactiveProperty<float> SliderValueRP_X => _floatReactivePropertyX;
        private readonly FloatReactiveProperty _floatReactivePropertyX = new FloatReactiveProperty();
        /// <summary>
        /// Y軸操作のSlider
        /// 購読機能のみ外部に公開
        /// </summary>
        public IReadOnlyReactiveProperty<float> SliderValueRP_Y => _floatReactivePropertyY;
        private readonly FloatReactiveProperty _floatReactivePropertyY = new FloatReactiveProperty();
        /// <summary>
        /// Z軸操作のSlider
        /// 購読機能のみ外部に公開
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
            // 各Sliderの値の更新イベントにリアクティブプロパティの変更処理を登録する
            // =======================================================================
            //X軸操作用
            sliderX.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyX, textX); })
                .AddTo(this);
            //Y軸操作用
            sliderY.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyY, textY); })
                .AddTo(this);
            //Z軸操作用
            sliderZ.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, _floatReactivePropertyZ, textZ); })
                .AddTo(this);
        }


        /// <summary>
        /// Sliderの値変更時の処理
        /// </summary>
        /// <param name="value">Sliderの値</param>
        /// <param name="floatReactiveProperty">値を更新をしたいRP</param>
        /// <param name="valueText">更新するテキスト</param>
        private void OnValueChange(float value, FloatReactiveProperty floatReactiveProperty, TextMeshProUGUI valueText)
        {
            //値の整形
            var arrangeValue = Mathf.Floor((value - 0.5f) * 100) / 100 * 360;
            //リアクティブプロパティの更新
            floatReactiveProperty.Value = arrangeValue;
            //テキストに値を反映
            valueText.text = arrangeValue.ToString();
        }
    }
}