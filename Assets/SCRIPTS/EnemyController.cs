using UnityEngine;

public class EnemyController : MonoBehaviour
{   
    public static EnemyController Instance;
    public EnemyState enemyState;
    public float health;
    public float damage;
    public float speed = 10f;
    public Transform player;

    public GameObject EnemyPig;
    public GameObject Skeleton;

    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }
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
        if(this.gameObject.name == "EnemyPig")
        {
            health = 6;
            damage = 3;
        }

        if(this.gameObject.name == "Skeleton")
        {
            health = 3;
            damage = 1;
        }
    }
    
    public enum EnemyState
    {
        Idle, 
        Moving,
        Attacking,
        Stunned,
        Dead
    }

    public void UpdateGameState(EnemyState state)
    {
        enemyState = state;

        switch (state)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Moving:
                break;
            case EnemyState.Attacking:
                break;
            case EnemyState.Stunned:
                break;
            case EnemyState.Dead:
                break;
            default:
                enemyState = EnemyState.Idle;
                break;
        }
    }
}
