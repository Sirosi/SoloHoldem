using System;
using System.Threading.Tasks;
using UnityEngine;

public class HoldemCardCollect: IHoldemState
{
    public Action AfterAction => null;
    private CardManager cardManager;

    public HoldemCardCollect(CardManager cardManager)
    {
        this.cardManager = cardManager;
    }

    public async Task Invoke()
    {
        await Task.Delay(2000);
        foreach (var card in cardManager.UsedCards)
        {
            card.Hide();
            _ = SmoothMover.MoveAndRotate(card.transform, cardManager.CardPosition.position, cardManager.CardPosition.rotation);
        }

        AfterAction?.Invoke();
    }
}