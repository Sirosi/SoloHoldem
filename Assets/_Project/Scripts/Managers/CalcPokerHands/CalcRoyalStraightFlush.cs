using System.Collections.Generic;
using System.Linq;

public class CalcRoyalStraightFlush: ICalcPokerHand
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
        foreach(Card card in cards)
        {
            suitValues[card.Type].Add(card.Value);
        }

        List<byte> flushList = suitValues.Values.First(x => x.Count >= 5); // 플러쉬의 값을 불러오기
        SuitType suitType = suitValues.First(x => x.Value.Count >= 5).Key; // 플러쉬의 속성을 불러오기
        if(flushList == null) return null; // 플러쉬가 존재하지 않음.

        if (flushList[0] == 1 && flushList[^4] == 10 && flushList[^1] == 13) // 플러쉬 소속의 1이 존재하고, 플러쉬 소속에서 가장 큰 숫자 4개가 10~13(10~K)이면
        {
            return new PokerHand(PokerHandType.RoyalStraightFlush, suitType, new byte[] { 1 });
        }


        return null;
    }
}