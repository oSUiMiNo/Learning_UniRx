using UniRx;
using UnityEngine;

//Presenter は Model と View を知っている
using MakuExample.MVP_Basic.Model;
using MakuExample.MVP_Basic.View;


namespace MakuExample.MVP_Basic.Presenter
{
    /// <summary>
    /// 適当なゲームオブジェクトにアタッチする。
    /// Model と View を繋ぐ Presenter
    /// View の更新を監視して、Model のデータを更新する。
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
            // View リアクティブプロパティ更新イベントに、Model のデータを更新処理を登録する
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