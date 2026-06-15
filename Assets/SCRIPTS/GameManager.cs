using UnityEngine;

public class GameManager : MonoBehaviour
{
    //DECLARE VARIABLES
    public static GameManager Instance;

    public PlayerState playerState;
    public EnemyState enemyState;
  

    public PlayerController Player;
    public EnemyController Enemy;


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
        
    }

    public void RegisterPlayer(PlayerController player)
    {
        Player = player;
    }

    public void RegisterEnemy(EnemyController enemy)
    {
        Enemy = enemy;
    }

   public enum PlayerState
    {
        Idle,
        Moving,
        Attacking,
        Stunned,
        Dead
    }

    public enum EnemyState
    {
        Idle,
        Moving,
        Attacking,
        Stunned,
        Dead
    }

    public void UpdateGameState(PlayerState pState)
    {
        playerState = pState;

        switch (pState)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Moving:
                break;
            case PlayerState.Attacking:
                break;
            case PlayerState.Stunned:
                break;
            case PlayerState.Dead:
                break;
            default:
                playerState = PlayerState.Idle;
                break;
        }
    }

    public void UpdateGameState(EnemyState eState)
    {
        enemyState = eState;

        switch (eState)
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
