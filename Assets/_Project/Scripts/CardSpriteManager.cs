using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpriteManager : Singleton<CardSpriteManager>
{
    /// <summary>
    /// 0~12: 스페이드
    /// 13~25: 클로버
    /// 26~38: 다이아
    /// 39~51: 하트
    /// </summary>
    public Sprite[] CardSprites;

    public Sprite[] SpadeSprites
    {
        get => CardSprites[..13];
    }
    public Sprite[] ColverSprites
    {
        get => CardSprites[13..13];
    }
    public Sprite[] DiaSprites
    {
        get => CardSprites[26..13];
    }
    public Sprite[] HeartSprites
    {
        get => CardSprites[39..13];
    }
}
