using UnityEngine;
using System;

public class PrintLogObserver<T> : IObserver<T>
{
    public void OnCompleted()
    {
        Debug.Log("OnCompiled");
    }


    public void OnError(Exception error)
    {
        Debug.Log(error);
    }


    public void OnNext(T value)
    {
        Debug.Log(value);
    }
}
