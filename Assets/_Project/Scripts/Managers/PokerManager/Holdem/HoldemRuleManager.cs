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

    private IHoldemState ready, flop, turn, river, collect;
    private HoldemTurn holdemTurn = HoldemTurn.Ready;
    private int turnCount = 0;




    public void OnReady()
    {
        ready = new HoldemReady(GraveyardPosition, CardManager, CardCrtls.ToArray(), OpenFlop);
        flop = new HoldemOpenPublics(GraveyardPosition, CardManager, publicCardPositions, 0, 3, HoldemUserController.Instance.OpenPublicCard, OpenTurn);
        turn = new HoldemOpenPublics(GraveyardPosition, CardManager, publicCardPositions, 3, 4, HoldemUserController.Instance.OpenPublicCard, OpenRiver);
        river = new HoldemOpenPublics(GraveyardPosition, CardManager, publicCardPositions, 4, 5, HoldemUserController.Instance.OpenPublicCard, CollectCards);
        collect = new HoldemCardCollect(CardManager, ReadyHand);

        ReadyHand();
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



    private void ReadyHand()
    {
        foreach (var crtl in CardCrtls)
        {
            crtl.Clear();
        }
        CardManager.Shuffle();

        ready.Invoke();
    }
    private void OpenFlop()
    {
        flop.Invoke();
    }
    private void OpenTurn()
    {
        turn.Invoke();
    }
    private void OpenRiver()
    {
        river.Invoke();
    }
    private void CollectCards()
    {
        collect.Invoke();
    }
}
