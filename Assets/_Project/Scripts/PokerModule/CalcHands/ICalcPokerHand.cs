using System.Collections.Generic;

public interface ICalcPokerHand
{
    /// <summary>
    /// �ش� ������ �´��� �����ϴ� Method
    /// </summary>
    /// <param name="cards">������������ ���ĵ� ī���, A�� ���ܷ� ���� �տ� ��ġ</param>
    /// <returns></returns>
    public PokerHand Calulate(List<Card> cards);
}