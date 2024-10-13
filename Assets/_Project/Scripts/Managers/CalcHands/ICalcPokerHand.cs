using System.Collections.Generic;

public interface ICalcPokerHand
{
    /// <summary>
    /// 해당 족보가 맞는지 연산하는 Method
    /// </summary>
    /// <param name="cards">오름차순으로 정렬된 카드들</param>
    /// <param name="nonDuplicate">숫자중복제거 작업을 거친 오름차순 정렬 카드들</param>
    /// <returns></returns>
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate);
}