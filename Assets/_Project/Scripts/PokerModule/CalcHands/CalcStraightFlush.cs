using System.Collections.Generic;
using System.Linq;

public class CalcStraightFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> flushList = PokerHandUtility.GetFlush(cards);
        if (flushList != null) // �÷����� ������ ��
        {
            flushList.Sort((x, y) => x <= y ? 1 : -1); // �⺻������ 1�� �� �տ� �δ� ���ܰ� �ֱ� ������ ������ �ʿ�
            while (flushList.Count >= 5) // ��������� ������ ���� �а� 5�� �̻��� ��
            {
                if (flushList[0] == flushList[4] + 4) // �÷����� �п��� ���� ���� �� 5���� ��Ʈ����Ʈ�� �����ϸ�
                {
                    // !!!!!Important
                    // �Ϲ����� ��Ʈ����Ʈ�� A�� K���� ���� ���� ���� ����
                    return new PokerHand(PokerHandType.StraightFlush, flushList.Take(5).ToArray());
                }
                flushList.RemoveAt(0); // ���� ���� ���� ����
            }
        }

        return null;
    }
}