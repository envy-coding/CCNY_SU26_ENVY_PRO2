using UnityEngine;

public class EnemyController : MonoBehaviour
{   public float health;
    public float damage;

    public float speed = 10f;
    public Transform player;

    public GameObject EnemyPig;
    public GameObject Skeleton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyStats();    
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void Chase()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void EnemyStats()
    {
        if(this.GameObject == "EnemyPig")
        {
            health = 6;
            damage = 3;
        }

        if(this.GameObject == "Skeleton")
        {
            health = 3;
            damage = 1;
        }
    }

    void Attack()
    {

    }

    
}
