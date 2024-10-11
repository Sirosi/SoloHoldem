using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldemHandChecker: IPokerHandChecker
{

    private static ICalcPokerHand[] calcPokerHands =
    {
        new CalcRoyalStraightFlush(),
        new CalcStraightFlush(),
        new CalcFourOfAKind(),
        new CalcFullHouse(),
        new CalcFlush(),

        new CalcNoPair()
    };



    public PokerHand CalcPokerHand(params Card[] cards)
    {
        List<Card> sortedCards = new(cards);// ���ĵ� ī�� ����Ʈ
        List<Card> nonDuplicate = new();    // �ߺ����� ���� ī�� ����Ʈ
        sortedCards.Sort((x, y) => x.Value >= y.Value ? 1 : -1);
        for(int i = 0;i < sortedCards.Count - 1;i++)
        {
            if (sortedCards[i] != sortedCards[i + 1])
            {
                nonDuplicate.Add(sortedCards[i]);
            }
        }

        foreach(ICalcPokerHand calc in calcPokerHands)
        {
            PokerHand pokerHand = calc.Calulate(sortedCards, nonDuplicate);
            if(pokerHand != null)
            {
                return pokerHand;
            }
        }

        return null;
    }
}
