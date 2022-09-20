using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody2D ballRb2d;

    private void Awake()
    {
        ballRb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ballRb2d.AddForce(new Vector2(1, 1), ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void FixedUpdate()
    {
    }
}
