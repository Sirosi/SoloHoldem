using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroupController : MonoBehaviour
{
    [Header("Card Settings")]
    [SerializeField] private int cardSize = 2;
    [SerializeField] private Transform cardGroup;
    [SerializeField] private Transform dealerButtonPosition;
    [SerializeField] private float cardOffset = 1.25f;

    #region ¡Þ Gizmos º¯¼öµé ¡Þ
    [Header("Gizmos Settings")]
    [SerializeField] private int gizmosEllipseCount = 4;
    [SerializeField] private float gizmosSize = 0.5f;
    [SerializeField] private Color gizmosColor = Color.red;
    #endregion



    public Action ClearEvent
    {
        private get;
        set;
    }
    public Action<Card> TakeCardEvent
    {
        private get;
        set;
    }



    public readonly List<Card> Cards = new();
    public Vector3[] CardPositions = null;

    public ushort InvestedPot = 0;
    public ushort Stack = 0;



    void OnDrawGizmos()
    {
        foreach(Vector3 pos in CardPositions)
        {
            GizmosDrawer.DrawEllipse(pos, gizmosSize, gizmosEllipseCount, gizmosColor);
        }
    }

    void OnValidate()
    {
        CardPositions = new Vector3[cardSize];

        float leftOffset = (cardSize - 1) * 0.5f * cardOffset;
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector3 leftPos = cardGroup.position - new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * leftOffset;
        for (int i = 0; i < cardSize; i++)
        {
            float nowOffset = cardOffset * i;
            CardPositions[i] = leftPos + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * nowOffset;
        }
    }

    public void Clear()
    {
        Cards.Clear();
        ClearEvent?.Invoke();
    }

    public void TakeCard(Card card)
    {
        Cards.Add(card);
        TakeCardEvent?.Invoke(card);
    }
}
