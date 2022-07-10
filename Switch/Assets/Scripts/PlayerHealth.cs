using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("PlayerHealth")]

    public int maxHealth;
    public int currentHealth;
    public int damage;
    public KeyControl script;
   
    private Animator animator;

    public HealthController healthbar;

    void Awake()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            switch(script.Chara)
            {
                case 0:
                    TakeDamage();
                    break;

                case 1:
                    //no damage for now
                    break;

                case 2:
                    TakeDamage();
                    break;
            }
        }
    }
    void TakeDamage()
    {
        currentHealth = currentHealth - damage;
        healthbar.SetHealth(currentHealth);
        Death();
    }

    void Death()
    {
        if (currentHealth == 0)
        {
            animator.SetBool("IsDead", true);
            Debug.Log("You Died");
           //GetComponent<Rigidbody>().isKinematic = false;


        }

        else
        {

            animator.SetBool("IsDead", false);
            Debug.Log(currentHealth);
            //GetComponent<Rigidbody>().isKinematic = true;

        }
    }


}

