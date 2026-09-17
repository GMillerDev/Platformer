using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;

    [SerializeField] private float jumpForce = 10f;

    [SerializeField] private bool isGrounded;

    [SerializeField] private float minGroundNormalY = 0.7f;

    Rigidbody2D rb;
    private SpriteRenderer spriteRender;
    private Animator animator;
    private float moveInput;
    private bool touchingWall;
    private float wallNormalX;
    private bool isLanding;
    private Vector3 spawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
        spriteRender =  GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isLanding = animator.GetCurrentAnimatorStateInfo(0).IsName("landed");
        isGrounded = false;

        if (isLanding)
        {
            rb.linearVelocity = new Vector2 (0f, rb.linearVelocity.y);
        } 
        else 
        {
            rb.linearVelocity = new Vector2 (moveInput * moveSpeed, rb.linearVelocity.y);
        }

        animator.SetFloat("yVelocity", rb.linearVelocity.y);

    }

    private void LateUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("GroundedYes", isGrounded);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>().x;

        if (moveInput > 0)
            spriteRender.flipX = false;
        else if (moveInput < 0)
            spriteRender.flipX = true;
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed && isGrounded && !isLanding)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y >= minGroundNormalY)
            {
                isGrounded = true;
                break;
            }
        }

    }

    public void Respawn(Vector3? overridePosition = null)
    {
        transform.position = overridePosition ?? spawnPosition;
        rb.linearVelocity = Vector2.zero;
    }
}
