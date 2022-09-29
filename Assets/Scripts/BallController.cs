using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float ballSpeed;

    [SerializeField]
    private float countDownTimer = 3;


    [SerializeField]
    private TimerTextController timerTextController;

    private Rigidbody2D ballRb2d;

    private Vector2 ballMoveSpeed;
    private bool isTimerRunning = true;

    private void Awake()
    {
        ballRb2d = GetComponent<Rigidbody2D>();

        ballMoveSpeed = new Vector2(1,1) * ballSpeed;
    }   

    public void ResetBall()
    {
        transform.position = new Vector2(0, 0);
        ballRb2d.velocity *= 0;
        ballRb2d.angularVelocity = 0;
        ballRb2d.rotation = 0;
        countDownTimer = 3;
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (countDownTimer > 0)
            {
                countDownTimer -= Time.deltaTime;
                timerTextController.DisplayTime(countDownTimer);
            }
            else
            {
                countDownTimer = 0;
                isTimerRunning = false;
                StartBallMovement();
            }
        }
    }

    public void StartBallMovement()
    {
        float numSwitch = Random.Range(0, 3) > 1 ? 1f : -1f;

        AddTorqueAndForce(25f, numSwitch);
    }


    public void AddTorqueAndForce(float angularChangeInDegrees, float numSwitch)
    {
        var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * ballRb2d.inertia;

        ballRb2d.AddTorque(impulse, ForceMode2D.Impulse);

        ballRb2d.AddForce(ballMoveSpeed * numSwitch, ForceMode2D.Impulse);
    }
}
