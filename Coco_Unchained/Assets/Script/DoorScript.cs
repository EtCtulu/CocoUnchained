using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DoorScript : MonoBehaviour
{
    public GameObject[] TorchesToActivate;
    private bool[] TorchesActivated;

    private void Start()
    {
        Debug.Log(TorchesToActivate.Length);
        TorchesActivated = new bool[TorchesToActivate.Length];
        for (int i = 0; i < TorchesActivated.Length; i++)
        {
            TorchesActivated[i] = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < TorchesToActivate.Length; i++)
        {
            if(collision.gameObject == TorchesToActivate[i])
            {
                TorchesActivated[i] = true;
                Destroy(TorchesToActivate[i]);

                for (int y = 0; y < TorchesActivated.Length; y++)
                {
                    if (TorchesActivated.All(a => !a))
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
