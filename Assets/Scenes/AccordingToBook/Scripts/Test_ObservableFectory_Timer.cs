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
        //指定時間経過したらUnit型のメッセージを発行する。
        disposable = Observable
            .Timer(TimeSpan.FromSeconds(countTimeSeconds))
            .Subscribe(_ =>
            {
                Debug.Log("タイマー発火");
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
