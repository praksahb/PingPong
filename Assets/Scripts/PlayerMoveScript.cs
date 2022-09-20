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

    private void Awake()
    {
        playerRb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(moveKeyUp)) {
            moveUp = true;
        } else
        {
            moveUp = false;
        }

        if (Input.GetKey(moveKeyDown)) {
            moveDown = true;
        } else
        {
            moveDown = false;
        }

    }

    private void FixedUpdate()
    {
        if (moveUp)
        {
            playerRb2D.MovePosition(playerRb2D.position + (Vector2.up * moveSpeed * Time.fixedDeltaTime));
        }
        if(moveDown)
        {
            playerRb2D.MovePosition(playerRb2D.position + (Vector2.down * moveSpeed * Time.fixedDeltaTime));
        }
    }
}
