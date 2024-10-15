using System.Collections.Generic;
using System.Linq;

public class CalcBroadwayStraight : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        byte[] distinctedValues = cards.Select(x => x.Value).Distinct().ToArray(); // 카드의 값을 배열로 변경 및 중복제거

        if(distinctedValues.Length >= 5) // 중복이 아닌 값이 5장 이상일 때
        {
            if (distinctedValues[0] == 1 && distinctedValues[4] == 10) // 마운틴 확인
            {
                return new PokerHand(PokerHandType.BroadwayStraight, new byte[]{14, 13, 12, 11, 10});
            }
        }

        return null;
    }
}