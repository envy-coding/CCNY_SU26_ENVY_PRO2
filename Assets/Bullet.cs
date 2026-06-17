using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rB;
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        rB.linearVelocity = transform.forward * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }

        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(1);
        }
    }

    
}
