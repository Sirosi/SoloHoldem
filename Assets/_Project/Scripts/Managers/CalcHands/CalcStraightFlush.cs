using System.Collections.Generic;
using System.Linq;

public class CalcStraightFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        List<byte> flushList = CalcFlush.GetFlush(cards, nonDuplicate);
        if (flushList == null) return null; // 플러쉬가 존재하지 않음.

        while(flushList.Count >= 5) // 순서계산이 끝나지 않은 패가 5장 이상일 시
        {
            if (flushList[^4] + 4 == flushList[^0]) // 플러쉬인 패에서 가장 높은 수 5장이 스트레이트로 존재하면
            {
                return new PokerHand(PokerHandType.StraightFlush, new byte[]
                {
                    flushList[^0],
                    flushList[^1],
                    flushList[^2],
                    flushList[^3],
                    flushList[^4]
                });
            }
            flushList.RemoveAt(flushList.Count - 1); // 가장 높은 수를 제거
        }


        return null;
    }
}