using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldemManager : MonoBehaviour
{
    public CardGroupController[] CardController;

    public Card[] Cards;
    public IPokerHandChecker HandChecker = new HoldemHandChecker();


    private readonly Dictionary<CardGroupController, int> controllerPerBat = new();

    // Start is called before the first frame update
    void Start()
    {
        PokerHand pokerHand = HandChecker.CalcPokerHand(Cards);
        Logger.Debug(pokerHand.HandType.ToString(), pokerHand.Kicker[0], pokerHand.Kicker[1], pokerHand.Kicker[2], pokerHand.Kicker[3], pokerHand.Kicker[4]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BatBalance(CardGroupController controller, int balance)
    {
        controllerPerBat[controller] += balance;
    }
}
