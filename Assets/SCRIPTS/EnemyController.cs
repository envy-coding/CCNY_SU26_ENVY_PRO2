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
       
        UpdateGameState(EnemyState.Idle); 
        EnemyStats();  
    }

    // Update is called once per frame
    void Update()
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
    }

    void EnemyStats()
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
                float x = Mathf.Cos(Time.time * frequency) * amplitude;
                float y = this.transform.position.y;
                float z = this.transform.position.z;

                this.transform.position = new Vector3(x, y, z);
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

    public void Idle()
    {
        UpdateGameState(EnemyState.Idle);
    }
}
