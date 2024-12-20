using System.Collections.Generic;
using System.Linq;

public class CalcStraightFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> flushList = PokerHandUtility.GetFlush(cards);
        if (flushList != null) // 플러쉬가 존재할 때
        {
            flushList.Sort((x, y) => x <= y ? 1 : -1); // 기본적으로 1을 맨 앞에 두는 예외가 있기 때문에 재정렬 필요
            while (flushList.Count >= 5) // 순서계산이 끝나지 않은 패가 5장 이상일 시
            {
                if (flushList[0] == flushList[4] + 4) // 플러쉬인 패에서 가장 높은 수 5장이 스트레이트로 존재하면
                {
                    // !!!!!Important
                    // 일반적인 스트레이트는 A를 K보다 높은 수로 보지 않음
                    return new PokerHand(PokerHandType.StraightFlush, flushList.Take(5).ToArray());
                }
                flushList.RemoveAt(0); // 가장 높은 수를 제거
            }
        }

        return null;
    }
}