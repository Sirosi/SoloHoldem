using System.Collections.Generic;
using System.Linq;

public class CalcNoPair : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards)
    {
        List<byte> values = cards.Select(x => PokerHandUtility.ConvertToKicker(x.Value)).ToList();

        return new PokerHand(PokerHandType.NoPair, values.Take(5).ToArray());
    }
}