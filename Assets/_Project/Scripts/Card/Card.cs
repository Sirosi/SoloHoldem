using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer Renderer = null;
    public SuitType Type = SuitType.Joker;
    public byte Value = 1;

    public bool Opend = false;

    public Vector3 OriginPosition
    {
        get => transform.parent.position;
    }

    public void SetCard(SuitType type, byte value)
    {
        Type = type;
        Value = value;

        SetImage();
    }

    public void SetImage()
    {
        Renderer.sprite = Opend ? GetCardSprite(Type, Value) : CardSpriteManager.Instance.BackSprite;
    }

    private static Sprite GetCardSprite(SuitType type, byte value)
    {
        Sprite result = CardSpriteManager.Instance.BackSprite;
        try
        {
            switch (type)
            {
                case SuitType.Joker:
                    result = CardSpriteManager.Instance.JokerSprite;
                    break;
                case SuitType.Spade:
                    result = CardSpriteManager.Instance.SpadeSprites[value - 1];
                    break;
                case SuitType.Clover:
                    result = CardSpriteManager.Instance.CloverSprites[value - 1];
                    break;
                case SuitType.Diamond:
                    result = CardSpriteManager.Instance.DiamondSprites[value - 1];
                    break;
                case SuitType.Heart:
                    result = CardSpriteManager.Instance.HeartSprites[value - 1];
                    break;
            }
        }
        catch
        {
            Logger.Error("CardValue Error", type, value);
        }

        return result;
    }
}
