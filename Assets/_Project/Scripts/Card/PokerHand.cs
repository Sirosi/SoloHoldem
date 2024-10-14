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

    #region ¡Þ operators ¡Þ
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
        return left.GetHashCode() == right.GetHashCode();
    }
    public static bool operator !=(PokerHand left, PokerHand right)
    {
        return left.GetHashCode() != right.GetHashCode();
    }
    #endregion
}
