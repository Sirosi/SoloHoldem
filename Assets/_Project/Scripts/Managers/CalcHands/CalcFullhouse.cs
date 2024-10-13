using System.Collections.Generic;

public class CalcFullHouse : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        if(nonDuplicate.Count <= 4)
        {
            Dictionary<byte, byte> overlapCnt = new();
            if (nonDuplicate[0].Value == 1)
            {
                overlapCnt.Add(1, 0);
            }
            for(int i = nonDuplicate.Count - 1; overlapCnt.Count < nonDuplicate.Count;i--)
            {
                overlapCnt.Add(nonDuplicate[i].Value, 0);
            }

            foreach(Card card in cards)
            {
                overlapCnt[card.Value]++;
            }
            byte tripleCnt = 0;
            byte twoPairCnt = 0;
            foreach((byte key, byte value) in overlapCnt)
            {
                if (value >= 3) tripleCnt++;
                if (value >= 2) twoPairCnt++;
            }

            if(tripleCnt >= 1 && twoPairCnt >= 2) // 2장이상 겹친게 2개, 3장 이상 겹친게 1개 이상일 때 풀하우스
            {
                List<byte> powers = new();

                foreach(Card card in nonDuplicate)
                {
                    if (overlapCnt[card.Value] >= 3)
                    {
                        powers.Add(card.Value);
                        overlapCnt.Remove(card.Value);
                    }
                }
                foreach (Card card in nonDuplicate)
                {
                    if (card.Value != powers[0] && overlapCnt[card.Value] >= 2)
                    {
                        powers.Add(card.Value);
                        overlapCnt.Remove(card.Value);
                    }
                }
                foreach ((byte key, byte value) in overlapCnt)
                {
                    powers.Add(key);
                }

                return new PokerHand(PokerHandType.FullHouse, SuitType.Joker, powers.ToArray());
            }
        }
        return null;
    }
}