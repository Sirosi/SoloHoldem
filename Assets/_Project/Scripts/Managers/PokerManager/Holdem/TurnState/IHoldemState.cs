using System;
using System.Collections;
using System.Threading.Tasks;

public interface IHoldemState
{
    public Action AfterAction
    {
        get;
    }

    public Task Invoke();
}