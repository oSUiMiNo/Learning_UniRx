using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;  //追加　ObserveEventComponent には無い

/// <summary>
/// Observer をデリゲートで用意して Subject に登録するスクリプト
/// </summary>
public class ObserveEventComponent_Revision : MonoBehaviour
{
    private CountDownEventProvider countDownEventProvider;
    private IDisposable disposable;


    private void Start()
    {
        countDownEventProvider = GetComponent<CountDownEventProvider>();

        //PrintLogObserver の中身と同等の処理をこの場で実装しているので PrintLogObserver は必要ない
        disposable = countDownEventProvider.CountDownSubject.Subscribe(
                x => Debug.Log(x), //OnNext
                ex => Debug.Log(ex), //OnError
                () => Debug.Log("OnCompleted!") //OnCompleted
            );
        //Subject の Subscribe() を呼び出して observer を登録

        countDownEventProvider.Count();

        //var subject = new Subject<string>();
        //var A = subject.Scan((a, b) => a + " " + b).Last(); //なんだこれ
        //A.Subscribe(x => Debug.Log(x));
    }

    private void OnDestroy() { disposable?.Dispose(); }
    //GameObject破棄時にイベント購読を中断
}
