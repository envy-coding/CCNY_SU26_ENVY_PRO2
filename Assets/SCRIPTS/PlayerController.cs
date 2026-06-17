using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //HEALTH
    public float health = 10;
    public float damage;
    public float jump = 10;

    //STAIRS
    private float vertical;
    private float speed = 10f;
    private bool isStairs;
    private bool isClimbing;

    public bool isAlive = true;
    public bool isMoving;
    public bool isAttacking;
    public bool isStunned;

    public float horizontal;

    public Rigidbody2D rB;
    public SpriteRenderer sR;

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
         UpdateGameState(PlayerState.Idle);

         rB = GetComponent<Rigidbody2D>();
         sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameState(playerState);
        Move();
        Jump();

        if (rB.linearVelocity == Vector2.zero)
        {
            playerState = PlayerState.Idle;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rB.gravityScale = 0f;
            rB.linearVelocity = new Vector2(rB.linearVelocity.x, vertical * speed);
        }

        rB.linearVelocity = new Vector2(horizontal * speed, rB.linearVelocity.y);

        
    }

    public void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isStairs && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

        playerState = PlayerState.Moving;

        
    }

    public void Jump()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            rB.AddForce(new Vector2(rB.linearVelocity.x, jump));
        }

        playerState = PlayerState.Moving;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stairs"))
        {
            isStairs = true;
        }

        playerState = PlayerState.Moving;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Stairs"))
        {
            isStairs = false;
            isClimbing = false;
        }

        playerState = PlayerState.Moving;

    }

    public void Die()
    {
        isAlive = false;
        rB.linearVelocity = Vector2.zero;
        sR.color = Color.red;

        playerState = PlayerState.Dead;
    }

    public enum PlayerState
    {
        Idle,
        Moving,
        Attacking,
        Stunned,
        Dead
    }

    public void UpdateGameState(PlayerState state)
    {
        playerState = state;

        switch (state)
        {
            case PlayerState.Idle:
                isMoving = false;
                isAttacking = false;
                isStunned = false;
                isAlive = true;
                sR.color = Color.gray;
                break;
           
            case PlayerState.Moving:
                isMoving = true;
                isAttacking = false;
                isStunned = false;
                isAlive = true;
                sR.color = Color.green;
                break;
            
            case PlayerState.Attacking:
                isMoving = true;
                isAttacking = true;
                isStunned = false;
                isAlive = true;
                sR.color = Color.red;
                break;
            
            case PlayerState.Stunned:
                isMoving = false;
                isAttacking = false;
                isStunned = true;
                isAlive = true;
                sR.color = Color.yellow;
                break;
            
            case PlayerState.Dead:
                isMoving = false;
                isAttacking = false;
                isStunned = false;
                isAlive = false;
                break;
           
            default:
                playerState = PlayerState.Idle;
                break;
        }
    }
}