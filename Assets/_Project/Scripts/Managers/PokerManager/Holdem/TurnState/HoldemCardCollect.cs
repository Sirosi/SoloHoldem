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

    public IEnumerator Invoke(MonoBehaviour mono)
    {
        yield return new WaitForSeconds(2);
        foreach (var card in cardManager.UsedCards)
        {
            card.Hide();
            mono.StartCoroutine(SmoothMover.MoveAndRotate(mono, card.transform, cardManager.CardPosition.position, cardManager.CardPosition.rotation, 50));
        }
        yield return new WaitForSeconds(2);

        AfterAction?.Invoke();
    }
}