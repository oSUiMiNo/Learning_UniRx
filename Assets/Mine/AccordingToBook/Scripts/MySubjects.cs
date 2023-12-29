using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

/// <summary>
/// 【 基本的な使い方 】
/// Subscribe() された Observer を List<IObserver<T>> に追加。つまり購読を開始。
/// OnNext() されたら List に登録された Observer 全員にメッセージをばらまく
/// Subscribe() した際に .Dispose() をすると、その Observer の購読を停止する。
/// </summary>
public class MySubject<T> : ISubject<T>, IDisposable  //独自実装 Subject
{
    public bool IsStopped { get; } = false;
    public bool IsDisposed { get; } = false;

    private readonly object lockObject = new object();

    private Exception error;  //途中で発生した例外
    
    private List<IObserver<T>> observers;  //自身を購読しているObserverリスト

    public MySubject()
    {
        observers = new List<IObserver<T>>();
    }


    /// <summary>
    ///ISubject<T> は、
    ///IObserver<T>(メッセージを受け取るやつ) と IObservable<T>(メッセージを出力するやつ) の両方を持っているため、
    ///自分が Observer としてメッセージを受け取り、自分が管理する Observer達 に横流しすることができる。
    /// </summary>
    #region IObserver<T>系 の部分
    public void OnNext(T value)  //自身が受け取った イベントメッセージ本体 を横流し
    {
        if (IsStopped) return;  //既に終了していたらなし
        lock (lockObject)
        {
            ThrowIfDisPosed();  
            
            foreach(var observer in observers)  //自信を購読している Observer 全員にメッセージをばらまく
            {
                observer.OnNext(value);
            }
        }
    }

    
    public void OnError(Exception error)  //自身が受け取った エラーメッセージ(例外) を横流し
    {
        lock (lockObject)
        {
            ThrowIfDisPosed();
            if (IsStopped) return;  //既に終了していたらなし
            this.error = error;

            try
            {
                foreach(var observer in observers)
                {
                    observer.OnError(error);
                }
            }
            finally
            {
                Dispose();
            }
        }
    }

   
    public void OnCompleted()  //自身が受け取った ベントメッセージの発行が全て完了した通知 を横流し
    {
        lock (lockObject)
        {
            ThrowIfDisPosed();
            if (IsStopped) return;  //既に終了していたらなし

            try
            {
                foreach (var observer in observers)
                {
                    observer.OnCompleted();
                }
            }
            finally
            {
                Dispose();
            }
        }
    }


    private void ThrowIfDisPosed()
    {
        if (IsDisposed) throw new ObjectDisposedException("MySubject");
    }
    #endregion IObserver<T>系 の部分



    #region IObservable<T>系 の部分
    public IDisposable Subscribe(IObserver<T> observer)
    {
        lock(lockObject)
        {
            if(IsStopped)  //既に終了していたら
            {
                if(error != null) observer.OnError(error);
                else observer.OnCompleted();

                return Disposable.Empty;
            }

            observers.Add(observer);
            
            return new Subscription(this, observer);
        }
    }


    public void Dispose()
    {
        lock(lockObject)
        {
            if(!IsDisposed)
            {
                observers?.Clear();
                observers = null;
                error = null;
            }
        }
    }


    // SubscriveのDispose( 購読の解除 ) をできるようにするために用いるクラス
    private sealed class Subscription : IDisposable
    {
        private readonly IObserver<T> observer;
        private readonly MySubject<T> parent;

        public Subscription(MySubject<T> parent, IObserver<T> observer)
        {
            this.parent = parent;
            this.observer = observer;
        }

        public void Dispose()
        {
            parent.observers?.Remove(observer);  //Observerリスト から消去する
        }
    }
    #endregion IObservable<T>系 の部分
}
