public class PokerHand
{
    !@#_!@#!@_#!@_#
    // TODO
    // Ǯ�Ͽ콺�� �ִ� 2���� ���� ����, ŰĿ�� �ۺ� ī�庸�� Ŀ�� �� ����
    // AAKJ8
    // 1. A3
    // 2. A8
    // �� ��쿡�� 2�� AƮ���� + 8�� �� ���� ������, �ۺ� ī���� K���� ���� ������ ŰĿ�� �������� ���� ���º�
    // 1. AAAKJ-83
    // 2. AAAKJ-88
    // �ϼ��� ���� �̿ܿ� ���� ���ڸ� ���� �� 5���� �쿭�� ������ ������ �ϰ� ��

    public PokerHandType HandType;
    public byte[] Powers;

    public PokerHand(PokerHandType handType, byte[] powers)
    {
        HandType = handType;
        Powers = powers;
    }

    #region �� operators ��
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

        return false; // Equal ����
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

        return false; // Equal ����
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
