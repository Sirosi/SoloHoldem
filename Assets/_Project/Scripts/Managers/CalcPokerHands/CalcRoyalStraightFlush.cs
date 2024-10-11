using System.Collections.Generic;
using System.Linq;

public class CalcRoyalStraightFlush: ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        Dictionary<SuitType, List<byte>> suitValues = new()
        {
            {SuitType.Spade, new()},
            {SuitType.Clover, new()},
            {SuitType.Diamond, new()},
            {SuitType.Heart, new()}
        };

        foreach(Card card in cards)
        {
            suitValues[card.Type].Add(card.Value);
        }

        List<byte> flushList = suitValues.Values.First(x => x.Count >= 5);
        if(flushList == null) return null; // 플러쉬가 존재하지 않음.

        if (flushList.Contains(1) && flushList[^ - 1] == 13 && flushList[^ - 4] == 10)
        {
            return new PokerHand(PokerHandType.RoyalStraightFlush, new byte[] { 1 });
        }


        return null;
    }
}