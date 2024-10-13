using System.Collections.Generic;

public interface ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate);
}