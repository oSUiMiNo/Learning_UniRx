using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;  //�ǉ��@ObserveEventComponent �ɂ͖���

/// <summary>
/// Observer ���f���Q�[�g�ŗp�ӂ��� Subject �ɓo�^����X�N���v�g
/// </summary>
public class ObserveEventComponent_Revision : MonoBehaviour
{
    private CountDownEventProvider countDownEventProvider;
    private IDisposable disposable;

    private void Start()
    {
        countDownEventProvider = GetComponent<CountDownEventProvider>();

        //PrintLogObserver �̒��g�Ɠ����̏��������̏�Ŏ������Ă���̂� PrintLogObserver �͕K�v�Ȃ�
        disposable = countDownEventProvider.CountDownSubject.Subscribe(
                x => Debug.Log(x), //OnNext
                ex => Debug.Log(ex), //OnError
                () => Debug.Log("OnCompleted!") //OnCompleted
            );
        //Subject �� Subscribe() ���Ăяo���� observer ��o�^

        countDownEventProvider.Count();

        var subject = new  Subject<string>();
        var A = subject.Scan((a, b) => a + " " + b).Last(); //�Ȃ񂾂���
        A.Subscribe(x => Debug.Log(x));
    }

    private void OnDestroy() { disposable?.Dispose(); }
    //GameObject�j�����ɃC�x���g�w�ǂ𒆒f
}
