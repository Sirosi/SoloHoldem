using UnityEngine;

public class CardHandler : MonoBehaviour
{
    public SpriteRenderer MainRenderer = null;
    public SpriteRenderer HideRenderer = null;
    public Card Card = new(SuitType.Joker, 1);

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }



    public void Set(SuitType type, byte value)
    {
        Card.Type = type;
        Card.Value = value;

        MainRenderer.sprite = CardSpriteAssets.GetCardSprite(Card);
    }

    public void Open()
    {
        animator.SetBool("open", true);
    }

    public void Hide()
    {
        animator.SetBool("open", false);
    }
}
