using System;
using System.Threading.Tasks;
using UnityEngine;

public interface IHoldemState
{
    public Action AfterAction
    {
        get;
    }

    public Task Invoke();
}