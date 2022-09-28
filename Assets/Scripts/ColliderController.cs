using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField]
    private BoundaryType boundaryType;


    private BallController bController;
    private PlayerMoveScript pController;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(boundaryType == BoundaryType.topBoundary)
        {
            pController = collision.gameObject.GetComponent<PlayerMoveScript>();
            if(pController != null)
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


        bController = collision.gameObject.GetComponent<BallController>();

        if(bController != null)
        {
            if(boundaryType == BoundaryType.leftBoundary)
            {
                //gameWonController.EditWonText(Player.blue);
                //gameWonUI.SetActive(true);
                //scoreController.IncrementScore();
                GameManager.Instance.IncrementScore(Player.blue);
            }

            if (boundaryType == BoundaryType.rightBoundary)
            {
            //    gameWonController.EditWonText(Player.red);
            //    gameWonUI.SetActive(true);
               // scoreController.IncrementScore();
                GameManager.Instance.IncrementScore(Player.red);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
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
}
