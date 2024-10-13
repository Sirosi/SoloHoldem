using System.Collections.Generic;
using System.Linq;

public class CalcFlush : ICalcPokerHand
{
    public PokerHand Calulate(List<Card> cards, List<Card> nonDuplicate)
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

        List<byte> flushList = suitValues.Values.First(x => x.Count >= 5); // 플러쉬의 값을 불러오기
        SuitType suitType = suitValues.First(x => x.Value.Count >= 5).Key; // 플러쉬의 속성을 불러오기
        if (flushList == null) return null; // 플러쉬가 존재하지 않음.

        while (flushList.Count >= 5) // 순서계산이 끝나지 않은 패가 5장 이상일 시
        {
            return new PokerHand(PokerHandType.Flush, suitType, new byte[]
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
}