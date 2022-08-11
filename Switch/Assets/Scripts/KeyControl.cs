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

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Start()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
        PlayerCombat = GetComponent<PlayerCombat>();
        PlayerMana = GetComponent<PlayerMana>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode .Q))
        {
            FindObjectOfType<AudioManager>().Play("God Swap");
            DisableOtherCharecters(0);
        } //Switchg machenic

        if (Input.GetKeyDown(KeyCode.W))
        {
            FindObjectOfType<AudioManager>().Play("God Swap");
            DisableOtherCharecters(1);
        } //Switchg machenic

        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<AudioManager>().Play("God Swap");
            DisableOtherCharecters(2);
        } //Switchg machenic
        
        if (Input.GetKeyDown(KeyCode.Space)) //Special abbility machenic
        {
            switch(Chara)
            {
                case 0:

                    if (Time.time >= nextAttackTime)
                    {
                        animator.SetBool("IsAttecking", true);
                        PlayerCombat.Attack();
                        StartCoroutine(AnimationEvents.instance.AnimationEndPoint("IsAttecking", false, "Sword And Shield Attack"));
                        FindObjectOfType<AudioManager>().Play("Attack");
                        //Hit effect is called from an aniamtion event
                    }
                    break;

                case 1:
                    animator.SetBool("IsBlocking", true);
                    FindObjectOfType<AudioManager>().Play("Shield");
                    EffectManager.BlockEffect(true);
                    //transform.LookAt(target);
                    break;

                    
                case 2:
                    animator.SetBool("IsHealing", true);
                    FindObjectOfType<AudioManager>().Play("Heal");
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
