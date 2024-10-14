using System;
using System.Collections.Generic;

public class PokerHand
{
    public PokerHandType HandType;
    public byte[] Kicker;

    private const byte KICKER_SIZE = 5;

    public PokerHand(PokerHandType handType, byte[] kicker)
    {
        if(handType == PokerHandType.None)
        {
            throw new Exception();
        }
        else if(kicker.Length != KICKER_SIZE)
        {
            throw new Exception();
        }
        else
        {
            HandType = handType;
            Kicker = kicker;
        }
    }
    public PokerHand(PokerHandType handType, List<byte> kicker) : this(handType, kicker.ToArray())
    {

    }

    #region ◇ operators ◇
    public override bool Equals(object obj)
    {
        return this.GetHashCode() == obj.GetHashCode();
    }
    public override int GetHashCode()
    {
        int cnt = (byte)HandType;
        foreach(byte b in Kicker)
        {
            cnt <<= 4;
            cnt += b;
        }
        return cnt;
    }

    public static bool operator >(PokerHand left, PokerHand right)
    {
        return left.GetHashCode() > right.GetHashCode();
    }
    public static bool operator >=(PokerHand left, PokerHand right)
    {
        return left.GetHashCode() >= right.GetHashCode();
    }
    public static bool operator <(PokerHand left, PokerHand right)
    {
        return left.GetHashCode() < right.GetHashCode();
    }
    public static bool operator <=(PokerHand left, PokerHand right)
    {
        return left.GetHashCode() <= right.GetHashCode();
    }
    public static bool operator ==(PokerHand left, PokerHand right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }
        else if (left is null || right is null)
        {
            return false;
        }

        // 같은 해시 코드를 가지면 true
        return left.GetHashCode() == right.GetHashCode();
    }

    public static bool operator !=(PokerHand left, PokerHand right)
    {
        // == 연산자의 반대 결과를 반환
        return !(left == right);
    }
    #endregion
}
