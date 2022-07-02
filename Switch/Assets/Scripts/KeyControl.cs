using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyControl : MonoBehaviour
{
    [Header ("KeyControls")]
    [SerializeField] List<GameObject> charecters;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode .Q))
        {
            DisableOtherCharecters(0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            DisableOtherCharecters(1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            DisableOtherCharecters(2);
        }

    }

    void DisableOtherCharecters (int whatToActive)
    {
        for (int i = 0; i < charecters.Count; i++)
        {
            if (i == whatToActive)
            {
                charecters[i].SetActive(true);
            }
            
            else
            {
                charecters[i].SetActive(false);
            }
        }  
    }
}
