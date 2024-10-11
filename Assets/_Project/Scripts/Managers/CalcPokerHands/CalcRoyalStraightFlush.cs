using System.Collections.Generic;

public class CalcRoyalStraightFlush: ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        List<byte> spadeList = new();
        List<byte> cloverList = new();
        List<byte> diamondList = new();
        List<byte> heartList = new();
        List<byte> flushList = null;

        foreach(Card card in cards)
        {
            switch(card.Type)
            {
                case SuitType.Spade:
                    spadeList.Add(card.Value);
                    break;
                case SuitType.Clover:
                    cloverList.Add(card.Value);
                    break;
                case SuitType.Diamond:
                    diamondList.Add(card.Value);
                    break;
                case SuitType.Heart:
                    heartList.Add(card.Value);
                    break;
            }
        }

        // �÷��� ���� Ȯ��
        if(spadeList.Count >= 5)        flushList = spadeList;
        else if(cloverList.Count >= 5)  flushList = cloverList;
        else if(diamondList.Count >= 5) flushList = diamondList;
        else if(heartList.Count >= 5)   flushList = heartList;
        else return null; // �÷����� �������� ����.

        if (flushList[0] == 1) // A�� �����ϰ�
        {
            flushList.Reverse();
            if (flushList[0] == 13 && flushList[3] == 10) // �ǵڿ����� K~10���� 4���� �����ϸ�
            {
                return new PokerHand(PokerHandType.RoyalStraightFlush, new byte[] { 1 });
            }
        }



        return null;
    }
}