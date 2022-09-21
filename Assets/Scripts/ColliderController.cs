using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField]
    private BoundaryType boundaryType;


    private BallController bController;


    private void OnCollisionEnter2D(Collision2D collision)
    {
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

}
