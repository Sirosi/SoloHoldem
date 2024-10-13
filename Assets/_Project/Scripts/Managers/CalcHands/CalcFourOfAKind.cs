using System.Collections.Generic;

public class CalcFourOfAKind : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        for(int i = 0;i <= cards.Count - 4;i++)
        {
            if (cards[i].Value == cards[i + 3].Value)
            {
                List<byte> powers = new();
                powers.Add(cards[i].Value);
                for(int j = nonDuplicate.Count - 1;j >= 0;j--)
                {
                    if (cards[j].Value != nonDuplicate[j].Value)
                    {
                        powers.Add(cards[j].Value);
                    }
                }

                return new PokerHand(PokerHandType.FourOfAKind, SuitType.Joker, powers.ToArray());
            }
        }

        return null;
    }
}