using System.Collections.Generic;
using System.Linq;

public class CalcStraightFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> flushList = PokerHandUtility.GetFlush(cards);
        if (flushList != null) // �÷����� ������ ��
        {
            while (flushList.Count >= 5) // ��������� ������ ���� �а� 5�� �̻��� ��
            {
                if (flushList[^5] + 4 == flushList[^1]) // �÷����� �п��� ���� ���� �� 5���� ��Ʈ����Ʈ�� �����ϸ�
                {
                    // !!!!!Important
                    // �Ϲ����� ��Ʈ����Ʈ�� A�� K���� ���� ���� ���� ����
                    return new PokerHand(PokerHandType.StraightFlush, flushList.TakeLast(5).ToArray());
                }
                flushList.RemoveAt(flushList.Count - 1); // ���� ���� ���� ����
            }
        }

        return null;
    }
}