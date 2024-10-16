public interface IBatting
{
    public delegate ushort GetAmountHandler();

    /// <summary>
    /// Call�� �� ������ �ݾ��� ��ȯ�ϴ� �븮��
    /// </summary>
    public GetAmountHandler CallAmount { get; set; }
    /// <summary>
    /// ���� ���� �ִ� �ڱ��� ��ȯ�ϴ� �븮��
    /// </summary>
    public GetAmountHandler StackAmount { get; set; }

    /// <summary>
    /// ������ ������ �ڱ��� �ִ��� Ȯ���ϴ� Method
    /// </summary>
    /// <returns></returns>
    public bool CanBat();
    /// <summary>
    /// �����ϴ� ���� Method
    /// </summary>
    /// <param name="stack">�ڱ� ���۷���</param>
    public void Bat(ref ushort stack);
}