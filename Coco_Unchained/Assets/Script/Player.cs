using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement Settings")]
    // Movespeed player value
    public float moveSpeed = 0.1f;
    private Vector3 _direction;

    public GameObject SwapProjectile;
    public GameObject FirePointLeft;
    public GameObject FirePointRight;
    public GameObject FirePointUp;
    public GameObject FirePointDown;

    public bool Horizontal;
    public bool Vertical;

    private void Update()
    {

        // Get move x and z input direction
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        if (_direction.x > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            //right
            Instantiate(SwapProjectile, FirePointRight.transform.position, FirePointRight.transform.rotation);
        }

        if (_direction.x < 0 && Input.GetKeyDown(KeyCode.Space))
        {
            //left
            Instantiate(SwapProjectile, FirePointLeft.transform.position, FirePointLeft.transform.rotation);
        }

        if (_direction.y < 0 && _direction.x == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            //down
            Instantiate(SwapProjectile, FirePointDown.transform.position, FirePointDown.transform.rotation);
        }

        if (_direction.y > 0 && _direction.x == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            //up
            Instantiate(SwapProjectile, FirePointUp.transform.position, FirePointUp.transform.rotation);
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

    

}
