using System.Collections.Generic;
using System.Linq;

public class CalcBroadwayStraight : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        byte[] distinctedValues = cards.Select(x => x.Value).Distinct().ToArray(); // ī���� ���� �迭�� ���� �� �ߺ�����

        if(distinctedValues.Length >= 5) // �ߺ��� �ƴ� ���� 5�� �̻��� ��
        {
            if (distinctedValues[0] == 1 && distinctedValues[^4] == 10 && distinctedValues[^1] == 13) // ����ƾ Ȯ��
            {
                return new PokerHand(PokerHandType.BroadwayStraight, new byte[]
                {
                PokerHandUtility.ConvertToKicker(1),
                13,
                12,
                11,
                10
                });
            }
        }

        return null;
    }
}