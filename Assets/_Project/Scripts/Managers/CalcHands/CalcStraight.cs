using System.Collections.Generic;
using System.Linq;

public class CalcStraight : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> distinctedValues = cards.Select(x => x.Value).Distinct().ToList(); // ī���� ���� �迭�� ���� �� �ߺ�����

        while (distinctedValues.Count >= 5) // �ߺ��� �ƴ� ���� 5�̻��� ��
        {
            if (distinctedValues[^5] + 4 == distinctedValues[^1]) // ���� ���� �� 5���� ��Ʈ����Ʈ�� �����ϸ�
            {
                // !!!!!Important
                // �Ϲ����� ��Ʈ����Ʈ�� A�� K���� ���� ���� ���� ����
                return new PokerHand(PokerHandType.Straight, distinctedValues.TakeLast(5).ToArray());
            }
            distinctedValues.RemoveAt(distinctedValues.Count - 1); // ���� ���� ���� ����
        }

        return null;
    }
}