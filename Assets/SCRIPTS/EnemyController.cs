using UnityEditor.Callbacks;
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

    [SerializeField] private int amplitude = 1;
    [SerializeField] private float frequency = 1f;
    

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
        enemyState = EnemyState.Idle;
        EnemyStats();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateGameState(enemyState);
    }

    void Chase()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        enemyState = EnemyState.Moving;
    }

    public void EnemyStats()
    {
        if(this.gameObject.name == "ENEMY PIG")
        {
            health = 6;
            damage = 3;
        }

        if(this.gameObject.name == "SKELETON")
        {
            health = 3;
            damage = 1;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Idle()
    {
        UpdateGameState(EnemyState.Idle);

        float x = Mathf.Sin(Time.time * frequency) * amplitude;
        float y = this.transform.position.y;
        float z = this.transform.position.z;
 
        this.transform.position = new Vector3(x, y, z);
    }

    public void Stun()
    {
        UpdateGameState(EnemyState.Stunned);

        float x = this.transform.localScale.x;
        float y = Mathf.Pow(this.transform.localScale.y, 3f);
        float z = this.transform.localScale.z;

        this.transform.localScale = new Vector3(x, y, z);
    }

    public void Unstun()
    {
        UpdateGameState(EnemyState.Moving);

        float x = this.transform.localScale.x;
        float y = Mathf.Pow(this.transform.localScale.y, 1f/3f);
        float z = this.transform.localScale.z;

        this.transform.localScale = new Vector3(x, y, z);
    }

    public void Die()
    {
        UpdateGameState(EnemyState.Dead);

        Destroy(this.gameObject);
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
                Idle();
                break;
            case EnemyState.Moving:
                Chase();
                break;
            case EnemyState.Attacking:
                break;
            case EnemyState.Stunned:
                Stun();
                break;
            case EnemyState.Dead:
                Die();
                break;
            default:
                enemyState = EnemyState.Idle;
                break;
        }
    }
}
