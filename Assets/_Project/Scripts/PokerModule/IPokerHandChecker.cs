public interface IPokerHandChecker
{
    /// <summary>
    /// 족보를 구성할 카드들을 받으면, 족보를 반환하는 Method
    /// </summary>
    /// <param name="cards">족보를 구성할 카드들</param>
    /// <returns></returns>
    public PokerHand CalcPokerHand(params Card[] cards);
}