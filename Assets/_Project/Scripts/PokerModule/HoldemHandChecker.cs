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
        List<Card> sortedCards = new(cards);// 정렬된 카드 리스트
        sortedCards.Sort((x, y) => PokerHandUtility.ConvertToKicker(x.Value) <= PokerHandUtility.ConvertToKicker(y.Value) ? 1 : -1); // 내림차순, A는 예외로 가장 앞에 위치

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
