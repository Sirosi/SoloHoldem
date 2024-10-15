using System.Collections.Generic;
using System.Linq;

public class CalcFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> flushList = PokerHandUtility.GetFlush(cards);
        if (flushList != null) // 플러쉬가 존재할 때
        {
            return new PokerHand(PokerHandType.Flush, flushList.Select(x => PokerHandUtility.ConvertToKicker(x)).Take(5).ToList());
        }

        return null;
    }
}