using UnityEngine;
// Model は View も Presenter も知らない


namespace MakuExample.MVP_Practical.Model
{
    /// <summary>
    /// キューブにアタッチする。
    /// データ外部から渡されるデータによってキューブを回転させるロジックを持つモデルクラス。
    /// キューブが View のように見えるが、View は UIの見た目であるスライダー。
    /// Modelのデータが更新されているのが分かりやすいようにキューブでビジュアライズしているだけで、
    /// 重要なのは当Modelクラスの数値（データ）なのだが、データを保存する変数が無いので更に分かりにくい
    /// データはキューブ Transform のプロパティに格納される形になっているから。
    /// なので厳密には今回は Transform が Model と言っていい。
    /// </summary>
    public class EX_Model : MonoBehaviour
    {
        public static EX_Model Ins;
        void Awake() { Ins = this; }


        /// <summary>
        /// 与えられたパラメータに応じてX軸方向にキューブを回転
        /// </summary>
        /// <param name="x">X軸回転</param>
        public void SetRotationX(float x)
        {
            var rot = Quaternion.AngleAxis(x, Vector3.right);
            transform.rotation = rot;
        }

        /// <summary>
        /// 与えられたパラメータに応じてY軸方向にキューブを回転
        /// </summary>
        /// <param name="y">X軸回転</param>
        public void SetRotationY(float y)
        {
            var rot = Quaternion.AngleAxis(y, Vector3.up);
            transform.rotation = rot;
        }

        /// <summary>
        /// 与えられたパラメータに応じてZ軸方向にキューブを回転
        /// </summary>
        /// <param name="z">Z軸回転</param>
        public void SetRotationZ(float z)
        {
            var rot = Quaternion.AngleAxis(z, Vector3.forward);
            transform.rotation = rot;
        }
    }
}