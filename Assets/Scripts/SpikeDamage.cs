
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

        if (other.GetComponent<PlayerMovement>() != null &&
            playerRb != null)
        {
            playerRb.linearVelocity = Vector2.zero;
            other.transform.position = new Vector3(-7f, -2f, 0f);

            Debug.Log("Player Respawned!");
        }
    }
}
