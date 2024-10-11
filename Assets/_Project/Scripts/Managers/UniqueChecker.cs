using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueChecker : Singleton<UniqueChecker>
{
    void Start()
    {
        if(Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
