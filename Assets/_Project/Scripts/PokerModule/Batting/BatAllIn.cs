public class BatAllIn : IBatting
{
    public IBatting.GetAmountHandler CallAmount
    {
        get;
        set;
    }
    public IBatting.GetAmountHandler StackAmount
    {
        get;
        set;
    }

    public bool CanBat()
    {
        return 1 <= (StackAmount?.Invoke() ?? ushort.MinValue);
    }

    public void Bat(ref ushort stack)
    {
        stack = 0;
    }
}