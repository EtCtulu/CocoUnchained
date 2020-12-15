using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DoorScript : MonoBehaviour
{
    [Header("Mettre trois torches pour la dernière porte du LD")]
    [Header("Mettre une seule Torche pour les deux premières portes du LD")]
    [Header("Torches qui appartiennent à la porte")]
    public GameObject[] TorchesToActivate;
    
    [HideInInspector]
    public bool[] TorchesActivated;

    private void Start()
    {
        TorchesActivated = new bool[TorchesToActivate.Length];
        for (int i = 0; i < TorchesActivated.Length; i++)
        {
            TorchesActivated[i] = false;
        }
    }
}
