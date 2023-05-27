using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;

public class CountDownEventProvider : MonoBehaviour
{
    [SerializeField] 
    private int countSeconds = 10; //�J�E���g�p

    private MySubject<int> subject = new MySubject<int>();

    /// <summary>
    /// Subject<T> ( ����� MySubject<T> �ő�p ) ���p�����Ă��� ISubject<T> �́A IObserver<T>, IObservable<T> �Ȃǂ��p�����Ă��邪�A
    /// ���̂��� IObservable�C���^�[�t�F�C�X �̕����̂݌��J�B
    /// IObservable ���B�ꎝ���Ă���̂́A�o�^���� Observer ���w�ǂ��邽�߂� Subscrive() �ł���B
    /// �܂�A���̃N���X���� subject �� Subscrive() �������Ăׂ�悤�ɂȂ�B
    /// ���Ȃ݂ɁASubscrive() �� IDisposable�^ ��Ԃ��֐��Ȃ̂ŁA
    /// IDisposable�^�̕ϐ� �ɑ���ł��邵�ADispose() ���Ăׂ�B
    /// </summary>
    public IObservable<int> CountDownSubject => subject;
    
    
    /// <summary>
    /// subject.OnNext() ������΁Asubject ���w�ǂ��Ă���S Observer �� OnNext() �����s�����B
    /// ���ꂪ�A
    /// �uSubject �ɂ͕����� Observer ��o�^�ł��Ă��ꂼ��ɃC�x���g���b�Z�[�W��z���B�v
    /// ���Ă�B
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
    //GameObject�j�����ɃC�x���g�w�ǂ𒆒f
}
