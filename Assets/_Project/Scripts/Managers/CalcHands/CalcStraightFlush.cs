using System.Collections.Generic;
using System.Linq;

public class CalcStraightFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        List<byte> flushList = CalcFlush.GetFlush(cards, nonDuplicate);
        if (flushList == null) return null; // �÷����� �������� ����.

        while(flushList.Count >= 5) // ��������� ������ ���� �а� 5�� �̻��� ��
        {
            if (flushList[^4] + 4 == flushList[^0]) // �÷����� �п��� ���� ���� �� 5���� ��Ʈ����Ʈ�� �����ϸ�
            {
                return new PokerHand(PokerHandType.StraightFlush, new byte[]
                {
                    flushList[^0],
                    flushList[^1],
                    flushList[^2],
                    flushList[^3],
                    flushList[^4]
                });
            }
            flushList.RemoveAt(flushList.Count - 1); // ���� ���� ���� ����
        }


        return null;
    }
}