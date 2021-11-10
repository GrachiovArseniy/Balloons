using UnityEngine;

[RequireComponent(typeof(BalloonPresenter))]
[RequireComponent(typeof(CircleCollider2D))]
public class Destroyed : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<BalloonPresenter>().Model.Destroy();
    }
}
