using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class Test_ObservableFectory_Timer : MonoBehaviour
{
    [SerializeField] 
    float countTimeSeconds = 5f;
    public IObservable<Unit> OnTimeUpAsyncSubject => onTimeUpAsyncSubject;

    readonly AsyncSubject<Unit> onTimeUpAsyncSubject = new AsyncSubject<Unit> ();

    IDisposable disposable;

    void Start()
    {
        //�w�莞�Ԍo�߂�����Unit�^�̃��b�Z�[�W�𔭍s����B
        disposable = Observable
            .Timer(TimeSpan.FromSeconds(countTimeSeconds))
            .Subscribe(_ =>
            {
                Debug.Log("�^�C�}�[����");
                onTimeUpAsyncSubject.OnNext (Unit.Default);
                onTimeUpAsyncSubject.OnCompleted();
            });
    }

    void OnDestroy()
    {
        disposable?.Dispose();
        onTimeUpAsyncSubject?.Dispose();
    }
}
