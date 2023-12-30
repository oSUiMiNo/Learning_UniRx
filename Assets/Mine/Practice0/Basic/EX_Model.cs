using UnityEngine;
// Model は View も Presenter も知らない


namespace MakuExample.MVP_Basic.Model
{
    /// <summary>
    /// キューブにアタッチする。
    /// 外部から渡される( V → P → M )データによってキューブを回転させるロジックを持つ Modelクラス。
    /// キューブが View のように見えるが、View は UIの見た目であるスライダー。
    /// Modelのデータが更新されているのが分かりやすいようにキューブでビジュアライズしているだけ。
    /// </summary>
    public class EX_Model : MonoBehaviour
    {
        public static EX_Model Ins;
        private void Awake() { Ins = this; }


        // ===========================================================================
        // こいつが Model のデータ本体。Presenter によって View に合わせて更新される
        // ===========================================================================
        public Vector3 rotation;


        // ビジュアライズ
        void Update() { transform.rotation = Quaternion.Euler(rotation); }
    }
}