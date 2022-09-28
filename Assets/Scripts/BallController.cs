using System;
using UnityEngine;
using Random = System.Random;

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
        ballRb2d.velocity *= 0;
        ballRb2d.angularVelocity = 0;
    }

    private void FixedUpdate()
    {
        //print("angularVelocity: " + ballRb2d.angularVelocity);
    }

    public void StartBallMovement()
    {
        float numSwitch = UnityEngine.Random.Range(0, 3) > 1 ? 1f : -1f;

        AddTorqueAndForce(25f, numSwitch);
    }

    // Add an impulse which produces a change in angular velocity (specified in degrees).
    public void AddTorqueAndForce(float angularChangeInDegrees, float numSwitch)
    {
        var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * ballRb2d.inertia;

        ballRb2d.AddTorque(impulse, ForceMode2D.Impulse);

        ballRb2d.AddForce(ballMoveSpeed * numSwitch, ForceMode2D.Impulse);
    }
}
