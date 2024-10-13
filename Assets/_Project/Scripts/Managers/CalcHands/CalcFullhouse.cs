using System.Collections.Generic;

public class CalcFullHouse : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        if(nonDuplicate.Count <= 4) // AAA22nm인 만큼, 풀하우스 자체는 최대 4 종류의 숫자밖에 나올 수가 없음.
        {
            List<byte> pairs = new();
            List<byte> triples = new();
            List<byte> others = new();
            for(int i = 0;i < cards.Count - 1;i++) // 2최소 2장이 겹치는지 확인하는 부분이라, 마지막 인덱스는 패스
            {
                Card nowCard = cards[^i];
                if (nowCard == cards[^(i + 1)]) // 동일 카드가 존재할 때
                {
                    if (i + 2 < cards.Count && nowCard == cards[^(i + 2)]) // 동일 카드가 3장일 때
                    {
                        triples.Add(nowCard.Value);
                        i += 2; // 한 번에 인덱싱을 3을 해야 함
                    }
                    else // 동일 카드가 2장일 때
                    {
                        pairs.Add(nowCard.Value);
                        i++; // 한 번에 인덱싱을 2를 해야 함
                    }
                }
                else
                {
                    if(others.Contains(nowCard.Value)) // 중복값 제외
                    {
                        others.Add(nowCard.Value);
                    }
                }
            }

            if(triples.Count >= 2 || triples.Count >= 1 && pairs.Count >= 1) // 트리플이 2개 이상이거나, 트리플 1개 이상 + 페어 1개 이상일 때
            {

            }
        }

        return null;

        /*if(nonDuplicate.Count <= 4)
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
        return null;*/
    }
}