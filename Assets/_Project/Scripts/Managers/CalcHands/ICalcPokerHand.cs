using System.Collections.Generic;

public interface ICalcPokerHand
{
    /// <summary>
    /// �ش� ������ �´��� �����ϴ� Method
    /// </summary>
    /// <param name="cards">������������ ���ĵ� ī���</param>
    /// <param name="nonDuplicate">�����ߺ����� �۾��� ��ģ �������� ���� ī���</param>
    /// <returns></returns>
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate);
}