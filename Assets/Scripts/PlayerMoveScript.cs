using System;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeedVertical;
    [SerializeField]
    private float moveSpeedHorizontal;
    [SerializeField]
    private Player playerType;
    [SerializeField]
    private KeyCode moveKeyUp;
    [SerializeField]
    private KeyCode moveKeyDown;
    [SerializeField]
    private KeyCode moveKeyLeft;
    [SerializeField]
    private KeyCode moveKeyRight;

    private Rigidbody2D playerRb2D;

    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;

    private bool isMaxTopReached = false;
    private bool isMaxBottomReached = false;
    private bool isMaxLeftReached = false;
    private bool isMaxRightReached = false;

    private void Awake()
    {
        playerRb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovementInputRegistry();
    }

    private void MovementInputRegistry()
    {
        //vertical
        if (Input.GetKey(moveKeyUp))
        {
            moveUp = true;
        }
        else
        {
            moveUp = false;
        }

        if (Input.GetKey(moveKeyDown))
        {
            moveDown = true;
        }
        else
        {
            moveDown = false;
        }

        //horizontal
        if (Input.GetKey(moveKeyLeft)) moveLeft = true;
        else moveLeft = false;
        if (Input.GetKey(moveKeyRight)) moveRight = true;
        else moveRight = false;
    }

    private void FixedUpdate()
    {
        MovementUsingRB2D();
    }

    private void MovementUsingRB2D()
    {
        //vertical
        if (moveUp && !isMaxTopReached)
        {
            playerRb2D.MovePosition(playerRb2D.position + (Vector2.up * moveSpeedVertical * Time.fixedDeltaTime));
        }
        if (moveDown && !isMaxBottomReached)
        {
            playerRb2D.MovePosition(playerRb2D.position + (Vector2.down * moveSpeedVertical * Time.fixedDeltaTime));
        }

        //horizontal
        if (moveLeft && !isMaxLeftReached) playerRb2D.MovePosition(playerRb2D.position + Vector2.left * moveSpeedHorizontal * Time.fixedDeltaTime);
        if (moveRight && !isMaxRightReached) playerRb2D.MovePosition(playerRb2D.position + Vector2.right * moveSpeedHorizontal * Time.fixedDeltaTime);
    }

    public void ReachedMaxTop()
    {
        if (!isMaxTopReached)
            isMaxTopReached = true;
    }

    public void LeftMaxTop()
    {
       if(isMaxTopReached)
        {
            isMaxTopReached = false;
        }
    }
    public void ReachedMaxBottom()
    {
        if (!isMaxBottomReached)
            isMaxBottomReached = true;
    }

    public void LeftMaxBottom()
    {
        if (isMaxBottomReached)
        {
            isMaxBottomReached = false;
        }
    }

    public void ReachedMaxLeft()
    {
        if (!isMaxLeftReached)
            isMaxLeftReached = true;
    }

    public void LeftMaxLeft()
    {
        if (isMaxLeftReached)
        {
            isMaxLeftReached = false;
        }
    }

    public void ReachedMaxRight()
    {
        if (!isMaxRightReached)
            isMaxRightReached = true;
    }

    public void LeftMaxRight()
    {
        if (isMaxRightReached)
        {
            isMaxRightReached = false;
        }
    }

    public void SwitchBoolValue(bool maxBool, bool switchedValue)
    {
        if(maxBool != switchedValue)
        {
            maxBool = switchedValue;
        }
    }
}
