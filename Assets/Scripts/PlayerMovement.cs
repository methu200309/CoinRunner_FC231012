
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;
    public float fallLimit = -8f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(
            move * moveSpeed,
            rb.linearVelocity.y
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
        }

        // Respawn when player falls into a gap
        if (transform.position.y < fallLimit)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        isGrounded = false;

        Debug.Log("Player Respawned!");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
