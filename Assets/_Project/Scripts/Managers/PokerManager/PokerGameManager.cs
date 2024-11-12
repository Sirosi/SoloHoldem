using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class PokerGameManager : Singleton<PokerGameManager>
{
    [SerializeField] private Transform graveyardPosition;

    public CardGroupController Dealer = null;

    private CardManager cardManager;
    private IPokerHandChecker handChecker = new HoldemHandChecker();
    private IPokerRule pokerRule = null;

    private List<CardHandler> CardHandlers => cardManager.Cards;



    /// <summary>
    /// ÀüÃ¼ ÆÇµ·
    /// </summary>
    public int TotalPot
    {
        get
        {
            int result = 0;
            foreach (var ctrl in pokerRule.CardCrtls)
            {
                result += ctrl.InvestedPot;
            }

            return result;
        }
    }

    void Start()
    {
        cardManager = gameObject.GetComponent<CardManager>();
        cardManager.Init();

        pokerRule = gameObject.GetComponent<IPokerRule>();
        pokerRule.GraveyardPosition = graveyardPosition;
        pokerRule.CardManager = cardManager;
        pokerRule.CardCrtls.AddRange(GameObject.FindObjectsOfType<CardGroupController>());

        HoldemUserController.Instance.SetController(pokerRule.CardCrtls[Random.Range(0, pokerRule.CardCrtls.Count)]);

        pokerRule.OnReady();
    }

    public PokerHand CalcPokerHand(params Card[] cards)
    {
        return handChecker.CalcPokerHand(cards);
    }

    public void OnBegin()
    {

    }

    public void OnEnd()
    {

    }
}
