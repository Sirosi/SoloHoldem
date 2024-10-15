using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldemManager : MonoBehaviour
{
    public CardGroupController[] CardController;

    public Card[] Cards =
    {
        new(),
        new(),
        new(),
        new(),
        new(),
        new(),
        new(),
    };
    public IPokerHandChecker HandChecker = new HoldemHandChecker();


    private readonly Dictionary<CardGroupController, int> controllerPerBat = new();

    // Start is called before the first frame update
    void Start()
    {


        #region �׽�Ʈ �ڵ�
        /*// ��Ƽ��
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Spade, SuitType.Spade, SuitType.Spade,
            SuitType.Heart, SuitType.Spade
            , 1, 5, 10, 11, 12, 10, 13);
        // ��Ƽ��
        Test(SuitType.Spade, SuitType.Spade, SuitType.Spade, SuitType.Spade, SuitType.Spade,
            SuitType.Heart, SuitType.Spade
            , 1, 2, 3, 4, 5, 10, 13);
        // ��ī��
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Clover, SuitType.Spade, SuitType.Diamond,
            SuitType.Heart, SuitType.Spade
            , 1, 5, 13, 11, 13, 13, 13);
        // Ǯ�Ͽ콺
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Clover, SuitType.Spade, SuitType.Heart,
            SuitType.Heart, SuitType.Spade
            , 1, 5, 10, 12, 12, 10, 10);
        // �÷���
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Spade, SuitType.Spade, SuitType.Spade,
            SuitType.Diamond, SuitType.Spade
            , 1, 5, 10, 8, 12, 10, 13);
        // ����ƾ
        Test(SuitType.Diamond, SuitType.Diamond, SuitType.Spade, SuitType.Spade, SuitType.Spade,
            SuitType.Heart, SuitType.Spade
            , 1, 5, 10, 11, 12, 10, 13);
        // ��Ʈ����Ʈ
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Clover, SuitType.Heart, SuitType.Spade,
            SuitType.Diamond, SuitType.Clover
            , 1, 2, 3, 4, 5, 10, 13);
        // Ʈ����
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Spade, SuitType.Diamond, SuitType.Clover,
            SuitType.Heart, SuitType.Spade
            , 1, 5, 10, 12, 12, 12, 13);
        // �����
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Spade, SuitType.Diamond, SuitType.Spade,
            SuitType.Heart, SuitType.Spade
            , 11, 5, 5, 11, 12, 10, 1);
        // �����
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Spade, SuitType.Diamond, SuitType.Spade,
            SuitType.Heart, SuitType.Spade
            , 1, 5, 5, 1, 12, 10, 13);
        // �����
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Spade, SuitType.Diamond, SuitType.Spade,
            SuitType.Heart, SuitType.Spade
            , 1, 5, 10, 11, 12, 10, 9);
        // �����
        Test(SuitType.Spade, SuitType.Diamond, SuitType.Spade, SuitType.Diamond, SuitType.Spade,
            SuitType.Heart, SuitType.Diamond
            , 1, 5, 10, 11, 12, 7, 9);*/
        #endregion
    }

    public void Test(SuitType s1, SuitType s2, SuitType s3, SuitType s4, SuitType s5, SuitType s6, SuitType s7
        , byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7)
    {
        Cards[0] = new Card(s1, b1);
        Cards[1] = new Card(s2, b2);
        Cards[2] = new Card(s3, b3);
        Cards[3] = new Card(s4, b4);
        Cards[4] = new Card(s5, b5);
        Cards[5] = new Card(s6, b6);
        Cards[6] = new Card(s7, b7);
        PokerHand pokerHand = HandChecker.CalcPokerHand(Cards);
        Logger.Debug(pokerHand.HandType.ToString(), pokerHand.GetHashCode(), pokerHand.Kicker[0], pokerHand.Kicker[1], pokerHand.Kicker[2], pokerHand.Kicker[3], pokerHand.Kicker[4]);
    }

    public void BatBalance(CardGroupController controller, int balance)
    {
        controllerPerBat[controller] += balance;
    }
}
