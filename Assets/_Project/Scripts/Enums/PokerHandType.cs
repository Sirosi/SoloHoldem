public enum PokerHandType: byte
{
    None                = 0x00,
    NoPair              = 0x10,
    OnePair             = 0x11,
    TwoPair             = 0x12,
    ThreeOfAKind        = 0x13,
    Straight            = 0x20,
    BroadwayStraight    = 0x25,
    Flush               = 0x30,
    FullHouse           = 0x40,
    FourOfAKind         = 0x50,
    StraightFlush       = 0x60,
    RoyalStraightFlush  = 0x90,
}