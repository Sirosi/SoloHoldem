using System.Collections.Generic;

public class CalcStraightFlush : ICalcPokerHand
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

        // 플러시 판정 확인
        if (spadeList.Count >= 5) flushList = spadeList;
        else if (cloverList.Count >= 5) flushList = cloverList;
        else if (diamondList.Count >= 5) flushList = diamondList;
        else if (heartList.Count >= 5) flushList = heartList;
        else return null; // 플러쉬가 존재하지 않음.

        List<byte> powers = new();
        for(int i = flushList.Count - 1; i >= 4;i--)
        {
            byte firstNumber = flushList[i - 4];
            byte lastNumber = flushList[i];
            if (firstNumber + 4 == lastNumber)
            {
                break;
            }

            flushList.RemoveAt(i);
        }

        flushList.Reverse();
        for(int i = 0;i < 5;i++)
        {
            powers.Add(powers[i]);
        }



        return new PokerHand(PokerHandType.StraightFlush, powers.ToArray());
    }
}