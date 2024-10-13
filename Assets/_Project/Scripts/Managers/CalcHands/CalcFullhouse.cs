using System.Collections.Generic;

public class CalcFullHouse : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        if(nonDuplicate.Count <= 4) // AAA22nm�� ��ŭ, Ǯ�Ͽ콺 ��ü�� �ִ� 4 ������ ���ڹۿ� ���� ���� ����.
        {
            List<byte> pairs = new();
            List<byte> triples = new();
            List<byte> others = new();
            for(int i = 0;i < cards.Count - 1;i++) // 2�ּ� 2���� ��ġ���� Ȯ���ϴ� �κ��̶�, ������ �ε����� �н�
            {
                Card nowCard = cards[^i];
                if (nowCard == cards[^(i + 1)]) // ���� ī�尡 ������ ��
                {
                    if (i + 2 < cards.Count && nowCard == cards[^(i + 2)]) // ���� ī�尡 3���� ��
                    {
                        triples.Add(nowCard.Value);
                        i += 2; // �� ���� �ε����� 3�� �ؾ� ��
                    }
                    else // ���� ī�尡 2���� ��
                    {
                        pairs.Add(nowCard.Value);
                        i++; // �� ���� �ε����� 2�� �ؾ� ��
                    }
                }
                else
                {
                    if(others.Contains(nowCard.Value)) // �ߺ��� ����
                    {
                        others.Add(nowCard.Value);
                    }
                }
            }

            if(triples.Count >= 2 || triples.Count >= 1 && pairs.Count >= 1) // Ʈ������ 2�� �̻��̰ų�, Ʈ���� 1�� �̻� + ��� 1�� �̻��� ��
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

            if(tripleCnt >= 1 && twoPairCnt >= 2) // 2���̻� ��ģ�� 2��, 3�� �̻� ��ģ�� 1�� �̻��� �� Ǯ�Ͽ콺
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