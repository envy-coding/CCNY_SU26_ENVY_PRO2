using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rB;
    public float timer = 3f;
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        speed = 10;
    }

    void Update()
    {
         rB.linearVelocity = transform.right * speed;

         if (timer < 3)
         {
            timer -= timer;
         }

         if (timer <= 0)
         {
              Destroy(this.gameObject);
         }
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
