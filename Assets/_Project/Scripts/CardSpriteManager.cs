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
