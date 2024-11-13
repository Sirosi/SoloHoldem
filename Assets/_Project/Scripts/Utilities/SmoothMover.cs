using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public static class SmoothMover
{
    private const float CARD_MOVEMENT_SPEED = 25;
    private const float CARD_ROTATMENT_SPEED = 360;

    public static IEnumerator MoveAndRotate(MonoBehaviour mono, Transform card, Vector3 position, Quaternion rotation, float moveSpeed = CARD_MOVEMENT_SPEED, float rotateSpeed = CARD_ROTATMENT_SPEED)
    {
        mono.StartCoroutine(Rotate(card, rotation, rotateSpeed));
        yield return mono.StartCoroutine(Move(card, position, moveSpeed));
    }

    public static IEnumerator Rotate(Transform card, Quaternion target, float speed)
    {
        while (Mathf.Abs(target.eulerAngles.z - card.transform.rotation.eulerAngles.z) > 1)
        {
            card.transform.rotation = Quaternion.RotateTowards(card.transform.rotation, target, speed * Time.deltaTime);
            yield return null;
        }
        card.transform.rotation = target;
    }

    public static IEnumerator Move(Transform card, Vector3 target, float speed)
    {
        while (Vector3.Magnitude(target - card.transform.position) > 0.03125f)
        {
            card.transform.position = Vector3.MoveTowards(card.transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        card.transform.position = target;
    }
}