using UnityEngine;

public class GOAL : MonoBehaviour
{
    public PlayerController playerObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(gameObject == playerObject)
        {
        
        }
    }

}
