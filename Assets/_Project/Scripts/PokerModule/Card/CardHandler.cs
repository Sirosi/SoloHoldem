using UnityEngine;

public class CardHandler : MonoBehaviour
{
    public SpriteRenderer MainRenderer = null;
    public SpriteRenderer HideRenderer = null;
    public Card Card = new(SuitType.Joker, 1);



    public void Set(SuitType type, byte value)
    {
        Card.Type = type;
        Card.Value = value;

        MainRenderer.sprite = GetCardSprite(Card);
    }

    private static Sprite GetCardSprite(Card card)
    {
        Sprite result = CardSpriteAssets.BackSprite;
        byte value = card.Value;
        try
        {
            switch (card.Type)
            {
                case SuitType.Joker:
                    result = CardSpriteAssets.JokerSprite;
                    break;
                case SuitType.Spade:
                    result = CardSpriteAssets.SpadeSprites[value - 1];
                    break;
                case SuitType.Clover:
                    result = CardSpriteAssets.CloverSprites[value - 1];
                    break;
                case SuitType.Diamond:
                    result = CardSpriteAssets.DiamondSprites[value - 1];
                    break;
                case SuitType.Heart:
                    result = CardSpriteAssets.HeartSprites[value - 1];
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
