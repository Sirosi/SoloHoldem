using System.Collections.Generic;
using System.Linq;

public class CalcRoyalStraightFlush: ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        List<byte> flushList = CalcFlush.GetFlush(cards, nonDuplicate);
        if (flushList == null) return null; // 플러쉬가 존재하지 않음.

        if (flushList[0] == 1 && flushList[^4] == 10 && flushList[^1] == 13) // 플러쉬 소속의 1이 존재하고, 플러쉬 소속에서 가장 큰 숫자 4개가 10~13(10~K)이면
        {
            return new PokerHand(PokerHandType.RoyalStraightFlush, new byte[] { 14, 13, 12, 11, 10 });
        }


        return null;
    }
}