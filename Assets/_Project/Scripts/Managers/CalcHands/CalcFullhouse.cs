using System.Collections.Generic;
using System.Linq;

public class CalcFullHouse : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        byte[] cardValues = cards.Select(x => x.Value).Reverse().ToArray(); // ī���� ���ڸ��� ������������ ������
        List<byte> triples = new();
        List<byte> pairs = new();
        for (int i = 0;i < cardValues.Length - 1;i++)
        {
            byte nowValue = cardValues[i]; // ���� ���� ��
            if(nowValue == cardValues[i + 1])
            {
                pairs.Add(nowValue);
                if (i + 2 < cardValues.Length && nowValue == cardValues[i + 2])
                {
                    triples.Add(nowValue);
                    i+=2; // Ʈ������ ��쿡�� �ε��� ī���� 3
                }
                else
                {
                    i++; // ����� ��쿡�� �ε��� ī���� 2
                }
            }
        }

        // Ʈ������ 1��, �� 1�� �̻��� ��
        // pairs�� Ʈ���õ� ������
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