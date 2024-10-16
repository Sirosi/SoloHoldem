public interface IBatting
{
    public delegate ushort GetAmountHandler();

    /// <summary>
    /// Call할 떄 지불할 금액을 반환하는 대리자
    /// </summary>
    public GetAmountHandler CallAmount { get; set; }
    /// <summary>
    /// 현재 갖고 있는 자금을 반환하는 대리자
    /// </summary>
    public GetAmountHandler StackAmount { get; set; }

    /// <summary>
    /// 배팅할 수준의 자금이 있는지 확인하는 Method
    /// </summary>
    /// <returns></returns>
    public bool CanBat();
    /// <summary>
    /// 배팅하는 동작 Method
    /// </summary>
    /// <param name="stack">자금 레퍼런스</param>
    public void Bat(ref ushort stack);
}