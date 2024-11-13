using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldemRuleManager : MonoBehaviour, IPokerRule
{
    [SerializeField] private Transform[] publicCardPositions;

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
    public List<CardGroupController> CardCrtls => _CardCrtls;
    private readonly List<CardGroupController> _CardCrtls = new();



    public List<Card> PublicCards = new();

    private HoldemTurn holdemTurn = HoldemTurn.Ready;
    private int turnCount = 0;

    IHoldemState ready, flop, turn, river, collect;



    public void OnReady()
    {
        ready = new HoldemReady(GraveyardPosition, CardManager, CardCrtls.ToArray(), OpenFlop);
        flop = new HoldemOpenPublics(GraveyardPosition, CardManager, publicCardPositions, 0, 3, OpenTurn);
        turn = new HoldemOpenPublics(GraveyardPosition, CardManager, publicCardPositions, 3, 4, OpenRiver);
        river = new HoldemOpenPublics(GraveyardPosition, CardManager, publicCardPositions, 4, 5, CallToDack);
        collect = new HoldemCardCollect(CardManager, Reload);

        Reload();
    }

    public void OnBeginHand()
    {

    }

    public void OnTurning()
    {

    }

    public void OnEndHand()
    {

    }

    private void OpenFlop()
    {
        StartCoroutine(flop.Invoke(this));
    }
    private void OpenTurn()
    {
        StartCoroutine(turn.Invoke(this));
    }
    private void OpenRiver()
    {
        StartCoroutine(river.Invoke(this));
    }
    private void CallToDack()
    {
        StartCoroutine(collect.Invoke(this));
    }

    public void Reload()
    {
        foreach (var crtl in CardCrtls)
        {
            crtl.Clear();
        }
        CardManager.Shuffle();

        StartCoroutine(ready.Invoke(this));
    }
}