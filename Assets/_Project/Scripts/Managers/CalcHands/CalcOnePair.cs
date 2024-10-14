using System.Collections.Generic;
using System.Linq;

public class CalcOnePair : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> pairs = new();
        for (int i = 0; i < cards.Count - 1; i++)
        {
            if (cards[i].Value == cards[i + 1].Value)
            {
                pairs.Add(cards[i].Value);
                i++;
            }
        }

        if (pairs.Count >= 1)
        {
            List<byte> values = cards.Select(x => PokerHandUtility.ConvertToKicker(x.Value)).ToList();
            values.Sort();

            byte mainKicker = pairs.Max(PokerHandUtility.ConvertToKicker);
            pairs.Remove(PokerHandUtility.ReconvertToKicker(mainKicker));
            values.RemoveAll(x => x == mainKicker);
            List<byte> kickers = Enumerable.Repeat(mainKicker, 2).Concat(values.TakeLast(3).Reverse()).ToList();

            return new PokerHand(PokerHandType.OnePair, kickers);
        }

        return null;
    }
}