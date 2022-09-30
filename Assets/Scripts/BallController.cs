using System.Collections;
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

    private IEnumerator coroutine;
    private bool isCoroutineCalled;

    private void Awake()
    {
        ballRb2d = GetComponent<Rigidbody2D>();

        ballMoveSpeed = new Vector2(1,1) * ballSpeed;
    }

    private void Start()
    {
        isCoroutineCalled = true;
    }

    public void ResetBall()
    {
        transform.position = new Vector2(0, 0);
        ballRb2d.velocity *= 0;
        ballRb2d.angularVelocity = 0;
        ballRb2d.rotation = 0;
        countDownTimer = 3;
        isTimerRunning = true;
        isCoroutineCalled = true;
    }

    private void Update()
    {
        RunCountdownTimer();
        CallCoroutine();
    }

    private void CallCoroutine()
    {
        if (isCoroutineCalled && this.coroutine  == null)
        {
            isCoroutineCalled = false;
            this.coroutine = CountdownTime();
            StartCoroutine(this.coroutine);
        }
    }

    IEnumerator CountdownTime()
    {
        yield return new WaitForSeconds(countDownTimer);
        StartBallMovement();
        this.coroutine = null;
    }

    private void RunCountdownTimer()
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
