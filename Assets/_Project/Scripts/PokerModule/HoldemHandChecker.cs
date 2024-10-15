using System.Collections.Generic;

public class HoldemHandChecker: IPokerHandChecker
{
    private static readonly ICalcPokerHand[] calcPokerHands =
    {
        new CalcRoyalStraightFlush(),
        new CalcStraightFlush(),
        new CalcFourOfAKind(),
        new CalcFullHouse(),
        new CalcFlush(),
        new CalcBroadwayStraight(),
        new CalcStraight(),
        new CalcThreeOfAKind(),
        new CalcTwoPair(),
        new CalcOnePair(),
        new CalcNoPair()
    };



    public PokerHand CalcPokerHand(params Card[] cards)
    {
        List<Card> sortedCards = new(cards);// ���ĵ� ī�� ����Ʈ
        sortedCards.Sort((x, y) => PokerHandUtility.ConvertToKicker(x.Value) <= PokerHandUtility.ConvertToKicker(y.Value) ? 1 : -1); // ��������, A�� ���ܷ� ���� �տ� ��ġ

        foreach(ICalcPokerHand calc in calcPokerHands)
        {
            PokerHand pokerHand = calc.Calulate(sortedCards);
            if(pokerHand != null)
            {
                return pokerHand;
            }
        }

        return null;
    }
}
