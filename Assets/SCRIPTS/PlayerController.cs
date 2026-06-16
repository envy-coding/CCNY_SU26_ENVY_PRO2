using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //HEALTH
    public float health = 10;
    public float damage;

    public Rigidbody2D rB;

    public PlayerState playerState;

    public static PlayerController Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rB.AddForce(new Vector2(10,0));
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            rB.AddForce(new Vector2(-10,0));
        }
        else
        {
            rB.AddForce(new Vector2(-rB.linearVelocity.x*5, 0));
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }

    public enum PlayerState
    {
        Idle,
        Moving,
        Attacking,
        Stunned,
        Dead
    }

    private void UpdateGameState(PlayerState state)
    {
        playerState = state;

        switch (state)
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
}
