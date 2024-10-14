using System.Collections.Generic;
using System.Linq;

public class CalcFourOfAKind : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> values = cards.Select(x => x.Value).ToList();
        for (int i = 0; i < values.Count - 3; i++) // 한 번에 4개의 인덱스를 동시 확인해야 하기 때문에 -3을 함.
        {
            if (values[i] == values[i + 3]) // 포카드 확인
            {
                byte mainKicker = PokerHandUtility.ConvertToKicker(values[i]);
                List<byte> kickers = Enumerable.Repeat(mainKicker, 4).ToList();
                values.RemoveRange(i, 4);

                byte subKicker = values.Max(PokerHandUtility.ConvertToKicker);
                kickers.Add(subKicker);

                return new PokerHand(PokerHandType.FourOfAKind, kickers);
            }
        }

        return null;
    }
}