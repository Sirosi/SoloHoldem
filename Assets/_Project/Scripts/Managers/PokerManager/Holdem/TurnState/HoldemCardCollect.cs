using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class HoldemCardCollect: IHoldemState
{
    public Action AfterAction => _AfterAction;
    private Action _AfterAction = null;
    private CardManager cardManager;

    public HoldemCardCollect(CardManager cardManager, Action action)
    {
        this.cardManager = cardManager;
        _AfterAction = action;
    }

    public async Task Invoke()
    {
        try
        {
            await Task.Delay(2000);
            foreach (var card in cardManager.UsedCards)
            {
                card.Hide();
                _ = SmoothMover.MoveAndRotate(card.transform, cardManager.CardPosition.position, cardManager.CardPosition.rotation, 50);
            }
            await Task.Delay(2000);

            AfterAction?.Invoke();
        }
        catch(Exception ex)
        {
            Logger.Error(ex.Message);
        }
    }
}