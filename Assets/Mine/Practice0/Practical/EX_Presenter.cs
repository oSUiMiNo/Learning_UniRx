using UniRx;
using UnityEngine;

// Presenter は Model と View を知っている
using MakuExample.MVP_Practical.Model;
using MakuExample.MVP_Practical.View;


namespace MakuExample.MVP_Basic.Presenter_Practical
{
    /// <summary>
    /// 適当なゲームオブジェクトにアタッチ。
    /// Model と View を繋ぐ Presenter
    /// View の更新を監視して、Model のデータを更新する。
    /// </summary>
    public class EX_Presenter : MonoBehaviour
    {
        void Start()
        {
            EX_View _VIEW_ = EX_View.Ins;
            EX_Model _MODEL_ = EX_Model.Ins;

            // ===============================================================================
            // View リアクティブプロパティ更新イベントに、Model のデータを更新処理を登録する
            // ===============================================================================
            _VIEW_.SliderValueRP_X
                .Subscribe(value => { _MODEL_.SetRotationX(value); }).AddTo(this);

            _VIEW_.SliderValueRP_Y
                .Subscribe(value => { _MODEL_.SetRotationY(value); }).AddTo(this);

            _VIEW_.SliderValueRP_Z
                .Subscribe(value => { _MODEL_.SetRotationZ(value); }).AddTo(this);
        }
    }
}