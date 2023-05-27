using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Observer ‚ğ Subject ‚É“o˜^‚·‚éƒXƒNƒŠƒvƒg
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
        //Subject ‚Ì Subscribe() ‚ğŒÄ‚Ño‚µ‚Ä observer ‚ğ“o˜^

        countDownEventProvider.Count();
    }

    private void OnDestroy() { disposable?.Dispose(); }
    //GameObject”jŠü‚ÉƒCƒxƒ“ƒgw“Ç‚ğ’†’f
}
