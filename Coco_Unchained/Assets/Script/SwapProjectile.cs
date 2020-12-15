using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapProjectile : MonoBehaviour
{

    private GameObject Player;
    private Vector2 statuePos;
    private Vector2 playerPos;
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 4f);
        Physics2D.IgnoreLayerCollision(0,8);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SwapTarget")
        {
            statuePos = collision.gameObject.transform.position;
            playerPos = Player.transform.position;
            collision.gameObject.transform.position = playerPos;
            Player.transform.position = statuePos;
            Destroy(gameObject);
        }
    }
}
