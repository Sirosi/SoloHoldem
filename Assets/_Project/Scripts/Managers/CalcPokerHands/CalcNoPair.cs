using System.Collections.Generic;

public class CalcNoPair : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        List<byte> powers = new();
        if (nonDuplicate[0].Value != 1)
        {
            powers.Add(nonDuplicate[0].Value);
            for (int i = nonDuplicate.Count - 1;i > 0;i--)
            {
                powers.Add(nonDuplicate[i].Value);
            }
        }
        else
        {
            for (int i = nonDuplicate.Count - 1; i >= 0; i--)
            {
                powers.Add(nonDuplicate[i].Value);
            }
        }

        for(int i = powers.Count - 1;i >= 5;i--)
        {
            powers.RemoveAt(i);
        }
        return new PokerHand(PokerHandType.NoPair, powers.ToArray());
    }
}