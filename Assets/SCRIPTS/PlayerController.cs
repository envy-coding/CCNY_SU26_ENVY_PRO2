using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //HEALTH
    public float health = 10;
    public float damage;

    public Rigidbody2D rB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        rB.maxLinearVelocity = 30;

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
            rB.AddForce(new Vector2(-rB.linearVelocity.x.normalized*5, 0));
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }
}
