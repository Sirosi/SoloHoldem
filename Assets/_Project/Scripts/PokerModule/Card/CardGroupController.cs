using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroupController : MonoBehaviour
{
    public Transform CardAreaLeft;
    public Transform CardAreaRight;
    public Card[] Cards;

    public int InvestedPot = 0;

    void Start()
    {
        Vector3 range = CardAreaRight.position - CardAreaLeft.position;
    }

    public void Open()
    {
        
    }
}
