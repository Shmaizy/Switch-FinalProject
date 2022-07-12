using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyControl : MonoBehaviour
{
    [Header ("KeyControls")]
    [SerializeField] List<GameObject> charecters;
    public int Chara;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(Chara)
            {
                case 0:
                    Debug.Log("I'M ARES");
                    animator.SetBool("IsAttecking", true);
                    break;

                case 1:
                    Debug.Log("I'M ODIN");
                    animator.SetBool("IsBlocking", true);

                    break;

                case 2:
                    Debug.Log("I'M HORUS");
                    animator.SetBool("IsHealing", true);
                    break;
            }
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            switch(Chara)
            {
                case 0:
                    Debug.Log("I'M ARES");
                    animator.SetBool("IsAttecking", false);
                    break;

                case 1:
                    Debug.Log("I'M ODIN");
                    animator.SetBool("IsBlocking", false);
                    break;

                case 2:
                    Debug.Log("I'M HORUS");
                    animator.SetBool("IsHealing", false);
                    break;
            }
        }
    }

    void DisableOtherCharecters (int whatToActive)
    {
        for (int i = 0; i < charecters.Count; i++)
        {
            if (i == whatToActive)
            {
                charecters[i].SetActive(true);
                Chara = i;
            }
            
            else
            {
                charecters[i].SetActive(false);
            }
        }  
    }
}
