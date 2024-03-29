using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Observer を Subject に登録するスクリプト
/// </summary>
public class ObserveEventComponent : MonoBehaviour
{
    private CountDownEventProvider countDownEventProvider;
    private PrintLogObserver<int> printLogObserver;
    private IDisposable disposable;


    private void Start()
    {
        countDownEventProvider = GetComponent<CountDownEventProvider>();
        printLogObserver = new PrintLogObserver<int>();

        disposable = countDownEventProvider.CountDownSubject.Subscribe(printLogObserver);
        //Subject の Subscribe() を呼び出して observer を登録

        countDownEventProvider.Count();
    }

    private void OnDestroy() { disposable?.Dispose(); }
    //GameObject破棄時にイベント購読を中断
}
