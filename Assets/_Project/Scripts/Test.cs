using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public SpriteRenderer SpadeSprite;
    public SpriteRenderer CloverSprite;
    public SpriteRenderer DiaSprite;
    public SpriteRenderer HeartSprite;

    void Start()
    {
        StartCoroutine("Loop");
    }

    private IEnumerator Loop()
    {
        int cnt = 0;
        while(true)
        {
            SpadeSprite.sprite  = CardSpriteManager.Instance.SpadeSprites[cnt];
            CloverSprite.sprite = CardSpriteManager.Instance.CloverSprites[cnt];
            DiaSprite.sprite    = CardSpriteManager.Instance.DiamondSprites[cnt];
            HeartSprite.sprite  = CardSpriteManager.Instance.HeartSprites[cnt];
            cnt++;
            if(cnt >= 13)//CardSpriteManager.Instance.CardSprites.Length)
            {
                cnt = 0;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
