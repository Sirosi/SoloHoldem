using System.Collections.Generic;
using System.Linq;

public class CalcThreeOfAKind : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> triples = new();
        for(int i = 0;i < cards.Count - 2;i++)
        {
            if (cards[i].Value == cards[i + 2].Value)
            {
                triples.Add(cards[i].Value);
                i += 2;
            }
        }

        if(triples.Count >= 1) // Ʈ������ �����ϸ�
        {
            // kicker �ĺ��� ��� Convert�س���.
            List<byte> values = cards.Select(x => PokerHandUtility.ConvertToKicker(x.Value)).ToList();
            values.Sort();

            byte mainKicker = triples.Max(PokerHandUtility.ConvertToKicker); // triples �߿��� űĿ���� ���� ���� ���� ����
            values.RemoveAll(x => x == mainKicker);
            byte[] kickers = Enumerable.Repeat(mainKicker, 3).Concat(values.TakeLast(2).Reverse()).ToArray();

            return new PokerHand(PokerHandType.ThreeOfAKind, kickers);
        }

        return null;
    }
}