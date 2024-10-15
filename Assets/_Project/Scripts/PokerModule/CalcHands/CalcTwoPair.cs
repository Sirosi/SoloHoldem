using System.Collections.Generic;
using System.Linq;

public class CalcTwoPair : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> pairs = new();
        for(int i = 0;i < cards.Count - 1;i++)
        {
            if (cards[i].Value == cards[i + 1].Value)
            {
                pairs.Add(cards[i].Value);
                i++;
            }
        }

        if(pairs.Count >= 2)
        {
            List<byte> values = cards.Select(x => PokerHandUtility.ConvertToKicker(x.Value)).ToList();

            byte mainKicker = PokerHandUtility.ConvertToKicker(pairs[0]);
            byte subKicker = PokerHandUtility.ConvertToKicker(pairs[1]);
            values.RemoveAll(x => x == mainKicker || x == subKicker);
            byte lastKicker = values.Max(PokerHandUtility.ConvertToKicker);

            return new PokerHand(PokerHandType.TwoPair, new byte[]{mainKicker, mainKicker, subKicker, subKicker, lastKicker});
        }

        return null;
    }
}