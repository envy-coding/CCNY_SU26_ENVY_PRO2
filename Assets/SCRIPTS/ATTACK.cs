using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //DECLARE VARIABLES
    
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Rigidbody2D rB;
    public float speed = 10;

    public EnemyController enemy;
    public PlayerController player;

    // Update is called once per frame
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {   if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        PlayerController player = collision.GetComponent<PlayerController>();
        EnemyController enemy = collision.GetComponent<EnemyController>();
       
        if (this.gameObject == player && enemy != null)
        {
            enemy.TakeDamage(1);
            Destroy(this.gameObject);
        }

        
        if (this.gameObject == enemy && player != null)
        {
            player.TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
