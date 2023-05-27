using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class CountDownEventProvider : MonoBehaviour
{
    [SerializeField] 
    private int countSeconds = 10; //カウント用

    private MySubject<int> subject = new MySubject<int>();

    /// <summary>
    /// Subject<T> ( 今回は MySubject<T> で代用 ) が継承している ISubject<T> は、 IObserver<T>, IObservable<T> などを継承しているが、
    /// そのうち IObservableインターフェイス の部分のみ公開。
    /// IObservable が唯一持っているのは、登録した Observer を購読するための Subscrive() である。
    /// つまり、他のクラスから subject の Subscrive() だけを呼べるようになる。
    /// ちなみに、Subscrive() は IDisposable型 を返す関数なので、
    /// IDisposable型の変数 に代入できるし、Dispose() を呼べる。
    /// </summary>
    public IObservable<int> CountDownSubject => subject;
    
    
    /// <summary>
    /// subject.OnNext() をすれば、subject を購読している全 Observer の OnNext() が実行される。
    /// これが、
    /// 「Subject には複数の Observer を登録できてそれぞれにイベントメッセージを配れる。」
    /// ってやつ。
    /// </summary>
    public void Count() { StartCoroutine(Count_Co()); }
    private IEnumerator Count_Co()
    {
        var current = countSeconds;
        while ( current > 0 )
        {
            //Debug.Log(current);
            subject.OnNext( current );
            current --;
            yield return new WaitForSeconds(1.0f);
        }
        subject.OnNext(0);

        subject.OnCompleted();
    }


    private void OnDestroy() { subject.Dispose(); }
    //GameObject破棄時にイベント購読を中断
}
