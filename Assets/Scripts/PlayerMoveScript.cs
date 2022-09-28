using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Player playerType;
    [SerializeField]
    private KeyCode moveKeyUp;
    [SerializeField]
    private KeyCode moveKeyDown;


    private Rigidbody2D playerRb2D;


    private bool moveUp;
    private bool moveDown;

    private bool isMaxTopReached = false;
    private bool isMaxBottomReached = false;

    private void Awake()
    {
        playerRb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
    }

    private void FixedUpdate()
    {
        if (moveUp && !isMaxTopReached)
        {
            playerRb2D.MovePosition(playerRb2D.position + (Vector2.up * moveSpeed * Time.fixedDeltaTime));
        }
        if(moveDown && !isMaxBottomReached)
        {
            playerRb2D.MovePosition(playerRb2D.position + (Vector2.down * moveSpeed * Time.fixedDeltaTime));
        }
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

    private void SwitchBoolValue(bool MaxTopOrBottom)
    {
        MaxTopOrBottom = !MaxTopOrBottom;
    }
}
