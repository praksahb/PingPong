using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float ballSpeed;

    private Rigidbody2D ballRb2d;

    private Vector2 ballMoveSpeed;

    private void Awake()
    {
        ballRb2d = GetComponent<Rigidbody2D>();

        ballMoveSpeed = new Vector2(1,1) * ballSpeed;
    }   

    

    public void ResetBallPosition()
    {
        transform.position = new Vector2(0, 0);
    }

    public void StartBallMovement()
    {
        ballRb2d.AddForce(ballMoveSpeed, ForceMode2D.Impulse);
    }
}
