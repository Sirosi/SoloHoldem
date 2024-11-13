using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class HoldemOpenPublics : IHoldemState
{
    public Action AfterAction => _AfterAction;
    private readonly Action _AfterAction = null;



    private readonly Transform graveyardPosition;
    private readonly CardManager cardManager;
    private readonly Transform[] publicCardPositions;

    private int start = 0;
    private int end = 0;



    public HoldemOpenPublics(Transform graveyardPosition, CardManager cardManager, Transform[] publicCardPositions, int start, int end, Action action)
    {
        this.graveyardPosition = graveyardPosition;
        this.cardManager = cardManager;
        this.publicCardPositions = publicCardPositions;
        this.start = start;
        this.end = end;
        _AfterAction = action;
    }


    public IEnumerator Invoke(MonoBehaviour mono)
    {
        yield return mono.StartCoroutine(SmoothMover.MoveAndRotate(mono, cardManager.NextCard.transform, graveyardPosition.position, graveyardPosition.rotation, 10));
        for(int i = start; i < end; i++)
        {
            Transform nowPos = publicCardPositions[i];
            CardHandler nowCard = cardManager.NextCard;
            yield return mono.StartCoroutine(SmoothMover.MoveAndRotate(mono, nowCard.transform, nowPos.position, nowPos.rotation));
            HoldemUserController.Instance.OpenPublicCard(nowCard.Card, i);
            nowCard.Open();
        }

        AfterAction?.Invoke();
    }
}