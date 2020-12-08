using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeDeVue : MonoBehaviour
{
    private Renderer rend;
    private Color colorTrigger = Color.red;
    private Color colorIdle = Color.yellow;
   
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = colorIdle;
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        rend.material.color = colorTrigger;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rend.material.color = colorIdle;
    }
}
