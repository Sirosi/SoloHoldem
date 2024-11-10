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

    [Header("Gizmos Settings")]
    [SerializeField] private int gizmosEllipseCount = 4;
    [SerializeField] private float gizmosSize = 0.5f;
    [SerializeField] private Color gizmosColor = Color.red;

    public Card[] Cards;

    public ushort InvestedPot = 0;
    public ushort Stack = 0;

    void Start()
    {

    }

    void OnDrawGizmos()
    {
        float leftOffset = (cardSize - 1) * 0.5f * cardOffset;
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector2 leftPos = cardGroup.position - new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * leftOffset;
        for(int i = 0;i< cardSize;i++)
        {
            float nowOffset = cardOffset * i;
            Debug.Log($"{angle} - {new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))}");
            Vector3 nowCenter = leftPos + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * nowOffset;
            GizmosDrawer.DrawEllipse(nowCenter, gizmosSize, gizmosEllipseCount, gizmosColor);
        }
    }
    

    public void Call()
    {
        
    }
    
    public void Check()
    {

    }

    public void Raise()
    {

    }
}
