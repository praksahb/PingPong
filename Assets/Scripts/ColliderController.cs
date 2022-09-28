using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField]
    private BoundaryType boundaryType;


    private BallController bController;
    private PlayerMoveScript pController;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovementRestriction(collision);

        RoundOverCondition(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ResetPlayerMoveRestriction(collision);
    }

    private void ResetPlayerMoveRestriction(Collision2D collision)
    {
        if (boundaryType == BoundaryType.topBoundary)
        {
            pController = collision.gameObject.GetComponent<PlayerMoveScript>();
            if (pController != null)
            {
                pController.LeftMaxTop();
            }
        }

        if (boundaryType == BoundaryType.bottomBoundary)
        {
            pController = collision.gameObject.GetComponent<PlayerMoveScript>();
            if (pController != null)
            {
                pController.LeftMaxBottom();
            }
        }
    }

    private void PlayerMovementRestriction(Collision2D collision)
    {
        if (boundaryType == BoundaryType.topBoundary)
        {
            pController = collision.gameObject.GetComponent<PlayerMoveScript>();
            if (pController != null)
            {
                pController.ReachedMaxTop();
            }
        }
        if (boundaryType == BoundaryType.bottomBoundary)
        {
            pController = collision.gameObject.GetComponent<PlayerMoveScript>();
            if (pController != null)
            {
                pController.ReachedMaxBottom();
            }
        }
    }

    private void RoundOverCondition(Collision2D collision)
    {
        bController = collision.gameObject.GetComponent<BallController>();

        if (bController != null)
        {
            if (boundaryType == BoundaryType.leftBoundary)
            {
                GameManager.Instance.IncrementScore(Player.blue);
            }

            if (boundaryType == BoundaryType.rightBoundary)
            {
                GameManager.Instance.IncrementScore(Player.red);
            }
        }
    }
}
