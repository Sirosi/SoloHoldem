using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpriteManager : Singleton<CardSpriteManager>
{
    /// <summary>
    /// 0~12: �����̵�
    /// 13~25: Ŭ�ι�
    /// 26~38: ���̾�
    /// 39~51: ��Ʈ
    /// </summary>
    public Sprite[] CardSprites;

    public Sprite[] SpadeSprites
    {
        get => CardSprites[..13];
    }
    public Sprite[] CloverSprites
    {
        get => CardSprites[13..26];
    }
    public Sprite[] DiamondSprites
    {
        get => CardSprites[26..39];
    }
    public Sprite[] HeartSprites
    {
        get => CardSprites[39..52];
    }
    public Sprite JokerSprite
    {
        get => CardSprites[53];
    }
    public Sprite BackSprite
    {
        get => CardSprites[52];
    }
}
