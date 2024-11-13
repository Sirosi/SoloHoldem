using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public interface IHoldemState
{
    public Action AfterAction
    {
        get;
    }

    public IEnumerator Invoke(MonoBehaviour mono);
}