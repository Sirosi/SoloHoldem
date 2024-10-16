using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroupController : MonoBehaviour
{
    public Transform CardAreaLeft;
    public Transform CardAreaRight;
    public Transform DealerButtonPosition;
    public Card[] Cards;

    public ushort InvestedPot = 0;
    public ushort Stack = 0;

    void Start()
    {
        Vector3 range = CardAreaRight.position - CardAreaLeft.position;
    }

    public void Call()
    {
        
    }
    
    public void Check()
    {

    }

    public void Raise()
    {

    }
}
