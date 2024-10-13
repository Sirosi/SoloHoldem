using System.Collections.Generic;
using System.Linq;

public class CalcFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
    {
        List<byte> flushList = GetFlush(cards, nonDuplicate);

        while (flushList.Count >= 5) // 순서계산이 끝나지 않은 패가 5장 이상일 시
        {
            return new PokerHand(PokerHandType.Flush, new byte[]
            {
                flushList[^0],
                flushList[^1],
                flushList[^2],
                flushList[^3],
                flushList[^4]
            });
        }


        return null;
    }


    /// <summary>
    /// 플러쉬가 존재하는지 확인하는 Method<br/>
    /// 존재하지 않으면, (SuitType.None, null)을 반환
    /// </summary>
    /// <param name="cards">오름차순으로 정렬된 카드들</param>
    /// <param name="nonDuplicate">숫자중복제거 작업을 거친 오름차순 정렬 카드들</param>
    /// <returns></returns>
    public static List<byte> GetFlush(List<Card> cards, List<Card> nonDuplicate)
    {
        Dictionary<SuitType, List<byte>> suitValues = new()
        {
            {SuitType.Spade, new()},
            {SuitType.Clover, new()},
            {SuitType.Diamond, new()},
            {SuitType.Heart, new()}
        };

        // 속성별 카드 수 카운팅
        foreach (Card card in cards)
        {
            suitValues[card.Type].Add(card.Value);
        }

        List<byte> flushList = suitValues.Values.FirstOrDefault(x => x.Count >= 5); // 플러쉬의 값을 불러오기

        return flushList;
    }
}