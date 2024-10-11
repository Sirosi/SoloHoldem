using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldemManager : MonoBehaviour
{
    public Card[] Cards;
    public IPokerHandChecker HandChecker = new HoldemHandChecker();

    // Start is called before the first frame update
    void Start()
    {
        HandChecker.CalcPokerHand(Cards);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
