using System;
using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class HoldemReady: IHoldemState
{
    public Action AfterAction => _AfterAction;
    private readonly Action _AfterAction = null;



    private readonly Transform graveyardPosition;
    private readonly CardManager cardManager;
    private readonly CardGroupController[] crtls;


    
    public HoldemReady(Transform graveyardPosition, CardManager cardManager, CardGroupController[] crtls, Action action)
    {
        this.graveyardPosition = graveyardPosition;
        this.cardManager = cardManager;
        this.crtls = crtls;
        _AfterAction = action;
    }


    public async Task Invoke()
    {
        try
        {
            foreach (var crtl in crtls)
            {
                await SmoothMover.MoveAndRotate(cardManager.NextCard.transform, graveyardPosition.position, graveyardPosition.rotation, 10);

                foreach (var target in crtl.CardPositions)
                {
                    var nowCard = cardManager.NextCard;
                    crtl.TakeCard(nowCard.Card);
                    await SmoothMover.MoveAndRotate(nowCard.transform, target, crtl.transform.rotation);
                }
            }

            AfterAction?.Invoke();
        }
        catch (Exception ex)
        {
            Logger.Error(ex.Message);
        }
    }
}