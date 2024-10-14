using System.Collections.Generic;
using System.Linq;

public class CalcFourOfAKind : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> values = cards.Select(x => x.Value).ToList();
        for (int i = 0; i < values.Count - 3; i++) // �� ���� 4���� �ε����� ���� Ȯ���ؾ� �ϱ� ������ -3�� ��.
        {
            if (values[i] == values[i + 3]) // ��ī�� Ȯ��
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