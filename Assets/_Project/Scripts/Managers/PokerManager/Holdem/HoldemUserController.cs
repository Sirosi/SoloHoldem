using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class HoldemUserController: Singleton<HoldemUserController>
{
    [SerializeField] private Image[] publicCards;
    [SerializeField] private Image[] privateCards;
    [SerializeField] private Text handText;

    [SerializeField] private CardGroupController myGroup;



    private int cardCnt = 0;
    private List<Card> cards = new();



    public void SetController(CardGroupController controller)
    {
        if(myGroup != null)
        {
            myGroup.ClearEvent = null;
            myGroup.TakeCardEvent = null;
        }

        myGroup = controller;
        myGroup.ClearEvent = Clear;
        myGroup.TakeCardEvent = TakeCard;
    }



    private void Clear()
    {
        cards.Clear();
        cardCnt = 0;
        handText.text = string.Empty;

        foreach (var card in publicCards)
        {
            card.enabled = false;
        }
        foreach (var card in privateCards)
        {
            card.enabled = false;
        }
    }

    private void TakeCard(Card card)
    {
        privateCards[cardCnt].sprite = CardSpriteAssets.GetCardSprite(card);
        privateCards[cardCnt].enabled = true;
        cardCnt++;

        CheckHand(card);
    }

    public void OpenPublicCard(Card card, int idx)
    {
        publicCards[idx].sprite = CardSpriteAssets.GetCardSprite(card);
        publicCards[idx].enabled = true;

        CheckHand(card);
    }

    private void CheckHand(Card card)
    {
        cards.Add(card);
        if (cards.Count >= 5)
        {
            handText.text = PokerGameManager.Instance.CalcPokerHand(cards.ToArray()).Name;
        }
    }
}