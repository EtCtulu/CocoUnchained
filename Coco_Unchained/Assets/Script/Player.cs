using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [Header("Movement Settings")]
    // Movespeed player value
    public float moveSpeed = 0.1f;

    private Vector3 _direction;

    public GameObject SwapProjectilePrefab;
    public Text NumberOfUsesText;
    public Text NumberOfUsesNumber;

    public float ProjectilesSpeed = 20f;

    private bool CanShoot = true;

    public int NumberOfUses = 2;

    private void Update()
    {

        // Get move x and z input direction
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        if (Input.GetKeyDown(KeyCode.RightArrow) && CanShoot && NumberOfUses > 0)
        {
            GameObject projectile = Instantiate(SwapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f * ProjectilesSpeed, 0f);
            CanShoot = false;
            NumberOfUses -= 1;
            Invoke("CanShootON", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && CanShoot && NumberOfUses > 0)
        {
            GameObject projectile = Instantiate(SwapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f * ProjectilesSpeed, 0f);
            CanShoot = false;
            NumberOfUses -= 1;
            Invoke("CanShootON", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && CanShoot && NumberOfUses > 0)
        {
            GameObject projectile = Instantiate(SwapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1.0f * ProjectilesSpeed);
            CanShoot = false;
            NumberOfUses -= 1;
            Invoke("CanShootON", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && CanShoot && NumberOfUses > 0)
        {
            GameObject projectile = Instantiate(SwapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -1.0f * ProjectilesSpeed);
            CanShoot = false;
            NumberOfUses -= 1;
            Invoke("CanShootON", 0.5f);
        }

        if(NumberOfUses < 0)
        {
            NumberOfUses = 0;
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
