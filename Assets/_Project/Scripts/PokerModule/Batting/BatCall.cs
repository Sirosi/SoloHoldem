public class BatCall : IBatting
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
        return (CallAmount?.Invoke() ?? ushort.MaxValue) <= (StackAmount?.Invoke() ?? ushort.MinValue);
    }

    public void Bat(ref ushort stack)
    {
        stack -= CallAmount?.Invoke() ?? stack;
    }
}