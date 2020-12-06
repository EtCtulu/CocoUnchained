using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapProjectile : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 4f);
    }

}
