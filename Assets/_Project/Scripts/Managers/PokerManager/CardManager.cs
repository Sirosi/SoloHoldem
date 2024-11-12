using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private const byte SUIT_TYPE_SIZE = 4;
    private const byte CARD_VALUE_SIZE = 13;



    [Header("General Settins")]
    [SerializeField] private Transform cardGroup;
    [SerializeField] public Transform CardPosition;
    [SerializeField] private byte packSize = 1;

    [Header("Prefab Settings")]
    [SerializeField] private GameObject cardPrefab;



    public CardHandler NextCard
    {
        get
        {
            var result = Cards[UsedCards.Count];
            UsedCards.Add(result);
            return result;
        }
    }

    public readonly List<CardHandler> UsedCards = new();
    public readonly List<CardHandler> Cards = new();

    public void Init()
    {
        Cards.Clear();
        foreach (Transform t in cardGroup)
        {
            Destroy(t.gameObject);
        }

        for (int i = 0;i < packSize;i++)
        {
            for (int j = 0; j < SUIT_TYPE_SIZE; j++)
            {
                SuitType suitType = (SuitType)((byte)SuitType.Spade + j);

                for (int k = 0; k < CARD_VALUE_SIZE; k++)
                {
                    GameObject g = Instantiate(cardPrefab, CardPosition.position, Quaternion.identity, cardGroup);
                    CardHandler handler = g.GetComponent<CardHandler>();
                    handler.Set(suitType, (byte)(k + 1));
                    Cards.Add(handler);
                }
            }
        }
    }



    public void Clear()
    {
        UsedCards.Clear();
    }

    public void Shuffle(int suffleCount = 1)
    {
        Clear();
        for (int i = 0; i < suffleCount; i++)
        {
            for (int j = 0; j < Cards.Count; j++)
            {
                int randIdx = Random.Range(0, Cards.Count);
                CardHandler temp = Cards[randIdx];
                Cards[randIdx] = Cards[j];
                Cards[j] = temp;
            }
        }
    }
}
