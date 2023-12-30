using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// View は Model も Presenter も知らない。


namespace MakuExample.MVP_Basic.View
{
    /// <summary>
    /// 適当なゲームオブジェクトにアタッチ
    /// 表現対象の Slider の View を担う。
    /// Slider の値の変更を監視して View の内容を更新する。
    /// </summary>
    public class EX_View : MonoBehaviour
    {
        /// <summary>
        /// Sliderの値
        /// 購読機能のみ外部に公開
        /// </summary>
        public IReadOnlyReactiveProperty<float> SliderValueRP => floatReactiveProperty;
        private readonly FloatReactiveProperty floatReactiveProperty = new FloatReactiveProperty();


        void Start()
        {
            Slider slider = GetComponent<Slider>();
            TextMeshProUGUI text = transform.Find("Text").GetComponent<TextMeshProUGUI>();


            // =======================================================================
            // 各Sliderの値の更新イベントにリアクティブプロパティの変更処理を登録する
            // =======================================================================
            slider.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(value => { OnValueChange(value, floatReactiveProperty, text); })
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
            //値の更新
            floatReactiveProperty.Value = arrangeValue;
            //テキストに値を反映
            valueText.text = arrangeValue.ToString();
        }
    }
}