public class PokerHand
{
    public PokerHandType HandType;
    public SuitType SuitType;
    public byte[] Powers;

    public PokerHand(PokerHandType type, byte[] powers)
    {
        HandType = type;
        Powers = powers;
    }

    #region ◇ operators ◇
    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator >(PokerHand left, PokerHand right)
    {
        if ((byte)left.HandType != (byte)right.HandType)
        {
            return (byte)left.HandType > (byte)right.HandType;
        }

        for (int i = 0; i < left.Powers.Length; i++)
        {
            if (left.Powers[i] != right.Powers[i])
            {
                return left.Powers[i] > right.Powers[i];
            }
        }

        return false; // Equal 상태
    }
    public static bool operator <(PokerHand left, PokerHand right)
    {
        if ((byte)left.HandType != (byte)right.HandType)
        {
            return (byte)left.HandType < (byte)right.HandType;
        }

        for (int i = 0; i < left.Powers.Length; i++)
        {
            if (left.Powers[i] != right.Powers[i])
            {
                return left.Powers[i] < right.Powers[i];
            }
        }

        return false; // Equal 상태
    }

    public static bool operator ==(PokerHand left, PokerHand right)
    {
        if ((byte)left.HandType != (byte)right.HandType)
        {
            return false;
        }

        for (int i = 0; i < left.Powers.Length; i++)
        {
            if (left.Powers[i] != right.Powers[i])
            {
                return false;
            }
        }

        return true;
    }
    public static bool operator !=(PokerHand left, PokerHand right)
    {
        if ((byte)left.HandType != (byte)right.HandType)
        {
            return true;
        }

        for (int i = 0; i < left.Powers.Length; i++)
        {
            if (left.Powers[i] != right.Powers[i])
            {
                return true;
            }
        }

        return false;
    }
    #endregion
}
