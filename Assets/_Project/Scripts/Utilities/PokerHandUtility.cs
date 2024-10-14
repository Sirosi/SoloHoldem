using System.Collections.Generic;
using System.Linq;

public static class PokerHandUtility
{
    /// <summary>
    /// 키커가 A일 경우 14로 변경하는 용도
    /// </summary>
    /// <param name="kicker">키커 값</param>
    /// <returns></returns>
    public static byte ConvertToKicker(byte kicker) => kicker == 1 ? (byte)14 : kicker;
    /// <summary>
    /// 키커를 위해 변환했던 값을 원래의 카드 값으로 되돌리는 용도
    /// </summary>
    /// <param name="kicker">변환했던 키커 값</param>
    /// <returns></returns>
    public static byte ReconvertToKicker(byte kicker) => kicker == 14 ? (byte)1 : kicker;

    /// <summary>
    /// 플러쉬가 존재하는지 확인하는 Method<br/>
    /// 존재하지 않으면, (SuitType.None, null)을 반환
    /// </summary>
    /// <param name="cards">오름차순으로 정렬된 카드들</param>
    /// <param name="nonDuplicate">숫자중복제거 작업을 거친 오름차순 정렬 카드들</param>
    /// <returns>플러쉬 소속의 숫자들</returns>
    public static List<byte> GetFlush(List<Card> cards)
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