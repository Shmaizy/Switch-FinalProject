using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyControl : MonoBehaviour
{
    [Header ("KeyControls")]
    [SerializeField] List<GameObject> charecters;
    public int Chara;

    [SerializeField] private Animator animator;
    public PlayerHealth PlayerHealth;
    public PlayerCombat PlayerCombat;
    public PlayerMana PlayerMana;
    public EffectManager EffectManager;

    public Transform target;

    private void Start()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
        PlayerCombat = GetComponent<PlayerCombat>();
        PlayerMana = GetComponent<PlayerMana>();
        //animator = GetComponent<Animator>();
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

                    animator.SetBool("IsAttecking", true);
                    PlayerCombat.Attack();
                    StartCoroutine(AnimationEvents.instance.AnimationEndPoint("IsAttecking", false , "Sword And Shield Attack"));
                    //Hit effect is called from an aniamtion event
                    break;

                case 1:
                    animator.SetBool("IsBlocking", true);
                    EffectManager.BlockEffect(true);
                    //transform.LookAt(target);
                    break;


                case 2:
                    animator.SetBool("IsHealing", true);
                    EffectManager.HealEffect();
                    PlayerHealth.Healing();
                    PlayerMana.ReduceMana();
                    StartCoroutine(AnimationEvents.instance.AnimationEndPoint("IsHealing", false, "Healing"));
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            switch (Chara)
            {
                case 1:
                animator.SetBool("IsBlocking", false);
                    EffectManager.BlockEffect(false);
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
