using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : Singleton<CardManager>
{
    public GameObject CardPrefab;
    public Transform CardGroup;

    public byte PackSize = 1;

    private CardHandler[] cardHandlers = null;


    private const byte SUIT_TYPE_SIZE = 4;
    private const byte CARD_VALUE_SIZE = 13;


    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        List<CardHandler> cards = new();
        for(int i = 0;i < PackSize;i++)
        {
            for (int j = 0; j < SUIT_TYPE_SIZE; j++)
            {
                SuitType suitType = (SuitType)((byte)SuitType.Spade + j);

                for (int k = 0; k < CARD_VALUE_SIZE; k++)
                {
                    GameObject g = Instantiate(CardPrefab, CardGroup);
                    CardHandler handler = g.GetComponent<CardHandler>();
                    handler.Set(suitType, (byte)(k + 1));
                    cards.Add(handler);
                }
            }
        }

        cardHandlers = cards.ToArray();
    }
}
