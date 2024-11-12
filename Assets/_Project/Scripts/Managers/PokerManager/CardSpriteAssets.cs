using UnityEngine;

public static class CardSpriteAssets
{
    public static Sprite[] CardSprites
    {
        get
        {
            if(_CardSprites == null)
            {
                Init();
            }

            return _CardSprites;
        }
    }
    private static Sprite[] _CardSprites = null;


    public static Sprite[] SpadeSprites
    {
        get => CardSprites[..13];
    }
    public static Sprite[] CloverSprites
    {
        get => CardSprites[13..26];
    }
    public static Sprite[] DiamondSprites
    {
        get => CardSprites[26..39];
    }
    public static Sprite[] HeartSprites
    {
        get => CardSprites[39..52];
    }
    public static Sprite JokerSprite
    {
        get => CardSprites[53];
    }
    public static Sprite BackSprite
    {
        get => CardSprites[52];
    }



    private static void Init()
    {
        _CardSprites = Resources.LoadAll<Sprite>("Sprites/PokerCards");
    }

    public static Sprite GetCardSprite(Card card)
    {
        Sprite result = BackSprite;
        byte value = card.Value;
        try
        {
            switch (card.Type)
            {
                case SuitType.Joker:
                    result = JokerSprite;
                    break;
                case SuitType.Spade:
                    result = SpadeSprites[value - 1];
                    break;
                case SuitType.Clover:
                    result = CloverSprites[value - 1];
                    break;
                case SuitType.Diamond:
                    result = DiamondSprites[value - 1];
                    break;
                case SuitType.Heart:
                    result = HeartSprites[value - 1];
                    break;
            }
        }
        catch
        {
            Logger.Error("CardValue Error", card.Type, value);
        }

        return result;
    }
}