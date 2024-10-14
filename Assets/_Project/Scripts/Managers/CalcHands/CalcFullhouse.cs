using System.Collections.Generic;
using System.Linq;

public class CalcFullHouse : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        byte[] cardValues = cards.Select(x => x.Value).Reverse().ToArray(); // 카드의 숫자만을 내림차순으로 재정렬
        List<byte> triples = new();
        List<byte> pairs = new();
        for (int i = 0;i < cardValues.Length - 1;i++)
        {
            byte nowValue = cardValues[i]; // 가장 높은 수
            if(nowValue == cardValues[i + 1])
            {
                pairs.Add(nowValue);
                if (i + 2 < cardValues.Length && nowValue == cardValues[i + 2])
                {
                    triples.Add(nowValue);
                    i+=2; // 트리플일 경우에는 인덱싱 카운팅 3
                }
                else
                {
                    i++; // 페어일 경우에는 인덱싱 카운팅 2
                }
            }
        }

        // 트리플이 1개, 페어가 1개 이상일 때
        // pairs는 트리플도 포함함
        if (triples.Count >= 1 && pairs.Count >= 2)
        {
            byte mainKicker = triples.Max(PokerHandUtility.ConvertToKicker);
            pairs.Remove(PokerHandUtility.ReconvertToKicker(mainKicker));
            byte subKicker = pairs.Max(PokerHandUtility.ConvertToKicker);

            byte[] kickers = Enumerable.Repeat(mainKicker, 3).Concat(Enumerable.Repeat(subKicker, 2)).ToArray();

            return new PokerHand(PokerHandType.FullHouse, kickers);
        }

        return null;
    }
}