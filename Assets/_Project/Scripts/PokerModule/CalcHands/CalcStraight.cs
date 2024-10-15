using System.Collections.Generic;
using System.Linq;

public class CalcStraight : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> distinctedValues = cards.Select(x => x.Value).Distinct().ToList(); // ī���� ���� �迭�� ���� �� �ߺ�����

        while (distinctedValues.Count >= 5) // �ߺ��� �ƴ� ���� 5�̻��� ��
        {
            distinctedValues.Sort((x, y) => x <= y ? 1 : -1); // �⺻������ 1�� �� �տ� �δ� ���ܰ� �ֱ� ������ ������ �ʿ�
            if (distinctedValues[0] == distinctedValues[4] + 4) // ���� ���� �� 5���� ��Ʈ����Ʈ�� �����ϸ�
            {
                // !!!!!Important
                // �Ϲ����� ��Ʈ����Ʈ�� A�� K���� ���� ���� ���� ����
                return new PokerHand(PokerHandType.Straight, distinctedValues.Take(5).ToArray());
            }
            distinctedValues.RemoveAt(0); // ���� ���� ���� ����
        }

        return null;
    }
}