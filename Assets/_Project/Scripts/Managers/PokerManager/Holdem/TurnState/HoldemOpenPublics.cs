using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class HoldemOpenPublics : IHoldemState
{
    public Action AfterAction => _AfterAction;
    private readonly Action _AfterAction = null;

    private readonly Action<Card, int> drawAction = null;

    private readonly Transform graveyardPosition;
    private readonly CardManager cardManager;
    private readonly Transform[] publicCardPositions;

    private int start = 0;
    private int end = 0;



    public HoldemOpenPublics(Transform graveyardPosition, CardManager cardManager, Transform[] publicCardPositions, int start, int end, Action<Card, int> drawAction, Action action)
    {
        this.graveyardPosition = graveyardPosition;
        this.cardManager = cardManager;
        this.publicCardPositions = publicCardPositions;
        this.start = start;
        this.end = end;
        this.drawAction = drawAction;
        _AfterAction = action;
    }


    public async Task Invoke()
    {
        try
        {
            await SmoothMover.MoveAndRotate(cardManager.NextCard.transform, graveyardPosition.position, graveyardPosition.rotation, 10);
            for (int i = start; i < end; i++)
            {
                Transform nowPos = publicCardPositions[i];
                CardHandler nowCard = cardManager.NextCard;
                await SmoothMover.MoveAndRotate(nowCard.transform, nowPos.position, nowPos.rotation);
                drawAction?.Invoke(nowCard.Card, i);
                nowCard.Open();
            }

            AfterAction?.Invoke();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message);
        }
    }
}