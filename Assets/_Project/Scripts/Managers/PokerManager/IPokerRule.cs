using System.Collections.Generic;
using UnityEngine;

public interface IPokerRule
{
    public Transform GraveyardPosition
    {
        get;
        set;
    }
    public CardManager CardManager
    {
        get;
        set;
    }
    public List<CardGroupController> CardCrtls
    {
        get;
    }
    public void OnReady();
    public void OnBeginHand();
    public void OnEndHand();
}