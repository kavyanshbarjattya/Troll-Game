using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] Animator animator;

    [Header("Gravity Tweaks")]
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;

    Rigidbody2D rb;
    bool isJumping = false;
    float moveInput = 0f;
    float groundCheckRadius = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TempControls();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                isJumping = true;
            }
        }
        // Movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);


        // Apply custom gravity for better jump feel
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !isJumping)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        // Animation
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            animator.SetBool("IsGrounded", IsGrounded());
        }
    }

    void FixedUpdate()
    {
        if (isJumping && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;
        }
    }

    void TempControls()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if ( isJumping && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = false;
        }
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // Mobile Button Callbacks
    public void MoveLeft(bool isPressed)
    {
        moveInput = isPressed ? -1f : 0f;
    }

    public void MoveRight(bool isPressed)
    {
        moveInput = isPressed ? 1f : 0f;
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            isJumping = true;
        }
    }
}

