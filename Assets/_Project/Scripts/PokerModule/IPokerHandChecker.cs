public interface IPokerHandChecker
{
    /// <summary>
    /// ������ ������ ī����� ������, ������ ��ȯ�ϴ� Method
    /// </summary>
    /// <param name="cards">������ ������ ī���</param>
    /// <returns></returns>
    public PokerHand CalcPokerHand(params Card[] cards);
}