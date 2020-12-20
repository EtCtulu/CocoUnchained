using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{

    [Header("Movement Settings")]
    // Movespeed player value
    public float moveSpeed = 0.1f;

    private Vector3 _direction;

    public GameObject menuManager;
    public GameObject swapProjectilePrefab;
    public Text numberOfUsesText;
    public Text numberOfUsesNumber;

    public float projectilesSpeed = 20f;

    private bool canShoot = true;

    public int numberOfUses = 0;

    [Header("Scripts de porte")]
    public DoorScript firstDoor;
    public DoorScript middleDoor;
    public DoorScript endDoor;


    private void Update()
    {

        // Get move x and z input direction
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        if (Input.GetKeyDown(KeyCode.RightArrow) && canShoot && numberOfUses > 0)
        {
            GameObject projectile = Instantiate(swapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f * projectilesSpeed, 0f);
            canShoot = false;
            numberOfUses -= 1;
            Invoke("CanShootON", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && canShoot && numberOfUses > 0)
        {
            GameObject projectile = Instantiate(swapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f * projectilesSpeed, 0f);
            canShoot = false;
            numberOfUses -= 1;
            Invoke("CanShootON", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && canShoot && numberOfUses > 0)
        {
            GameObject projectile = Instantiate(swapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1.0f * projectilesSpeed);
            canShoot = false;
            numberOfUses -= 1;
            Invoke("CanShootON", 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && canShoot && numberOfUses > 0)
        {
            GameObject projectile = Instantiate(swapProjectilePrefab, transform.position, Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -1.0f * projectilesSpeed);
            canShoot = false;
            numberOfUses -= 1;
            Invoke("CanShootON", 0.5f);
        }

        if(numberOfUses < 0)
        {
            numberOfUses = 0;
        }

        numberOfUsesText.text = numberOfUses.ToString();
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
        canShoot = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint0"))
        {
            numberOfUses = 4;            
        }

        if (other.CompareTag("Checkpoint1"))
        {
            numberOfUses = 9;            
        }

        if (other.CompareTag("CP2"))
        {
            numberOfUses = 7;            
        }

        if (other.CompareTag("CP3"))
        {
            numberOfUses = 3;            
        }

        if (other.CompareTag("GameEnder"))
        {
            menuManager.GetComponent<Menu>().EndGame();
        }

        //Torche de la première salle qui active la première porte
        for (int i = 0; i < firstDoor.TorchesToActivate.Length; i++)
        {
            if (other.gameObject == firstDoor.TorchesToActivate[i])
            {
                firstDoor.TorchesActivated[i] = true;
                Destroy(firstDoor.TorchesToActivate[i]);

                for (int y = 0; y < firstDoor.TorchesActivated.Length; y++)
                {
                    if (firstDoor.TorchesActivated[y] == true)
                    {
                        Destroy(firstDoor.gameObject);
                    }
                }
            }
        }

        //Torche de la première salle qui active la porte du milieu
        for (int i = 0; i < middleDoor.TorchesToActivate.Length; i++)
        {
            if (other.gameObject == middleDoor.TorchesToActivate[i])
            {
                middleDoor.TorchesActivated[i] = true;
                Destroy(middleDoor.TorchesToActivate[i]);

                for (int y = 0; y < middleDoor.TorchesActivated.Length; y++)
                {
                    if (middleDoor.TorchesActivated[y] == true)
                    {
                        Destroy(middleDoor.gameObject);
                    }
                }
            }
        }

        //3 Torches des autres salles
        for (int i = 0; i < endDoor.TorchesToActivate.Length; i++)
        {
            if (other.gameObject == endDoor.TorchesToActivate[i])
            {
                endDoor.TorchesActivated[i] = true;
                Destroy(endDoor.TorchesToActivate[i]);

                for (int y = 0; y < endDoor.TorchesActivated.Length; y++)
                {
                    if (endDoor.TorchesActivated[0] == true && endDoor.TorchesActivated[1] == true && endDoor.TorchesActivated[2] == true)
                    {
                        Destroy(endDoor.gameObject);
                    }
                }
            }
        }
    }



}
