using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapProjectile : MonoBehaviour
{
    public Player PlayerScript;
    public float speed = 20f;
    public Rigidbody2D rb;
    void Awake()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 5f);
    }
}
