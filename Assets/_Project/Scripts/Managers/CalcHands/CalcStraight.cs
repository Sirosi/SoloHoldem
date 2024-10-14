using System.Collections.Generic;
using System.Linq;

public class CalcStraight : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> distinctedValues = cards.Select(x => x.Value).Distinct().ToList(); // 카드의 값을 배열로 변경 및 중복제거

        while (distinctedValues.Count >= 5) // 중복이 아닌 값이 5이상일 때
        {
            if (distinctedValues[^5] + 4 == distinctedValues[^1]) // 가장 높은 수 5장이 스트레이트로 존재하면
            {
                // !!!!!Important
                // 일반적인 스트레이트는 A를 K보다 높은 수로 보지 않음
                return new PokerHand(PokerHandType.Straight, distinctedValues.TakeLast(5).ToArray());
            }
            distinctedValues.RemoveAt(distinctedValues.Count - 1); // 가장 높은 수를 제거
        }

        return null;
    }
}