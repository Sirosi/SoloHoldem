using System.Collections.Generic;
using System.Linq;

public class CalcFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> flushList = PokerHandUtility.GetFlush(cards);
        if (flushList != null) // 플러쉬가 맞을 때
        {
            List<byte> kickers = new();
            if (flushList[0] == 1)
            {
                kickers.Add(PokerHandUtility.ConvertToKicker(flushList[0]));
            }
            kickers.AddRange(flushList.TakeLast(5 - kickers.Count));
            return new PokerHand(PokerHandType.Flush, kickers.ToArray());
        }

        return null;
    }
}