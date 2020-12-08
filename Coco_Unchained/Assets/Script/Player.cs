using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement Settings")]
    // Movespeed player value
    public float moveSpeed = 0.1f;
    private Vector3 _direction;

    public GameObject SwapProjectilePrefab;
    public GameObject FirePointLeft;
    public GameObject FirePointRight;
    public GameObject FirePointUp;
    public GameObject FirePointDown;

    public float ProjectilesSpeed = 20f;

    public bool Horizontal;
    public bool Vertical;
    private bool CanShoot = true;

    private void Update()
    {

        // Get move x and z input direction
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        if (Input.GetKeyDown(KeyCode.RightArrow) && CanShoot)
        {
            GameObject projectile = Instantiate(SwapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f * ProjectilesSpeed, 0f);
            CanShoot = false;
            Invoke("CanShootON", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && CanShoot)
        {
            GameObject projectile = Instantiate(SwapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f * ProjectilesSpeed, 0f);
            CanShoot = false;
            Invoke("CanShootON", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && CanShoot)
        {
            GameObject projectile = Instantiate(SwapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1.0f * ProjectilesSpeed);
            CanShoot = false;
            Invoke("CanShootON", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && CanShoot)
        {
            GameObject projectile = Instantiate(SwapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -1.0f * ProjectilesSpeed);
            CanShoot = false;
            Invoke("CanShootON", 0.5f);
        }

    }

    private void FixedUpdate()
    {
        // Call the PlayerMove function
        PlayerMove();
    }

    private void PlayerMove()
    {
        // Set the movement X and Z with the movespeed
        var targetMovement = new Vector3(_direction.x, _direction.y, 0f) * moveSpeed;
        transform.Translate(new Vector3(targetMovement.x, targetMovement.y, 0f));
    }

    private void CanShootON()
    {
        CanShoot = true;
    }

    
    

}
