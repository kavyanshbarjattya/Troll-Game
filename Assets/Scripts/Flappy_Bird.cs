using UnityEngine;

public class Flappy_Bird : MonoBehaviour
{
    [SerializeField] float jumpForce;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FlappyJump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

    }
}
