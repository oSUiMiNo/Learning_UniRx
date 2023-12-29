using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

/// <summary>
/// �y ��{�I�Ȏg���� �z
/// Subscribe() ���ꂽ Observer �� List<IObserver<T>> �ɒǉ��B�܂�w�ǂ��J�n�B
/// OnNext() ���ꂽ�� List �ɓo�^���ꂽ Observer �S���Ƀ��b�Z�[�W���΂�܂�
/// Subscribe() �����ۂ� .Dispose() ������ƁA���� Observer �̍w�ǂ��~����B
/// </summary>
public class MySubject<T> : ISubject<T>, IDisposable  //�Ǝ����� Subject
{
    public bool IsStopped { get; } = false;
    public bool IsDisposed { get; } = false;

    private readonly object lockObject = new object();

    private Exception error;  //�r���Ŕ���������O
    
    private List<IObserver<T>> observers;  //���g���w�ǂ��Ă���Observer���X�g

    public MySubject()
    {
        observers = new List<IObserver<T>>();
    }


    /// <summary>
    ///ISubject<T> �́A
    ///IObserver<T>(���b�Z�[�W���󂯎����) �� IObservable<T>(���b�Z�[�W���o�͂�����) �̗����������Ă��邽�߁A
    ///������ Observer �Ƃ��ă��b�Z�[�W���󂯎��A�������Ǘ����� Observer�B �ɉ��������邱�Ƃ��ł���B
    /// </summary>
    #region IObserver<T>�n �̕���
    public void OnNext(T value)  //���g���󂯎���� �C�x���g���b�Z�[�W�{�� ��������
    {
        if (IsStopped) return;  //���ɏI�����Ă�����Ȃ�
        lock (lockObject)
        {
            ThrowIfDisPosed();  
            
            foreach(var observer in observers)  //���M���w�ǂ��Ă��� Observer �S���Ƀ��b�Z�[�W���΂�܂�
            {
                observer.OnNext(value);
            }
        }
    }

    
    public void OnError(Exception error)  //���g���󂯎���� �G���[���b�Z�[�W(��O) ��������
    {
        lock (lockObject)
        {
            ThrowIfDisPosed();
            if (IsStopped) return;  //���ɏI�����Ă�����Ȃ�
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

   
    public void OnCompleted()  //���g���󂯎���� �x���g���b�Z�[�W�̔��s���S�Ċ��������ʒm ��������
    {
        lock (lockObject)
        {
            ThrowIfDisPosed();
            if (IsStopped) return;  //���ɏI�����Ă�����Ȃ�

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
    #endregion IObserver<T>�n �̕���



    #region IObservable<T>�n �̕���
    public IDisposable Subscribe(IObserver<T> observer)
    {
        lock(lockObject)
        {
            if(IsStopped)  //���ɏI�����Ă�����
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


    // Subscrive��Dispose( �w�ǂ̉��� ) ���ł���悤�ɂ��邽�߂ɗp����N���X
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
            parent.observers?.Remove(observer);  //Observer���X�g �����������
        }
    }
    #endregion IObservable<T>�n �̕���
}
