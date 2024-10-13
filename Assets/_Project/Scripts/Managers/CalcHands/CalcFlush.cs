using System.Collections.Generic;
using System.Linq;

public class CalcFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        List<byte> flushList = GetFlush(cards, nonDuplicate);

        while (flushList.Count >= 5) // ��������� ������ ���� �а� 5�� �̻��� ��
        {
            return new PokerHand(PokerHandType.Flush, new byte[]
            {
                flushList[^0],
                flushList[^1],
                flushList[^2],
                flushList[^3],
                flushList[^4]
            });
        }


        return null;
    }


    /// <summary>
    /// �÷����� �����ϴ��� Ȯ���ϴ� Method<br/>
    /// �������� ������, (SuitType.None, null)�� ��ȯ
    /// </summary>
    /// <param name="cards">������������ ���ĵ� ī���</param>
    /// <param name="nonDuplicate">�����ߺ����� �۾��� ��ģ �������� ���� ī���</param>
    /// <returns></returns>
    public static List<byte> GetFlush(List<Card> cards, List<Card> nonDuplicate)
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

        List<byte> flushList = suitValues.Values.FirstOrDefault(x => x.Count >= 5); // �÷����� ���� �ҷ�����

        return flushList;
    }
}