using System.Collections.Generic;
using System.Linq;

public class CalcRoyalStraightFlush: ICalcPokerHand
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
        foreach(Card card in cards)
        {
            suitValues[card.Type].Add(card.Value);
        }

        List<byte> flushList = suitValues.Values.First(x => x.Count >= 5); // �÷����� ���� �ҷ�����
        SuitType suitType = suitValues.First(x => x.Value.Count >= 5).Key; // �÷����� �Ӽ��� �ҷ�����
        if(flushList == null) return null; // �÷����� �������� ����.

        if (flushList[0] == 1 && flushList[^4] == 10 && flushList[^1] == 13) // �÷��� �Ҽ��� 1�� �����ϰ�, �÷��� �Ҽӿ��� ���� ū ���� 4���� 10~13(10~K)�̸�
        {
            return new PokerHand(PokerHandType.RoyalStraightFlush, suitType, new byte[] { 1 });
        }


        return null;
    }
}