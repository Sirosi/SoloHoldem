using System;
using System.Collections.Generic;

public class PokerHand
{
    public string Name
    {
        get
        {
            string result = "Error";
            switch(HandType)
            {
                case PokerHandType.NoPair:
                    result = "�� ���";
                    break;
                case PokerHandType.OnePair:
                    result = "�� ���";
                    break;
                case PokerHandType.TwoPair:
                    result = "�� ���";
                    break;
                case PokerHandType.ThreeOfAKind:
                    result = "Ʈ����";
                    break;
                case PokerHandType.Straight:
                    result = "��Ʈ����Ʈ";
                    break;
                case PokerHandType.BroadwayStraight:
                    result = "����ƾ";
                    break;
                case PokerHandType.Flush:
                    result = "�÷���";
                    break;
                case PokerHandType.FullHouse:
                    result = "Ǯ�Ͽ콺";
                    break;
                case PokerHandType.FourOfAKind:
                    result = "��ī��";
                    break;
                case PokerHandType.StraightFlush:
                    result = "��Ʈ����Ʈ �÷���";
                    break;
                case PokerHandType.RoyalStraightFlush:
                    result = "�ξ� ��Ʈ����Ʈ �÷���";
                    break;
                case PokerHandType.None:
                default:
                    result = "None";
                    break;
            }

            return result;
        }
    }

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

    #region �� operators ��
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

        // ���� �ؽ� �ڵ带 ������ true
        return left.GetHashCode() == right.GetHashCode();
    }

    public static bool operator !=(PokerHand left, PokerHand right)
    {
        // == �������� �ݴ� ����� ��ȯ
        return !(left == right);
    }
    #endregion
}
