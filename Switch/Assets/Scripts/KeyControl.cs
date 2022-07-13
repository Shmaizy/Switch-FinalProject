using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyControl : MonoBehaviour
{
    [Header ("KeyControls")]
    [SerializeField] List<GameObject> charecters;
    public int Chara;

    private Animator animator;
    public PlayerHealth PlayerHealth;
    private void Start()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode .Q))
        {
            DisableOtherCharecters(0);
        } //Switchg machenic

        if (Input.GetKeyDown(KeyCode.W))
        {
            DisableOtherCharecters(1);
        } //Switchg machenic

        if (Input.GetKeyDown(KeyCode.E))
        {
            DisableOtherCharecters(2);
        } //Switchg machenic

        if (Input.GetKeyDown(KeyCode.Space)) //Special abbility machenic
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
                    PlayerHealth.Healing();
                    break;
            }
        }

        else if (Input.GetKeyUp(KeyCode.Space)) //End of special abbility machenic
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
