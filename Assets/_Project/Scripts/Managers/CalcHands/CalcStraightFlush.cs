using System.Collections.Generic;
using System.Linq;

public class CalcStraightFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        Dictionary<SuitType, List<byte>> suitValues = new()
        {
            {SuitType.Spade, new()},
            {SuitType.Clover, new()},
            {SuitType.Diamond, new()},
            {SuitType.Heart, new()}
        };

        // �Ӽ��� ī�� �� ī����
        foreach (Card card in cards)
        {
            suitValues[card.Type].Add(card.Value);
        }

        List<byte> flushList = suitValues.Values.First(x => x.Count >= 5); // �÷����� ���� �ҷ�����
        SuitType suitType = suitValues.First(x => x.Value.Count >= 5).Key; // �÷����� �Ӽ��� �ҷ�����
        if (flushList == null) return null; // �÷����� �������� ����.

        while(flushList.Count >= 5) // ��������� ������ ���� �а� 5�� �̻��� ��
        {
            if (flushList[^4] + 4 == flushList[^0]) // �÷����� �п��� ���� ���� �� 5���� ��Ʈ����Ʈ�� �����ϸ�
            {
                return new PokerHand(PokerHandType.RoyalStraightFlush, suitType, new byte[]
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