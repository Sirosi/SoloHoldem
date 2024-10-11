using System.Collections.Generic;

public class CalcFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        List<byte> spadeList = new();
        List<byte> cloverList = new();
        List<byte> diamondList = new();
        List<byte> heartList = new();
        List<byte> flushList = null;

        foreach (Card card in cards)
        {
            switch (card.Type)
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
        if (spadeList.Count >= 5) flushList = spadeList;
        else if (cloverList.Count >= 5) flushList = cloverList;
        else if (diamondList.Count >= 5) flushList = diamondList;
        else if (heartList.Count >= 5) flushList = heartList;
        else return null; // �÷����� �������� ����.

        List<byte> powers = new();
        if (flushList[0] == 1)
        {
            powers.Add(1);
        }
        flushList.Reverse();
        for(int i = 0;powers.Count < 5;i++)
        {
            powers.Add(powers[i]);
        }



        return new PokerHand(PokerHandType.StraightFlush, SuitType.Joker,powers.ToArray());
    }
}