public class PokerHand
{
    !@#_!@#!@_#!@_#
    // TODO
    // 풀하우스가 최대 2개의 값을 갖고, 키커는 퍼블릭 카드보다 커질 수 없음
    // AAKJ8
    // 1. A3
    // 2. A8
    // 의 경우에는 2가 A트리플 + 8로 더 높긴 하지만, 퍼블릭 카드의 K보다 낮기 때문에 키커로 인정받지 못해 무승부
    // 1. AAAKJ-83
    // 2. AAAKJ-88
    // 완성된 족보 이외에 높은 숫자를 합쳐 총 5장이 우열을 가리는 역할을 하게 됨

    public PokerHandType HandType;
    public byte[] Powers;

    public PokerHand(PokerHandType handType, byte[] powers)
    {
        HandType = handType;
        Powers = powers;
    }

    #region ◇ operators ◇
    /*public override bool Equals(object obj)
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
    }*/
    #endregion
}
