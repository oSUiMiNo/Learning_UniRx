using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Observer �� Subject �ɓo�^����X�N���v�g
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
        //Subject �� Subscribe() ���Ăяo���� observer ��o�^

        countDownEventProvider.Count();
    }

    private void OnDestroy() { disposable?.Dispose(); }
    //GameObject�j�����ɃC�x���g�w�ǂ𒆒f
}
