using System.Collections.Generic;

public interface ICalcPokerHand
{
    /// <summary>
    /// 해당 족보가 맞는지 연산하는 Method
    /// </summary>
    /// <param name="cards">내림차순으로 정렬된 카드들, A는 예외로 가장 앞에 위치</param>
    /// <returns></returns>
    public PokerHand Calulate(List<Card> cards);
}