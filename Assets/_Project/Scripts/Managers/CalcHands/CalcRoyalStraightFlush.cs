using System.Collections.Generic;
using System.Linq;

public class CalcRoyalStraightFlush: ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        List<byte> flushList = CalcFlush.GetFlush(cards, nonDuplicate);
        if (flushList == null) return null; // �÷����� �������� ����.

        if (flushList[0] == 1 && flushList[^4] == 10 && flushList[^1] == 13) // �÷��� �Ҽ��� 1�� �����ϰ�, �÷��� �Ҽӿ��� ���� ū ���� 4���� 10~13(10~K)�̸�
        {
            return new PokerHand(PokerHandType.RoyalStraightFlush, new byte[] { 14, 13, 12, 11, 10 });
        }


        return null;
    }
}