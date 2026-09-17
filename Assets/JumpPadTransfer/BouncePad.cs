using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce = 12f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.rigidbody;

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                bounceForce
            );
        }
    }
}