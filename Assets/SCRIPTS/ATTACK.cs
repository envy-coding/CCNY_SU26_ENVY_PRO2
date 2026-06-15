using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //DECLARE VARIABLES
    
    public Transform shootingPoint;
    public GameObject bulletPrefab;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}
