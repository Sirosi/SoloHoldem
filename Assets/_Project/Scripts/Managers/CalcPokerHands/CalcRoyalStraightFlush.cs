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

        // 플러시 판정 확인
        if(spadeList.Count >= 5)        flushList = spadeList;
        else if(cloverList.Count >= 5)  flushList = cloverList;
        else if(diamondList.Count >= 5) flushList = diamondList;
        else if(heartList.Count >= 5)   flushList = heartList;
        else return null; // 플러쉬가 존재하지 않음.

        if (flushList[0] == 1) // A가 존재하고
        {
            flushList.Reverse();
            if (flushList[0] == 13 && flushList[3] == 10) // 맨뒤에부터 K~10까지 4개가 존재하면
            {
                return new PokerHand(PokerHandType.RoyalStraightFlush, new byte[] { 1 });
            }
        }



        return null;
    }
}