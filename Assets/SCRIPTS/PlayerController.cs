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
    public PlayerController player;


    

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
         rB = GetComponent<Rigidbody2D>();
         sR = GetComponent<SpriteRenderer>();
        
         playerState = PlayerState.Idle;
         
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameState(playerState);

      

        if (rB.linearVelocity == Vector2.zero)
        {
            playerState = PlayerState.Idle;
        }

        if(isAlive)
        {
            Move();
            Jump();
            Flip();
            TakeDamage(damage);
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

    public void Flip()
    {
        if (horizontal > 0)
        {
            sR.flipX = false;
        }
        else if (horizontal < 0)
        {
            sR.flipX = true;
        }
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
        
        if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                rB.linearVelocity = new Vector2(0, jump);
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


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

        playerState = PlayerState.Stunned;
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
                Idle();
                break;
           
            case PlayerState.Moving:
                Moving();
                break;
            
            case PlayerState.Attacking:
                Attacking();
                break;
            
            case PlayerState.Stunned:
                Stunned();
                break;
            
            case PlayerState.Dead:
                Die();
                break;
           
            default:
                playerState = PlayerState.Idle;
                break;
        }
    }

    private void Idle()
    {
        isMoving = false;
        isAttacking = false;
        isStunned = false;
        isAlive = true;
        sR.color = Color.gray;

        playerState = PlayerState.Idle;
    }

    private void Moving()
    {
        isMoving = true;
        isAttacking = false;
        isStunned = false;
        isAlive = true;
        sR.color = Color.green;

        playerState = PlayerState.Moving;
    }

    private void Attacking()
    {
        isMoving = false;
        isAttacking = true;
        isStunned = false;
        isAlive = true;
        sR.color = Color.red;

        playerState = PlayerState.Attacking;
    }

    private void Stunned()
    {
        isMoving = false;
        isAttacking = false;
        isStunned = true;
        isAlive = true;
        sR.color = Color.yellow;

        playerState = PlayerState.Stunned;
    }

    private void Unstun()
    {
        playerState = PlayerState.Moving;

        float x = this.transform.localScale.x;
        float y = Mathf.Pow(this.transform.localScale.y, 1f/3f);
        float z = this.transform.localScale.z;

        this.transform.localScale = new Vector3(x, y, z);
    }

    public void Die()
    {
        isAlive = false;
        rB.linearVelocity = Vector2.zero;
        sR.color = Color.red;

        isMoving = false;
        isAttacking = false;
        isStunned = false;
        isAlive = false;

        playerState = PlayerState.Dead;
    }

}
